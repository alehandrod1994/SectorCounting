using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;
using Word = Microsoft.Office.Interop.Word;

namespace SectorCounting
{
    /// <summary>
    /// Отчёт.
    /// </summary>
    public class Report
    {
        private ProgressData _progressData = new ProgressData();
        private Status _status = Status.Start;

        private Word.Application _app;
        private Word.Document _doc;

        /// <summary>
        /// Создаёт новый экземпляр класса Report.
        /// </summary>
        public Report() { }

        /// <summary>
        /// Создаёт новый экземпляр класса Report.
        /// </summary>
        /// <param name="path"> Путь к файлу. </param>
        public Report(string path)
        {
            if (string.IsNullOrWhiteSpace(path))
            {
                throw new ArgumentNullException("Путь файла не может быть пустым.", nameof(path));
            }
        }

        /// <summary>
        /// Шапка.
        /// </summary>
        public string Head { get; set; } = "";

        /// <summary>
        /// Начальная дата.
        /// </summary>
        public DateTime StartDate { get; private set; }

        /// <summary>
        /// Конечная дата.
        /// </summary>
        public DateTime EndDate { get; private set; }

        /// <summary>
        /// Путь к исходному файлу.
        /// </summary>
        public string Path { get; set; } = "";

        /// <summary>
        /// Путь к сохранённому файлу.
        /// </summary>
        public string NewFilePath { get; private set; }

        /// <summary>
        /// Список тревог.
        /// </summary>
        public List<Alarm> Alarms { get; set; } = new List<Alarm>();

        /// <summary>
        /// Список количества сработок.
        /// </summary>
        public List<AlarmSum> AlarmSums { get; set; } = new List<AlarmSum>();

        /// <summary>
		/// Событие, которое происходит при подсчёте прогресса.
		/// </summary>
        public event EventHandler<ProgressData> CalculateProgress;

        /// <summary>
        /// Установливает начальную дату.
        /// </summary>
        /// <param name="value"> Начальная дата. </param>
        public void SetStartDate(string value)
        {
            StartDate = ParseDate(value);
        }

        /// <summary>
        /// Установливает конечную дату.
        /// </summary>
        /// <param name="value"> Конечная дата. </param>
        public void SetEndDate(string value)
        {
            EndDate = ParseDate(value);
        }

        /// <summary>
        /// Импортирует файл.
        /// </summary>
        /// <returns> Путь к файлу. </returns>
        public string ImportFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.FileName = "";
            ofd.Filter = "RTF Files (*.rtf)|*.rtf|TXT File (*.txt)|*.txt";
            ofd.Title = "Открыть документ";

            if (ofd.ShowDialog() != DialogResult.Cancel)
            {
                try
                {
                    Path = ofd.FileName;
                }
                catch
                {
                    MessageBox.Show("Недопустимый формат файла");
                }
            }

            return Path;
        }

        /// <summary>
        /// Конвертирует список строк в тревоги.
        /// </summary>
        /// <param name="list"> Список строк. </param>
        /// <param name="checkedItems"> Выбранные элементы в фильтре. </param>
        public void ConvertRichTextToAlarms(List<string> list, CheckedItemCollection checkedItems)
        {
            for (int i = 10; i < list.Count; i++)
            {
                if (list[i] == "")
                {
                    list.RemoveAt(i);
                    i--;
                    continue;
                }
            }

            for (int i = 10; i < list.Count; i++)
            {
                if (list[i].StartsWith("Сегмент"))
                {
                    if (!list[i + 1].StartsWith("Тревога") && !list[i + 1].StartsWith("Тревога2") && !list[i + 1].StartsWith("Все тревоги обработаны")
                        && !list[i + 1].StartsWith("Связь потеряна") && !list[i + 1].StartsWith("В норме") && !list[i + 1].StartsWith("Несоответствие")
                        && !list[i + 1].StartsWith("Системное"))
                    {
                        list[i] += list[i + 1];
                        list.RemoveAt(i + 1);
                    }

                    if (list[i + 2].IndexOf("20") == 6)
                        list.Insert(i + 2, "");
                    if (checkedItems.Contains(list[i + 1]) == false)
                    {
                        list.RemoveRange(i, 5);
                        i--;
                        continue;
                    }
                }
            }

            for (int i = 10; i < list.Count; i++)
            {
                if (list[i].StartsWith("Все тревоги обработаны") || list[i].StartsWith("Связь потеряна") ||
                    list[i].StartsWith("В норме") || list[i].StartsWith("Несоответствие") || list[i].StartsWith("Системное"))
                {
                    if (list[i + 1].IndexOf("20") == 6)
                        list.Insert(i + 1, "");
                    if (checkedItems.Contains(list[i]) == false)
                    {
                        list.RemoveRange(i - 1, 5);
                        i--;
                        continue;
                    }
                }
            }

            for (int i = 10; i < list.Count; i++)
            {
                if (list[i] == "Тревога" || list[i] == "Тревога2")
                {
                    if (list[i + 1].EndsWith("В норме ") && list[i + 2].IndexOf("20") == 6)
                    {

                    }
                    else if (list[i + 2].Contains("норме ") && list[i + 3].IndexOf("20") == 6)
                    {
                        list[i + 1] += "норме ";
                        list.RemoveAt(i + 2);
                    }

                    if (list[i + 1].EndsWith("Долгая "))
                    {
                        list[i + 1] += "тревога";
                        list.RemoveAt(i + 2);
                    }

                    if (checkedItems.Contains(list[i]) == false || checkedItems.Contains("В норме") == false && list[i + 1].EndsWith("В норме "))
                    {
                        list.RemoveRange(i - 1, 5);
                        i--;
                    }
                }
            }

            DeleteEmptyRows(list, "Компьютер", -5, 6);
            list.RemoveAt(list.Count - 1);

            Alarms = new List<Alarm>();
            for (int i = 9; i < list.Count; i = i + 5)
            {
                string source = list[i];
                string incident = list[i + 1];
                string info = list[i + 2];
                DateTime date = ParseDate(list[i + 3]);
                string computer = list[i + 4];

                Alarm alarm = new Alarm(source, incident, info, date, computer);
                Alarms.Add(alarm);
            }          
        }

        /// <summary>
        /// Удаляте пустые строки.
        /// </summary>
        /// <param name="list"> Список строк. </param>
        /// <param name="key"> Ключевое слово, по которому осуществляется поиск. </param>
        /// <param name="startPosition"> Начальная позиция от ключевого слова. </param>
        /// <param name="count"> Количество символов, которое нужно удалить от начальной позиции. </param>
        private void DeleteEmptyRows(List<string> list, string key, int startPosition, int count)
        {
            for (int i = 10; i < list.Count; i++)
            {
                if (list[i].EndsWith(key))
                {
                    list.RemoveRange(i + startPosition, count);
                    i--;
                }
            }
        }

        /// <summary>
        /// Парсит дату.
        /// </summary>
        /// <param name="value"> Дата. </param>
        /// <returns> Результат операции. </returns>
        private DateTime ParseDate(string value)
        {
            DateTime result;

            if (DateTime.TryParse(value, out result))
            {
                return result;
            }

            return default(DateTime);
        }

        /// <summary>
        /// Сортирует список тревог.
        /// </summary>
        /// <param name="columnName"> Название столбца. </param>
        /// <param name="sortMode"> Направленность сортировки. </param>
        /// <returns> Отсортированный список тревог. </returns>
        public List<Alarm> SortAlarms(string columnName, SortMode sortMode)
        {
            if (sortMode == SortMode.Up)
            {
                switch (columnName)
                {
                    case "Источник":
                        Alarms = Alarms.OrderBy(a => a.Source).ToList();
                        break;
                    case "Событие":
                        Alarms = Alarms.OrderBy(a => a.Incident).ToList();
                        break;
                    case "Информация":
                        Alarms = Alarms.OrderBy(a => a.Info).ToList();
                        break;
                    case "Дата":
                        Alarms = Alarms.OrderBy(a => a.Date).ToList();
                        break;
                    case "Компьютер":
                        Alarms = Alarms.OrderBy(a => a.Computer).ToList();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (columnName)
                {
                    case "Источник":
                        Alarms = Alarms.OrderByDescending(a => a.Source).ToList();
                        break;
                    case "Событие":
                        Alarms = Alarms.OrderByDescending(a => a.Incident).ToList();
                        break;
                    case "Информация":
                        Alarms = Alarms.OrderByDescending(a => a.Info).ToList();
                        break;
                    case "Дата":
                        Alarms = Alarms.OrderByDescending(a => a.Date).ToList();
                        break;
                    case "Компьютер":
                        Alarms = Alarms.OrderByDescending(a => a.Computer).ToList();
                        break;
                    default:
                        break;
                }
            }

            return Alarms ?? new List<Alarm>();
        }

        /// <summary>
        /// Сортирует список количества сработок.
        /// </summary>
        /// <param name="columnName"> Название столбца. </param>
        /// <param name="sortMode"> Направленность сортировки. </param>
        /// <returns> Отсортированный список количества сработок. </returns>
        public List<AlarmSum> SortAlarmSums(string columnName, SortMode sortMode)
        {
            if (sortMode == SortMode.Up)
            {
                switch (columnName)
                {
                    case "Источник":
                        AlarmSums = AlarmSums.OrderBy(a => a.Source).ToList();
                        break;
                    case "Количество":
                        AlarmSums = AlarmSums.OrderBy(a => a.Count).ToList();
                        break;                  
                    default:
                        break;
                }
            }
            else
            {
                switch (columnName)
                {
                    case "Источник":
                        AlarmSums = AlarmSums.OrderByDescending(a => a.Source).ToList();
                        break;
                    case "Количество":
                        AlarmSums = AlarmSums.OrderByDescending(a => a.Count).ToList();
                        break;
                    default:
                        break;
                }
            }

            return AlarmSums ?? new List<AlarmSum>();
        }

        /// <summary>
        /// Производит подсчёт количества сработок.
        /// </summary>
        /// <param name="checkedItems"> Выбранные элементы в фильтре. </param>
        /// <returns> Подсчитанный список. </returns>
        public List<AlarmSum> CalculateAlarmSum(CheckedItemCollection checkedItems)
        {
            bool found;
            AlarmSums = new List<AlarmSum>();
            _progressData.Watch.Restart();

            for (int i = 0; i < Alarms.Count; i++)
            {
                if ((Alarms[i].Incident == "Тревога" || Alarms[i].Incident == "Тревога2") && !Alarms[i].Info.Contains("норме"))
                {
                    found = false;
                    int index = Alarms[i].Source.IndexOf("(");
                    for (int j = 0; j < AlarmSums.Count; j++)
                    {
                        if (AlarmSums[j].Source == Alarms[i].Source.Remove(index) && checkedItems.Contains("Учитывать сегменты") == true
                            || AlarmSums[j].Source == Alarms[i].Source && checkedItems.Contains("Учитывать сегменты") == false)
                        {
                            AlarmSums[j].Count++;
                            found = true;
                            break;
                        }
                    }

                    if (found == false && checkedItems.Contains("Учитывать сегменты") == true)
                    {
                        AlarmSum alarmSum = new AlarmSum(Alarms[i].Source.Remove(index), 1);
                        AlarmSums.Add(alarmSum);
                    }
                    else if (found == false && checkedItems.Contains("Учитывать сегменты") == false)
                    {
                        AlarmSum alarmSum = new AlarmSum(Alarms[i].Source, 1);
                        AlarmSums.Add(alarmSum);
                    }                 
                }

                _progressData.CalculateProgress(i, Alarms.Count);
                CalculateProgress?.Invoke(this, _progressData);
            }

            _progressData.Watch.Stop();
            return AlarmSums ?? new List<AlarmSum>();
        }

        /// <summary>
        /// Сохраняет список тревог в файл.
        /// </summary>
        /// <returns> Статус операции. </returns>
        public Status SaveAlarms()
        {
            _progressData.Watch.Restart();
            CreateConnection();
           
            PasteHead();
            PasteDate();

            string[] headers = new string[]
            {
                "Источник",
                "Событие",
                "Информация",
                "Дата",
                "Компьютер"
            };
            CreateTable(headers);
            PasteAlarmData();

            string newFileName = Path.Remove(Path.Length - 4) + "_SC.docx";

            try
            {
                _doc.SaveAs(newFileName);
                NewFilePath = newFileName;
            }
            catch
            {
                CloseConnection();
                _status = Status.NotSave;
                return _status;
            }
           
            CloseConnection();
            _progressData.Watch.Stop();
            _status = Status.Success;
            return _status;           
        }

        /// <summary>
        /// Вставить дату в новый файл.
        /// </summary>
        private void PasteDate()
        {
            Word.Range data = _doc.Range(_doc.Paragraphs[2].Range.Start, _doc.Paragraphs[2].Range.End);
            data.Text = $"Дата с {StartDate.ToShortDateString()} по {EndDate.ToShortDateString()}" + Environment.NewLine;
            data.Bold = 2;
            data.Font.Size = 10;
            data.Font.Name = "Times New Roman";
            data.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }

        /// <summary>
        /// Вставить шапку в новый файл.
        /// </summary>
        private void PasteHead()
        {
            _doc.Sections.PageSetup.LeftMargin = 30;
            _doc.Sections.PageSetup.RightMargin = 30;

            Word.Range head = _doc.Range();
            head.Text = Head + Environment.NewLine;
            head.Bold = 20;
            head.Font.Size = 16;
            head.Font.Name = "Times New Roman";
            head.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
        }

        /// <summary>
        /// Сохраняет подсчитанный список количества сработок.
        /// </summary>
        /// <returns> Статус операции. </returns>
        public Status SaveAlarmSums()
        {
            _progressData.Watch.Restart();
            CreateConnection();

            PasteHead();
            PasteDate();

            string[] headers = new string[]
            {
                "Источник",
                "Количество",
            };
            CreateTable(headers);
            PasteAlarmSumData();

            string newFileName = Path.Remove(Path.Length - 4) + "_SC.docx";

            try
            {
                _doc.SaveAs(newFileName);
                NewFilePath = newFileName;
            }
            catch
            {
                CloseConnection();
                _status = Status.NotSave;
                return _status;
            }
            
            CloseConnection();
            _progressData.Watch.Stop();
            _status = Status.Success;
            return _status;
        }       

        /// <summary>
        /// Создаёт соединение с новым файлом.
        /// </summary>
        private void CreateConnection()
        {
            _app = new Word.Application();
            _doc = _app.Documents.Add(Visible: true);
        }

        /// <summary>
        /// Закрывает соединение с новым файлом.
        /// </summary>
        /// <returns> True, если подключение прошло успешно; в противном случае - false. </returns>
        private bool CloseConnection()
        {
            try
            {
                object saveOption = Word.WdSaveOptions.wdDoNotSaveChanges;
                object originalFormat = Word.WdOriginalFormat.wdOriginalDocumentFormat;
                object routeDocument = false;
                _doc.Close(ref saveOption, ref originalFormat, ref routeDocument);
                _app.DisplayAlerts = Word.WdAlertLevel.wdAlertsNone;
                _app.Quit();
                _doc = null;
                _app = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
		/// Создаёт таблицу.
		/// </summary>
		/// <param name="headers"> Заголовки. </param>
        private void CreateTable(string[] headers)
        {
            Word.Range tablePosition = _doc.Range(_doc.Paragraphs[3].Range.Start, _doc.Paragraphs[3].Range.End);
            Word.Table table = _doc.Tables.Add(tablePosition, 2, headers.Length);
            table.Borders.Enable = 1;

            for (int i = 1; i <= table.Columns.Count; i++)
            {
                table.Cell(1, i).Range.Text = headers[i - 1];
            }
        }

        /// <summary>
		/// Форматирует таблицу.
		/// </summary>
        private void FormatTable()
        {
            Word.Table table = _doc.Tables[1];         
            table.Rows[1].Range.Bold = 1;
            table.Rows[1].Range.Font.Name = "Times New Roman";
            table.Rows[1].Range.Font.Size = 10;
            table.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

            for (int i = 1; i <= table.Rows.Count; i++)
            {
                table.Rows[i].Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;
            }
        }

        /// <summary>
        ///  Вставляет список тревог в таблицу.
        /// </summary>
        private void PasteAlarmData()
        {
            Word.Table table = _doc.Tables[1];
            table.Range.Bold = 0;

            for (int i = 0; i < Alarms.Count; i++)
            {
                table.Cell(i + 2, 1).Range.Text = Alarms[i].Source;
                table.Cell(i + 2, 2).Range.Text = Alarms[i].Incident;
                table.Cell(i + 2, 3).Range.Text = Alarms[i].Info;
                table.Cell(i + 2, 4).Range.Text = Alarms[i].Date.ToString();
                table.Cell(i + 2, 5).Range.Text = Alarms[i].Computer;

                table.Rows.Add();

                _progressData.CalculateProgress(i, Alarms.Count);
                CalculateProgress?.Invoke(this, _progressData);
            }

            int lastRowIndex = table.Rows.Count;
            table.Rows[lastRowIndex].Delete();
            FormatTable();
        }

        /// <summary>
        ///  Вставляет список количества сработок в таблицу.
        /// </summary>
        private void PasteAlarmSumData()
        {
            Word.Table table = _doc.Tables[1];
            table.Range.Bold = 0;

            for (int i = 0; i < AlarmSums.Count; i++)
            {
                table.Cell(i + 2, 1).Range.Text = AlarmSums[i].Source;
                table.Cell(i + 2, 2).Range.Text = AlarmSums[i].Count.ToString();

                table.Rows.Add();

                _progressData.CalculateProgress(i, AlarmSums.Count);
                CalculateProgress?.Invoke(this, _progressData);
            }

            int lastRowIndex = table.Rows.Count;
            table.Rows[lastRowIndex].Delete();
            FormatTable();
        }

        public override string ToString()
        {
            return Path;
        }
    }
}

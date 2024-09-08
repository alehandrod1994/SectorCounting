using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SectorCounting
{
    /// <summary>
    /// Главная форма.
    /// </summary>
    public partial class Form1 : Form
    {
        private readonly Report _report = new Report();

        private SortMode _sortMode = SortMode.Up;
        private readonly Bitmap _sortUp = Properties.Resources.sortUp;
        private readonly Bitmap _sortDown = Properties.Resources.sortDown;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            aboutItem.Click += AboutItem_Click;
            openItem.Click += OpenFileItem_Click;
            saveItem.Click += SaveToFileItem_Click;
            exitItem.Click += ExitItem_Click;
            _report.CalculateProgress += Report_CalculateProgress;

            checkedListBoxDataToTable.SetItemChecked(1, true);
            checkedListBoxDataToTable.SetItemChecked(3, true);

            pictureBoxSort.Image = _sortUp;
            comboBoxSort.Text = "Сортировать по";
        }

        /// <summary>
        /// Импортирует файл.
        /// </summary>
        private void OpenFile()
        {
            string reportPath = _report.ImportFile();

            if (reportPath != "")
            {
                pictureBox1.Image = Properties.Resources.схема;
                textBox1.Text = reportPath;               
            }
            else
            {
                pictureBox1.Image = Properties.Resources.схема_чб;
                textBox1.Text = "";
            }
        }
        
        /// <summary>
        /// Конвертирует данные из файла в список тревог.
        /// </summary>
        private void ConvertFileDataToAlarms()
        {
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            progressBar1.Refresh();
            labelPercent.Text = "0%";
            labelPercent.Visible = true;
            labelPercent.Refresh();

            richTextBox1.LoadFile(textBox1.Text, RichTextBoxStreamType.RichText);
            List<string> items = new List<string>();
            items.AddRange(richTextBox1.Lines);
            _report.Head = items[0];
            _report.SetStartDate(items[2].Substring(7, 10));
            _report.SetEndDate(items[1].Substring(3));
            _report.ConvertRichTextToAlarms(items, checkedListBoxDataToTable.CheckedItems);                   
        }

        /// <summary>
        /// Показывает данные в таблице.
        /// </summary>

        private void ShowData()
        {            
            dataGridView1.DataSource = _report.Alarms;

            comboBoxSort.Items.Clear();
            comboBoxSort.Items.Add("Источник");
            comboBoxSort.Items.Add("Событие");
            comboBoxSort.Items.Add("Информация");
            comboBoxSort.Items.Add("Дата");
            comboBoxSort.Items.Add("Компьютер");
            comboBoxSort.Text = "Сортировать по";

            progressBar1.Visible = false;
            labelPercent.Visible = false;
            labelTime.Visible = false;
        }

        /// <summary>
        /// Сортирует данные.
        /// </summary>

        private async void Sorting()
        {
            string columnName = comboBoxSort.SelectedItem.ToString();

            if (dataGridView1.DataSource is List<Alarm>)
                dataGridView1.DataSource = await Task.Run(() => _report.SortAlarms(columnName, _sortMode));
            else if (dataGridView1.DataSource is List<AlarmSum>)
                dataGridView1.DataSource = await Task.Run (() =>_report.SortAlarmSums(columnName, _sortMode));           
        }

        /// <summary>
        /// Сохранияет в файл.
        /// </summary>
        /// <param name="status"> Статус сохранения. </param>
        /// <returns> Асинхронная операция. </returns>

        private async Task SaveToFile(Status status)
        {
            SetUiForStartAction();

            if (dataGridView1.DataSource is List<Alarm>)
                status = await Task.Run(() => _report.SaveAlarms());
            else if (dataGridView1.DataSource is List<AlarmSum>)
                status = await Task.Run(() => _report.SaveAlarmSums());

            if (status != Status.Success)
            {
                ShutdownSave(status);
                return;
            }

            SetUiForEndAction();
            ShowForm2(_report.NewFilePath);           
        }

        /// <summary>
        /// Меняет значения визуальных компонентов для начала действий с данными.
        /// </summary>
        private void SetUiForStartAction()
        {
            progressBar1.Value = 0;
            progressBar1.Visible = true;
            labelPercent.Text = "0%";
            labelPercent.Visible = true;
            progressBar1.Minimum = 0;
            progressBar1.Step = 1;
            labelTime.Text = "";
            labelTime.Visible = true;
            panel1.Enabled = false;
        }

        /// <summary>
        /// Меняет значения визуальных компонентов для завершения действий с данными.
        /// </summary>
        private void SetUiForEndAction()
        {
            progressBar1.Visible = false;
            labelPercent.Visible = false;
            labelTime.Visible = false;
            panel1.Enabled = true;
        }

        /// <summary>
        /// Прекращает процесс сохранения.
        /// </summary>
        /// <param name="status"> Статус сохранения. </param>
        private void ShutdownSave(Status status)
        {
            SetUiForEndAction();

            if (status == Status.NotSave)
            {
                MessageBox.Show("Не удалось сохранить файл");
            }
        }

        /// <summary>
        /// Открывает форму успешного сохранения.
        /// </summary>
        /// <param name="newPath"> Путь сохранёного файла. </param>
        private void ShowForm2(string newPath)
        {
            var form = new Form2(newPath);
            form.Show();
        }

        /// <summary>
        /// Считает количество сработок.
        /// </summary>
        /// <returns> Асинхронная операция. </returns>

        private async Task Counting()
        {
            SetUiForStartAction();      

            dataGridView1.DataSource = await Task.Run(() => _report.CalculateAlarmSum(checkedListBoxCounting.CheckedItems));

            comboBoxSort.Items.Clear();
            comboBoxSort.Items.Add("Источник");
            comboBoxSort.Items.Add("Количество");
            comboBoxSort.Text = "Сортировать по";

            SetUiForEndAction();
        }

        /// <summary>
        /// Открывает форму "О программе".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutItem_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3();
            Form3.Show();
        }

        /// <summary>
        /// Открывает файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFileItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        /// Сохраняет в файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveToFileItem_Click(object sender, EventArgs e)
        {
            pictureBoxSave_Click(sender, e);
        }

        /// <summary>
        /// Выход.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Подсчитывает значения процесса загрузки.
        /// </summary>
        /// <param name="sender"> Отчёт. </param>
        /// <param name="e"> Данные процесса загрузки. </param>
        private void Report_CalculateProgress(object sender, ProgressData e)
        {
            progressBar1?.BeginInvoke((Action)delegate 
            {
                progressBar1.PerformStep();
                labelPercent.Text = e.Percent + "%";
                labelPercent.Refresh();
                labelTime.Text = e.NormalTimeLeft;
                labelTime.Refresh();
            });                           
        }

        /// <summary>
        /// Отрывает файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxOpen_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        /// <summary>
        /// Переносит данные в таблицу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDataToTable_Click(object sender, EventArgs e)
        {
            checkedListBoxDataToTable.Visible = false;

            if (textBox1.Text != "")
            {
                ConvertFileDataToAlarms();
                ShowData();
            }
            else MessageBox.Show("Не выбран файл");
        }

        /// <summary>
        /// Открывает список фильтров для переноса данных в таблицу.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDataToTableSettings_Click(object sender, EventArgs e)
        {
            if (checkedListBoxDataToTable.Visible == false)
                checkedListBoxDataToTable.Visible = true;
            else checkedListBoxDataToTable.Visible = false;
        }

        /// <summary>
        /// Открывает список фильтров для подсчёта количества сработок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCountingSettings_Click(object sender, EventArgs e)
        {
            if (checkedListBoxCounting.Visible == false)
                checkedListBoxCounting.Visible = true;
            else checkedListBoxCounting.Visible = false;
        }

        /// <summary>
        /// Сохраняет данные в новый файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSave_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount > 0)
            {
                SaveToFile(Status.Start); 
            }
            else MessageBox.Show("Нет данных для сохранения");
        }

        /// <summary>
        /// Производит подсчёт количества сработок.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCounting_Click(object sender, EventArgs e)
        {
            checkedListBoxCounting.Visible = false;

            Counting();
        }

        private void checkedListBoxDataToTable_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0) 
            {
                if (checkedListBoxDataToTable.GetItemChecked(0))
                {
                    for (int i = 1; i <= 8; i++)
                        checkedListBoxDataToTable.SetItemChecked(i, false);
                }
                else
                {
                    for (int i = 1; i <= 8; i++)
                        checkedListBoxDataToTable.SetItemChecked(i, true);
                }
            }
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sorting();
        }

        /// <summary>
        /// Меняет направленность сортировки.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxSort_Click(object sender, EventArgs e)
        {
            if (_sortMode == SortMode.Down)
            {
                pictureBoxSort.Image = _sortUp;
                _sortMode = SortMode.Up;
            }
            else
            {
                pictureBoxSort.Image = _sortDown;
                _sortMode = SortMode.Down;
            }

            if (comboBoxSort.SelectedIndex > -1)
                Sorting();
        }

        private void dataGridView1_DragEnter(object sender, DragEventArgs e)
        {      
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
                e.Effect = DragDropEffects.All;
        }

        private void dataGridView1_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                    textBox1.Text = file;
                pictureBox1.Image = Properties.Resources.схема;
                buttonDataToTable_Click(sender, e);
            }
            catch 
            {
                MessageBox.Show("Недопустимый формат файла");
                pictureBox1.Image = Properties.Resources.схема_чб;
                textBox1.Text = "";
                labelPercent.Visible = false;
                progressBar1.Visible = false;
            }
        }

        private void pictureBoxOpen_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxOpen.Image = Properties.Resources.iconfinder_Open_1493293_enter;
        }

        private void pictureBoxOpen_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxOpen.Image = Properties.Resources.iconfinder_Open_1493293_down;
        }

        private void pictureBoxOpen_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxOpen.Image = Properties.Resources.iconfinder_Open_1493293;
        }

        private void pictureBoxSave_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxSave.Image = Properties.Resources.iconfinder_floppy_285657_enter;
        }

        private void pictureBoxSave_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBoxSave.Image = Properties.Resources.iconfinder_floppy_285657_down;
        }

        private void pictureBoxSave_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxSave.Image = Properties.Resources.iconfinder_floppy_285657;
        }

        private void pictureBoxSort_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxSort.Size = new Size(22, 22);
            pictureBoxSort.Left--;
            pictureBoxSort.Top--;
        }

        private void pictureBoxSort_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxSort.Size = new Size(20, 20);
            pictureBoxSort.Left++;
            pictureBoxSort.Top++;
        }
             
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}

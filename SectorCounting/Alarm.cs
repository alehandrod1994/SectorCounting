using System;
using System.ComponentModel;

namespace SectorCounting
{
    /// <summary>
    /// Тревога.
    /// </summary>
    public class Alarm
    {
        /// <summary>
        /// Создаёт новый экземпляр класса Alarm.
        /// </summary>
        public Alarm() { }

        /// <summary>
        /// Создаёт новый экземпляр класса Alarm.
        /// </summary>
        /// <param name="source"> Источник. </param>
        /// <param name="incident"> Событие. </param>
        /// <param name="info"> Информация. </param>
        /// <param name="date"> Дата. </param>
        /// <param name="computer"> Компьютер. </param>
        public Alarm(string source, string incident, string info, DateTime date, string computer)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException("Источник не может быть пустым.", nameof(source));
            }

            if (string.IsNullOrWhiteSpace(incident))
            {
                throw new ArgumentNullException("Событие не может быть пустым.", nameof(incident));
            }

            if (string.IsNullOrWhiteSpace(info))
            {
                throw new ArgumentNullException("Информация не может быть пустой.", nameof(info));
            }

            if (date.Year < 2000)
            {
                throw new ArgumentException("Дата не может быть меньше 2000 года.", nameof(date));
            }

            if (string.IsNullOrWhiteSpace(computer))
            {
                throw new ArgumentNullException("Компьютер не может быть пустым.", nameof(computer));
            }
            #endregion

            Source = source;
            Incident = incident;
            Info = info;
            Date = date;
            Computer = computer;
        }

        /// <summary>
        /// Источник.
        /// </summary>
        [DisplayName("Источник")]
        public string Source { get; set; }

        /// <summary>
        /// Событие.
        /// </summary>
        [DisplayName("Событие")]
        public string Incident { get; set; }

        /// <summary>
        /// Информация.
        /// </summary>
        [DisplayName("Информация")]
        public string Info { get; set; }

        /// <summary>
        /// Дата.
        /// </summary>
        [DisplayName("Дата")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Компьютер.
        /// </summary>
        [DisplayName("Компьютер")]
        public string Computer { get; set; }

        public override string ToString()
        {
            return $"{Date} - {Source}";
        }
    }
}

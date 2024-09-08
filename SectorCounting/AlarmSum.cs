using System;
using System.ComponentModel;

namespace SectorCounting
{
    /// <summary>
    /// Количество сработок одного сектора.
    /// </summary>
    public class AlarmSum
    {
        /// <summary>
        /// Создаёт новый экземпляр класса AlarmSum.
        /// </summary>
        public AlarmSum() { }

        /// <summary>
        /// Создаёт новый экземпляр класса AlarmSum.
        /// </summary>
        /// <param name="source"> Источник. </param>
        /// <param name="count"> Количество. </param>
        public AlarmSum(string source, int count)
        {
            #region Проверка входных параметров
            if (string.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException("Источник не может быть пустым.", nameof(source));
            }
         
            if (count < 1)
            {
                throw new ArgumentNullException("Количество тревог не может быть меньше 1.", nameof(count));
            }
            #endregion

            Source = source;
            Count = count;
        }

        /// <summary>
        /// Источник.
        /// </summary>
        [DisplayName("Источник")]
        public string Source { get; set; }

        /// <summary>
        /// Количество.
        /// </summary>
        [DisplayName("Количество")]
        public int Count { get; set; }

        public override string ToString()
        {
            return $"{Source} - {Count}";
        }
    }
}

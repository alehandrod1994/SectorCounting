using System;
using System.Diagnostics;

namespace SectorCounting
{
    /// <summary>
    /// Данные процесса загрузки.
    /// </summary>
    public class ProgressData
    {
        /// <summary>
        /// Таймер.
        /// </summary>
        public Stopwatch Watch { get; } = new Stopwatch();

        /// <summary>
        /// Процент.
        /// </summary>
        public int Percent { get; private set; } = 0;

        /// <summary>
        /// Осталось времени.
        /// </summary>
        public double TimeLeft { get; private set; } = 0;

        /// <summary>
        /// Осталось времени, разделяя минуты и секунды.
        /// </summary>
        public string NormalTimeLeft { get; set; }

        /// <summary>
        /// Подсчитывает прогресс.
        /// </summary>
        /// <param name="currentIndex"> Текущий индекс. </param>
        /// <param name="maxIndex"> Максимальный индекс. </param>
        public void CalculateProgress(int currentIndex, int maxIndex)
        {
            int min = 0;
            int sec = 0;

            Percent = currentIndex * 100 / maxIndex;
            TimeLeft = Watch.Elapsed.TotalSeconds * (maxIndex - currentIndex) / currentIndex;

            if (TimeLeft >= 60 && currentIndex > 1)
            {
                min = Convert.ToInt32(TimeLeft) / 60;
                sec = Convert.ToInt32(TimeLeft) - min * 60;
                NormalTimeLeft = "Осталось: " + min + " мин " + sec + " сек";
            }
            else if (currentIndex > 1)
            {
                if (TimeLeft.ToString().Contains(","))
                    NormalTimeLeft = "Осталось: " + TimeLeft.ToString().Remove(TimeLeft.ToString().IndexOf(",")) + " сек";
                else
                    NormalTimeLeft = "Осталось: " + TimeLeft.ToString() + " сек";
            }            
        }
    }
}

using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SectorCounting
{
    /// <summary>
    /// Форма "Сохранение файла".
    /// </summary>
    public partial class Form2 : Form
    {       
        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="newPath"></param>
        public Form2(string newPath)
        {
            InitializeComponent();

            labelPath2.Text = newPath;
        }

        /// <summary>
        /// Открыть файл.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string path = labelPath2.Text;

            if (File.Exists(path))
                Process.Start(path);
            else
                MessageBox.Show("Файл не найден");
        }

        /// <summary>
        /// Открыть папку.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            Process PrFolder = new Process();
            ProcessStartInfo psi = new ProcessStartInfo();
            string file = labelPath2.Text;
            psi.CreateNoWindow = true;
            psi.WindowStyle = ProcessWindowStyle.Normal;
            psi.FileName = "explorer";
            psi.Arguments = @"/n, /select, " + file;
            PrFolder.StartInfo = psi;
            PrFolder.Start();
        }

        /// <summary>
        /// Закрыть.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

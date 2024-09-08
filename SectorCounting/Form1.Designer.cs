namespace SectorCounting
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.buttonDataToTable = new System.Windows.Forms.Button();
            this.buttonCounting = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonCountingSettings = new System.Windows.Forms.Button();
            this.buttonDataToTableSettings = new System.Windows.Forms.Button();
            this.pictureBoxOpen = new System.Windows.Forms.PictureBox();
            this.pictureBoxSave = new System.Windows.Forms.PictureBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelPercent = new System.Windows.Forms.Label();
            this.checkedListBoxDataToTable = new System.Windows.Forms.CheckedListBox();
            this.checkedListBoxCounting = new System.Windows.Forms.CheckedListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxSort = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(274, 291);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(611, 20);
            this.textBox1.TabIndex = 3;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(37, 677);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(848, 23);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Источник",
            "Событие",
            "Информация",
            "Дата",
            "Компьютер"});
            this.comboBoxSort.Location = new System.Drawing.Point(37, 290);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSort.TabIndex = 15;
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(425, 6);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(391, 199);
            this.richTextBox1.TabIndex = 23;
            this.richTextBox1.Text = "";
            this.richTextBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(37, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(848, 330);
            this.dataGridView1.TabIndex = 31;
            this.dataGridView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragDrop);
            this.dataGridView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.dataGridView1_DragEnter);
            // 
            // buttonDataToTable
            // 
            this.buttonDataToTable.Location = new System.Drawing.Point(272, 5);
            this.buttonDataToTable.Name = "buttonDataToTable";
            this.buttonDataToTable.Size = new System.Drawing.Size(167, 30);
            this.buttonDataToTable.TabIndex = 32;
            this.buttonDataToTable.Text = "Показать исходные данные";
            this.buttonDataToTable.UseVisualStyleBackColor = true;
            this.buttonDataToTable.Click += new System.EventHandler(this.buttonDataToTable_Click);
            // 
            // buttonCounting
            // 
            this.buttonCounting.Location = new System.Drawing.Point(514, 5);
            this.buttonCounting.Name = "buttonCounting";
            this.buttonCounting.Size = new System.Drawing.Size(185, 30);
            this.buttonCounting.TabIndex = 33;
            this.buttonCounting.Text = "Подсчитать количество сработок";
            this.buttonCounting.UseVisualStyleBackColor = true;
            this.buttonCounting.Click += new System.EventHandler(this.buttonCounting_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.panel1.Controls.Add(this.buttonCountingSettings);
            this.panel1.Controls.Add(this.buttonDataToTableSettings);
            this.panel1.Controls.Add(this.pictureBoxOpen);
            this.panel1.Controls.Add(this.buttonCounting);
            this.panel1.Controls.Add(this.pictureBoxSave);
            this.panel1.Controls.Add(this.buttonDataToTable);
            this.panel1.Location = new System.Drawing.Point(0, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(926, 50);
            this.panel1.TabIndex = 34;
            // 
            // buttonCountingSettings
            // 
            this.buttonCountingSettings.BackgroundImage = global::SectorCounting.Properties.Resources.iconfinder_settings_115801;
            this.buttonCountingSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonCountingSettings.Location = new System.Drawing.Point(700, 5);
            this.buttonCountingSettings.Name = "buttonCountingSettings";
            this.buttonCountingSettings.Size = new System.Drawing.Size(30, 30);
            this.buttonCountingSettings.TabIndex = 35;
            this.buttonCountingSettings.UseVisualStyleBackColor = true;
            this.buttonCountingSettings.Click += new System.EventHandler(this.buttonCountingSettings_Click);
            // 
            // buttonDataToTableSettings
            // 
            this.buttonDataToTableSettings.BackgroundImage = global::SectorCounting.Properties.Resources.iconfinder_settings_115801;
            this.buttonDataToTableSettings.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDataToTableSettings.Location = new System.Drawing.Point(440, 5);
            this.buttonDataToTableSettings.Name = "buttonDataToTableSettings";
            this.buttonDataToTableSettings.Size = new System.Drawing.Size(30, 30);
            this.buttonDataToTableSettings.TabIndex = 34;
            this.buttonDataToTableSettings.UseVisualStyleBackColor = true;
            this.buttonDataToTableSettings.Click += new System.EventHandler(this.buttonDataToTableSettings_Click);
            // 
            // pictureBoxOpen
            // 
            this.pictureBoxOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxOpen.Image = global::SectorCounting.Properties.Resources.iconfinder_Open_1493293;
            this.pictureBoxOpen.Location = new System.Drawing.Point(37, 5);
            this.pictureBoxOpen.Name = "pictureBoxOpen";
            this.pictureBoxOpen.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxOpen.TabIndex = 29;
            this.pictureBoxOpen.TabStop = false;
            this.pictureBoxOpen.Click += new System.EventHandler(this.pictureBoxOpen_Click);
            this.pictureBoxOpen.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxOpen_MouseDown);
            this.pictureBoxOpen.MouseEnter += new System.EventHandler(this.pictureBoxOpen_MouseEnter);
            this.pictureBoxOpen.MouseLeave += new System.EventHandler(this.pictureBoxOpen_MouseLeave);
            // 
            // pictureBoxSave
            // 
            this.pictureBoxSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSave.Image = global::SectorCounting.Properties.Resources.iconfinder_floppy_285657;
            this.pictureBoxSave.Location = new System.Drawing.Point(118, 5);
            this.pictureBoxSave.Name = "pictureBoxSave";
            this.pictureBoxSave.Size = new System.Drawing.Size(35, 35);
            this.pictureBoxSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSave.TabIndex = 30;
            this.pictureBoxSave.TabStop = false;
            this.pictureBoxSave.Click += new System.EventHandler(this.pictureBoxSave_Click);
            this.pictureBoxSave.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxSave_MouseDown);
            this.pictureBoxSave.MouseEnter += new System.EventHandler(this.pictureBoxSave_MouseEnter);
            this.pictureBoxSave.MouseLeave += new System.EventHandler(this.pictureBoxSave_MouseLeave);
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(34, 659);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(52, 13);
            this.labelTime.TabIndex = 37;
            this.labelTime.Text = "labelTime";
            this.labelTime.Visible = false;
            // 
            // labelPercent
            // 
            this.labelPercent.AutoSize = true;
            this.labelPercent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPercent.Location = new System.Drawing.Point(440, 659);
            this.labelPercent.Name = "labelPercent";
            this.labelPercent.Size = new System.Drawing.Size(37, 13);
            this.labelPercent.TabIndex = 38;
            this.labelPercent.Text = "100%";
            this.labelPercent.Visible = false;
            // 
            // checkedListBoxDataToTable
            // 
            this.checkedListBoxDataToTable.CheckOnClick = true;
            this.checkedListBoxDataToTable.FormattingEnabled = true;
            this.checkedListBoxDataToTable.Items.AddRange(new object[] {
            "Выбрать всё",
            "Тревога",
            "Все тревоги обработаны",
            "Тревога2",
            "Связь потеряна",
            "В норме",
            "Несоответствие типа устройства",
            "Тревога обработана",
            "Системное сообщение"});
            this.checkedListBoxDataToTable.Location = new System.Drawing.Point(274, 265);
            this.checkedListBoxDataToTable.Name = "checkedListBoxDataToTable";
            this.checkedListBoxDataToTable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBoxDataToTable.Size = new System.Drawing.Size(203, 139);
            this.checkedListBoxDataToTable.TabIndex = 40;
            this.checkedListBoxDataToTable.Visible = false;
            this.checkedListBoxDataToTable.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxDataToTable_ItemCheck);
            // 
            // checkedListBoxCounting
            // 
            this.checkedListBoxCounting.CheckOnClick = true;
            this.checkedListBoxCounting.FormattingEnabled = true;
            this.checkedListBoxCounting.Items.AddRange(new object[] {
            "Учитывать сегменты"});
            this.checkedListBoxCounting.Location = new System.Drawing.Point(514, 265);
            this.checkedListBoxCounting.Name = "checkedListBoxCounting";
            this.checkedListBoxCounting.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.checkedListBoxCounting.Size = new System.Drawing.Size(217, 19);
            this.checkedListBoxCounting.TabIndex = 41;
            this.checkedListBoxCounting.Visible = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem,
            this.refItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(926, 24);
            this.menuStrip1.TabIndex = 43;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuItem
            // 
            this.menuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItem,
            this.saveItem,
            this.exitItem});
            this.menuItem.Name = "menuItem";
            this.menuItem.Size = new System.Drawing.Size(53, 20);
            this.menuItem.Text = "Меню";
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            this.openItem.Size = new System.Drawing.Size(133, 22);
            this.openItem.Text = "Открыть";
            // 
            // saveItem
            // 
            this.saveItem.Name = "saveItem";
            this.saveItem.Size = new System.Drawing.Size(133, 22);
            this.saveItem.Text = "Сохранить";
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(133, 22);
            this.exitItem.Text = "Выход";
            // 
            // refItem
            // 
            this.refItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutItem});
            this.refItem.Name = "refItem";
            this.refItem.Size = new System.Drawing.Size(65, 20);
            this.refItem.Text = "Справка";
            // 
            // aboutItem
            // 
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(149, 22);
            this.aboutItem.Text = "О программе";
            // 
            // pictureBoxSort
            // 
            this.pictureBoxSort.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxSort.Image = global::SectorCounting.Properties.Resources.sortUp;
            this.pictureBoxSort.Location = new System.Drawing.Point(164, 290);
            this.pictureBoxSort.Name = "pictureBoxSort";
            this.pictureBoxSort.Size = new System.Drawing.Size(20, 20);
            this.pictureBoxSort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSort.TabIndex = 34;
            this.pictureBoxSort.TabStop = false;
            this.pictureBoxSort.Click += new System.EventHandler(this.pictureBoxSort_Click);
            this.pictureBoxSort.MouseEnter += new System.EventHandler(this.pictureBoxSort_MouseEnter);
            this.pictureBoxSort.MouseLeave += new System.EventHandler(this.pictureBoxSort_MouseLeave);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::SectorCounting.Properties.Resources.схема_чб;
            this.pictureBox1.Location = new System.Drawing.Point(0, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(926, 195);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 706);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.checkedListBoxCounting);
            this.Controls.Add(this.checkedListBoxDataToTable);
            this.Controls.Add(this.labelPercent);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.pictureBoxSort);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.comboBoxSort);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SectorCounting";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSave)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.PictureBox pictureBoxOpen;
        private System.Windows.Forms.PictureBox pictureBoxSave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button buttonDataToTable;
        private System.Windows.Forms.Button buttonCounting;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxSort;
        private System.Windows.Forms.Button buttonDataToTableSettings;
        private System.Windows.Forms.Button buttonCountingSettings;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelPercent;
        private System.Windows.Forms.CheckedListBox checkedListBoxDataToTable;
        private System.Windows.Forms.CheckedListBox checkedListBoxCounting;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem saveItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.ToolStripMenuItem refItem;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
    }
}


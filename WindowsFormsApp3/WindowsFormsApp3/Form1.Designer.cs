namespace WindowsFormsApp3
{
    partial class PlayfairCode
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayfairCode));
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.textBoxKeyword = new System.Windows.Forms.TextBox();
            this.textBoxSource = new System.Windows.Forms.TextBox();
            this.textBoxBigramma = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьДанныеВФайлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьФайлДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvMatrix = new System.Windows.Forms.ListView();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(563, 54);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 22);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "ENG";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(628, 54);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(56, 22);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "РУС";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // textBoxKeyword
            // 
            this.textBoxKeyword.Location = new System.Drawing.Point(159, 53);
            this.textBoxKeyword.Name = "textBoxKeyword";
            this.textBoxKeyword.Size = new System.Drawing.Size(174, 23);
            this.textBoxKeyword.TabIndex = 3;
            // 
            // textBoxSource
            // 
            this.textBoxSource.Location = new System.Drawing.Point(40, 160);
            this.textBoxSource.Multiline = true;
            this.textBoxSource.Name = "textBoxSource";
            this.textBoxSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSource.Size = new System.Drawing.Size(336, 199);
            this.textBoxSource.TabIndex = 4;
            // 
            // textBoxBigramma
            // 
            this.textBoxBigramma.Location = new System.Drawing.Point(659, 160);
            this.textBoxBigramma.Multiline = true;
            this.textBoxBigramma.Name = "textBoxBigramma";
            this.textBoxBigramma.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxBigramma.Size = new System.Drawing.Size(336, 199);
            this.textBoxBigramma.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(422, 196);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(148, 38);
            this.button1.TabIndex = 6;
            this.button1.Text = "Зашифровать --->";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 18);
            this.label1.TabIndex = 7;
            this.label1.Text = "Кодовое слово";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Язык кодировки";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(140, 125);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Исходный текст";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(739, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 18);
            this.label4.TabIndex = 10;
            this.label4.Text = "Зашифрованный текст";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.MediumOrchid;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1176, 28);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem3,
            this.toolStripMenuItem2,
            this.сохранитьДанныеВФайлToolStripMenuItem,
            this.toolStripMenuItem4,
            this.открытьФайлДанныхToolStripMenuItem});
            this.файлToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItem3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.toolStripMenuItem3.Size = new System.Drawing.Size(383, 26);
            this.toolStripMenuItem3.Text = "Сохранить кодовое слово в файл";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItem2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.toolStripMenuItem2.Size = new System.Drawing.Size(383, 26);
            this.toolStripMenuItem2.Text = "Сохранить текст в файл";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // сохранитьДанныеВФайлToolStripMenuItem
            // 
            this.сохранитьДанныеВФайлToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.сохранитьДанныеВФайлToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.сохранитьДанныеВФайлToolStripMenuItem.Name = "сохранитьДанныеВФайлToolStripMenuItem";
            this.сохранитьДанныеВФайлToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F2)));
            this.сохранитьДанныеВФайлToolStripMenuItem.Size = new System.Drawing.Size(383, 26);
            this.сохранитьДанныеВФайлToolStripMenuItem.Text = "Сохранить данные в файл";
            this.сохранитьДанныеВФайлToolStripMenuItem.Click += new System.EventHandler(this.сохранитьТекстВФайлToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStripMenuItem4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(383, 26);
            this.toolStripMenuItem4.Text = "Открыть файл с кодовым словом";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // открытьФайлДанныхToolStripMenuItem
            // 
            this.открытьФайлДанныхToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
            this.открытьФайлДанныхToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.открытьФайлДанныхToolStripMenuItem.Name = "открытьФайлДанныхToolStripMenuItem";
            this.открытьФайлДанныхToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.открытьФайлДанныхToolStripMenuItem.Size = new System.Drawing.Size(383, 26);
            this.открытьФайлДанныхToolStripMenuItem.Text = "Открыть файл с текстом";
            this.открытьФайлДанныхToolStripMenuItem.Click += new System.EventHandler(this.открытьФайлДанныхToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(116, 24);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Control;
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.X)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(172, 24);
            this.выходToolStripMenuItem.Text = "Выйти из программы";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 30;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 30;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 30;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 30;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 30;
            // 
            // lvMatrix
            // 
            this.lvMatrix.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lvMatrix.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvMatrix.GridLines = true;
            this.lvMatrix.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvMatrix.HideSelection = false;
            this.lvMatrix.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvMatrix.Location = new System.Drawing.Point(409, 125);
            this.lvMatrix.MultiSelect = false;
            this.lvMatrix.Name = "lvMatrix";
            this.lvMatrix.Size = new System.Drawing.Size(189, 26);
            this.lvMatrix.TabIndex = 3;
            this.lvMatrix.UseCompatibleStateImageBehavior = false;
            this.lvMatrix.View = System.Windows.Forms.View.Details;
            this.lvMatrix.VirtualListSize = 5;
            this.lvMatrix.Visible = false;
            this.lvMatrix.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvMatrix_RetrieveVirtualItem);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(422, 252);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(148, 38);
            this.button2.TabIndex = 12;
            this.button2.Text = " Расшифровать<---";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // PlayfairCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1176, 495);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxBigramma);
            this.Controls.Add(this.textBoxSource);
            this.Controls.Add(this.textBoxKeyword);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.lvMatrix);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Montserrat", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PlayfairCode";
            this.Text = "Шифр Плейфера";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TextBox textBoxKeyword;
        private System.Windows.Forms.TextBox textBoxSource;
        private System.Windows.Forms.TextBox textBoxBigramma;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьДанныеВФайлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьФайлДанныхToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ListView lvMatrix;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
    }
}


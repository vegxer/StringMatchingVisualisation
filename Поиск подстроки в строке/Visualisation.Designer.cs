namespace Поиск_подстроки_в_строке
{
    partial class Visualisation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.labelText = new System.Windows.Forms.Label();
            this.textBoxText = new System.Windows.Forms.TextBox();
            this.labelPattern = new System.Windows.Forms.Label();
            this.textBoxPattern = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonNextStep = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelTextEnterChoice = new System.Windows.Forms.Label();
            this.radioButtonHere = new System.Windows.Forms.RadioButton();
            this.radioButtonText = new System.Windows.Forms.RadioButton();
            this.openFileDialogTxt = new System.Windows.Forms.OpenFileDialog();
            this.buttonTextFile = new System.Windows.Forms.Button();
            this.textBoxIsFileChosen = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxPatternFileHere = new System.Windows.Forms.TextBox();
            this.textBoxIsPatternChosen = new System.Windows.Forms.TextBox();
            this.buttonTextPattern = new System.Windows.Forms.Button();
            this.radioButtonHerePattern = new System.Windows.Forms.RadioButton();
            this.radioButtonFilePatternChoice = new System.Windows.Forms.RadioButton();
            this.groupBoxAppEnter = new System.Windows.Forms.GroupBox();
            this.openFileDialogPattern = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.toolTipInfo = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBoxAppEnter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelText
            // 
            this.labelText.AutoSize = true;
            this.labelText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelText.Location = new System.Drawing.Point(5, 16);
            this.labelText.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelText.Name = "labelText";
            this.labelText.Size = new System.Drawing.Size(107, 17);
            this.labelText.TabIndex = 0;
            this.labelText.Text = "Введите текст:";
            // 
            // textBoxText
            // 
            this.textBoxText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxText.Location = new System.Drawing.Point(5, 39);
            this.textBoxText.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxText.MaxLength = 25;
            this.textBoxText.Name = "textBoxText";
            this.textBoxText.Size = new System.Drawing.Size(259, 21);
            this.textBoxText.TabIndex = 1;
            // 
            // labelPattern
            // 
            this.labelPattern.AutoSize = true;
            this.labelPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelPattern.Location = new System.Drawing.Point(5, 65);
            this.labelPattern.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPattern.Name = "labelPattern";
            this.labelPattern.Size = new System.Drawing.Size(125, 17);
            this.labelPattern.TabIndex = 2;
            this.labelPattern.Text = "Введите паттерн:";
            // 
            // textBoxPattern
            // 
            this.textBoxPattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxPattern.Location = new System.Drawing.Point(5, 88);
            this.textBoxPattern.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.textBoxPattern.MaxLength = 25;
            this.textBoxPattern.Name = "textBoxPattern";
            this.textBoxPattern.Size = new System.Drawing.Size(259, 21);
            this.textBoxPattern.TabIndex = 3;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStart.Location = new System.Drawing.Point(104, 380);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(90, 40);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.MouseEnter += new System.EventHandler(this.buttonStart_MouseEnter);
            // 
            // buttonNextStep
            // 
            this.buttonNextStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonNextStep.Location = new System.Drawing.Point(96, 429);
            this.buttonNextStep.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.buttonNextStep.Name = "buttonNextStep";
            this.buttonNextStep.Size = new System.Drawing.Size(109, 51);
            this.buttonNextStep.TabIndex = 5;
            this.buttonNextStep.Text = "Следующий шаг";
            this.buttonNextStep.UseVisualStyleBackColor = true;
            this.buttonNextStep.Click += new System.EventHandler(this.button1_Click);
            this.buttonNextStep.DragEnter += new System.Windows.Forms.DragEventHandler(this.buttonNextStep_DragEnter);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(334, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 1000);
            this.panel1.TabIndex = 6;
            // 
            // labelTextEnterChoice
            // 
            this.labelTextEnterChoice.AutoSize = true;
            this.labelTextEnterChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTextEnterChoice.Location = new System.Drawing.Point(12, 9);
            this.labelTextEnterChoice.Name = "labelTextEnterChoice";
            this.labelTextEnterChoice.Size = new System.Drawing.Size(263, 20);
            this.labelTextEnterChoice.TabIndex = 7;
            this.labelTextEnterChoice.Text = "Выберите вариант ввода текста:";
            // 
            // radioButtonHere
            // 
            this.radioButtonHere.AutoSize = true;
            this.radioButtonHere.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonHere.Location = new System.Drawing.Point(8, 32);
            this.radioButtonHere.Name = "radioButtonHere";
            this.radioButtonHere.Size = new System.Drawing.Size(154, 21);
            this.radioButtonHere.TabIndex = 8;
            this.radioButtonHere.TabStop = true;
            this.radioButtonHere.Text = "Ввод в приложении";
            this.radioButtonHere.UseVisualStyleBackColor = true;
            this.radioButtonHere.CheckedChanged += new System.EventHandler(this.radioButtonHere_CheckedChanged);
            // 
            // radioButtonText
            // 
            this.radioButtonText.AutoSize = true;
            this.radioButtonText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonText.Location = new System.Drawing.Point(8, 62);
            this.radioButtonText.Name = "radioButtonText";
            this.radioButtonText.Size = new System.Drawing.Size(200, 21);
            this.radioButtonText.TabIndex = 9;
            this.radioButtonText.TabStop = true;
            this.radioButtonText.Text = "Ввод из текстового файла";
            this.radioButtonText.UseVisualStyleBackColor = true;
            this.radioButtonText.CheckedChanged += new System.EventHandler(this.radioButtonText_CheckedChanged);
            // 
            // buttonTextFile
            // 
            this.buttonTextFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonTextFile.Location = new System.Drawing.Point(6, 20);
            this.buttonTextFile.Name = "buttonTextFile";
            this.buttonTextFile.Size = new System.Drawing.Size(62, 23);
            this.buttonTextFile.TabIndex = 10;
            this.buttonTextFile.Text = "Обзор...";
            this.buttonTextFile.UseVisualStyleBackColor = true;
            this.buttonTextFile.Click += new System.EventHandler(this.buttonTextFile_Click);
            // 
            // textBoxIsFileChosen
            // 
            this.textBoxIsFileChosen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.textBoxIsFileChosen.Location = new System.Drawing.Point(74, 20);
            this.textBoxIsFileChosen.Name = "textBoxIsFileChosen";
            this.textBoxIsFileChosen.ReadOnly = true;
            this.textBoxIsFileChosen.Size = new System.Drawing.Size(190, 21);
            this.textBoxIsFileChosen.TabIndex = 11;
            this.textBoxIsFileChosen.Text = "Текст не выбран";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxPatternFileHere);
            this.groupBox1.Controls.Add(this.textBoxIsPatternChosen);
            this.groupBox1.Controls.Add(this.buttonTextPattern);
            this.groupBox1.Controls.Add(this.radioButtonHerePattern);
            this.groupBox1.Controls.Add(this.radioButtonFilePatternChoice);
            this.groupBox1.Controls.Add(this.buttonTextFile);
            this.groupBox1.Controls.Add(this.textBoxIsFileChosen);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox1.Location = new System.Drawing.Point(8, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 163);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ввод из файла";
            // 
            // textBoxPatternFileHere
            // 
            this.textBoxPatternFileHere.Location = new System.Drawing.Point(8, 135);
            this.textBoxPatternFileHere.MaxLength = 25;
            this.textBoxPatternFileHere.Name = "textBoxPatternFileHere";
            this.textBoxPatternFileHere.Size = new System.Drawing.Size(256, 21);
            this.textBoxPatternFileHere.TabIndex = 16;
            // 
            // textBoxIsPatternChosen
            // 
            this.textBoxIsPatternChosen.Location = new System.Drawing.Point(74, 79);
            this.textBoxIsPatternChosen.Name = "textBoxIsPatternChosen";
            this.textBoxIsPatternChosen.ReadOnly = true;
            this.textBoxIsPatternChosen.Size = new System.Drawing.Size(188, 21);
            this.textBoxIsPatternChosen.TabIndex = 15;
            this.textBoxIsPatternChosen.Text = "Паттерн не выбран";
            // 
            // buttonTextPattern
            // 
            this.buttonTextPattern.Location = new System.Drawing.Point(6, 78);
            this.buttonTextPattern.Name = "buttonTextPattern";
            this.buttonTextPattern.Size = new System.Drawing.Size(62, 23);
            this.buttonTextPattern.TabIndex = 14;
            this.buttonTextPattern.Text = "Обзор...";
            this.buttonTextPattern.UseVisualStyleBackColor = true;
            this.buttonTextPattern.Click += new System.EventHandler(this.buttonTextPattern_Click);
            // 
            // radioButtonHerePattern
            // 
            this.radioButtonHerePattern.AutoSize = true;
            this.radioButtonHerePattern.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonHerePattern.Location = new System.Drawing.Point(6, 107);
            this.radioButtonHerePattern.Name = "radioButtonHerePattern";
            this.radioButtonHerePattern.Size = new System.Drawing.Size(165, 21);
            this.radioButtonHerePattern.TabIndex = 13;
            this.radioButtonHerePattern.TabStop = true;
            this.radioButtonHerePattern.Text = "Ввод паттерна здесь";
            this.radioButtonHerePattern.UseVisualStyleBackColor = true;
            this.radioButtonHerePattern.CheckedChanged += new System.EventHandler(this.radioButtonHerePattern_CheckedChanged);
            // 
            // radioButtonFilePatternChoice
            // 
            this.radioButtonFilePatternChoice.AutoSize = true;
            this.radioButtonFilePatternChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.radioButtonFilePatternChoice.Location = new System.Drawing.Point(7, 50);
            this.radioButtonFilePatternChoice.Name = "radioButtonFilePatternChoice";
            this.radioButtonFilePatternChoice.Size = new System.Drawing.Size(190, 21);
            this.radioButtonFilePatternChoice.TabIndex = 12;
            this.radioButtonFilePatternChoice.TabStop = true;
            this.radioButtonFilePatternChoice.Text = "Ввод паттерна из файла";
            this.radioButtonFilePatternChoice.UseVisualStyleBackColor = true;
            this.radioButtonFilePatternChoice.CheckedChanged += new System.EventHandler(this.radioButtonFilePatternChoice_CheckedChanged);
            // 
            // groupBoxAppEnter
            // 
            this.groupBoxAppEnter.Controls.Add(this.labelText);
            this.groupBoxAppEnter.Controls.Add(this.textBoxText);
            this.groupBoxAppEnter.Controls.Add(this.labelPattern);
            this.groupBoxAppEnter.Controls.Add(this.textBoxPattern);
            this.groupBoxAppEnter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBoxAppEnter.Location = new System.Drawing.Point(8, 258);
            this.groupBoxAppEnter.Name = "groupBoxAppEnter";
            this.groupBoxAppEnter.Size = new System.Drawing.Size(270, 116);
            this.groupBoxAppEnter.TabIndex = 13;
            this.groupBoxAppEnter.TabStop = false;
            this.groupBoxAppEnter.Text = "Ввод в приложении";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Поиск_подстроки_в_строке.Properties.Resources.inf;
            this.pictureBox1.Location = new System.Drawing.Point(8, 388);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            this.toolTipInfo.SetToolTip(this.pictureBox1, "Информация об алгоритме");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // Visualisation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 424);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxAppEnter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.radioButtonText);
            this.Controls.Add(this.radioButtonHere);
            this.Controls.Add(this.labelTextEnterChoice);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.buttonNextStep);
            this.Controls.Add(this.buttonStart);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "Visualisation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Алгоритм КМП";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KMP_FormClosing);
            this.Load += new System.EventHandler(this.KMP_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxAppEnter.ResumeLayout(false);
            this.groupBoxAppEnter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelText;
        private System.Windows.Forms.TextBox textBoxText;
        private System.Windows.Forms.Label labelPattern;
        private System.Windows.Forms.TextBox textBoxPattern;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonNextStep;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelTextEnterChoice;
        private System.Windows.Forms.RadioButton radioButtonHere;
        private System.Windows.Forms.RadioButton radioButtonText;
        private System.Windows.Forms.OpenFileDialog openFileDialogTxt;
        private System.Windows.Forms.Button buttonTextFile;
        private System.Windows.Forms.TextBox textBoxIsFileChosen;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxPatternFileHere;
        private System.Windows.Forms.TextBox textBoxIsPatternChosen;
        private System.Windows.Forms.Button buttonTextPattern;
        private System.Windows.Forms.RadioButton radioButtonHerePattern;
        private System.Windows.Forms.RadioButton radioButtonFilePatternChoice;
        private System.Windows.Forms.GroupBox groupBoxAppEnter;
        private System.Windows.Forms.OpenFileDialog openFileDialogPattern;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTipInfo;
    }
}
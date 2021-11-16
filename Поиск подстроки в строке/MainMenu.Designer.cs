namespace Поиск_подстроки_в_строке
{
    partial class MainMenu
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
            this.labelChoice = new System.Windows.Forms.Label();
            this.radioButtonKMP = new System.Windows.Forms.RadioButton();
            this.radioButtonBoyer = new System.Windows.Forms.RadioButton();
            this.radioButtonNaive = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelChoice
            // 
            this.labelChoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.labelChoice.Location = new System.Drawing.Point(0, 9);
            this.labelChoice.Name = "labelChoice";
            this.labelChoice.Size = new System.Drawing.Size(384, 55);
            this.labelChoice.TabIndex = 0;
            this.labelChoice.Text = "Выберите алгоритм для \r\nпоиска подстроки в строке";
            this.labelChoice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radioButtonKMP
            // 
            this.radioButtonKMP.AutoSize = true;
            this.radioButtonKMP.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButtonKMP.Location = new System.Drawing.Point(13, 86);
            this.radioButtonKMP.Name = "radioButtonKMP";
            this.radioButtonKMP.Size = new System.Drawing.Size(283, 24);
            this.radioButtonKMP.TabIndex = 1;
            this.radioButtonKMP.TabStop = true;
            this.radioButtonKMP.Text = "Алгоритм Кнута-Морриса-Пратта";
            this.radioButtonKMP.UseVisualStyleBackColor = true;
            // 
            // radioButtonBoyer
            // 
            this.radioButtonBoyer.AutoSize = true;
            this.radioButtonBoyer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButtonBoyer.Location = new System.Drawing.Point(13, 117);
            this.radioButtonBoyer.Name = "radioButtonBoyer";
            this.radioButtonBoyer.Size = new System.Drawing.Size(282, 24);
            this.radioButtonBoyer.TabIndex = 2;
            this.radioButtonBoyer.TabStop = true;
            this.radioButtonBoyer.Text = "Алгоритм Бойера-Мура-Хорспула";
            this.radioButtonBoyer.UseVisualStyleBackColor = true;
            // 
            // radioButtonNaive
            // 
            this.radioButtonNaive.AutoSize = true;
            this.radioButtonNaive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radioButtonNaive.Location = new System.Drawing.Point(13, 148);
            this.radioButtonNaive.Name = "radioButtonNaive";
            this.radioButtonNaive.Size = new System.Drawing.Size(172, 24);
            this.radioButtonNaive.TabIndex = 3;
            this.radioButtonNaive.TabStop = true;
            this.radioButtonNaive.Text = "Наивный алгоритм";
            this.radioButtonNaive.UseVisualStyleBackColor = true;
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.buttonStart.Location = new System.Drawing.Point(142, 197);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(115, 50);
            this.buttonStart.TabIndex = 7;
            this.buttonStart.Text = "Начать";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            this.buttonStart.MouseEnter += new System.EventHandler(this.buttonStart_MouseEnter);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(383, 259);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.radioButtonNaive);
            this.Controls.Add(this.radioButtonBoyer);
            this.Controls.Add(this.radioButtonKMP);
            this.Controls.Add(this.labelChoice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Поиск шаблона в тексте";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelChoice;
        private System.Windows.Forms.RadioButton radioButtonKMP;
        private System.Windows.Forms.RadioButton radioButtonBoyer;
        private System.Windows.Forms.RadioButton radioButtonNaive;
        private System.Windows.Forms.Button buttonStart;
    }
}


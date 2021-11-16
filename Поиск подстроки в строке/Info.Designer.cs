namespace Поиск_подстроки_в_строке
{
    partial class Info
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
            this.buttonNext = new System.Windows.Forms.Button();
            this.pictureBoxInfoImage = new System.Windows.Forms.PictureBox();
            this.buttonBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfoImage)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonNext
            // 
            this.buttonNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonNext.Location = new System.Drawing.Point(1197, 609);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 30);
            this.buttonNext.TabIndex = 0;
            this.buttonNext.Text = "Вперёд";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            this.buttonNext.MouseEnter += new System.EventHandler(this.buttonNext_MouseEnter);
            // 
            // pictureBoxInfoImage
            // 
            this.pictureBoxInfoImage.Location = new System.Drawing.Point(2, 1);
            this.pictureBoxInfoImage.Name = "pictureBoxInfoImage";
            this.pictureBoxInfoImage.Size = new System.Drawing.Size(1280, 649);
            this.pictureBoxInfoImage.TabIndex = 1;
            this.pictureBoxInfoImage.TabStop = false;
            // 
            // buttonBack
            // 
            this.buttonBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonBack.Location = new System.Drawing.Point(1116, 609);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(75, 30);
            this.buttonBack.TabIndex = 2;
            this.buttonBack.Text = "Назад";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            this.buttonBack.MouseEnter += new System.EventHandler(this.buttonBack_MouseEnter);
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1284, 651);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.pictureBoxInfoImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Info";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Описание алгоритма ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Info_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Info_FormClosed);
            this.Load += new System.EventHandler(this.Info_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfoImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.PictureBox pictureBoxInfoImage;
        private System.Windows.Forms.Button buttonBack;
    }
}
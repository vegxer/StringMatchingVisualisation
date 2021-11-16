using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Поиск_подстроки_в_строке
{
    public partial class Info : Form
    {
        private string algorithm;
        private bool userClosing;
        private int pageCount;
        public Info(string al)
        {
            InitializeComponent();
            algorithm = al;
        }

        private void Info_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.infoIcon;
            buttonBack.Enabled = false;
            userClosing = true;
            Text += algorithm;
            buttonNext.Text = "Вперёд";
            pageCount = 1;
            if (algorithm == "Кнута-Морриса-Пратта")
                pictureBoxInfoImage.Image = Properties.Resources.firstKMP;
            else if (algorithm == "Бойера-Мура-Хорспула")
                pictureBoxInfoImage.Image = Properties.Resources.firstBM;
            else if (algorithm == "Наивный алгоритм")
            {
                Text = "Описание наивного алгоритма";
                pictureBoxInfoImage.Image = Properties.Resources.firstNaive;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (!buttonBack.Enabled)
                buttonBack.Enabled = true;
            ++pageCount;
            if (algorithm == "Кнута-Морриса-Пратта")
            {
                if (pageCount == 2)
                    pictureBoxInfoImage.Image = Properties.Resources.secondKMP;
                else if (pageCount == 3)
                    pictureBoxInfoImage.Image = Properties.Resources.thirdKMP;
                else if (pageCount == 4)
                {
                    pictureBoxInfoImage.Image = Properties.Resources.fourthKMP;
                    buttonNext.Text = "Выход";
                }
                else
                {
                    userClosing = false;
                    Close();
                }
            }
            else if (algorithm == "Бойера-Мура-Хорспула")
            {
                if (pageCount == 2)
                    pictureBoxInfoImage.Image = Properties.Resources.secondBM;
                else if (pageCount == 3)
                {
                    pictureBoxInfoImage.Image = Properties.Resources.thirdBM;
                    buttonNext.Text = "Выход";
                }
                else
                {
                    userClosing = false;
                    Close();
                }
            }
            else if (algorithm == "Наивный алгоритм")
            {
                if (pageCount == 2)
                {
                    pictureBoxInfoImage.Image = Properties.Resources.secondNaive;
                    buttonNext.Text = "Выход";
                }
                else
                {
                    userClosing = false;
                    Close();
                }
            }
        }

        private void buttonBack_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.Cursor = Cursors.Hand;
        }

        private void buttonNext_MouseEnter(object sender, EventArgs e)
        {
            buttonNext.Cursor = Cursors.Hand;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            --pageCount;
            if (algorithm == "Кнута-Морриса-Пратта")
            {
                if (pageCount == 1)
                    pictureBoxInfoImage.Image = Properties.Resources.firstKMP;
                else if (pageCount == 2)
                    pictureBoxInfoImage.Image = Properties.Resources.secondKMP;
                else if (pageCount == 3)
                {
                    pictureBoxInfoImage.Image = Properties.Resources.thirdKMP;
                    buttonNext.Text = "Вперёд";
                }
            }
            else if (algorithm == "Бойера-Мура-Хорспула")
            {
                if (pageCount == 1)
                    pictureBoxInfoImage.Image = Properties.Resources.firstBM;
                else if (pageCount == 2)
                {
                    pictureBoxInfoImage.Image = Properties.Resources.secondBM;
                    buttonNext.Text = "Вперёд";
                }
            }
            else if (algorithm == "Наивный алгоритм")
            {
                if (pageCount == 1)
                {
                    pictureBoxInfoImage.Image = Properties.Resources.firstNaive;
                    buttonNext.Text = "Вперёд";
                }
            }
            if (pageCount == 1)
                buttonBack.Enabled = false;
        }

        private void Info_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (userClosing)
                if (MessageBox.Show("Вы действительно хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    e.Cancel = true;
        }

        private void Info_FormClosed(object sender, FormClosedEventArgs e)
        {
            pictureBoxInfoImage.Image.Dispose();
            pictureBoxInfoImage.Dispose();
            buttonBack.Dispose();
            buttonNext.Dispose();
            Dispose();
        }
    }
}

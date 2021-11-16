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
    public partial class MainMenu : Form
    {
        private Visualisation vis;
        public MainMenu()
        {
            InitializeComponent();
            Icon = Properties.Resources.mainIcon;
            radioButtonKMP.Checked = true;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (radioButtonKMP.Checked)
                vis = new Visualisation("Кнута-Морриса-Пратта");
            else if (radioButtonBoyer.Checked)
                vis = new Visualisation("Бойера-Мура-Хорспула");
            else if (radioButtonNaive.Checked)
                vis = new Visualisation("Наивный алгоритм");
            vis.ShowDialog();
            vis.Dispose();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
        }

        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            buttonStart.Cursor = Cursors.Hand;
        }
    }
}

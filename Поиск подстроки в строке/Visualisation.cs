using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Net.Http.Headers;
using System.IO;
using System.Globalization;

namespace Поиск_подстроки_в_строке
{
    public partial class Visualisation : Form
    {
        private Info info;
        private Font MyFont;
        private Graphics Graph;
        private Label helpFunc;
        private Label[] index, copy;
        private Label[,] prefix, positions, lbl;
        private int x, y, res, start = -1;
        private string text, pattern, algorithmType;
        private int[] pi, remotenessArr;
        private TaskCompletionSource<bool> _tcs;

        public Visualisation(string algorithm)
        {
            InitializeComponent();
            algorithmType = algorithm;
        }

        private async Task printRes(int res)
        {
            if (res == -1)
                MessageBox.Show("Вхождений паттерна в текст не найдено", "Конец поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Найдено вхождение подстроки в строку с номера " + res, "Конец алгоритма", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _tcs = new TaskCompletionSource<bool>();
            await _tcs.Task;
            /* сбрасывание параметров к начальным */
            Width = 303;
            Height = 463;
            y = 115;
            buttonNextStep.Text = "Следующий шаг";
            panel1.Controls.Clear();
            Graph.Clear(BackColor);
            buttonNextStep.Hide();
            start = 0;
            ChangeControlsState();
        }

        private async Task KnuthMorrisPrattVisual()
        { 
            int i = 0, j = 0;
            while (i <= text.Length - pattern.Length && j - i != pattern.Length)
            {
                j = i;
                do
                {
                    _tcs = new TaskCompletionSource<bool>(); 
                    await _tcs.Task; //ожидание нажатия кнопки
                    if (j - i > 0) //очистка цвета уже пройденного лэйбла
                    {
                        lbl[0, j - 1].BackColor = Color.Transparent;
                        lbl[1, j - 1].BackColor = Color.Transparent;
                    }
                    if (text[j] == pattern[j - i]) //если символы текста и паттерна совпадают
                    {
                        lbl[0, j].BackColor = Color.LightGreen;
                        lbl[1, j].BackColor = Color.LightGreen;
                        ++j;
                    }
                } while (j - i < pattern.Length && text[j] == pattern[j - i]);
                if (j - i == pattern.Length) //нашли вхождение
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    printRes(j - pattern.Length + 1);
                }
                else
                {
                    if (i != j) //несовпадение символов не на первом индексе
                    {
                        _tcs = new TaskCompletionSource<bool>();
                        await _tcs.Task;
                        if (j - pi[j - i - 1] + pattern.Length <= text.Length) //если не последний сдвиг
                            Graph.DrawString("Сдвиг на " + (j - i) + " - pi[" + (j - i) + "]", MyFont, Brushes.Black, (text.Length + 1) * 30 + 5, y + 5);
                    }
                    else if (j + 1 - pi[j - i] + pattern.Length <= text.Length) //если не последний сдвиг
                        Graph.DrawString("Сдвиг на 1 - pi[0]", MyFont, Brushes.Black, (text.Length + 1) * 30 + 5, y + 5);
                    if (j > 0) //очистка цвета уже пройденного лэйбла
                    {
                        lbl[0, j - 1].BackColor = Color.Transparent;
                        lbl[1, j - 1].BackColor = Color.Transparent;
                    }
                    lbl[0, j].BackColor = Color.Red; //при несовпадении символов
                    lbl[1, j].BackColor = Color.Red;
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task; //ждём
                    if (lbl[1, 0].Location.Y + 30 >= buttonNextStep.Location.Y)
                        Height += 30; //увеличиваем высоту формы для новой строки таблицы свдигов
                    lbl[0, j].BackColor = Color.Transparent; //убираем красный цвет с лэйблов
                    lbl[1, j].BackColor = Color.Transparent;
                    if (i == j) //если при сдвиге первые символы не совпали (i = j = 0 и символы не совпали)
                        ++j;
                    int temp = i;
                    i += (j - i - pi[j - i - 1]); //сдвиг
                    if (i <= text.Length - pattern.Length) //если не вышли за пределы
                    {
                        for (int h = 0; h < text.Length; ++h) //массив лэйблов-копия текущего сдвига, чтобы предыдущие сдвиги не пропали с формы
                        {
                            copy[h] = new Label();
                            copy[h].Location = new Point(x + h * 30, y);
                            copy[h].Size = new Size(30, 30);
                            copy[h].Font = new Font("Arial", 16);
                            copy[h].BorderStyle = BorderStyle.FixedSingle;
                            copy[h].TextAlign = ContentAlignment.MiddleCenter;
                            copy[h].Text = lbl[1, h].Text;
                        }
                        //сдвиг подстроки
                        for (int k = i + pattern.Length - 1; k >= i; --k)
                        {
                            lbl[1, k].Text = lbl[1, k - (i - temp)].Text;
                            lbl[1, k - (i - temp)].Text = "";
                        }
                        y += 30;
                        //перемещаем новый сдвиг на строчку ниже
                        for (int p = 0; p < lbl.GetLength(1); ++p)
                            lbl[1, p].Location = new Point(x + p * 30, y);
                        //добавляем на форму копию предыдущего сдвига
                        for (int t = 0; t < text.Length; ++t)
                            panel1.Controls.Add(copy[t]);
                    }
                }
            }
            buttonNextStep.Text = "Закончить поиск";
            if (j - i != pattern.Length) //не нашли вхождение
                printRes(-1);
        }

        private async Task BoyerMooreVisual()
        {
            int textLength = text.Length, patternLength = pattern.Length, count = 0, j, letterIndex = -1, i = patternLength - 1;
            while (i < textLength)
            {
                for (count = 0, j = i; j >= i - patternLength + 1 && text[j] == pattern[patternLength - count - 1]; ++count, --j)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task; //ждём
                    if (letterIndex != -1)
                    {
                        lbl[0, letterIndex].BackColor = Color.Transparent;
                        lbl[1, letterIndex].BackColor = Color.Transparent;
                    }
                    if (text[j] == pattern[patternLength - count - 1])
                    {
                        lbl[0, j].BackColor = Color.LightGreen;
                        lbl[1, j].BackColor = Color.LightGreen;
                        letterIndex = j;
                    }
                }
                if (count == patternLength)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    printRes(i - patternLength + 2);
                    i = textLength;
                }
                else
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task; //ждём
                    if (letterIndex != -1)
                    {
                        lbl[0, letterIndex].BackColor = Color.Transparent;
                        lbl[1, letterIndex].BackColor = Color.Transparent;
                    }
                    lbl[0, j].BackColor = Color.Red;
                    lbl[1, j].BackColor = Color.Red;
                    letterIndex = j;
                    if (i + remotenessArr[text[i]] < textLength)
                    {
                        _tcs = new TaskCompletionSource<bool>();
                        await _tcs.Task; //ждём
                        lbl[1, letterIndex].BackColor = Color.Transparent;
                        lbl[0, letterIndex].BackColor = Color.Transparent;
                        lbl[0, i].BackColor = Color.Yellow;
                        Graph.DrawString("Сдвиг на pos['" + text[i] + "']", MyFont, Brushes.Black, (text.Length + 1) * 30 + 5, y + 5);
                    }
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task; //ждём
                    lbl[1, i].BackColor = Color.Transparent;
                    lbl[0, i].BackColor = Color.Transparent;
                    if (lbl[1, 0].Location.Y + 30 >= buttonNextStep.Location.Y)
                        Height += 30; //увеличиваем высоту формы для новой строки таблицы свдигов
                    int temp = i;
                    i += remotenessArr[text[i]];
                    if (i < textLength) //если не вышли за пределы
                    {
                        for (int h = 0; h < text.Length; ++h) //массив лэйблов-копия текущего сдвига, чтобы предыдущие сдвиги не пропали с формы
                        {
                            copy[h] = new Label();
                            copy[h].Location = new Point(x + h * 30, y);
                            copy[h].Size = new Size(30, 30);
                            copy[h].Font = new Font("Arial", 16);
                            copy[h].BorderStyle = BorderStyle.FixedSingle;
                            copy[h].TextAlign = ContentAlignment.MiddleCenter;
                            copy[h].Text = lbl[1, h].Text;
                        }
                        //сдвиг подстроки
                        for (int k = i; k > i - patternLength; --k)
                        {
                            lbl[1, k].Text = lbl[1, temp - (i - k)].Text;
                            lbl[1, temp - (i - k)].Text = "";
                        }
                        y += 30;
                        //перемещаем новый сдвиг на строчку ниже
                        for (int p = 0; p < lbl.GetLength(1); ++p)
                            lbl[1, p].Location = new Point(x + p * 30, y);
                        //добавляем на форму копию предыдущего сдвига
                        for (int t = 0; t < text.Length; ++t)
                            panel1.Controls.Add(copy[t]);
                    }
                }
            }
            buttonNextStep.Text = "Закончить поиск";
            if (count != patternLength) //не нашли вхождение
                printRes(-1);
        }

        private async Task NaiveSearchVisual()
        {
            int textLength = text.Length, patternLength = pattern.Length, i = 0, j = 0;
            for (i = 0; i <= textLength - patternLength; ++i)
            {
                for (j = i; j - i < patternLength && text[j] == pattern[j - i]; ++j)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task; //ждём
                    if (j > 0)
                    {
                        lbl[0, j - 1].BackColor = Color.Transparent;
                        lbl[1, j - 1].BackColor = Color.Transparent;
                    }
                    lbl[0, j].BackColor = Color.LightGreen;
                    lbl[1, j].BackColor = Color.LightGreen;
                }
                if (j - i == patternLength)
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task;
                    printRes(i + 1);
                    i = textLength + 2;
                }
                else
                {
                    _tcs = new TaskCompletionSource<bool>();
                    await _tcs.Task; //ждём
                    if (j > 0)
                    {
                        lbl[0, j - 1].BackColor = Color.Transparent;
                        lbl[1, j - 1].BackColor = Color.Transparent;
                    }
                    lbl[0, j].BackColor = Color.Red;
                    lbl[1, j].BackColor = Color.Red;
                    if (i < textLength - patternLength)
                    {
                        _tcs = new TaskCompletionSource<bool>();
                        await _tcs.Task; //ждём
                        lbl[0, j].BackColor = Color.Transparent;
                        lbl[1, j].BackColor = Color.Transparent;
                        if (lbl[1, 0].Location.Y + 30 >= buttonNextStep.Location.Y)
                            Height += 30; //увеличиваем высоту формы для новой строки таблицы свдигов
                        for (int h = 0; h < text.Length; ++h) //массив лэйблов-копия текущего сдвига, чтобы предыдущие сдвиги не пропали с формы
                        {
                            copy[h] = new Label();
                            copy[h].Location = new Point(x + h * 30, y);
                            copy[h].Size = new Size(30, 30);
                            copy[h].Font = new Font("Arial", 16);
                            copy[h].BorderStyle = BorderStyle.FixedSingle;
                            copy[h].TextAlign = ContentAlignment.MiddleCenter;
                            copy[h].Text = lbl[1, h].Text;
                        }
                        //сдвиг подстроки
                        for (int k = i + patternLength; k > i; --k)
                        {
                            lbl[1, k].Text = lbl[1, k - 1].Text;
                            lbl[1, k - 1].Text = "";
                        }
                        y += 30;
                        //перемещаем новый сдвиг на строчку ниже
                        for (int p = 0; p < lbl.GetLength(1); ++p)
                            lbl[1, p].Location = new Point(x + p * 30, y);
                        //добавляем на форму копию предыдущего сдвига
                        for (int t = 0; t < text.Length; ++t)
                            panel1.Controls.Add(copy[t]);
                    }
                }
            }
            buttonNextStep.Text = "Закончить поиск";
            if (i != textLength + 3) //не нашли вхождение
                printRes(-1);
        }

        private int KnuthMorrisPratt()
        {
            int patternLength = pattern.Length, textLength = text.Length;
            int i = 0;
            while (i <= textLength - patternLength)
            {
                int j = i;
                while (j - i < patternLength && (text[j] == pattern[j - i]))
                    ++j;
                if (j - i == patternLength)
                    return j - patternLength;
                else
                {
                    if (i == j)
                        ++j;
                    i += (j - i - pi[j - i - 1]);
                }
            }
            return -1;
        }

        private int BoyerMooreStringSearch()
        {
            int textLength = text.Length, patternLength = pattern.Length;
            for (int i = patternLength - 1; i < textLength; i += remotenessArr[text[i]])
            {
                if (text[i] == pattern[patternLength - 1])
                {
                    int count, j;
                    for (count = 0, j = i; j >= i - patternLength + 1 && text[j] == pattern[patternLength - count - 1]; ++count, --j);
                    if (count == patternLength)
                        return i - patternLength + 1;
                }
            }
	        return -1;
        }

        private int NaiveSearch()
        {
            int textLength = text.Length, patternLength = pattern.Length;
            for (int i = 0; i <= textLength - patternLength; ++i)
            {
                int j;
                for (j = i; j - i < patternLength && pattern[j - i] == text[j]; ++j);
                if (j - i == patternLength)
                    return i;
            }
            return -1;
        }

        private string DeleteEnters(string str)
        {
            for (int i = 0; i < str.Length; ++i)
                if (str[i] == '\n' || str[i] == '\r')
                    str = str.Remove(i--, 1);
            return str;
        }

        private int[] prefixFunction(string str)
        {
            int strLength = str.Length;
            int[] pi = new int[strLength];
            pi[0] = 0;
            for (int i = 1; i < strLength; ++i)
            {
                int j = pi[i - 1];
                while (j > 0 && str[i] != str[j])
                    j = pi[j - 1];
                if (str[i] == str[j])
                    ++j;
                pi[i] = j;
            }
            return pi;
        }

        private int[] initRemotenessArray(string pattern)
        {
            int length = pattern.Length;
            int size = 1104;
            int[] remotenessArray = new int[size];
            for (int i = 0; i < size; ++i)
                remotenessArray[i] = length;
            for (int i = 0; i < length - 1; ++i)
                remotenessArray[pattern[i]] = length - i - 1;
            return remotenessArray;
        }

        private void KMP_Load(object sender, EventArgs e)
        {
            Icon = Properties.Resources.mainIcon;
            ShowIcon = false;
            Text = algorithmType;
            MyFont = new Font("Arial", 14);
            radioButtonHere.Checked = true;
            buttonNextStep.Hide();
            x = 30;
            y = 115;
            Graph = panel1.CreateGraphics();
        }

        private void button1_Click(object sender, EventArgs e) //кнопка ожидания следующего шага
        {
            _tcs.SetResult(false);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        { 
            if (radioButtonHere.Checked)
            {
                pattern = textBoxPattern.Text;
                text = textBoxText.Text;
            }
            else if (radioButtonHerePattern.Checked)
                pattern = textBoxPatternFileHere.Text;
            if (!String.IsNullOrWhiteSpace(pattern) && !String.IsNullOrWhiteSpace(text))
            {
                string patternWithEnters = pattern;
                string textWithEnters = text;
                pattern = DeleteEnters(pattern);
                text = DeleteEnters(text);
                if (pattern.Length <= text.Length)
                {
                    if (algorithmType == "Кнута-Морриса-Пратта")
                    {
                        pi = prefixFunction(pattern);
                        if (text.Length > 25)
                        {
                            MessageBox.Show("Текст имеет более 25 символов\nПоиск паттерна пройдёт без визуализации", "Превышена длина текста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int result = KnuthMorrisPratt();
                            if (result == -1)
                                MessageBox.Show("Вхождений паттерна в текст не найдено", "Конец поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                int startPoint = result >= 40 ? result - 40 : 0;
                                string textFragment = text.Substring(startPoint, result + 40 + pattern.Length < text.Length ? 80 + pattern.Length : text.Length - startPoint);
                                MessageBox.Show("Найдено вхождение паттерна в текст с номера " + (result + 1) + "\nФрагмент текста рядом с вхождением:\n" + textFragment, "Конец поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            start = 1;
                            ChangeControlsState();
                            Width += (text.Length + 10) * 29; //увеличиваем ширину под размер длины текста
                            Height += 60;
                            lbl = new Label[2, text.Length];
                            copy = new Label[text.Length];
                            prefix = new Label[3, pattern.Length + 1];
                            index = new Label[text.Length + 1];
                            InitLabelsArr(prefix, pi, "pi");
                            buttonNextStep.Show();
                            helpFunc = new Label();
                            helpFunc.Width = 140;
                            helpFunc.Height = 60;
                            helpFunc.Text = "Префикс-функция\nдля паттерна";
                            helpFunc.Location = new Point((pattern.Length + 1) * 30 + 5, y - 115);
                            helpFunc.Font = new Font("Arial", 12);
                            panel1.Controls.Add(helpFunc);
                            KnuthMorrisPrattVisual();
                        }
                    }
                    else if (algorithmType == "Бойера-Мура-Хорспула")
                    {
                        remotenessArr = initRemotenessArray(pattern);
                        if (text.Length > 25)
                        {
                            MessageBox.Show("Текст имеет более 25 символов\nПоиск паттерна пройдёт без визуализации", "Превышена длина текста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int result = BoyerMooreStringSearch();
                            if (result == -1)
                                MessageBox.Show("Вхождений паттерна в текст не найдено", "Конец поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                int startPoint = result >= 40 ? result - 40 : 0;
                                string textFragment = text.Substring(startPoint, result + 40 + pattern.Length < text.Length ? 80 + pattern.Length : text.Length - startPoint);
                                MessageBox.Show("Найдено вхождение паттерна в текст с номера " + (result + 1) + "\nФрагмент текста рядом с вхождением:\n" + textFragment, "Конец поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            start = 1;
                            ChangeControlsState();
                            Width += (Math.Max(text.Length, pattern.Length + 2) + 10) * 29 + 13; //увеличиваем ширину под размер длины текста
                            Height += 60;
                            lbl = new Label[2, text.Length];
                            copy = new Label[text.Length];
                            positions = new Label[3, pattern.Length + 2];
                            index = new Label[text.Length + 1];
                            InitLabelsArr(positions, remotenessArr, "pos");
                            buttonNextStep.Show();
                            helpFunc = new Label();
                            helpFunc.Width = 160;
                            helpFunc.Height = 60;
                            helpFunc.Text = "Массив удалённости\nдля паттерна";
                            helpFunc.Location = new Point((pattern.Length + 3) * 30 + 5, y - 115);
                            helpFunc.Font = new Font("Arial", 12);
                            panel1.Controls.Add(helpFunc);
                            BoyerMooreVisual();
                        }
                    }
                    else if (algorithmType == "Наивный алгоритм")
                    {
                        if (text.Length > 25)
                        {
                            MessageBox.Show("Текст имеет более 25 символов\nПоиск паттерна пройдёт без визуализации", "Превышена длина текста", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            int result = NaiveSearch();
                            if (result == -1)
                                MessageBox.Show("Вхождений паттерна в текст не найдено", "Конец поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            else
                            {
                                int startPoint = result >= 40 ? result - 40 : 0;
                                string textFragment = text.Substring(startPoint, result + 40 + pattern.Length < text.Length ? 80 + pattern.Length : text.Length - startPoint);
                                MessageBox.Show("Найдено вхождение паттерна в текст с номера " + (result + 1) + "\nФрагмент текста рядом с вхождением:\n" + textFragment, "Конец поиска", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            start = 1;
                            ChangeControlsState();
                            Width += text.Length * 30 + 120; //увеличиваем ширину под размер длины текста
                            Height += 60;
                            lbl = new Label[2, text.Length];
                            copy = new Label[text.Length];
                            index = new Label[text.Length + 1];
                            InitLabelsNaiveAlg();
                            buttonNextStep.Show();
                            NaiveSearchVisual();
                        }
                    }
                }
                else
                    MessageBox.Show("Паттерн не может быть длиннее текста", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Введена пустая строка", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void InitLabelsNaiveAlg()
        {
            for (int i = 0; i < index.Length; ++i)
            {
                index[i] = new Label();
                index[i].Location = new Point(x - 30 + i * 30, y - 60);
                index[i].BackColor = Color.LightYellow;
                index[i].Size = new Size(30, 30);
                index[i].Font = new Font("Arial", 12);
                index[i].BorderStyle = BorderStyle.FixedSingle;
                index[i].TextAlign = ContentAlignment.MiddleCenter;
                if (i != 0)
                    index[i].Text = i.ToString();
                else
                    index[i].Text = "i";
                panel1.Controls.Add(index[i]);
            }
            for (int i = 0; i < lbl.GetLength(0); ++i)
            {
                for (int j = 0; j < lbl.GetLength(1); ++j)
                {
                    lbl[i, j] = new Label();
                    lbl[i, j].Location = new Point(x + j * 30, y - 30 + i * 30);
                    lbl[i, j].Name = "textBox" + i.ToString() + j.ToString();
                    lbl[i, j].Size = new Size(30, 30);
                    lbl[i, j].Font = new Font("Arial", 16);
                    lbl[i, j].BorderStyle = BorderStyle.FixedSingle;
                    lbl[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    if (i != 1 || j < pattern.Length)
                        lbl[i, j].Text = i == 0 ? text[j].ToString() : pattern[j].ToString();
                    else
                        lbl[i, j].Text = " ";
                    panel1.Controls.Add(lbl[i, j]);
                }
            }
        }

        private void InitLabelsArr(Label[,] helpFuncVisual, int[] helpFunc, string funcName)
        {   /* таблица лэйблов префикс-функции */
            for (int i = 0; i < 3; ++i)
                for (int j = 0; j < helpFuncVisual.GetLength(1); ++j)
                {
                    helpFuncVisual[i, j] = new Label();
                    helpFuncVisual[i, j].Location = new Point(x - 30 + j * 30, y - 100 + i * 30);
                    if (i == 0)
                        helpFuncVisual[i, j].BackColor = Color.LightYellow;
                    helpFuncVisual[i, j].Size = new Size(30, 30);
                    helpFuncVisual[i, j].Font = new Font("Arial", 12);
                    helpFuncVisual[i, j].BorderStyle = BorderStyle.FixedSingle;
                    helpFuncVisual[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    if (j != 0)
                    {
                        if (i == 0)
                            helpFuncVisual[i, j].Text = j.ToString();
                        else if (i == 1 && j - 1 < pattern.Length)
                            helpFuncVisual[i, j].Text = pattern[j - 1].ToString();
                        else if (j - 1 < pattern.Length)
                            helpFuncVisual[i, j].Text = helpFunc[algorithmType == "Бойера-Мура-Хорспула" ? pattern[j - 1] : j - 1].ToString();
                    }
                    panel1.Controls.Add(helpFuncVisual[i, j]);
                }
            helpFuncVisual[0, 0].Text = "i";
            helpFuncVisual[1, 0].Text = "P";
            if (algorithmType == "Бойера-Мура-Хорспула")
            {
                helpFuncVisual[2, 0].Font = new Font("Arial", 9);
                helpFuncVisual[0, pattern.Length + 1].Dispose();
                helpFuncVisual[1, pattern.Length + 1].Top -= 30;
                helpFuncVisual[1, pattern.Length + 1].Width = 60;
                helpFuncVisual[1, pattern.Length + 1].Height = 60;
                helpFuncVisual[1, pattern.Length + 1].Font = new Font("Arial", 11);
                helpFuncVisual[1, pattern.Length + 1].Text = "Другой символ";
                helpFuncVisual[2, pattern.Length + 1].Width = 60;
                helpFuncVisual[2, pattern.Length + 1].TextAlign = ContentAlignment.MiddleCenter;
                helpFuncVisual[2, pattern.Length + 1].Text = pattern.Length.ToString();
            }
            helpFuncVisual[2, 0].Text = funcName;
            y += 60;
            /* массив лэйблов-индексов для таблицы сдвига подстроки */
            for (int i = 0; i < index.Length; ++i)
            {
                index[i] = new Label();
                index[i].Location = new Point(x - 30 + i * 30, y - 60);
                index[i].BackColor = Color.LightYellow;
                index[i].Size = new Size(30, 30);
                index[i].Font = new Font("Arial", 12);
                index[i].BorderStyle = BorderStyle.FixedSingle;
                index[i].TextAlign = ContentAlignment.MiddleCenter;
                if (i != 0)
                    index[i].Text = i.ToString();
                else
                    index[i].Text = "i";
                panel1.Controls.Add(index[i]);
            }
            /* двумерный массив из двух строк лэйблов текста и паттерна */
            for (int i = 0; i < lbl.GetLength(0); ++i)
            {
                for (int j = 0; j < lbl.GetLength(1); ++j)
                {
                    lbl[i, j] = new Label();
                    lbl[i, j].Location = new Point(x + j * 30, y - 30 + i * 30);
                    lbl[i, j].Name = "textBox" + i.ToString() + j.ToString();
                    lbl[i, j].Size = new Size(30, 30);
                    lbl[i, j].Font = new Font("Arial", 16);
                    lbl[i, j].BorderStyle = BorderStyle.FixedSingle;
                    lbl[i, j].TextAlign = ContentAlignment.MiddleCenter;
                    if (i != 1 || j < pattern.Length)
                        lbl[i, j].Text = i == 0 ? text[j].ToString() : pattern[j].ToString();
                    else
                        lbl[i, j].Text = " ";
                    panel1.Controls.Add(lbl[i, j]);
                }
            }
        }

        private void ChangeControlsState()
        {
            if (start == 0)
            {
                if (radioButtonHere.Checked)
                {
                    textBoxPattern.Enabled = true;
                    textBoxText.Enabled = true;
                }
                else
                {
                    buttonTextFile.Enabled = true;
                    textBoxIsFileChosen.Enabled = true;
                    if (radioButtonFilePatternChoice.Checked)
                    {
                        textBoxIsPatternChosen.Enabled = true;
                        buttonTextPattern.Enabled = true;
                    }
                    else
                        textBoxPatternFileHere.Enabled = true;
                }
                radioButtonFilePatternChoice.Enabled = true;
                radioButtonHere.Enabled = true;
                radioButtonHerePattern.Enabled = true;
                radioButtonText.Enabled = true;
                buttonStart.Enabled = true;
            }
            else if (start == 1)
            {
                textBoxIsFileChosen.Enabled = false;
                textBoxIsPatternChosen.Enabled = false;
                textBoxPattern.Enabled = false;
                textBoxPatternFileHere.Enabled = false;
                textBoxText.Enabled = false;
                radioButtonFilePatternChoice.Enabled = false;
                radioButtonHere.Enabled = false;
                radioButtonText.Enabled = false;
                buttonStart.Enabled = false;
                buttonTextFile.Enabled = false;
                buttonTextPattern.Enabled = false;
                radioButtonHerePattern.Enabled = false;
            }
            start = -1;
        }

        private void radioButtonHerePattern_CheckedChanged(object sender, EventArgs e)
        {
            if (start == -1)
            {
                textBoxIsPatternChosen.Text = "Паттерн не выбран";
                textBoxIsPatternChosen.Enabled = false;
                buttonTextPattern.Enabled = false;
                textBoxPatternFileHere.Enabled = true;
                pattern = "";
            }
        }

        private void radioButtonFilePatternChoice_CheckedChanged(object sender, EventArgs e)
        {
            if (start == -1)
            {
                textBoxIsPatternChosen.Enabled = true;
                buttonTextPattern.Enabled = true;
                textBoxPatternFileHere.Enabled = false;
                textBoxPatternFileHere.Clear();
                pattern = "";
            }
        }

        private void KMP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите выйти?", "Выход из программы", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
            {
                MyFont.Dispose();
                Graph.Dispose();
                index = null;
                copy = null;
                prefix = positions = null;
                lbl = null;
                pi = remotenessArr = null;
                Dispose();
            }
        }

        private void radioButtonHere_CheckedChanged(object sender, EventArgs e)
        {
            if (start == -1)
            {
                textBoxPatternFileHere.Clear();
                textBoxIsPatternChosen.Enabled = false;
                textBoxIsFileChosen.Enabled = false;
                radioButtonFilePatternChoice.Enabled = false;
                radioButtonHerePattern.Enabled = false;
                buttonTextPattern.Enabled = false;
                buttonTextFile.Enabled = false;
                textBoxPatternFileHere.Enabled = false;
                textBoxPattern.Enabled = true;
                textBoxText.Enabled = true;
                textBoxIsFileChosen.Text = "Текст не выбран";
                textBoxIsPatternChosen.Text = "Паттерн не выбран";
                text = "";
                pattern = "";
            }
        }

        private void radioButtonText_CheckedChanged(object sender, EventArgs e)
        {
            if (start == -1)
            {
                textBoxIsFileChosen.Enabled = true;
                textBoxPattern.Enabled = false;
                textBoxText.Enabled = false;
                radioButtonFilePatternChoice.Enabled = true;
                radioButtonHerePattern.Enabled = true;
                buttonTextPattern.Enabled = false;
                textBoxIsPatternChosen.Enabled = false;
                buttonTextFile.Enabled = true;
                textBoxPatternFileHere.Enabled = true;
                radioButtonHerePattern.Checked = true;
                textBoxPattern.Clear();
                textBoxText.Clear();
                text = "";
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            info = new Info(algorithmType);
            info.ShowDialog();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void buttonStart_MouseEnter(object sender, EventArgs e)
        {
            buttonStart.Cursor = Cursors.Hand;
        }

        private void buttonNextStep_DragEnter(object sender, DragEventArgs e)
        {
            buttonNextStep.Cursor = Cursors.Hand;
        }

        private void buttonTextFile_Click(object sender, EventArgs e)
        {
            openFileDialogTxt.Filter = "Файлы txt|*.txt";
            if (openFileDialogTxt.ShowDialog() == DialogResult.OK)
            {
                string fileName = FileName(openFileDialogTxt.FileName);
                textBoxIsFileChosen.Text = fileName;
                text = File.ReadAllText(openFileDialogTxt.FileName);
            }
        }

        private void buttonTextPattern_Click(object sender, EventArgs e)
        {
            openFileDialogPattern.Filter = "Файлы txt|*.txt";
            if (openFileDialogPattern.ShowDialog() == DialogResult.OK)
            {
                string fileName = FileName(openFileDialogPattern.FileName);
                textBoxIsPatternChosen.Text = fileName;
                pattern = File.ReadAllText(openFileDialogPattern.FileName);
            }
        }

        private string FileName(string fullFileName)
        {
            string fileName = "";
            for (int i = fullFileName.Length - 1; fullFileName[i] != '\\'; --i)
                fileName = fullFileName[i] + fileName;
            return fileName;
        }

    }
}

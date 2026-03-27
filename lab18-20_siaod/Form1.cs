using System;
using System.Windows.Forms;

namespace lab18_20_siaod
{
    public partial class Form1 : Form
    {
        private Random rnd = new Random();
        private int[] array = new int[15];
        private int size = 0;
        private int resultCount = 0;

        public Form1()
        {
            InitializeComponent();

            // Настройка таблицы для отображения массива
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = 15;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.ColumnHeadersVisible = false;

            // Настройка таблицы для отображения дерева
            dataGridView2.RowCount = 4;
            dataGridView2.ColumnCount = 15;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.ColumnHeadersVisible = false;

            // Настройка таблицы результатов
            dataGridView3.RowCount = 1;
            dataGridView3.ColumnCount = 15;
            dataGridView3.RowHeadersVisible = false;
            dataGridView3.ColumnHeadersVisible = false;

            Clear_Tab();
        }

        // Функция ВВЕРХ для восстановления пирамидальности после вставки
        private void Up(int[] A, int k)
        {
            while (k > 0 && A[(k - 1) / 2] < A[k])
            {
                int temp = A[k];
                A[k] = A[(k - 1) / 2];
                A[(k - 1) / 2] = temp;
                k = (k - 1) / 2;
            }
        }

        // Функция ВНИЗ для восстановления пирамидальности после извлечения
        private void Down(int[] A, int k, int n)
        {
            while (2 * k + 1 < n)
            {
                int j = 2 * k + 1;
                if (j + 1 < n && A[j] < A[j + 1])
                {
                    j = j + 1;
                }
                if (A[k] >= A[j])
                {
                    break;
                }
                int temp = A[k];
                A[k] = A[j];
                A[j] = temp;
                k = j;
            }
        }

        // Функция вывода содержимого массива A
        private void Print(int[] A)
        {
            for (int i = 0; i < 15; i++)
            {
                if (i >= size || A[i] == 0)
                    dataGridView1.Rows[0].Cells[i].Value = "";
                else
                    dataGridView1.Rows[0].Cells[i].Value = A[i].ToString();
            }

            // Очистка перед перерисовкой дерева
            for (int r = 0; r < 4; r++)
                for (int c = 0; c < 15; c++)
                    dataGridView2.Rows[r].Cells[c].Value = "";

            // Корень
            if (A[0] != 0) dataGridView2.Rows[0].Cells[7].Value = A[0].ToString();

            // Уровень 1
            if (A[1] != 0) dataGridView2.Rows[1].Cells[3].Value = A[1].ToString();
            if (A[2] != 0) dataGridView2.Rows[1].Cells[11].Value = A[2].ToString();

            // Уровень 2
            if (A[3] != 0) dataGridView2.Rows[2].Cells[1].Value = A[3].ToString();
            if (A[4] != 0) dataGridView2.Rows[2].Cells[5].Value = A[4].ToString();
            if (A[5] != 0) dataGridView2.Rows[2].Cells[9].Value = A[5].ToString();
            if (A[6] != 0) dataGridView2.Rows[2].Cells[13].Value = A[6].ToString();

            // Уровень 3
            if (A[7] != 0) dataGridView2.Rows[3].Cells[0].Value = A[7].ToString();
            if (A[8] != 0) dataGridView2.Rows[3].Cells[2].Value = A[8].ToString();
            if (A[9] != 0) dataGridView2.Rows[3].Cells[4].Value = A[9].ToString();
            if (A[10] != 0) dataGridView2.Rows[3].Cells[6].Value = A[10].ToString();
            if (A[11] != 0) dataGridView2.Rows[3].Cells[8].Value = A[11].ToString();
            if (A[12] != 0) dataGridView2.Rows[3].Cells[10].Value = A[12].ToString();
            if (A[13] != 0) dataGridView2.Rows[3].Cells[12].Value = A[13].ToString();
            if (A[14] != 0) dataGridView2.Rows[3].Cells[14].Value = A[14].ToString();
        }

        // Функция очистки всех таблиц формы
        private void Clear_Tab()
        {
            for (int i = 0; i < 15; i++)
            {
                dataGridView1.Rows[0].Cells[i].Value = "";
                dataGridView3.Rows[0].Cells[i].Value = "";
            }

            for (int r = 0; r < 4; r++)
                for (int c = 0; c < 15; c++)
                    dataGridView2.Rows[r].Cells[c].Value = "";
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            size = 0;
            for (int i = 0; i < 15; i++)
            {
                array[i] = rnd.Next(10, 100);
                Up(array, i);
                size++;
            }

            resultCount = 0;
            Clear_Tab();
            Print(array);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
                array[i] = 0;

            size = 0;
            resultCount = 0;
            Clear_Tab();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (size == 0)
            {
                MessageBox.Show("Очередь пуста!");
                return;
            }
            if (resultCount >= 15)
            {
                MessageBox.Show("Массив результатов переполнен!");
                return;
            }

            int max = array[0];

            array[0] = array[size - 1];
            array[size - 1] = 0;
            size--;

            Down(array, 0, size);

            dataGridView3.Rows[0].Cells[resultCount].Value = max.ToString();
            resultCount++;

            Print(array);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (size >= 15)
            {
                MessageBox.Show("Очередь переполнена!");
                return;
            }

            int newValue = (int)numericUpDown1.Value;
            array[size] = newValue;
            Up(array, size);
            size++;

            Print(array);
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (size == 0)
            {
                MessageBox.Show("Очередь пуста!");
                return;
            }

            int oldValue = (int)numericUpDown2.Value;
            int newValue = (int)numericUpDown3.Value;

            int index = -1;
            for (int i = 0; i < size; i++)
            {
                if (array[i] == oldValue)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                MessageBox.Show("Элемент не найден!");
                return;
            }

            array[index] = newValue;

            if (newValue > oldValue)
            {
                Up(array, index);
            }
            else if (newValue < oldValue)
            {
                Down(array, index, size);
            }

            Print(array);
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
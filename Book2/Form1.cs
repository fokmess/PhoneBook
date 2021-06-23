using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Book2
{
    public partial class Form1 : Form
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream file;

        public Form1()
        {
             //1. Программа открывается
             //2. Заполнение данных из файла
             //3. Выбор действия
             //   3.1. Удаление - просто delete нажать на выбранной строке
             //   3.2. Добавление - открывается новая форма с добавлением
             //   3.3. Изменение - открывается новая форма с изменением
             //4. При закрытии программы текущие данные из grid записываются в файл

            //
            InitializeComponent();
            try
            {
                file = new FileStream("D:\\Users\\fokin\\Source\\Repos\\Book2\\Book2\\test.txt", FileMode.OpenOrCreate);
            }
            catch
            {
                MessageBox.Show("Ошибка открытия файла");
            }
                dataGridView1.AllowUserToAddRows = false;
            Refresh();
            

            //for (int i = 10; i < 100; i++)
            //{
            //    string[] row = { "Александр #" + i, "ул.Ромашина, " + (10 + i), "8-900-360-59-" + i, "fokin" + i + "@mail.com" };
            //    Note note = new Note(row[0], row[1], row[2], row[3]);
            //    dataGridView1.Rows.Add(row);
            //    formatter.Serialize(file, note);
            //    formatter.Deserialize(file);
            //    formatter.Serialize(note);

            //}
        }
        public void Refresh()
        {
            dataGridView1.Rows.Clear();
            file.Position = 0;
            while (file.Position < file.Length)
            {
                Note note = (Note)formatter.Deserialize(file);
                if (!note.IsEmpty())
                dataGridView1.Rows.Add(note.InRow(note));
                
            }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult result = MessageBox.Show("Действительно удалить выбранную строку?","Внимание!",MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
                e.Cancel = true;
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddSearchEdit add = new AddSearchEdit(dataGridView1,"add");
            add.ShowDialog();
           // Refresh();
        }

        private void editButt_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count != 1)
            {
                MessageBox.Show("Выберите ОДНУ строку для изменений");
                return;
            }
            AddSearchEdit edit = new AddSearchEdit(dataGridView1, "edit");
            edit.ShowDialog();
           // Refresh();
        }

        private void searchButt_Click(object sender, EventArgs e)
        {
            SearchForm search = new SearchForm(dataGridView1);
            search.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            file.SetLength(0);
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                formatter.Serialize(file, new Note((string)dataGridView1.Rows[i].Cells[0].Value, (string)dataGridView1.Rows[i].Cells[1].Value, (string)dataGridView1.Rows[i].Cells[2].Value, (string)dataGridView1.Rows[i].Cells[3].Value));
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Book2
{
    public partial class AddSearchEdit : Form
    {
        DataGridView dataGridView;
        string intent;

        public AddSearchEdit(DataGridView dataGridView,string intent)
        {
            InitializeComponent();

            this.dataGridView = dataGridView;
            this.intent = intent;

            switch (intent)
            {
                case "add":
                    button1.Text = "Добавить";
                    break;

                case "edit":
                     
                    textBoxName.Text = (string) dataGridView.SelectedRows[0].Cells[0].Value;
                    textBoxAdress.Text = (string) dataGridView.SelectedRows[0].Cells[1].Value;
                    textBoxPhone.Text = (string) dataGridView.SelectedRows[0].Cells[2].Value;
                    textBoxEmail.Text = (string) dataGridView.SelectedRows[0].Cells[3].Value;

                    button1.Text = "Изменить";
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                if (textBoxName.Text == "")
            { 
                 MessageBox.Show("Имя не может быть пустым");
                return;
            }
            if (textBoxAdress.Text == "")
            {
                MessageBox.Show("Адресс не может быть пустым");
                return;
            }
            if (textBoxPhone.Text == "")
            {
                MessageBox.Show("Телефон не может быть пустым");
                return;
            }
            if (textBoxEmail.Text == "")
            {
                MessageBox.Show("Емаил не может быть пустым");
                return;
            }
            string[] str = { textBoxName.Text, textBoxAdress.Text, textBoxPhone.Text, textBoxEmail.Text };
            switch (intent)
            {
              
             case "add":
                  //  string[] str = {textBoxName.Text,textBoxAdress.Text,textBoxPhone.Text,textBoxEmail.Text };
                    dataGridView.Rows.Add(str);
                    break;

             case "edit":
                    dataGridView.Rows.Remove(dataGridView.SelectedRows[0]);
                    dataGridView.Rows.Add(str);
                    break;
            }
            this.Close();
        }
    }
}

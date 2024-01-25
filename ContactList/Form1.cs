using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ContactList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.SelectionMode = SelectionMode.MultiExtended;
        }

        public void TextBoxDispose()
        {
            textBox1.Text = string.Empty;
            textBox2.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(new Contact { Name = textBox1.Text, Number = textBox2.Text });
            TextBoxDispose();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string text = listBox1.SelectedItem.ToString();
                string[] strings = text.Split('-');
                textBox1.Text = strings[0].TrimEnd();
                textBox2.Text = strings[1].TrimStart();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            TextBoxDispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items[listBox1.SelectedIndex] = new Contact { Name = textBox1.Text, Number = textBox2.Text };
            TextBoxDispose();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox3.Text;
            if (searchText == "")
            {
                listBox1.ClearSelected();
                TextBoxDispose();
            }
            else
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    string text = listBox1.Items[i].ToString();
                    string[] strings = text.Split('-');
                    Contact contact = new Contact { Name = strings[0].TrimEnd(), Number = strings[1].TrimStart() };

                    if (contact.Name.Contains(searchText))
                    {
                        listBox1.SetSelected(i, true); // подсветить найденный элемент
                    }
                    else
                    {
                        listBox1.SetSelected(i, false); // сбросить подсветку
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        List<Race> races = new List<Race>();

        public Form1()
        {
            InitializeComponent();
            

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Form2 form2 = new Form2();
            form2.ShowDialog();
            if (form2.DialogResult== DialogResult.OK)
            {
                races.Add(form2.R);
            }
            foreach (Race item in races)
            {
                listBox1.Items.Add(item);
            }
           

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
           

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {

            if (listBox1.SelectedIndex>=0)
            {
                listBox1.AllowDrop = false;
                listBox1.DoDragDrop(listBox1.SelectedItem, DragDropEffects.Copy);
                listBox1.AllowDrop = true;
            }
            
        }

        private void listBox2_DragDrop(object sender, DragEventArgs e)
        {
            listBox2.Items.Add(listBox1.SelectedItem);
        }

        private void listBox_DragEnter(object sender, DragEventArgs e)
        {
                e.Effect = DragDropEffects.Copy;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Все файлы(*.*)|*.*|Текстовые файлы(*.txt*)|*.txt";
            if (saveFileDialog1.ShowDialog()==DialogResult.OK)
            {
                
                StreamWriter writer = new StreamWriter(saveFileDialog1.FileName);
                foreach (Race item in races)
                {
                    writer.Write($"{item.Numb}\n{item.Type}\n{item.Point}\n{ item.ComeOut}\n{item.TimeOut}\n{item.ComeIn}\n{item.TimeIn}\n");
                }
                writer.Close();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Все файлы(*.*)|*.*|Текстовые файлы(*.txt*)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
                StreamReader reader = File.OpenText(openFileDialog1.FileName);
               
               

                do
                {
                    Race r = new Race();
                    r.Numb= int.Parse(reader.ReadLine());
                    r.Type = reader.ReadLine();
                    r.Point = reader.ReadLine();
                    r.ComeOut = reader.ReadLine();
                    r.TimeOut = reader.ReadLine();
                    r.ComeIn = reader.ReadLine();
                    r.TimeIn = reader.ReadLine();
                    races.Add(r);

                } while (!reader.EndOfStream);
                      
                reader.Close();
            }
            foreach (Race item in races)
            {
                listBox1.Items.Add(item);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                    Form2 form2 = new Form2();
           
                    form2.textBox1.Text = Convert.ToString(races[this.listBox1.SelectedIndex].Numb);
                    form2.textBox2.Text = races[this.listBox1.SelectedIndex].Type;
                    form2.textBox4.Text = races[this.listBox1.SelectedIndex].ComeOut;
                    form2.textBox5.Text = races[this.listBox1.SelectedIndex].ComeIn;
                    form2.textBox8.Text = races[this.listBox1.SelectedIndex].TimeOut;
                    form2.textBox6.Text = races[this.listBox1.SelectedIndex].TimeIn;
                    form2.textBox3.Text = races[this.listBox1.SelectedIndex].Point;
                    form2.ShowDialog();
           
                if (form2.DialogResult== DialogResult.OK)
                {
                
                    races[this.listBox1.SelectedIndex].Type= form2.textBox2.Text;
                    races[this.listBox1.SelectedIndex].Numb= Convert.ToInt32(form2.textBox1.Text);
                    races[this.listBox1.SelectedIndex].ComeOut = form2.textBox4.Text;
                    races[this.listBox1.SelectedIndex].ComeIn= form2.textBox5.Text;
                    races[this.listBox1.SelectedIndex].TimeOut= form2.textBox8.Text;
                    races[this.listBox1.SelectedIndex].TimeIn = form2.textBox6.Text;
                    races[this.listBox1.SelectedIndex].Point= form2.textBox3.Text;
                    listBox1.Items.Clear();

                    foreach (Race item in races)
                    {
                        listBox1.Items.Add(item);
                    }
                

                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex >= 0)
            {
                races.RemoveAt(listBox1.SelectedIndex);
            }
           

            listBox1.Items.Clear();



            foreach (Race item in races)
            {
                listBox1.Items.Add(item);
            }
        }

       
    }
    public class Race
    {
        public int Numb { get; set; }
        public string Type{ get; set; }
        public string Point{ get; set; }
        public string ComeOut { get; set; } 
        public string TimeOut { get; set; } 
        public string TimeIn { get; set; } 
        public string ComeIn { get; set; }


        public override string ToString()
        {
            return $"№{Numb}, Type: {Type}, { ComeOut}, {TimeOut}";
        }
    }
}

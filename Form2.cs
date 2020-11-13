using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        public Race R { get; set; }
        public Form2()
        {
            InitializeComponent();
            
            

            
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            R = new Race();
            R.Numb = Convert.ToInt32(textBox1.Text);
            R.Type = textBox2.Text;
            R.ComeOut = textBox4.Text;
            R.ComeIn = textBox5.Text;
            R.Point = textBox3.Text;
            R.TimeOut = textBox8.Text;
            R.TimeIn = textBox6.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}

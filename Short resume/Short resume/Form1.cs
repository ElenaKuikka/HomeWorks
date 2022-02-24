using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Short_resume
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res1 = DialogResult.None;
            DialogResult res2 = DialogResult.None;
            DialogResult res3 = DialogResult.None;
            string Name = new string($"{label1.Text}: {textBox1.Text}\n{label2.Text}: {textBox1.Text}\n{label3.Text}: {textBox3.Text}");
            string Education = new string($"{label4.Text}: {comboBox1.Text}\n{label5.Text}: {textBox4.Text}\n{label6.Text}: {textBox5.Text}");
            string Work = new string($"{label7.Text}: \n{textBox6.Text}\n\n{label8.Text}: \n{textBox7.Text}");
            string Allresume = Name + Education + Work;
            int AvrSym = Allresume.Length / 3;

            res1 = MessageBox.Show(
                Name,
                groupBox1.Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );

            if (res1 == DialogResult.OK)
            {
                res2 = MessageBox.Show(
                Education,
                groupBox2.Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );

            }

            if (res2 == DialogResult.OK)
            {
                res3 = MessageBox.Show(
                new string(Work + "\n\nЗакончить работу?"),
                new string($"Среднее количество символов на странице: {AvrSym}"),
                MessageBoxButtons.YesNo,
                MessageBoxIcon.None,
                MessageBoxDefaultButton.Button1,
                MessageBoxOptions.DefaultDesktopOnly
                );
            }

            if (res3 == DialogResult.Yes)
                this.Close();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(new string[] { "среднее общее", "среднее профессиональное", "высшее"});
            comboBox1.SelectedText = "высшее";
        }
    }
}

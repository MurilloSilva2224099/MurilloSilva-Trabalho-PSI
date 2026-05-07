using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_final_def
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            label3.MouseEnter += label3_MouseEnter;
            label3.MouseLeave += label3_MouseLeave;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
            this.Hide();
        }
        private void label3_MouseEnter(object sender, EventArgs e)

        {

            label3.ForeColor = Color.FromArgb(255, 128, 0); // quando o rato passa por cima

        }

        private void label3_MouseLeave(object sender, EventArgs e)

        {

            label3.ForeColor = Color.Black; // quando o rato sai

        }



        private void label4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Preenche o email e a senha antes de iniciar sessão.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Login iniciado com sucesso!");
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox4.UseSystemPasswordChar = true;
            }
        }
    }
}

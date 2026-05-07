using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_final_def
{
    public partial class Form3 : Form
    {

        public Form3()
        {
            SqlConnection salada = new SqlConnection("Server = (localdb)\\MSSQLLocalDB; Database = Projeto Final PSi; Trusted_Connection = True");
            salada.Open();



            InitializeComponent();
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            float centerX = width / 2f;
            float centerY = height * 0.35f;
            float radius = Math.Max(width, height) * 1.2f;

            using (var path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(centerX - radius, centerY - radius, radius * 2, radius * 2);

                using (var brush = new System.Drawing.Drawing2D.PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(45, 20, 70);   // centro iluminado
                    brush.SurroundColors = new Color[] { Color.FromArgb(8, 8, 15) }; // bordas escuras
                    brush.CenterPoint = new PointF(centerX, centerY);

                    e.Graphics.FillRectangle(brush, 0, 0, width, height);
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            {
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection salada = new SqlConnection(
                "Server=(localdb)\\MSSQLLocalDB;Database=[Projeto Final PSi];Trusted_Connection=True"))
            {
                salada.Open();

                string query = "INSERT INTO Contas (Numero1, Numero2, Resultado) VALUES (@n1, @n2, @res)";

                SqlCommand cmd = new SqlCommand(query, salada);

                cmd.Parameters.AddWithValue("@n1", 5);
                cmd.Parameters.AddWithValue("@n2", 3);
                cmd.Parameters.AddWithValue("@res", 8);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Dados guardados!");
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

                if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Preenche o email e a senha.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!textBox3.Text.Contains("@gmail.com"))
            {
                MessageBox.Show("Email incompleto, Falta (@gmail.com)", "Erro Email",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Login efetuado com sucesso!");
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Preenche o email e a senha antes de iniciar sessão.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
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

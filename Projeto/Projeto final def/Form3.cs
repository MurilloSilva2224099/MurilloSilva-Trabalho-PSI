using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Projeto_final_def
{
    public partial class Form3 : Form
    {
        SqlConnection conexao = new SqlConnection(
            @"Server=(localdb)\\MSSQLLocalDB;Database=Cinema;Trusted_Connection=True;"
        );

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        // ===================== CRIAR CONTA =====================
        private void btnCriarConta_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            string email = textBox3.Text;
            string senha = textBox4.Text;

            if (nome == "" || email == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos!");
                return;
            }

            if (Regex.IsMatch(nome, @"\d"))
            {
                MessageBox.Show("O nome não pode conter números!");
                return;
            }

            if (!email.Contains("@gmail.com"))
            {
                MessageBox.Show("Email inválido!");
                return;
            }

            string query = "INSERT INTO Utilizadores (Nome, Email, Senha) VALUES (@Nome,@Email,@Senha)";

            SqlCommand cmd = new SqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("@Nome", nome);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);

            try
            {
                conexao.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Conta criada com sucesso!");
            }
            catch
            {
                MessageBox.Show("Erro ao criar conta (email pode já existir).");
            }
            finally
            {
                conexao.Close();
            }
        }

        // ===================== MOSTRAR / OCULTAR SENHA =====================
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = !checkBox1.Checked;
        }

        // ===================== FUNDO PERSONALIZADO =====================
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            int width = this.ClientSize.Width;
            int height = this.ClientSize.Height;

            float centerX = width / 2f;
            float centerY = height * 0.35f;
            float radius = Math.Max(width, height) * 1.2f;

            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(centerX - radius, centerY - radius, radius * 2, radius * 2);

                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = Color.FromArgb(45, 20, 70);
                    brush.SurroundColors = new Color[] { Color.FromArgb(8, 8, 15) };
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

        // ===================== EVENTO QUE ESTAVA A DAR ERRO =====================
        private void label4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        // ===================== OUTROS EVENTOS =====================
        private void textBox3_TextChanged(object sender, EventArgs e) { }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox4.UseSystemPasswordChar = true;
        }

        private void label1_Click(object sender, EventArgs e) { }

        private void pictureBox1_Click(object sender, EventArgs e) { }

        private void panel1_Paint(object sender, PaintEventArgs e) { }
    }
}
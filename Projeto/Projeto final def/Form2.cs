using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

    namespace Projeto_final_def
    {
        public partial class Form2 : Form
        {
            SqlConnection conexao = new SqlConnection(
                @"Server=(localdb)\\MSSQLLocalDB;Database=Cinema;Trusted_Connection=True;"
            );

            public Form2()
            {
                InitializeComponent();

                label3.MouseEnter += label3_MouseEnter;
                label3.MouseLeave += label3_MouseLeave;
            }

            private void Form2_Load(object sender, EventArgs e)
            {
                textBox4.UseSystemPasswordChar = true;
            }

        // BOTÃO / LABEL DE LOGIN
        private void label4_Click(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string senha = textBox4.Text;

            MessageBox.Show(senha);

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                MessageBox.Show(
                    "Preenche o email e a senha antes de iniciar sessão.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }
            else
            {
                

                try
                {
                    string query = "SELECT COUNT(*) FROM Utilizadores WHERE Email=@Email AND Senha=@Senha";
                    SqlCommand cmd = new SqlCommand(query, conexao);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Senha", senha);

                    conexao.Open();
                    int resultado = (int)cmd.ExecuteScalar();
                 

                    if (resultado > 0)
                    {
                        MessageBox.Show("Login concluído com sucesso!");

                        Form4 form4 = new Form4();
                        form4.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show(
                            "Email ou senha incorretos!",
                            "Erro",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message);
                    conexao.Close();
                }
            }
            conexao.Close();
        }

            // ABRIR FORM DE CRIAR CONTA
            private void label3_Click(object sender, EventArgs e)
            {
                Form3 form3 = new Form3();
                form3.Show();
                this.Hide();
            }

            // EFEITO HOVER
            private void label3_MouseEnter(object sender, EventArgs e)
            {
                label3.ForeColor = Color.FromArgb(200, 162, 255);
            }

            private void label3_MouseLeave(object sender, EventArgs e)
            {
                label3.ForeColor = Color.White;
            }

            // MOSTRAR / ESCONDER SENHA
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                textBox4.UseSystemPasswordChar = !checkBox1.Checked;
            }

            // EVENTOS VAZIOS (podes apagar se não usares)
            private void label2_Click(object sender, EventArgs e)
            {
            }

            private void button1_Click(object sender, EventArgs e)
            {
            }
        }
    }
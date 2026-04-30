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
    public partial class Form3 : Form
    {
        public Form3()
        {
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

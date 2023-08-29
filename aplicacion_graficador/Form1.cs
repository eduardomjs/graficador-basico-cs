using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aplicacion_graficador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            double g, t, ti, tf, h, T, w, A;
            ti = -6;
            tf = 6;
            n = chart1.Width;
            h = (tf - ti) / n;
            w = trackBar1.Value;
            A = trackBar2.Value;
            T = trackBar3.Value;
            if (comboBox1.Text == "Senoidal")
            {
                chart1.Series["Series1"].Points.Clear();
                for (int i = 0; i < n; i++)
                {
                    t = ti + i * h;
                    g = A * Math.Sin(w * t - T);
                    chart1.Series["Series1"].Points.AddXY(i, g);
                }
            }
            if (comboBox1.Text == "Pulso")
            {
                chart1.Series["Series1"].Points.Clear();
                for (int i = 0; i < n; i++)
                {
                    t = ti + i * h;
                    double z = 0;
                    for (int j = 0; j < n; j++)
                    {
                        z += (Math.Sin((2 * j + 1) * w * (t - T)) / (2 * j + 1));
                    }
                    g = A * ((4 / Math.PI) * z);
                    chart1.Series["Series1"].Points.AddXY(i, g);
                }
            }
            if (comboBox1.Text == "Triangular")
            {
                chart1.Series["Series1"].Points.Clear();
                for (int i = 0; i < n; i++)
                {
                    t = ti + i * h;
                    double z = 0;
                    for (int j = 0; j < n; j++)
                    {
                        z += ((1 / (Math.Pow((2 * j + 1), 2))) * Math.Cos((2 * j + 1) * w * (t - T)));
                    }
                    g = A * ((Math.PI / 2) - ((4 / Math.PI) * z));
                    chart1.Series["Series1"].Points.AddXY(i, g);
                }
            }
            if (comboBox1.Text == "Diente de sierra")
            {
                chart1.Series["Series1"].Points.Clear();
                for (int i = 0; i < n; i++)
                {
                    t = ti + i * h;
                    double z = 0;
                    for (int j = 0; j < n; j++)
                    {
                        z += (2 / ((j + 1) * Math.PI)) * Math.Sin((j + 1) * w * (t - T));
                    }
                    g = A * ((4 / Math.PI) * z);
                    chart1.Series["Series1"].Points.AddXY(i, g);
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            comboBox1.Text = "(Seleccione una forma de onda)";
            trackBar1.Value = 0;
            trackBar2.Value = 0;
            trackBar3.Value = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
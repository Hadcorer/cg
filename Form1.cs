using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
        }


        public class CircleDrawer
        {
            private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
            }

            public static void DrawCircleBresenham(Graphics g, Color col, int x0, int y0, int radius)
            {
                int x = 0;
                int y = radius;
                int d = 3 - 2 * radius;

                while (x <= y)
                {
                    PutPixel(g, col, x0 + x, y0 + y, 255);
                    PutPixel(g, col, x0 - x, y0 + y, 255);
                    PutPixel(g, col, x0 + x, y0 - y, 255);
                    PutPixel(g, col, x0 - x, y0 - y, 255);
                    PutPixel(g, col, x0 + y, y0 + x, 255);
                    PutPixel(g, col, x0 - y, y0 + x, 255);
                    PutPixel(g, col, x0 + y, y0 - x, 255);
                    PutPixel(g, col, x0 - y, y0 - x, 255);

                    if (d < 0)
                        d = d + 4 * x + 6;
                    else
                    {
                        d = d + 4 * (x - y) + 10;
                        y -= 1;
                    }
                    x += 1;
                }
            }
        }
        public class EllipseDrawer
        {
            private static void PutPixel(Graphics g, Color col, int x, int y, int alpha)
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(alpha, col)), x, y, 1, 1);
            }

            public static void DrawEllipseBresenham(Graphics g, Color col, int x0, int y0, int a, int b, double angle)
            {
                double radians = angle * Math.PI / 180.0;
                double cosTheta = Math.Cos(radians);
                double sinTheta = Math.Sin(radians);

                for (double t = 0; t < 2 * Math.PI; t += 0.01)
                {
                    double x = x0 + a * Math.Cos(t);
                    double y = y0 + b * Math.Sin(t);

                    // Применение матрицы аффинного преобразования для поворота точки
                    double newX = x0 + (x - x0) * cosTheta - (y - y0) * sinTheta;
                    double newY = y0 + (x - x0) * sinTheta + (y - y0) * cosTheta;

                    int intX = Convert.ToInt32(newX);
                    int intY = Convert.ToInt32(newY);

                    PutPixel(g, col, intX, intY, 255);
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            // int x2 = int.Parse(textBox3.Text);
            //int y2 = int.Parse(textBox4.Text);
            int R = int.Parse(textBox5.Text);
            int a = int.Parse(textBox6.Text);
            int b = int.Parse(textBox3.Text);
            Graphics g = pictureBox1.CreateGraphics();
            Graphics g2 = pictureBox2.CreateGraphics();
            double angle = double.Parse(textBox4.Text);
            CircleDrawer.DrawCircleBresenham(g, Color.Black, x1, y1, R);
            EllipseDrawer.DrawEllipseBresenham(g2, Color.Black, x1, y1, a, b, angle);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x1 = int.Parse(textBox1.Text);
            int y1 = int.Parse(textBox2.Text);
            int a = int.Parse(textBox6.Text);
            int b = int.Parse(textBox3.Text);
            Graphics g2 = pictureBox2.CreateGraphics();
            double angle = double.Parse(textBox4.Text);
            g2.Clear(Color.White);
            EllipseDrawer.DrawEllipseBresenham(g2, Color.Black, x1, y1, a, b, angle);
        }
    }
}


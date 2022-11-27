namespace LB4
{
    public partial class Form1 : Form
    {
        #region Переменные
        float dkx = 20, dky = 20;//приращение при сдвиге
        float sizeX=50, sizeY=50;//масштаб по Х и Y
        float xc = 0, yc = 0;//центр фигуры
        PointF[] rhombus = new PointF[4];//точки фигуры ромб
        PointF square = new PointF();//точки фигуры квадрат
        PointF circle = new PointF();//точки фигуры круг
        PointF center = new PointF();//точка начала координат
        PointF rotate = new PointF(0,0);//точка поворота
        double angle = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
            center.X = pictureBox1.Size.Width / 2;
            center.Y = pictureBox1.Size.Height / 2;
            KeyPreview = true;
        }

        private void drawAxis(Graphics g)//рисование осей
        {
            Pen greenPen = new Pen(Color.Green);
            Pen bluePen = new Pen(Color.Blue);

            g.DrawLine(greenPen, new PointF(-pictureBox1.Width / 2.0f, 0.0f), new PointF(pictureBox1.Width / 2.0f, 0.0f));
            g.DrawLine(bluePen, new PointF(0.0f, -pictureBox1.Height / 2.0f), new PointF(0.0f, pictureBox1.Height / 2.0f));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//задание координаты х через textbox
        {
            xc = float.Parse(textBox1.Text);
            pictureBox1.Invalidate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//задание координаты y через textbox
        {
            yc = float.Parse(textBox2.Text);
            pictureBox1.Invalidate();
        }

        private void Центр_Click(object sender, EventArgs e)
        {
            xc = 0;
            yc = 0;
            pictureBox1.Refresh();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            sizeX *= float.Parse(textBox5.Text);
            sizeY *= float.Parse(textBox5.Text);
            pictureBox1.Refresh();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            sizeX *= float.Parse(textBox3.Text);
            pictureBox1.Refresh();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            sizeY *= float.Parse(textBox4.Text);
            pictureBox1.Refresh();
        }

        private void OX_Click(object sender, EventArgs e)
        {
            yc *= -1;
            pictureBox1.Refresh();
        }

        private void OY_Click(object sender, EventArgs e)
        {
            xc *= -1;
            pictureBox1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            float temp;
            temp = xc;
            xc = yc;
            yc = temp;
            pictureBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            xc *= -1;
            yc *= -1;
            float temp;
            temp = xc;
            xc = yc;
            yc = temp;
            pictureBox1.Refresh();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)//отрисовка фигуры
        {
            Graphics g = e.Graphics;
            Pen figure = new Pen(Color.DarkRed);
            g.TranslateTransform(center.X, center.Y);//перенос начала координат
            square.X = xc - sizeX/2;
            square.Y = yc - sizeY/2;
            g.DrawRectangle(figure, square.X, square.Y, sizeX, sizeY);//квадрат
            rhombus[0].X = xc;
            rhombus[0].Y = yc + sizeY/2 + 10;
            rhombus[1].X = xc + sizeX/2 + 10;
            rhombus[1].Y = yc;
            rhombus[2].X = xc;
            rhombus[2].Y = yc - sizeY / 2 - 10;
            rhombus[3].X = xc - sizeX / 2 - 10; ;
            rhombus[3].Y = yc;
            g.DrawPolygon(figure, rhombus);//ромб
            circle.X = xc - sizeX/4;
            circle.Y = yc - sizeY/4;
            g.DrawEllipse(figure,circle.X, circle.Y, sizeX/2, sizeY/2);//круг
            drawAxis(g);
            textBox1.Text = xc.ToString();
            textBox2.Text = yc.ToString();
            g.FillEllipse(Brushes.Green, rotate.X-5, rotate.Y-5, 10, 10);//центр вращения 
        }

        private void Вверх_Click(object sender, EventArgs e)//смещение вверх
        {
            yc -= dky;
            pictureBox1.Refresh();
        }

        private void Вниз_Click(object sender, EventArgs e)//смещение вниз
        {
            yc += dky;
            pictureBox1.Refresh();
        }

        private void RotateX_TextChanged(object sender, EventArgs e)
        {
            rotate.X = float.Parse(RotateX.Text);
        }

        private void RotateY_TextChanged(object sender, EventArgs e)
        {
            rotate.Y = float.Parse(RotateY.Text);
        }

        private void RotateAngle_TextChanged(object sender, EventArgs e)
        {
            angle = double.Parse(RotateAngle.Text);
        }

        private void Вправо_Click(object sender, EventArgs e)//смещение вправо
        {
            xc += dkx;
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xc = 0;
            yc = 0;
            sizeX = 50;
            sizeY = 50;
            angle = 0;
            rotate.X = 0;
            rotate.Y = 0;
            pictureBox1.Refresh();
            RotateX.Text = 0.ToString();
            RotateY.Text = 0.ToString();
            RotateAngle.Text = 0.ToString();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)//вверх
            {
                yc -= dky;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.S)//вниз
            {
                yc += dky;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.D)//вправо
            {
                xc += dkx;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.A)//влево
            {
                xc -= dkx;
                pictureBox1.Refresh();
            }
            if (e.Control && e.KeyCode == Keys.Up)
            {
                sizeX *= 2;
                sizeY *= 2;
                pictureBox1.Refresh();
            }
            if (e.Control && e.KeyCode == Keys.Down)
            {
                sizeX /= 2;
                sizeY /= 2;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.I)
            {
                sizeY *= 2;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.K)
            {
                sizeY /= 2;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.L)
            {
                sizeX *= 2;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.J)
            {
                sizeX /= 2;
                pictureBox1.Refresh();
            }
        }

        private void Влево_Click(object sender, EventArgs e)//смещение влево
        {
            xc -= dkx;
            pictureBox1.Refresh();
        }

        private void Повернуть_Click(object sender, EventArgs e)
        {
            PointF center = new PointF(xc, yc);
            center = RotatePoint(center, rotate, angle);
            xc = center.X;
            yc = center.Y;
            pictureBox1.Refresh();
        }

        static PointF RotatePoint(PointF pointToRotate, PointF centerPoint, double angleInDegrees)
        {
            double angleInRadians = angleInDegrees * (Math.PI / 180);
            double cosTheta = Math.Cos(angleInRadians);
            double sinTheta = Math.Sin(angleInRadians);
            return new PointF
            {
                X =
                    (int)
                    (cosTheta * (pointToRotate.X - centerPoint.X) -
                    sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                Y =
                    (int)
                    (sinTheta * (pointToRotate.X - centerPoint.X) +
                    cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
            };
        }



    }
}
namespace LB4
{
    public partial class Form1 : Form
    {
        #region ����������
        float dkx = 20, dky = 20;//���������� ��� ������
        float sizeX=50, sizeY=50;//������� �� � � Y
        float xc = 0, yc = 0;//����� ������
        PointF[] rhombus = new PointF[4];//����� ������ ����
        PointF square = new PointF();//����� ������ �������
        PointF circle = new PointF();//����� ������ ����
        PointF center = new PointF();//����� ������ ���������
        PointF rotate = new PointF(0,0);//����� ��������
        double angle = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
            center.X = pictureBox1.Size.Width / 2;
            center.Y = pictureBox1.Size.Height / 2;
            KeyPreview = true;
        }

        private void drawAxis(Graphics g)//��������� ����
        {
            Pen greenPen = new Pen(Color.Green);
            Pen bluePen = new Pen(Color.Blue);

            g.DrawLine(greenPen, new PointF(-pictureBox1.Width / 2.0f, 0.0f), new PointF(pictureBox1.Width / 2.0f, 0.0f));
            g.DrawLine(bluePen, new PointF(0.0f, -pictureBox1.Height / 2.0f), new PointF(0.0f, pictureBox1.Height / 2.0f));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)//������� ���������� � ����� textbox
        {
            xc = float.Parse(textBox1.Text);
            pictureBox1.Invalidate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)//������� ���������� y ����� textbox
        {
            yc = float.Parse(textBox2.Text);
            pictureBox1.Invalidate();
        }

        private void �����_Click(object sender, EventArgs e)
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)//��������� ������
        {
            Graphics g = e.Graphics;
            Pen figure = new Pen(Color.DarkRed);
            g.TranslateTransform(center.X, center.Y);//������� ������ ���������
            square.X = xc - sizeX/2;
            square.Y = yc - sizeY/2;
            g.DrawRectangle(figure, square.X, square.Y, sizeX, sizeY);//�������
            rhombus[0].X = xc;
            rhombus[0].Y = yc + sizeY/2 + 10;
            rhombus[1].X = xc + sizeX/2 + 10;
            rhombus[1].Y = yc;
            rhombus[2].X = xc;
            rhombus[2].Y = yc - sizeY / 2 - 10;
            rhombus[3].X = xc - sizeX / 2 - 10; ;
            rhombus[3].Y = yc;
            g.DrawPolygon(figure, rhombus);//����
            circle.X = xc - sizeX/4;
            circle.Y = yc - sizeY/4;
            g.DrawEllipse(figure,circle.X, circle.Y, sizeX/2, sizeY/2);//����
            drawAxis(g);
            textBox1.Text = xc.ToString();
            textBox2.Text = yc.ToString();
            g.FillEllipse(Brushes.Green, rotate.X-5, rotate.Y-5, 10, 10);//����� �������� 
        }

        private void �����_Click(object sender, EventArgs e)//�������� �����
        {
            yc -= dky;
            pictureBox1.Refresh();
        }

        private void ����_Click(object sender, EventArgs e)//�������� ����
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

        private void ������_Click(object sender, EventArgs e)//�������� ������
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
            if (e.KeyCode == Keys.W)//�����
            {
                yc -= dky;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.S)//����
            {
                yc += dky;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.D)//������
            {
                xc += dkx;
                pictureBox1.Refresh();
            }
            if (e.KeyCode == Keys.A)//�����
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

        private void �����_Click(object sender, EventArgs e)//�������� �����
        {
            xc -= dkx;
            pictureBox1.Refresh();
        }

        private void ���������_Click(object sender, EventArgs e)
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
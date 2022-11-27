using System;
using System.Windows.Forms;

namespace LB5V3
{
    public partial class Form1 : Form
    {
        #region Переменные

        int vertex_count = 4; //кол-во вершин

        int n_matr = 4; //размерность матрицы преобразования

        float sizeX, sizeY; //масштаб по x и y

        float stepX, stepY; // приращение по x и y в одном пикселе

        float relX, relY; //координаты точки относительно начала координат

        float local_x, local_y, local_z;


        float[,] points = { { 1, 1, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 1 }, { 1, 1, 1, 1 } };

        float[,] old_points = { { 1, 1, 0, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 1 }, { 1, 1, 1, 1 } };

        PointF[] scr_points = new PointF[4]; // экранные точки

        PointF[] old_scr_points = new PointF[4];

        PointF XY = new PointF(); //текущая точка на экране

        PointF centerXOY = new PointF(); // точка начала координат

        PointF centerXOZ = new PointF();

        PointF centerYOZ = new PointF();

        PointF local_centerXOY = new PointF();

        PointF local_centerXOZ = new PointF();

        PointF local_centerYOZ = new PointF();
        #endregion
        public Form1()
        {
            InitializeComponent();

            centerXOY.X = XOY.Size.Width / 2;

            centerXOY.Y = XOY.Size.Height / 2;

            local_centerXOY.X = centerXOY.X;

            local_centerXOY.Y = centerXOY.Y;

            centerXOZ.X = XOZ.Size.Width / 2;

            centerXOZ.Y = XOZ.Size.Height / 2;

            local_centerXOZ.X = centerXOZ.X;

            local_centerXOZ.Y = centerXOZ.Y;

            centerYOZ.X = YOZ.Size.Width / 2;

            centerYOZ.Y = YOZ.Size.Height / 2;

            local_centerYOZ.X = centerYOZ.X;

            local_centerYOZ.Y = centerYOZ.Y;

            koords_print();

            KeyPreview = true;
        }

        #region Горячие клавиши
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode) 
            { 
                case(Keys.W):
                {
                    float yy;
                    yy = 1;
                    perenos(0,yy, 0);
                    Graph_Update();
                    koords_print();
                }
                break;

                case(Keys.S): 
                {
                   float yy;
                   yy = -1;
                   perenos(0, yy, 0);
                   Graph_Update();
                   koords_print();
                }
                break;

                case(Keys.D):
                {
                   float xx;
                   xx = 1;
                   perenos(xx, 0, 0);
                   Graph_Update();
                   koords_print();
                }
                break;

                case (Keys.A):
                {
                    float xx;
                    xx = -1;
                    perenos(xx, 0, 0);
                    Graph_Update();
                    koords_print();
                }
                break;

                case (Keys.E): 
                {
                   float zz;
                   zz = 1;
                   perenos(0, 0, zz);
                   Graph_Update();
                   koords_print();
                }
                break;

                case (Keys.Q):
                {
                    float zz;
                    zz = -1;
                    perenos(0, 0, zz);
                    Graph_Update();
                    koords_print();
                }
                break;

                case (Keys.X): 
                {
                        float ugol;
                        ugol = 5;
                        int XYZ = 1;

                        perenos(-local_x, -local_y, -local_z);
                        povorot(ugol, XYZ);
                        perenos(local_x, local_y, local_z);

                        Graph_Update();
                        koords_print();
                }
                break;

                case (Keys.Y):
                {
                        float ugol;
                        ugol = 5;
                        int XYZ = 2;

                        perenos(-local_x, -local_y, -local_z);
                        povorot(ugol, XYZ);
                        perenos(local_x, local_y, local_z);

                        Graph_Update();
                        koords_print();
                }
                break;

                case (Keys.Z):
                {
                        float ugol;
                        ugol = 5;
                        int XYZ = 3;

                        perenos(-local_x, -local_y, -local_z);
                        povorot(ugol, XYZ);
                        perenos(local_x, local_y, local_z);

                        Graph_Update();
                        koords_print();
                }
               break;

               case (Keys.O): 
               {
                        float kx;

                        kx = 2;

                        mashtab(kx, 1, 1);

                        Graph_Update();
                        koords_print();
               }
               break;

               case (Keys.P): 
               {
                        float ky;

                        ky = 2;

                        mashtab(1, ky, 1);

                        Graph_Update();
                        koords_print();
               }
               break;

               case (Keys.I):
               {
                        float kz;

                        kz = 2;

                        mashtab(1, 1, kz);

                        Graph_Update();
                        koords_print();
               }
               break;

                case (Keys.J):
                    {
                        float kx;

                        kx = 0.5f;

                        mashtab(kx, 1, 1);

                        Graph_Update();
                        koords_print();
                    }
                    break;

                case (Keys.K):
                    {
                        float ky;

                        ky = 0.5f;

                        mashtab(1, ky, 1);

                        Graph_Update();
                        koords_print();
                    }
                    break;

                case (Keys.L):
                    {
                        float kz;

                        kz = 0.5f;

                        mashtab(1, 1, kz);

                        Graph_Update();
                        koords_print();
                    }
                    break;

                case (Keys.F): 
                {
                        float k;
                        k = 2;

                        mashtab_common(k);

                        Graph_Update();
                        koords_print();
                }
                break;

                case (Keys.H):
                {
                        float k;
                        k = 0.5f;

                        mashtab_common(k);

                        Graph_Update();
                        koords_print();
                }
                break;

                case (Keys.V):
                {
                        float[,] matr = { { -1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                        points = matr_mult(matr, points);
                        Graph_Update();
                        koords_print();
                }
                break;

                case (Keys.B):
                {
                        float[,] matr = { { 1, 0, 0, 0 }, { 0, -1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                        points = matr_mult(matr, points);
                        Graph_Update();
                        koords_print();
                }
                break;

                case (Keys.N):
                {
                    float[,] matr = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, -1, 0 }, { 0, 0, 0, 1 } };
                    points = matr_mult(matr, points);
                    Graph_Update();
                    koords_print();
                }
                break;

                case (Keys.M):
                {
                        points[0, 0] = 1;
                        points[0, 1] = 1;
                        points[0, 2] = 0;
                        points[0, 3] = 0;
                        points[1, 0] = 0;
                        points[1, 1] = 1;
                        points[1, 2] = 1;
                        points[1, 3] = 0;
                        points[2, 0] = 0;
                        points[2, 1] = 0;
                        points[2, 2] = 0;
                        points[2, 3] = 1;
                        points[3, 0] = 1;
                        points[3, 1] = 1;
                        points[3, 2] = 1;
                        points[3, 3] = 1;

                        Graph_Update();
                        koords_print();
                }
                break;

            }
        }
        #endregion

        #region Вспомогательные методы
        void koords_print()//печать координат вершин
        {
            int i;
            txtOutput.Clear();
            for (i = 0; i < vertex_count; i++)
            {
                txtOutput.Text += "Вершина " + (i + 1).ToString() + ":\n";
                txtOutput.Text += "X = " + points[0, i].ToString() + "      " + "Y = " + points[1, i].ToString() + "      " + "Z = " + points[2, i].ToString() + "\n\n";
            }
        }

        void Graph_Update()
        {
            XOY.Refresh();
            XOZ.Refresh();
            YOZ.Refresh();
        }

        private void Center_Click(object sender, EventArgs e)//перенос центра
        {
            float xx, yy, zz;

            try
            {
                xx = float.Parse(txtRel_X.Text);
                yy = float.Parse(txtRel_Y.Text);
                zz = float.Parse(txtRel_Z.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные!");
                return;
            }

            local_x = xx;
            local_y = yy;
            local_z = zz;

            Graph_Update();
        }

        #endregion

        #region Графические построения
        private void XOY_Paint(object sender, PaintEventArgs e)
        {
            Pen OXY = new Pen(Color.Blue, 2); //перо оси XOY
            Pen setka = new Pen(Color.Gray, 1); //перо масштабной сетки
            Pen figur = new Pen(Color.Red, 3); //перо для рисования фигуры
            Pen figur1 = new Pen(Color.Blue, 3);
            Graphics g = e.Graphics;
            Font txt = new Font("Arial", 14, FontStyle.Bold);
            int count = 0;
            float cx, cy;  //текущие точки плоскости XOY
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.FillRectangle(Brushes.White, 0, 0, XOY.Size.Width, XOY.Size.Height);

            sizeX = 50;
            sizeY = 50;
            stepX = 1 / sizeX;
            stepY = 1 / sizeY;

            //рисование масштабной сетки по x
            for (XY.X = centerXOY.X, count = 0; XY.X < XOY.Size.Width; XY.X += sizeX, count--)
            {
                g.DrawLine(setka, XY.X, 0, XY.X, XOY.Size.Height);
                g.DrawString(count.ToString(), txt, Brushes.Black, XY.X - txt.Size, centerXOY.Y);
            }
            for (XY.X = centerXOY.X, count = 0; XY.X > 0; XY.X -= sizeX, count++)
            {
                g.DrawLine(setka, XY.X, 0, XY.X, XOY.Size.Height);
                if (count != 0)
                    g.DrawString(count.ToString(), txt, Brushes.Black, XY.X - 1.5f * txt.Size, centerXOY.Y);
            }
            //по y
            for (XY.Y = centerXOY.Y, count = 0; XY.Y > 0; XY.Y -= sizeY, count--)
            {
                g.DrawLine(setka, 0, XY.Y, XOY.Size.Width, XY.Y);
                if (count != 0)
                    g.DrawString(count.ToString(), txt, Brushes.Black, centerXOY.X - 1.5f * txt.Size, XY.Y);
            }
            for (XY.Y = centerXOY.Y, count = 0; XY.Y < XOY.Size.Height; XY.Y += sizeY, count++)
            {
                g.DrawLine(setka, 0, XY.Y, XOY.Size.Width, XY.Y);
                if (count != 0)
                    g.DrawString(count.ToString(), txt, Brushes.Black, centerXOY.X - txt.Size, XY.Y);
            }
            //рисование координатных осей
            g.DrawLine(OXY, 0, centerXOY.Y, XOY.Size.Width, centerXOY.Y);
            g.DrawLine(OXY, centerXOY.X, 0, centerXOY.X, XOY.Size.Height);
            g.DrawString("0", txt, Brushes.Black, centerXOY.X - txt.Size, centerXOY.Y);
            cx = local_x;
            cy = local_y;
            relX = cx / stepX;
            relY = cy / stepY;
            XY.X = centerXOY.X - relX;
            XY.Y = centerXOY.Y + relY;
            g.FillEllipse(Brushes.Green, XY.X - 10, XY.Y - 10, 20, 20);

            for (int i = 0; i < 4; i++) //преобразование точек плоскости в экранные
            {
                cx = points[0, i];
                cy = points[1, i];
                relX = cx / stepX;
                relY = cy / stepY;

                XY.X = centerXOY.X - relX;
                XY.Y = centerXOY.Y + relY;

                scr_points[i].X = XY.X;
                scr_points[i].Y = XY.Y;
            }

            g.DrawLine(figur, scr_points[0], scr_points[3]); //рисование фигуры
            g.DrawLine(figur, scr_points[0], scr_points[1]);
            g.DrawLine(figur, scr_points[1], scr_points[2]);
            g.DrawLine(figur, scr_points[2], scr_points[3]);
            g.DrawLine(figur, scr_points[3], scr_points[1]);
            g.DrawLine(figur, scr_points[0], scr_points[2]);

        }


        private void XOZ_Paint(object sender, PaintEventArgs e)
        {
            Pen OXY = new Pen(Color.Blue, 2); //перо оси XOY
            Pen setka = new Pen(Color.Gray, 1); //перо масштабной сетки
            Pen figur = new Pen(Color.Red, 3); //перо для рисования фигуры
            Pen figur1 = new Pen(Color.Blue, 3);

            Graphics g = e.Graphics;
            Font txt = new Font("Arial", 14, FontStyle.Bold);
            int count = 0;
            float cx, cy;  //текущие точки плоскости XOY
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.FillRectangle(Brushes.White, 0, 0, XOZ.Size.Width, XOZ.Size.Height);


            sizeX = 50;
            sizeY = 50;
            stepX = 1 / sizeX;
            stepY = 1 / sizeY;

            //рисование масштабной сетки по x
            for (XY.X = centerXOZ.X, count = 0; XY.X < XOZ.Size.Width; XY.X += sizeX, count--)
            {
                g.DrawLine(setka, XY.X, 0, XY.X, XOZ.Size.Height);
                g.DrawString(count.ToString(), txt, Brushes.Black, XY.X - txt.Size, centerXOZ.Y);
            }
            for (XY.X = centerXOZ.X, count = 0; XY.X > 0; XY.X -= sizeX, count++)
            {
                g.DrawLine(setka, XY.X, 0, XY.X, XOZ.Size.Height);
                if (count != 0)
                    g.DrawString(count.ToString(), txt, Brushes.Black, XY.X - 1.5f * txt.Size, centerXOZ.Y);
            }
            //по y
            for (XY.Y = centerXOZ.Y, count = 0; XY.Y > 0; XY.Y -= sizeY, count++)
            {
                g.DrawLine(setka, 0, XY.Y, XOZ.Size.Width, XY.Y);
                g.DrawString(count.ToString(), txt, Brushes.Black, centerXOZ.X - txt.Size, XY.Y);
            }
            for (XY.Y = centerXOZ.Y, count = 0; XY.Y < XOZ.Size.Height; XY.Y += sizeY, count--)
            {
                g.DrawLine(setka, 0, XY.Y, XOZ.Size.Width, XY.Y);
                if (count != 0)
                    g.DrawString(count.ToString(), txt, Brushes.Black, centerXOZ.X - 1.5f * txt.Size, XY.Y);
            }
            //рисование координатных осей
            g.DrawLine(OXY, 0, centerXOZ.Y, XOZ.Size.Width, centerXOZ.Y);
            g.DrawLine(OXY, centerXOZ.X, 0, centerXOZ.X, XOZ.Size.Height);
            g.DrawString("0", txt, Brushes.Black, centerXOZ.X - txt.Size, centerXOZ.Y);


            cx = local_x;
            cy = local_z;
            relX = cx / stepX;
            relY = cy / stepY;

            XY.X = centerXOZ.X - relX;
            XY.Y = centerXOZ.Y - relY;

            g.FillEllipse(Brushes.Green, XY.X - 10, XY.Y - 10, 20, 20);

            for (int i = 0; i < 4; i++) //преобразование точек плоскости в экранные
            {
                cx = points[0, i];
                cy = points[2, i];
                relX = cx / stepX;
                relY = cy / stepY;

                XY.X = centerXOZ.X - relX;
                XY.Y = centerXOZ.Y - relY;

                scr_points[i].X = XY.X;
                scr_points[i].Y = XY.Y;
            }

            g.DrawLine(figur, scr_points[0], scr_points[3]); //рисование фигуры
            g.DrawLine(figur, scr_points[0], scr_points[1]);
            g.DrawLine(figur, scr_points[1], scr_points[2]);
            g.DrawLine(figur, scr_points[2], scr_points[3]);
            g.DrawLine(figur, scr_points[3], scr_points[1]);
            g.DrawLine(figur, scr_points[0], scr_points[2]);

        }

        private void YOZ_Paint(object sender, PaintEventArgs e)
        {
            Pen OXY = new Pen(Color.Blue, 2); //перо оси XOY
            Pen setka = new Pen(Color.Gray, 1); //перо масштабной сетки
            Pen figur = new Pen(Color.Red, 3); //перо для рисования фигуры
            Pen figur1 = new Pen(Color.Blue, 3);
            Graphics g = e.Graphics;
            Font txt = new Font("Arial", 14, FontStyle.Bold);
            int count = 0;
            float cx, cy;  //текущие точки плоскости XOY
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.FillRectangle(Brushes.White, 0, 0, YOZ.Size.Width, YOZ.Size.Height);


            sizeX = 50;
            sizeY = 50;
            stepX = 1 / sizeX;
            stepY = 1 / sizeY;

            //рисование масштабной сетки по x
            for (XY.X = centerYOZ.X, count = 0; XY.X < YOZ.Size.Width; XY.X += sizeX, count++)
            {
                g.DrawLine(setka, XY.X, 0, XY.X, YOZ.Size.Height);
                g.DrawString(count.ToString(), txt, Brushes.Black, XY.X - txt.Size, centerYOZ.Y);
            }
            for (XY.X = centerYOZ.X, count = 0; XY.X > 0; XY.X -= sizeX, count--)
            {
                g.DrawLine(setka, XY.X, 0, XY.X, YOZ.Size.Height);
                if (count != 0)
                    g.DrawString(count.ToString(), txt, Brushes.Black, XY.X - 1.5f * txt.Size, centerYOZ.Y);
            }
            //по y
            for (XY.Y = centerYOZ.Y, count = 0; XY.Y > 0; XY.Y -= sizeY, count++)
            {
                g.DrawLine(setka, 0, XY.Y, YOZ.Size.Width, XY.Y);
                g.DrawString(count.ToString(), txt, Brushes.Black, centerYOZ.X - txt.Size, XY.Y);
            }
            for (XY.Y = centerYOZ.Y, count = 0; XY.Y < YOZ.Size.Height; XY.Y += sizeY, count--)
            {
                g.DrawLine(setka, 0, XY.Y, YOZ.Size.Width, XY.Y);
                if (count != 0)
                    g.DrawString(count.ToString(), txt, Brushes.Black, centerYOZ.X - 1.5f * txt.Size, XY.Y);
            }
            //рисование координатных осей
            g.DrawLine(OXY, 0, centerYOZ.Y, YOZ.Size.Width, centerYOZ.Y);
            g.DrawLine(OXY, centerYOZ.X, 0, centerYOZ.X, YOZ.Size.Height);
            g.DrawString("0", txt, Brushes.Black, centerYOZ.X - txt.Size, centerYOZ.Y);


            cx = local_y;
            cy = local_z;
            relX = cx / stepX;
            relY = cy / stepY;

            XY.X = centerYOZ.X + relX;
            XY.Y = centerYOZ.Y - relY;

            g.FillEllipse(Brushes.Green, XY.X - 10, XY.Y - 10, 20, 20);

            for (int i = 0; i < 4; i++) //преобразование точек плоскости в экранные
            {
                cx = points[1, i];
                cy = points[2, i];
                relX = cx / stepX;
                relY = cy / stepY;

                XY.X = relX + centerYOZ.X;
                XY.Y = centerYOZ.Y - relY;

                scr_points[i].X = XY.X;
                scr_points[i].Y = XY.Y;
            }

            g.DrawLine(figur, scr_points[0], scr_points[3]); //рисование фигуры
            g.DrawLine(figur, scr_points[0], scr_points[1]);
            g.DrawLine(figur, scr_points[1], scr_points[2]);
            g.DrawLine(figur, scr_points[2], scr_points[3]);
            g.DrawLine(figur, scr_points[3], scr_points[1]);
            g.DrawLine(figur, scr_points[0], scr_points[2]);

        }

        #endregion

        #region Матрицы преобразований
        void mashtab(float kx, float ky, float kz)  //масштабирование
        {
            float[,] matr = { { kx, 0, 0, 0 }, { 0, ky, 0, 0 }, { 0, 0, kz, 0 }, { 0, 0, 0, 1 } };

            points = matr_mult(matr, points);
        }

        void mashtab_common(float k)  //масштабирование
        {
            float[,] matr = { { k, 0, 0, 0 }, { 0, k, 0, 0 }, { 0, 0, k, 0 }, { 0, 0, 0, 1 } };

            points = matr_mult(matr, points);
        }


        void perenos(float tx, float ty, float tz)    //перенос
        {
            float[,] matr = { { 1, 0, 0, tx }, { 0, 1, 0, ty }, { 0, 0, 1, tz }, { 0, 0, 0, 1 } };
            points = matr_mult(matr, points);
        }

        void povorot(float ugol, int XYZ)         //поворот на угол относительно оси
        {
            float rad = (float)(ugol * Math.PI / 180);

            float[,] matr = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

            if (XYZ == 1)
            {
                matr[1, 1] = (float)(Math.Cos(rad));
                matr[1, 2] = (float)(-1 * Math.Sin(rad));
                matr[2, 1] = (float)(Math.Sin(rad));
                matr[2, 2] = (float)(Math.Cos(rad));
            }
            if (XYZ == 2)
            {
                matr[0, 0] = (float)(Math.Cos(rad));
                matr[2, 0] = (float)(-1 * Math.Sin(rad));
                matr[0, 2] = (float)(Math.Sin(rad));
                matr[2, 2] = (float)(Math.Cos(rad));

            }
            if (XYZ == 3)
            {
                matr[0, 0] = (float)(Math.Cos(rad));
                matr[0, 1] = (float)(-1 * Math.Sin(rad));
                matr[1, 0] = (float)(Math.Sin(rad));
                matr[1, 1] = (float)(Math.Cos(rad));

            }

            points = matr_mult(matr, points);
        }


        void sdvig(float koeff, int k) //Сдвиг
        {
            float[,] matr = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };


            switch (k)
            {
                case 1:
                    matr[0, 1] = koeff;
                    break;
                case 2:
                    matr[0, 2] = koeff;
                    break;
                case 3:
                    matr[1, 0] = koeff;
                    break;
                case 4:
                    matr[1, 2] = koeff;
                    break;
                case 5:
                    matr[2, 0] = koeff;
                    break;
                case 6:
                    matr[2, 1] = koeff;
                    break;
            }
            points = matr_mult(matr, points);
        }

        void projection ()
        {

            if (Rectangular.Checked)
            {
                if (plXOY.Checked) 
                {
                    float[,] matr = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 0, 1 } };
                    points = matr_mult(matr, points);
                }
                if (plXOZ.Checked)
                {
                    float[,] matr = { { 1, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                    points = matr_mult(matr, points);
                }
                if (plYOZ.Checked)
                {
                    float[,] matr = { { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
                    points = matr_mult(matr, points);
                }
            }
            if (SinglePoint.Checked) 
            { 
                float r = -0.5f;
                if (plXOY.Checked)
                {
                    float[,] matr = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 0, r }, { 0, 0, 0, 1 } };
                    points = matr_mult(matr, points);
                }
                if (plXOZ.Checked)
                {
                    float[,] matr = { { 1, 0, 0, 0 }, { 0, 0, 0, 0 }, { 0, 0, 1, r }, { 0, 0, 0, 1 } };
                    points = matr_mult(matr, points);
                }
                if (plYOZ.Checked)
                {
                    float[,] matr = { { 0, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, r }, { 0, 0, 0, 1 } };
                    points = matr_mult(matr, points);
                }
            }
            if (Kavalie.Checked) 
            {
                float l = 1.0f;
                float alpha = (float)Math.PI / 4.0f;
                float[,] matr = {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                {l * (float)Math.Cos(alpha), l * (float)Math.Sin(alpha), 0, 0 },
                { 0, 0, 0, 1 } };

                points = matr_mult(matr, points);
            };
            if (Kabine.Checked) 
            {
                float l = 1 / 2.0f;
                float alpha = (float)Math.Atan(2);
                float[,] matr = {
                { 1, 0, 0, 0 },
                { 0, 1, 0, 0 },
                {l * (float)Math.Cos(alpha), l * (float)Math.Sin(alpha), 0, 0 },
                { 0, 0, 0, 1 } };

                points = matr_mult(matr, points);
            } 

        }


        float[,] matr_mult(float[,] matr, float[,] points)  //умножение матриц
        {
            int i, j, k;
            float[,] rez = new float[n_matr, vertex_count];

            for (i = 0; i < n_matr; i++)
                for (j = 0; j < vertex_count; j++)
                {
                    rez[i, j] = 0;
                    for (k = 0; k < n_matr; k++)
                        rez[i, j] += matr[i, k] * points[k, j];
                }
            for (i = 0; i < n_matr; i++)
                for (j = 0; j < vertex_count; j++) points[i, j] = rez[i, j];
            return rez;
        }

        #endregion

        #region Масштаб
        private void Mashtab_Click(object sender, EventArgs e)
        {
            float kx, ky, kz;

            try
            {
                kx = float.Parse(txtMashtab_X.Text);
                ky = float.Parse(txtMashtab_Y.Text);
                kz = float.Parse(txtMashtab_Z.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные!");
                return;
            }

            if (kx * ky * kz == 0)
            {
                MessageBox.Show("Коэффициенты должны быть ненулевыми!");
                return;
            }

            mashtab(kx, ky, kz);

            Graph_Update();
            koords_print();

        }

        private void btnMashtab_Common_Click(object sender, EventArgs e)
        {
            float k;
            try
            {
                k = float.Parse(txtMashtab_Common.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные!");
                return;
            }

            if (k == 0)
            {
                MessageBox.Show("Коэффициенты должны быть ненулевыми!");
                return;
            }

            mashtab_common(k);

            Graph_Update();
            koords_print();
        }

        #endregion

        #region Перенос
        private void btnPerenos_Click(object sender, EventArgs e)
        {
            float xx, yy, zz;

            try
            {
                xx = float.Parse(txtPeren_X.Text);
                yy = float.Parse(txtPeren_Y.Text);
                zz = float.Parse(txtPeren_Z.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные!");
                return;
            }

            perenos(xx, yy, zz);

            Graph_Update();

            koords_print();

        }
        #endregion

        #region Поворот
        private void btnRotate_Click(object sender, EventArgs e)
        {
            float ugol;
            int XYZ = 0;

            try
            {
                ugol = float.Parse(txtRotate_ugol.Text);
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные!");
                return;
            }

            if (btnRotate_X.Checked) XYZ = 1;
            if (btnRotate_Y.Checked) XYZ = 2;
            if (btnRotate_Z.Checked) XYZ = 3;

            perenos(-local_x, -local_y, -local_z);
            povorot(ugol, XYZ);
            perenos(local_x, local_y, local_z);

            Graph_Update();
            koords_print();
        }

        #endregion

        #region Сдвиг
        private void btnSdvig_Click(object sender, EventArgs e)
        {
            float koeff;
            int k = 0;
            try
            {
                koeff = float.Parse(txtKoeff_Sdvig.Text);
                
            }
            catch
            {
                MessageBox.Show("Неправильно введены данные!");
                return;
            }
            
            if (btnNapr_X.Checked)
            {
                if (btnNormal_Y.Checked)
                {
                    k = 1;
                    sdvig(koeff, k);
                }
                if (btnNormal_Z.Checked)
                {
                    k = 2;
                    sdvig(koeff, k);
                }
            }
            if (btnNapr_Y.Checked)
            {
                if (btnNormal_X.Checked)
                {
                    k = 3;
                    sdvig(koeff, k);  
                }
                if (btnNormal_Z.Checked)
                {
                    k = 4;
                    sdvig(koeff, k);    
                }
            }
            if (btnNapr_Z.Checked)
            {
                if (btnNormal_X.Checked)
                {
                    k = 5;
                    sdvig(koeff, k);
                }
                if (btnNormal_Y.Checked)
                {
                    k = 6;
                    sdvig(koeff, k);
                }
            }
            Graph_Update();
            koords_print();

        }
        #endregion

        #region Проекция
        private void btnProjection_Click(object sender, EventArgs e)
        {
 
            projection();
            Graph_Update();
            koords_print();
        }
        #endregion

        #region Отражение
        private void MirrorX_Click(object sender, EventArgs e)
        {
            float[,] matr = { { -1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

            points = matr_mult(matr, points);
            Graph_Update();
            koords_print();
        }

        private void MirrorY_Click(object sender, EventArgs e)
        {
            float[,] matr = { { 1, 0, 0, 0 }, { 0, -1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

            points = matr_mult(matr, points);
            Graph_Update();
            koords_print();
        }

        private void MirrorZ_Click(object sender, EventArgs e)
        {
            float[,] matr = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, -1, 0 }, { 0, 0, 0, 1 } };

            points = matr_mult(matr, points);
            Graph_Update();
            koords_print();
        }
        #endregion

        #region Сброс
        private void Default_Click(object sender, EventArgs e)
        {
            
            points[0,0] = 1;
            points[0, 1] = 1;
            points[0, 2] = 0;
            points[0, 3] = 0;
            points[1, 0] = 0;
            points[1, 1] = 1;
            points[1, 2] = 1;
            points[1, 3] = 0;
            points[2, 0] = 0;
            points[2, 1] = 0;
            points[2, 2] = 0;
            points[2, 3] = 1;
            points[3, 0] = 1;
            points[3, 1] = 1;
            points[3, 2] = 1;
            points[3, 3] = 1;

            Graph_Update();
            koords_print();
        }
    }
    #endregion

}
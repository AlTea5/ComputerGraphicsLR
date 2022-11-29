using System.Diagnostics.Contracts;

namespace LB3
{
    public partial class Form1 : Form
    {
        //Объявляем переменные доступные в каждом обработчике события
        private Point PreviousPoint, point; //Точка до перемещения курсора мыши 
                                            //и текущая точка
        private Bitmap bmp;
        private Pen blackPen;
        private Graphics g;
        int contrast = 0;
        int R, G, B;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            blackPen = new Pen(Color.Black, 4); //подготавливаем перо
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // обработчик события нажатия кнопки на мыши
            // записываем в предыдущую точку (PreviousPoint) текущие координаты
            PreviousPoint.X = e.X;
            PreviousPoint.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Обработчик события перемещения мыши по pictuteBox1
            if (e.Button == MouseButtons.Left) //Проверяем нажатие левой кнопка
            { //запоминаем в point текущее положение курсора мыши
                point.X = e.X;
                point.Y = e.Y;
                //соединяем линией предыдущую точку с текущей
                g.DrawLine(blackPen, PreviousPoint, point);
                //текущее положение курсора мыши сохраняем в PreviousPoint
                PreviousPoint.X = point.X;
                PreviousPoint.Y = point.Y;
                pictureBox1.Invalidate();//Принудительно вызываем перерисовку
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //открытие файла
            OpenFileDialog dialog = new OpenFileDialog();
            //задаем расширения файлов
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)| *.bmp; *.jpg; *.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)//вызываем диалоговое окно
            {
                Image image = Image.FromFile(dialog.FileName); //Загружаем в image 
                                                               //изображение из выбранного файла
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                bmp = new Bitmap(image, width, height); //создаем и загружаем из 
                                                        //image изображение в формате bmp
                pictureBox1.Image = bmp; //записываем изображение в формате bmp 
                                         //в pictureBox1
                g = Graphics.FromImage(pictureBox1.Image); //подготавливаем объект
                                                           //Graphics для рисования в pictureBox1
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //сохранение файла
            SaveFileDialog savedialog = new SaveFileDialog();
            //задаем свойства для savedialog
            savedialog.Title = "Сохранить картинку как ...";
            savedialog.OverwritePrompt = true;
            savedialog.CheckPathExists = true;
            savedialog.Filter =
            "Bitmap File(*.bmp)|*.bmp|" +
            "GIF File(*.gif)|*.gif|" +
            "JPEG File(*.jpg)|*.jpg|" +
            "TIF File(*.tif)|*.tif|" +
            "PNG File(*.png)|*.png";
            savedialog.ShowHelp = true;
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                // в fileName записываем полный путь к файлу
                string fileName = savedialog.FileName;
                // Убираем из имени три последних символа (расширение файла)
                string strFilExtn =
                fileName.Remove(0, fileName.Length - 3);
                // Сохраняем файл в нужном формате и с нужным расширением
                switch (strFilExtn)
                {
                    case "bmp":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case "jpg":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case "gif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                    case "tif":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Tiff);
                        break;
                    case "png":
                        bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Png);
                        break;
                    default:
                    break;
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                     R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                     G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                     B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета
                    int Gray = (R = G + B) / 3; // высчитываем среднее
                    Color p = Color.FromArgb(255, Gray, Gray, Gray); //переводим 
                                                                     //int в значение цвета. 255 - показывает степень прозрачности. остальные значения одинаковы
                                                                     //для трех каналов R,G,B
                bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна

        }

        private void button4_Click(object sender, EventArgs e) //яркость+
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                     R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                     G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                     B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    R+=5; G+=5; B+=5;

                    if (B > 255) B = 255; //контролируем переполнение переменных
                    if (G > 255) G = 255;
                    if (R > 255) R = 255;

                    Color p = Color.FromArgb(255, R, G, B); //переводим
                                                                     
                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button5_Click(object sender, EventArgs e) //яркость-
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    R -= 5; G -= 5; B -= 5;

                    //контролируем переполнение переменных
                    if (B < 0) B = 0;
                    if (G < 0) G = 0;
                    if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button6_Click(object sender, EventArgs e)//контраст-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    if (100 - contrast == 0) contrast = 99;

                    R = (R * (100 - contrast) + 128 * contrast) / 100;
                    B = (B * (100 - contrast) + 128 * contrast) / 100;
                    G = (G * (100 - contrast) + 128 * contrast) / 100;


                    if (B > 255) B = 255; //контролируем переполнение переменных
                    else if (B < 0) B = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button7_Click(object sender, EventArgs e)//контраст+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета
  
                    R = (R * 100 - 128 * contrast) / (100 - contrast);
                    B = (B * 100 - 128 * contrast) / (100 - contrast);
                    G = (G * 100 - 128 * contrast) / (100 - contrast);

                    if (B > 255) B = 255; //контролируем переполнение переменных
                    else if (B < 0) B = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button8_Click(object sender, EventArgs e)//ЯркостьR-
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    R -= 5;

                    if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button9_Click(object sender, EventArgs e)//ЯркостьR+
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    R += 5;

                    if (R > 255) R = 255;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button10_Click(object sender, EventArgs e) //ЯркостьG-
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    G -= 5;

                    if (G < 0) G = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button11_Click(object sender, EventArgs e)//ЯркостьG+
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    G += 5;

                    if (G > 255) G = 255;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button12_Click(object sender, EventArgs e)//ЯркостьB-
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    B -= 5;

                    if (B < 0) B = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }


        private void button13_Click(object sender, EventArgs e)//яркость B+
        {
            //циклы для перебора всех пикселей на изображении
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    B += 5;

                    if (B > 255) B = 255;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button14_Click(object sender, EventArgs e)//контраст B+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета
 
                    B = (B * 100 - 128 * contrast) / (100 - contrast);
                    
                    if (B > 255) B = 255; //контролируем переполнение переменных
                    else if (B < 0) B = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button15_Click(object sender, EventArgs e)//Контраст B-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    if (100 - contrast == 0) contrast = 99;

                    B = (B * (100 - contrast) + 128 * contrast) / 100;
                    
                    if (B > 255) B = 255; //контролируем переполнение переменных
                    else if (B < 0) B = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button16_Click(object sender, EventArgs e)//Контраст G+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    G = (G * 100 - 128 * contrast) / (100 - contrast);

                    if (G > 255) G = 255; //контролируем переполнение переменных
                    else if (G < 0) G = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button17_Click(object sender, EventArgs e)//Контраст G-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    if (100 - contrast == 0) contrast = 99;

                    G = (G * (100 - contrast) + 128 * contrast) / 100;

                    if (G > 255) G = 255; //контролируем переполнение переменных
                    else if (G < 0) G = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button18_Click(object sender, EventArgs e)//Контраст R+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    R = (R * 100 - 128 * contrast) / (100 - contrast);

                    if (R > 255) R = 255; //контролируем переполнение переменных
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

        private void button19_Click(object sender, EventArgs e)//Контраст R-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //извлекаем долю красного цвета
                    G = bmp.GetPixel(i, j).G; //извлекаем долю зеленого цвета
                    B = bmp.GetPixel(i, j).B; //извлекаем долю синего цвета

                    if (100 - contrast == 0) contrast = 99;

                    R = (R * (100 - contrast) + 128 * contrast) / 100;

                    if (R > 255) R = 255; //контролируем переполнение переменных
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //переводим

                    bmp.SetPixel(i, j, p); //записываем полученный цвет в точку
                }
            Refresh(); //вызываем функцию перерисовки окна
        }

    }
}

        

        


    

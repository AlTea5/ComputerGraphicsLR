using System.Diagnostics.Contracts;

namespace LB3
{
    public partial class Form1 : Form
    {
        //��������� ���������� ��������� � ������ ����������� �������
        private Point PreviousPoint, point; //����� �� ����������� ������� ���� 
                                            //� ������� �����
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
            blackPen = new Pen(Color.Black, 4); //�������������� ����
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // ���������� ������� ������� ������ �� ����
            // ���������� � ���������� ����� (PreviousPoint) ������� ����������
            PreviousPoint.X = e.X;
            PreviousPoint.Y = e.Y;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //���������� ������� ����������� ���� �� pictuteBox1
            if (e.Button == MouseButtons.Left) //��������� ������� ����� ������
            { //���������� � point ������� ��������� ������� ����
                point.X = e.X;
                point.Y = e.Y;
                //��������� ������ ���������� ����� � �������
                g.DrawLine(blackPen, PreviousPoint, point);
                //������� ��������� ������� ���� ��������� � PreviousPoint
                PreviousPoint.X = point.X;
                PreviousPoint.Y = point.Y;
                pictureBox1.Invalidate();//������������� �������� �����������
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //�������� �����
            OpenFileDialog dialog = new OpenFileDialog();
            //������ ���������� ������
            dialog.Filter = "Image files (*.BMP, *.JPG, *.GIF, *.TIF, *.PNG, *.ICO, *.EMF, *.WMF)| *.bmp; *.jpg; *.gif; *.tif; *.png; *.ico; *.emf; *.wmf";
            if (dialog.ShowDialog() == DialogResult.OK)//�������� ���������� ����
            {
                Image image = Image.FromFile(dialog.FileName); //��������� � image 
                                                               //����������� �� ���������� �����
                int width = image.Width;
                int height = image.Height;
                pictureBox1.Width = width;
                pictureBox1.Height = height;
                bmp = new Bitmap(image, width, height); //������� � ��������� �� 
                                                        //image ����������� � ������� bmp
                pictureBox1.Image = bmp; //���������� ����������� � ������� bmp 
                                         //� pictureBox1
                g = Graphics.FromImage(pictureBox1.Image); //�������������� ������
                                                           //Graphics ��� ��������� � pictureBox1
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //���������� �����
            SaveFileDialog savedialog = new SaveFileDialog();
            //������ �������� ��� savedialog
            savedialog.Title = "��������� �������� ��� ...";
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
                // � fileName ���������� ������ ���� � �����
                string fileName = savedialog.FileName;
                // ������� �� ����� ��� ��������� ������� (���������� �����)
                string strFilExtn =
                fileName.Remove(0, fileName.Length - 3);
                // ��������� ���� � ������ ������� � � ������ �����������
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
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                     R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                     G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                     B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����
                    int Gray = (R = G + B) / 3; // ����������� �������
                    Color p = Color.FromArgb(255, Gray, Gray, Gray); //��������� 
                                                                     //int � �������� �����. 255 - ���������� ������� ������������. ��������� �������� ���������
                                                                     //��� ���� ������� R,G,B
                bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����

        }

        private void button4_Click(object sender, EventArgs e) //�������+
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                     R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                     G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                     B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    R+=5; G+=5; B+=5;

                    if (B > 255) B = 255; //������������ ������������ ����������
                    if (G > 255) G = 255;
                    if (R > 255) R = 255;

                    Color p = Color.FromArgb(255, R, G, B); //���������
                                                                     
                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button5_Click(object sender, EventArgs e) //�������-
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    R -= 5; G -= 5; B -= 5;

                    //������������ ������������ ����������
                    if (B < 0) B = 0;
                    if (G < 0) G = 0;
                    if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button6_Click(object sender, EventArgs e)//��������-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    if (100 - contrast == 0) contrast = 99;

                    R = (R * (100 - contrast) + 128 * contrast) / 100;
                    B = (B * (100 - contrast) + 128 * contrast) / 100;
                    G = (G * (100 - contrast) + 128 * contrast) / 100;


                    if (B > 255) B = 255; //������������ ������������ ����������
                    else if (B < 0) B = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button7_Click(object sender, EventArgs e)//��������+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����
  
                    R = (R * 100 - 128 * contrast) / (100 - contrast);
                    B = (B * 100 - 128 * contrast) / (100 - contrast);
                    G = (G * 100 - 128 * contrast) / (100 - contrast);

                    if (B > 255) B = 255; //������������ ������������ ����������
                    else if (B < 0) B = 0;
                    if (G > 255) G = 255;
                    else if (G < 0) G = 0;
                    if (R > 255) R = 255;
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button8_Click(object sender, EventArgs e)//�������R-
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    R -= 5;

                    if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button9_Click(object sender, EventArgs e)//�������R+
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    R += 5;

                    if (R > 255) R = 255;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button10_Click(object sender, EventArgs e) //�������G-
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    G -= 5;

                    if (G < 0) G = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button11_Click(object sender, EventArgs e)//�������G+
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    G += 5;

                    if (G > 255) G = 255;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button12_Click(object sender, EventArgs e)//�������B-
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    B -= 5;

                    if (B < 0) B = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }


        private void button13_Click(object sender, EventArgs e)//������� B+
        {
            //����� ��� �������� ���� �������� �� �����������
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    B += 5;

                    if (B > 255) B = 255;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button14_Click(object sender, EventArgs e)//�������� B+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����
 
                    B = (B * 100 - 128 * contrast) / (100 - contrast);
                    
                    if (B > 255) B = 255; //������������ ������������ ����������
                    else if (B < 0) B = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button15_Click(object sender, EventArgs e)//�������� B-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    if (100 - contrast == 0) contrast = 99;

                    B = (B * (100 - contrast) + 128 * contrast) / 100;
                    
                    if (B > 255) B = 255; //������������ ������������ ����������
                    else if (B < 0) B = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button16_Click(object sender, EventArgs e)//�������� G+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    G = (G * 100 - 128 * contrast) / (100 - contrast);

                    if (G > 255) G = 255; //������������ ������������ ����������
                    else if (G < 0) G = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button17_Click(object sender, EventArgs e)//�������� G-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    if (100 - contrast == 0) contrast = 99;

                    G = (G * (100 - contrast) + 128 * contrast) / 100;

                    if (G > 255) G = 255; //������������ ������������ ����������
                    else if (G < 0) G = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button18_Click(object sender, EventArgs e)//�������� R+
        {
            contrast += 5;
            if (contrast >= 100) contrast = 99;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    R = (R * 100 - 128 * contrast) / (100 - contrast);

                    if (R > 255) R = 255; //������������ ������������ ����������
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

        private void button19_Click(object sender, EventArgs e)//�������� R-
        {
            contrast -= 5;
            if (contrast < -100) contrast = -100;

            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    R = bmp.GetPixel(i, j).R; //��������� ���� �������� �����
                    G = bmp.GetPixel(i, j).G; //��������� ���� �������� �����
                    B = bmp.GetPixel(i, j).B; //��������� ���� ������ �����

                    if (100 - contrast == 0) contrast = 99;

                    R = (R * (100 - contrast) + 128 * contrast) / 100;

                    if (R > 255) R = 255; //������������ ������������ ����������
                    else if (R < 0) R = 0;

                    Color p = Color.FromArgb(255, R, G, B); //���������

                    bmp.SetPixel(i, j, p); //���������� ���������� ���� � �����
                }
            Refresh(); //�������� ������� ����������� ����
        }

    }
}

        

        


    

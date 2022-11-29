namespace LB1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics g;
        private void Form1_Paint(object sender, PaintEventArgs e)
        { 
            g = CreateGraphics();
            g.Clear(Color.Azure);
            //рисуем тело
            g.DrawEllipse(Pens.Black, 300, 200, 100, 200);
            g.FillEllipse(Brushes.Black, 300, 200, 100, 200);
            //голова
            g.DrawEllipse(Pens.Black, 325, 150, 50, 50);
            g.FillEllipse(Brushes.Black, 325, 150, 50, 50);
            //верхние крылья
            g.DrawEllipse(Pens.BlueViolet, 160, 200, 150, 150);//левое
            g.FillEllipse(Brushes.BlueViolet, 160, 200, 150, 150);
            g.DrawEllipse(Pens.BlueViolet, 390, 200, 150, 150);//правое
            g.FillEllipse(Brushes.BlueViolet, 390, 200, 150, 150);
            //нижние крылья
            g.DrawEllipse(Pens.Blue, 380, 320, 125, 125);//правое
            g.FillEllipse(Brushes.Blue, 380, 320, 125, 125);
            g.DrawEllipse(Pens.Blue, 200, 320, 125, 125);//левое
            g.FillEllipse(Brushes.Blue, 200, 320, 125, 125);
            g.DrawLine(Pens.Black, 325, 165, 290, 100);//левый ус
            g.DrawLine(Pens.Black, 350, 200, 425, 100);//правый ус

            g.DrawRectangle(Pens.Brown, 100, 100, 100, 100);//коробка
            g.FillRectangle(Brushes.Brown, 100, 100, 100, 100);
        }
    }
}
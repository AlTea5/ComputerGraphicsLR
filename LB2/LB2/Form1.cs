namespace LB2
{
    public partial class Form1 : Form
    {
        private int x1, y1, x2, y2;
        private double a, t;
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = ClientSize.Width / 4;
            y1 = ClientSize.Height / 4;
            a = 25;
            t = 0;
            x2 = x1 + (int)(a * (t - Math.Sin(t)));
            y2 = y1 - (int)(a * (1 - Math.Cos(t)));
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(Brushes.Blue, x2, y2, 25, 25);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            t += 0.2;
            x2 = x1 + (int)(a * (t - Math.Sin(t)));
            y2 = y1 - (int)(a * (1 - Math.Cos(t)));
            Invalidate();
        }



    }
}
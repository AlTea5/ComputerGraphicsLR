namespace LB4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Вверх = new System.Windows.Forms.Button();
            this.Вниз = new System.Windows.Forms.Button();
            this.Вправо = new System.Windows.Forms.Button();
            this.Влево = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.Центр = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.OX = new System.Windows.Forms.Button();
            this.OY = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.RotateX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.RotateY = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.RotateAngle = new System.Windows.Forms.TextBox();
            this.Повернуть = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(579, 513);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Вверх
            // 
            this.Вверх.Location = new System.Drawing.Point(720, 12);
            this.Вверх.Name = "Вверх";
            this.Вверх.Size = new System.Drawing.Size(62, 29);
            this.Вверх.TabIndex = 1;
            this.Вверх.Text = "Вверх";
            this.Вверх.UseVisualStyleBackColor = true;
            this.Вверх.Click += new System.EventHandler(this.Вверх_Click);
            // 
            // Вниз
            // 
            this.Вниз.Location = new System.Drawing.Point(720, 82);
            this.Вниз.Name = "Вниз";
            this.Вниз.Size = new System.Drawing.Size(62, 29);
            this.Вниз.TabIndex = 2;
            this.Вниз.Text = "Вниз";
            this.Вниз.UseVisualStyleBackColor = true;
            this.Вниз.Click += new System.EventHandler(this.Вниз_Click);
            // 
            // Вправо
            // 
            this.Вправо.Location = new System.Drawing.Point(799, 49);
            this.Вправо.Name = "Вправо";
            this.Вправо.Size = new System.Drawing.Size(70, 29);
            this.Вправо.TabIndex = 3;
            this.Вправо.Text = "Вправо";
            this.Вправо.UseVisualStyleBackColor = true;
            this.Вправо.Click += new System.EventHandler(this.Вправо_Click);
            // 
            // Влево
            // 
            this.Влево.Location = new System.Drawing.Point(634, 49);
            this.Влево.Name = "Влево";
            this.Влево.Size = new System.Drawing.Size(70, 29);
            this.Влево.TabIndex = 4;
            this.Влево.Text = "Влево";
            this.Влево.UseVisualStyleBackColor = true;
            this.Влево.Click += new System.EventHandler(this.Влево_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(634, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(755, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Y";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(658, 117);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(91, 27);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(778, 117);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(91, 27);
            this.textBox2.TabIndex = 8;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Центр
            // 
            this.Центр.Location = new System.Drawing.Point(710, 49);
            this.Центр.Name = "Центр";
            this.Центр.Size = new System.Drawing.Size(83, 29);
            this.Центр.TabIndex = 9;
            this.Центр.Text = "Центр";
            this.Центр.UseVisualStyleBackColor = true;
            this.Центр.Click += new System.EventHandler(this.Центр_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(590, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Масштаб";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(590, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(110, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Перемещение";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(634, 195);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 20);
            this.label5.TabIndex = 12;
            this.label5.Text = "Х";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(755, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Y";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(657, 195);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(92, 27);
            this.textBox3.TabIndex = 14;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(778, 195);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(91, 27);
            this.textBox4.TabIndex = 15;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(668, 155);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(125, 27);
            this.textBox5.TabIndex = 16;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(590, 237);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Отразить";
            // 
            // OX
            // 
            this.OX.Location = new System.Drawing.Point(668, 233);
            this.OX.Name = "OX";
            this.OX.Size = new System.Drawing.Size(49, 29);
            this.OX.TabIndex = 18;
            this.OX.Text = "ОХ";
            this.OX.UseVisualStyleBackColor = true;
            this.OX.Click += new System.EventHandler(this.OX_Click);
            // 
            // OY
            // 
            this.OY.Location = new System.Drawing.Point(723, 233);
            this.OY.Name = "OY";
            this.OY.Size = new System.Drawing.Size(49, 29);
            this.OY.TabIndex = 19;
            this.OY.Text = "OY";
            this.OY.UseVisualStyleBackColor = true;
            this.OY.Click += new System.EventHandler(this.OY_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(778, 233);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 29);
            this.button1.TabIndex = 20;
            this.button1.Text = "X=-Y";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(834, 233);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(57, 29);
            this.button2.TabIndex = 21;
            this.button2.Text = "X=Y";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(593, 280);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Поворот";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(669, 280);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "Х";
            // 
            // RotateX
            // 
            this.RotateX.Location = new System.Drawing.Point(693, 277);
            this.RotateX.Name = "RotateX";
            this.RotateX.Size = new System.Drawing.Size(79, 27);
            this.RotateX.TabIndex = 24;
            this.RotateX.Text = "0";
            this.RotateX.TextChanged += new System.EventHandler(this.RotateX_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(778, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(17, 20);
            this.label10.TabIndex = 25;
            this.label10.Text = "Y";
            // 
            // RotateY
            // 
            this.RotateY.Location = new System.Drawing.Point(799, 277);
            this.RotateY.Name = "RotateY";
            this.RotateY.Size = new System.Drawing.Size(79, 27);
            this.RotateY.TabIndex = 26;
            this.RotateY.Text = "0";
            this.RotateY.TextChanged += new System.EventHandler(this.RotateY_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(646, 323);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 27;
            this.label11.Text = "Угол";
            // 
            // RotateAngle
            // 
            this.RotateAngle.Location = new System.Drawing.Point(693, 320);
            this.RotateAngle.Name = "RotateAngle";
            this.RotateAngle.Size = new System.Drawing.Size(79, 27);
            this.RotateAngle.TabIndex = 28;
            this.RotateAngle.Text = "0";
            this.RotateAngle.TextChanged += new System.EventHandler(this.RotateAngle_TextChanged);
            // 
            // Повернуть
            // 
            this.Повернуть.Location = new System.Drawing.Point(688, 353);
            this.Повернуть.Name = "Повернуть";
            this.Повернуть.Size = new System.Drawing.Size(94, 29);
            this.Повернуть.TabIndex = 29;
            this.Повернуть.Text = "Повернуть";
            this.Повернуть.UseVisualStyleBackColor = true;
            this.Повернуть.Click += new System.EventHandler(this.Повернуть_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(688, 402);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 30;
            this.button3.Text = "Сбросить";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 522);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.Повернуть);
            this.Controls.Add(this.RotateAngle);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.RotateY);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.RotateX);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.OY);
            this.Controls.Add(this.OX);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Центр);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Влево);
            this.Controls.Add(this.Вправо);
            this.Controls.Add(this.Вниз);
            this.Controls.Add(this.Вверх);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Аффинные преобразования";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Button Вверх;
        private Button Вниз;
        private Button Вправо;
        private Button Влево;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button Центр;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label7;
        private Button OX;
        private Button OY;
        private Button button1;
        private Button button2;
        private Label label8;
        private Label label9;
        private TextBox RotateX;
        private Label label10;
        private TextBox RotateY;
        private Label label11;
        private TextBox RotateAngle;
        private Button Повернуть;
        private Button button3;
    }
}
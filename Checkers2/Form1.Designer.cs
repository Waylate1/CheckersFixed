namespace Checkers2
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
            G = new Panel();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            labelp1 = new Label();
            labelp2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // G
            // 
            G.BackColor = Color.Gray;
            G.Location = new Point(10, 10);
            G.Name = "G";
            G.Size = new Size(484, 484);
            G.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.Red;
            pictureBox1.Location = new Point(500, 444);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(50, 50);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.Blue;
            pictureBox2.Location = new Point(500, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(50, 50);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // labelp1
            // 
            labelp1.AutoSize = true;
            labelp1.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelp1.ForeColor = Color.Blue;
            labelp1.Location = new Point(556, 17);
            labelp1.Name = "labelp1";
            labelp1.Size = new Size(34, 40);
            labelp1.TabIndex = 3;
            labelp1.Text = "0";
            // 
            // labelp2
            // 
            labelp2.AutoSize = true;
            labelp2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelp2.ForeColor = Color.Red;
            labelp2.Location = new Point(556, 449);
            labelp2.Name = "labelp2";
            labelp2.Size = new Size(34, 40);
            labelp2.TabIndex = 4;
            labelp2.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(800, 517);
            Controls.Add(labelp2);
            Controls.Add(labelp1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(G);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Checkers";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel G;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label labelp1;
        private Label labelp2;
    }
}

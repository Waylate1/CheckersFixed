using System.Security.Cryptography.Xml;

namespace Checkers2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int n;
        PictureBox[,] P;
        string color = "r", k = "", B1 = "", B2 = "", k2 = "";
        int blue = 0;
        int red = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            n = 8;
            P = new PictureBox[n, n];
            int left = 2;
            int top = 2;
            Color[] colors = new Color[] { Color.White, Color.Black };
            for (int i = 0; i < n; i++)
            {
                left = 2;
                if (i % 2 == 0) { colors[0] = Color.White; colors[1] = Color.Black; }
                else { colors[0] = Color.Black; colors[1] = Color.White; }
                for (int j = 0; j < n; j++)
                {
                    P[i, j] = new PictureBox();
                    P[i, j].BackColor = colors[(j % 2 == 0) ? 1 : 0];
                    P[i, j].Location = new Point(left, top);
                    P[i, j].Size = new Size(60, 60);
                    left += 60;
                    P[i, j].Name = i + " " + j;
                    if (i < (n / 2) - 1 && P[i, j].BackColor == Color.Black)
                    {
                        P[i, j].Image = Properties.Resources.Red;
                        P[i, j].Name += " r";
                    }
                    else if (i > (n / 2) && P[i, j].BackColor == Color.Black)
                    {
                        P[i, j].Image = Properties.Resources.Blue;
                        P[i, j].Name += " b";
                    }
                    P[i, j].SizeMode = PictureBoxSizeMode.CenterImage;
                    P[i, j].MouseHover += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null)
                        {
                            p.BackColor = Color.FromArgb(255, 64, 64, 64);
                        }
                    };
                    P[i, j].MouseLeave += (sender2, e2) =>
                    {
                        PictureBox p = sender2 as PictureBox;
                        if (p.Image != null)
                        {
                            p.BackColor = Color.Black;
                        }
                    };
                    P[i, j].Click += (sender3, e3) =>
                    {
                        PictureBox p = sender3 as PictureBox;
                        if (p.Image != null)
                        {
                            int c = -1, x, y;
                            F();
                            if (p.Name.Split(' ')[2] == "m")
                            {
                                if (color == "r") color = "b";
                                else color = "r";
                                x = Convert.ToInt32(k.Split(' ')[0]);
                                y = Convert.ToInt32(k.Split(' ')[1]);
                                B1 = "";
                                B2 = "";
                                if (k.Split(' ')[2] == "r")
                                {
                                    p.Image = Properties.Resources.Red;
                                    p.Name = p.Name.Replace("m", "r");
                                }
                                else
                                if (k.Split(' ')[2] == "b")
                                {
                                    p.Image = Properties.Resources.Blue;
                                    p.Name = p.Name.Replace("m", "b");
                                }
                                P[x, y].Image = null;
                                if (k2 != "")
                                {
                                    x = Convert.ToInt32(k2.Split(' ')[0]);
                                    y = Convert.ToInt32(k2.Split(' ')[1]);
                                    P[x, y].Image = null;
                                    if (k2.Split(' ')[2] == "r") red++;
                                    else blue++;
                                    labelp1.Text = blue + "";
                                    labelp2.Text = red + "";
                                    k2 = "";
                                }
                            }
                            else



                            if (p.Name.Split(' ')[2] == color)
                            {
                                x = Convert.ToInt32(p.Name.Split(' ')[0]);
                                y = Convert.ToInt32(p.Name.Split(' ')[1]);
                                k = p.Name;
                                if (p.Name.Split(' ')[2] == "r") c = 1;
                                try
                                {
                                    if (P[x + c, y + 1].Image == null)
                                    {
                                        P[x + c, y + 1].Image = Properties.Resources.Move;
                                        P[x + c, y + 1].Name = (x + c) + " " + (y + 1) + " m";
                                        B1 = (x + c) + " " + (y + 1);
                                    }
                                    else
                                        if (P[x + c, y + 1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x + (c * 2), y + 2].Image == null)
                                    {
                                        P[x + (c * 2), y + 2].Image = Properties.Resources.Move;
                                        P[x + (c * 2), y + 2].Name = (x + (c * 2)) + " " + (y + 2) + " m";
                                        B1 = (x + (c * 2)) + " " + (y + 2);
                                        k2 = (x + c) + " " + (y + 1) + " " + P[x + c, y + 1].Name.Split(' ')[2];
                                    }
                                }
                                catch { }
                                try
                                {
                                if (P[x + c, y - 1].Image == null)
                                {
                                    P[x + c, y - 1].Image = Properties.Resources.Move;
                                    P[x + c, y - 1].Name = (x + c) + " " + (y - 1) + " m";
                                    B2 = (x + c) + " " + (y - 1);
                                }
                                else
                                    if (P[x + c, y - 1].Name.Split(' ')[2] != p.Name.Split(' ')[2] && P[x + (c * 2), y - 2].Image == null)
                                    {
                                        P[x + (c * 2), y - 2].Image = Properties.Resources.Move;
                                        P[x + (c * 2), y - 2].Name = (x + (c * 2)) + " " + (y - 2) + " m";
                                        B2 = (x + x + (c * 2)) + " " + (y - 2);
                                        k2 = (x + c) + " " + (y - 1) + " " + P[x + c, y - 1].Name.Split(' ')[2];
                                    }
                                }
                                catch { }
                            }
                        }
                    };

                    G.Controls.Add(P[i, j]);
                }
                top += 60;
            }
    }
    public void F()
        {
            if (B1 != "")
            {
                int x, y;
                x = Convert.ToInt32(B1.Split(' ')[0]);
                y = Convert.ToInt32(B1.Split(' ')[1]);
                P[x, y].Image = null;
            }
            if (B2 != "")
            {
                int x, y;
                x = Convert.ToInt32(B2.Split(' ')[0]);
                y = Convert.ToInt32(B2.Split(' ')[1]);
                P[x, y].Image = null;
            }
        }
    }
}

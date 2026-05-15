using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Checkers2
{
    public partial class Form1 : Form
    {
        int n = 8;
        PictureBox[,] P;
        string turn = "r";
        int blueCount = 12, redCount = 12;

        PictureBox selectedBox = null;
        List<Point> currentMoves = new List<Point>();
        Dictionary<Point, Point> jumpCaptures = new Dictionary<Point, Point>();

        public Form1()
        {
            InitializeComponent();
            this.Size = new Size(500, 550);
            SetupBoard();
        }

        private void SetupBoard()
        {
            P = new PictureBox[n, n];
            int size = 60;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    P[i, j] = new PictureBox
                    {
                        Size = new Size(size, size),
                        Location = new Point(j * size, i * size),
                        BackColor = (i + j) % 2 == 0 ? Color.White : Color.Black,
                        SizeMode = PictureBoxSizeMode.CenterImage,
                        Tag = new Grid { X = i, Y = j, Piece = "" }
                    };

                    var info = (Grid)P[i, j].Tag;
                    if (P[i, j].BackColor == Color.Black)
                    {
                        if (i < 3) { P[i, j].Image = Properties.Resources.Red; info.Piece = "r"; }
                        else if (i > 4) { P[i, j].Image = Properties.Resources.Blue; info.Piece = "b"; }
                    }
                    P[i, j].Click += Square_Click;
                    this.Controls.Add(P[i, j]);
                }
            }
        }

        private void Square_Click(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;
            Grid info = (Grid)clicked.Tag;

            if (currentMoves.Contains(new Point(info.X, info.Y)))
            {
                ExecuteMove(selectedBox, clicked);
                return;
            }

            if (info.Piece == turn)
            {
                ClearHints();
                selectedBox = clicked;
                ShowValidMoves(info.X, info.Y, info.Piece, info.IsKing);
            }
        }

        private void ShowValidMoves(int x, int y, string pColor, bool isKing)
        {
            List<int> directions = new List<int>();
            if (isKing) { directions.Add(1); directions.Add(-1); }
            else { directions.Add(pColor == "r" ? 1 : -1); }

            int[] dy = { -1, 1 };

            foreach (int dir in directions)
            {
                foreach (int side in dy)
                {
                    int nx = x + dir, ny = y + side;
                    if (IsInside(nx, ny))
                    {
                        var target = (Grid)P[nx, ny].Tag;
                        if (target.Piece == "")
                        {
                            MarkMove(nx, ny);
                        }
                        else if (target.Piece != pColor)
                        {
                            int jx = nx + dir, jy = ny + side;
                            if (IsInside(jx, jy) && ((Grid)P[jx, jy].Tag).Piece == "")
                            {
                                jumpCaptures[new Point(jx, jy)] = new Point(nx, ny);
                                MarkMove(jx, jy);
                            }
                        }
                    }
                }
            }
        }

        private void ExecuteMove(PictureBox from, PictureBox to)
        {
            Grid fromInfo = (Grid)from.Tag;
            Grid toInfo = (Grid)to.Tag;

            string pColor = fromInfo.Piece;
            bool pWasKing = fromInfo.IsKing;
            Image pImg = from.Image;

            Point toPt = new Point(toInfo.X, toInfo.Y);
            if (jumpCaptures.ContainsKey(toPt))
            {
                Point vic = jumpCaptures[toPt];
                var vicInfo = (Grid)P[vic.X, vic.Y].Tag;
                vicInfo.Piece = "";
                P[vic.X, vic.Y].Image = null;

                if (pColor == "r") blueCount--; else redCount--;
            }

            ClearHints();
            from.Image = null;
            fromInfo.Piece = "";
            fromInfo.IsKing = false;

            toInfo.Piece = pColor;
            toInfo.IsKing = pWasKing;

            if ((pColor == "r" && toInfo.X == 7) || (pColor == "b" && toInfo.X == 0))
            {
                toInfo.IsKing = true;
                to.BackColor = Color.Gold;
            }

            to.Image = pImg;

            CheckWin();

            turn = (turn == "r") ? "b" : "r";
            if (turn == "b") RunInstantAI();
        }

        private void RunInstantAI()
        {
            var pieces = new List<PictureBox>();
            foreach (var pb in P) if (((Grid)pb.Tag).Piece == "b") pieces.Add(pb);

            foreach (var pb in pieces.OrderBy(x => Guid.NewGuid()))
            {
                var info = (Grid)pb.Tag;
                selectedBox = pb;
                ShowValidMoves(info.X, info.Y, "b", info.IsKing);
                if (currentMoves.Count > 0)
                {
                    Point move = currentMoves.OrderByDescending(m => jumpCaptures.ContainsKey(m)).First();
                    ExecuteMove(pb, P[move.X, move.Y]);
                    return;
                }
            }
        }

        private void MarkMove(int x, int y)
        {
            P[x, y].Image = Properties.Resources.Move;
            currentMoves.Add(new Point(x, y));
        }

        private void ClearHints()
        {
            foreach (var pt in currentMoves)
                if (((Grid)P[pt.X, pt.Y].Tag).Piece == "") P[pt.X, pt.Y].Image = null;

            currentMoves.Clear();
            jumpCaptures.Clear();
        }

        private bool IsInside(int x, int y) => x >= 0 && x < n && y >= 0 && y < n;

        private void CheckWin()
        {
            if (redCount <= 0) MessageBox.Show("AI Wins!");
            else if (blueCount <= 0) MessageBox.Show("You Win!");
        }
    }

    public class Grid
    {
        public int X, Y;
        public string Piece;
        public bool IsKing = false;
    }
}
using NUnit.Framework;
using System.Drawing;
using System.Windows.Forms;
using Checkers2;

namespace CheckersTest
{
    [TestFixture]
    public class CheckersTests
    {
        private Form1 gameForm;

        [SetUp]
        public void Setup()
        {
            gameForm = new Form1();
        }

        [TearDown]
        public void TearDown()
        {
            gameForm.Dispose();
        }

        [Test]
        public void SetupBoard_ShouldInitializeCorrectNumberOfInitialPieces()
        {
            var fieldInfo = typeof(Form1).GetField("P", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            PictureBox[,] board = (PictureBox[,])fieldInfo.GetValue(gameForm);

            int redPieces = 0;
            int bluePieces = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Grid info = (Grid)board[i, j].Tag;
                    if (info.Piece == "red") redPieces++;
                    if (info.Piece == "blue") bluePieces++;
                }
            }

            Assert.That(redPieces, Is.EqualTo(12), "Red side should start with 12 pieces.");
            Assert.That(bluePieces, Is.EqualTo(12), "Blue side should start with 12 pieces.");
        }

    }
}
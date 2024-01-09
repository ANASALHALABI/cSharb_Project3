using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }

        private void promptLabel_Click(object sender, EventArgs e)
        {

        }
        private int secretNumber;
        private bool gameActive;



        private void InitializeGame()
        {
            Random random = new Random();
            secretNumber = random.Next(1, 101);
            gameActive = true;

            promptLabel.Text = "I have a number between 1 and 100 -- can you guess my number?";
            resultLabel.Text = "";
            guessTextBox.Text = "";
            guessTextBox.Enabled = true;
            b1.Enabled = true;
            this.BackColor = DefaultBackColor;
        }

        private void b1_Click(object sender, EventArgs e)
        {
            if (!gameActive)
            {
                MessageBox.Show("Please click 'Play Again' to start a new game.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                int userGuess = int.Parse(guessTextBox.Text);
                CheckGuess(userGuess);
                guessTextBox.Text = ""; 
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CheckGuess(int userGuess)
        {
            int difference = Math.Abs(secretNumber - userGuess);

            if (difference == 0)
            {
                MessageBox.Show("Congratulations! You guessed the correct number.", "Game Over", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.BackColor = DefaultBackColor;
                gameActive = false;
            }
            else
            {   
                this.BackColor = difference > 25 ? Color.Red : Color.Blue;
                resultLabel.Text = difference > 25 ? "Warmer" : "Colder";

            }
        }

        

        private void guessTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void b2_Click_1(object sender, EventArgs e)
        {
            this.BackColor = DefaultBackColor;
            guessTextBox.Text = "";
            InitializeGame();
        }
    }

}

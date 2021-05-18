using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public bool isWin(int[] you, int[] opponent)
        {
            if (you[0] > opponent[0]) return true;
            if (you[0] == opponent[0] && you[1] >= opponent[1]) return true;
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Player opponent = new Player();
            int[] opponent_dices = opponent.cheat_roll();
            label1.Text = Convert.ToString(opponent_dices[0]);
            label2.Text = Convert.ToString(opponent_dices[1]);
            label3.Text = Convert.ToString(opponent_dices[2]);
            label4.Text = Convert.ToString(opponent_dices[3]);
            label5.Text = Convert.ToString(opponent_dices[4]);

            Player you = new Player();
            int[] your_dices = you.common_roll();
            label6.Text = Convert.ToString(your_dices[0]);
            label7.Text = Convert.ToString(your_dices[1]);
            label8.Text = Convert.ToString(your_dices[2]);
            label9.Text = Convert.ToString(your_dices[3]);
            label10.Text = Convert.ToString(your_dices[4]);

            bool win = isWin(you.check_combination(), opponent.check_combination());
            if (win) label11.Text = "You won";
            if (!win) label11.Text = "You lost";
        }
    }
}

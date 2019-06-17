using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BigBoatGame.Screens
{
    public partial class EndScreen : UserControl
    {
        Score s;
        char c = 'A';
        int boxNumber = 0;
        public EndScreen()
        {
            InitializeComponent();
            OnStart();
        }

        private void OnStart()
        {
            s = new Score();
            s.number = GameForm.score;
            scoreLabel.Text = "Score: " + s.number;
            msgLabel.Text = GameForm.msg;
            if (GameForm.vs)
            {
                oneLabel.Visible = false;
                twoLabel.Visible = false;
                threeLabel.Visible = false;
                carrierBox.Visible = false;

            }
            if (GameForm.yank)
            {
                carrierBox.Image = Properties.Resources.Lexington;
            }
        }
       
        private void selected(Label label)
        {

            label.BackColor = Color.DeepPink;
            label.ForeColor = Color.Transparent;
            label.Text = "" + c;
        }


        private void EndScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (GameForm.vs)
            {
                boxNumber = 2;
            }

            if (boxNumber < 3)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        if (c != 'Z')
                        {
                            c++;
                        }
                        break;

                    case Keys.W:
                        if (c != 'A')
                        {
                            c--;
                        }
                        break;
                    case Keys.Up:
                        if (c != 'A')
                        {
                            c--;
                        }
                        break;
                    case Keys.Down:
                        if (c != 'Z')
                        {
                            c++;
                        }
                        break;

                    case Keys.Right:
                        boxNumber++;
                        c = 'A';
                        twoLabel.BackColor = Color.Transparent;
                        twoLabel.ForeColor = Color.Black;
                        oneLabel.BackColor = Color.Transparent;
                        oneLabel.ForeColor = Color.Black;
                        threeLabel.BackColor = Color.Transparent;
                        threeLabel.ForeColor = Color.Black;
                        break;
                    case Keys.Left:
                        boxNumber--;
                        c = 'A';
                        twoLabel.BackColor = Color.Transparent;
                        twoLabel.ForeColor = Color.Black;
                        oneLabel.BackColor = Color.Transparent;
                        oneLabel.ForeColor = Color.Black;
                        threeLabel.BackColor = Color.Transparent;
                        threeLabel.ForeColor = Color.Black;
                        break;

                        //case Keys.Escape:
                        //    GameForm.ChangeScreen(this, "MenuScreen");
                        //    break;
                }
                switch (boxNumber)
                {
                    case 0:
                        selected(oneLabel);
                        break;
                    case 1:
                        selected(twoLabel);
                        break;
                    case 2:
                        selected(threeLabel);
                        break;
                    case 3:
                        s.name = oneLabel.Text + twoLabel.Text + threeLabel.Text;
                        GameForm.scores.Add(s);
                        GameForm.ChangeScreen(this, "HighScreen");
                        break;

                }
            }
        }

       
    }
}

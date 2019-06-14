using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BigBoatGame
{
    public partial class GameForm : Form
    {
        public static string msg;
        public static List<Score> scores;
        public static int score;
        XmlReader reader; 
        public static bool yank = true;
        public static bool vs = false;
        public GameForm()
        {
            InitializeComponent();
            OnStart();
            
        }
        public void OnStart()
        {
         
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            Form f = this.FindForm();
            f.Controls.Remove(this);
            UserControl ns = null;
            ns = new Screens.MenuScreen();
            f.Controls.Add(ns);
            ns.Location = new Point((f.Width - ns.Width) / 2, ((f.Height - ns.Height) / 2) - 30);
            ns.Focus();
            XmlRead();
        }
        public void XmlRead()
        {
            try {

                scores = new List<Score>();
                reader = XmlReader.Create("Resources/HighScores.xml");

                while (reader.Read())
                {
                    if (reader.Name == "player")
                    {
                        // create a score object
                        Score s = new Score();
                        
                        // fill score object with required data
                        s.number = Convert.ToInt16(reader.GetAttribute("number"));
                        s.name = reader.GetAttribute("name");

                        scores.Add(s);
                    }

                }
                reader.Close();
            }
            catch { }
        }
        
    

        public static void ChangeScreen(UserControl current, string next)
        {
            //f is set to the form that the current control is on
            Form f = current.FindForm();
            if (next != "PauseScreen")
            {
                f.Controls.Remove(current);
            }
            UserControl ns = null;

            //switches screen
            switch (next)
            {
                case "MenuScreen":
                    ns = new Screens.MenuScreen();
                    break;
                case "GameScreen":
                    ns = new Screens.GameScreen();
                    break;
                case "HighScreen":
                    ns = new Screens.HighScreen();
                    break;
                case "HowScreen":
                    ns = new Screens.HowScreen();
                    break;   
                case "EndScreen":
                     ns = new Screens.EndScreen();
                    break;
            }
            //centres on the screen
            ns.Location = new Point((f.Width - ns.Width) / 2, ((f.Height - ns.Height) / 2) - 30);

            f.Controls.Add(ns);
            ns.Focus();
        }



    }
}

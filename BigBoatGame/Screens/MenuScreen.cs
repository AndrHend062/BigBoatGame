﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace BigBoatGame.Screens
{
    public partial class MenuScreen : UserControl
    {
        public XmlWriter writer;
        public MenuScreen()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            GameForm.ChangeScreen(this, "GameScreen");
        }

        private void highscoreButton_Click(object sender, EventArgs e)
        {
            GameForm.ChangeScreen(this, "HighScreen");
        }

        private void howButton_Click(object sender, EventArgs e)
        {
            GameForm.ChangeScreen(this, "HowScreen");
        }

        private void flipperButton_Click(object sender, EventArgs e)
        {
            GameForm.yank = !GameForm.yank;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            writer = XmlWriter.Create("HighScores.xml"); // make reader
            writer.WriteStartElement("HighScores");

            for(int i = 0; i < 10; i++)
            { 

                //Write sub-elements
                writer.WriteStartElement("score");
                writer.WriteAttributeString("name", GameForm.scores[i].name);
                writer.WriteAttributeString("number", GameForm.scores[i].number);
                writer.WriteEndElement();
            }
            // end the element
            writer.WriteEndElement();
            // end the root element

            //Write the XML to file and close the writer
            writer.Close();


            Application.Exit();
        }
    }
}

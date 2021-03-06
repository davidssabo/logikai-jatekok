﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace logikai_jatekok
{
    public partial class MinesweeperForm : Form
    {
        static int width = 18; static int height = 14;
        int mineChance = 5; // chance-> 1 : minechance (def. 4)
        int nonMineRadius = 3; //def 4
        int revealedOnDefault = 0;
        int score = 0;

        //(42, 145, 42); //green1
        //(51, 181, 51); //green2
        //(181, 137, 83); //brown1
        //(166, 126, 78); //brown2

        Field[,] fields = new Field[width, height];

        Label scoreLb = new Label();

        bool isFirstClick = true;
        bool isGameOver = false;

        public MinesweeperForm()
        {
            this.Icon = Properties.Resources.flag;

            InitializeComponent();

            SetUpFields();

            #region --scorelabel
            scoreLb.AutoSize = true;
            scoreLb.Location = new Point(607,80);
            scoreLb.Text = " Pontok: 0p";
            scoreLb.Font = new Font("Lucida Sans Unicode", 14);
            Controls.Add(scoreLb);
            #endregion

            SetUpInfo();

            Timer();
        }



        private async Task Timer()
        {

            #region --timer
            Label timer = new Label();
            timer.Location = new Point(600, 30);
            timer.Font = new Font("Lucida Sans Unicode", 25);
            timer.AutoSize = true;
            Controls.Add(timer);
            #endregion

            int sec = 0;
            while (!isGameOver)
            {
                timer.Text = $" {(sec / 60).ToString("D2")}:{(sec % 60).ToString("D2")}";
                await Task.Delay(1000);
                sec++;
            }
        }

        private void ShowHowToPlay(object sender, EventArgs args)
        {
            MessageBox.Show(this, "Játék célja:\n\nFedd fel az összes nem aknát rejtő mezőt, anélkül, hogy aknát fednél fel! Akna-felfedés esetén a játék véget ér!\n\nA mezőn megjelenő szám, a mező közvetlen szomszédságában lévő aknák számát mutatja. Ezek alapján következtess!\n\n\nIrányítás:\n\n Mező felfedés: BAL-KLIKK (üres mezőn)\n\n Zászló lerakás: JOBB-KLIKK (üres mezőn)\n\n Zaszló felvevés: JOBB-KLIKK vagy BAL-KLIKK (zászlós mezőn)", "Hogy kell játszani?",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void SetUpInfo()
        {
            Label info = new Label();
            info.Location = new Point(590, 400);
            info.Font = new Font("Ariel", 12);
            info.Text = "  Hogy kell játszani?";
            info.Cursor = Cursors.Hand;
            info.AutoSize = true;
            info.Click += new EventHandler(ShowHowToPlay);
            info.Padding = new Padding(5);
            info.BorderStyle = BorderStyle.Fixed3D;
            Controls.Add(info);
        }



        private void Field_Click(object sender, MouseEventArgs args)
        {
            Label label = (Label)sender;
            string[] coords = label.Name.Split('.');
            int x = int.Parse(coords[0]); int y = int.Parse(coords[1]);

            switch (args.Button)
            {
                case MouseButtons.Left:
                    if (isFirstClick)
                    {
                        GenerateMines(x, y);
                        DiscoverNeighbours(x, y);
                        CountDefaultRevealedFields();
                        isFirstClick = false;
                    }
                    else if (!fields[x, y].isFlaged) DiscoverNeighbours(x, y);
                    else UnFlagField(x, y);

                    ShowScore();
                    break;

                case MouseButtons.Right:
                    if (!isFirstClick && !fields[x, y].isRevealed)
                    {
                        if (!fields[x, y].isFlaged) FlagField(x, y);
                        else UnFlagField(x, y);
                    }
                    break;
            }
        }

        private void CountDefaultRevealedFields()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (fields[x, y].isRevealed) revealedOnDefault++;
                }
            }
        }

        private void ShowScore()
        {
            int currentRevealed = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (fields[x, y].isRevealed && fields[x, y].minesNearby != -1) currentRevealed++;
                }
            }
            score = currentRevealed - revealedOnDefault;
            scoreLb.Text = $" Pontok: {score}p";
        }
        
        private void FlagField(int x, int y)
        {
            fields[x, y].panel.BackColor = Color.Transparent;

            if ((x + y) % 2 == 0) fields[x, y].panel.BackgroundImage = Properties.Resources.flag0;
            else fields[x, y].panel.BackgroundImage = Properties.Resources.flag1;

            fields[x, y].panel.BackgroundImageLayout = ImageLayout.Stretch;
            fields[x, y].isFlaged = true;
        }

        private void UnFlagField(int x, int y)
        {
            fields[x, y].panel.BackgroundImage = null;

            if ((x + y) % 2 == 0) fields[x, y].panel.BackColor = Color.FromArgb(42, 145, 42); //green1
            else fields[x, y].panel.BackColor = Color.FromArgb(51, 181, 51); //green2

            fields[x, y].isFlaged = false;
        }

        private void DiscoverNeighbours(int x, int y)
        {
            if(fields[x, y].minesNearby == 0)
            {
                MakeFieldBrown(x, y);

                fields[x, y].isRevealed = true;
                fields[x, y].panel.Controls[0].Cursor = Cursors.Arrow;

                for (int i = -1; i < 2; i++)
                {
                    for (int j = -1; j < 2; j++)
                    {
                        if (i + x < width && j + y < height && i + x > -1 && j + y > -1 && !(i==0 && j==0))
                        {
                            if (!fields[i + x, j + y].isRevealed)
                            {
                                if (fields[i + x, j + y].minesNearby == 0 && !fields[i + x, j + y].isFlaged) DiscoverNeighbours(i + x, j + y);
                                else RevealNotNullField(i + x, j + y);
                            }
                        }
                    }
                }
            }
            else if (fields[x, y].minesNearby == -1) //if fields[x, y] is a Mine
            {
                Gameover(x,y);
            }
            else //fields[x, y].minesNearby != 0
            {
                RevealNotNullField(x, y);
            }            
        }

        private void MakeFieldBrown(int x, int y)
        {
            if ((x + y) % 2 == 0) fields[x, y].panel.BackColor = Color.FromArgb(181, 137, 83); //brown1
            else fields[x, y].panel.BackColor = Color.FromArgb(166, 126, 78); //brown2
        }

        private void RevealNotNullField(int x, int y)
        {
            if(!fields[x, y].isFlaged)
            {
                MakeFieldBrown(x, y);

                fields[x, y].isRevealed = true;
                fields[x, y].panel.Controls[0].Cursor = Cursors.Arrow;

                Color fieldColor = new Color();

                switch (fields[x, y].minesNearby)
                {
                    case 1:
                        fieldColor = Color.Blue;
                        break;

                    case 2:
                        fieldColor = Color.Green;
                        break;

                    case 3:
                        fieldColor = Color.Red;
                        break;

                    case 4:
                        fieldColor = Color.Purple;
                        break;

                    case 5:
                        fieldColor = Color.Pink;
                        break;

                    default:
                        fieldColor = Color.Yellow;
                        break;
                }

                fields[x, y].panel.Controls[0].ForeColor = fieldColor;
                fields[x, y].panel.Controls[0].Text = $"{fields[x, y].minesNearby}";
            }
        }


        
        private async Task ExplodeMines()
        {
            List<Field> mines = new List<Field>();
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (fields[i, j].minesNearby == -1 && !fields[i, j].isRevealed) mines.Add(fields[i, j]);
                }
            }

            Random random = new Random();
            while (mines.Count() != 0)
            {
                int ran = random.Next(0, mines.Count());

                string[] coords = mines[ran].panel.Controls[0].Name.Split('.');

                await Task.Delay(500);

                RevealMine(int.Parse(coords[0]), int.Parse(coords[1]));

                mines.RemoveAt(ran);
            }
        }

        private async Task RevealMine(int x, int y)
        {
            if(fields[x, y].isFlaged)
            {
                fields[x, y].panel.BackColor = Color.Transparent;

                fields[x, y].panel.BackgroundImage = Properties.Resources.flag2;

                fields[x, y].panel.BackgroundImageLayout = ImageLayout.Stretch;
            }
            else fields[x, y].panel.BackColor = Color.White;

            fields[x, y].isRevealed = true;

            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (!(i == 0 && j == 0)) ExplosionWave(x, y, i, j);
                }
            }
        }

        private async Task ExplosionWave(int x, int y, int addX, int addY)
        {
            x += addX; y += addY;

            while (x < width && y < height && x > -1 && y > -1)
            {                
                Color origColor = fields[x, y].panel.BackColor;

                fields[x, y].panel.BackColor = Color.Yellow;

                await Task.Delay(18);

                fields[x, y].panel.BackColor = origColor;

                x += addX; y += addY;
            }
        }



        private void SetUpFields()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    Panel panel = new Panel();
                    panel.Location = new Point(20 + i * 30, 20 + j * 30);
                    panel.Size = new Size(25, 25);
                    if ((i + j) % 2 == 0) panel.BackColor = Color.FromArgb(42, 145, 42); //green1
                    else panel.BackColor = Color.FromArgb(51, 181, 51); //green2

                    Label lb = new Label();
                    lb.Font = new Font("Ariel", 17, FontStyle.Bold);
                    lb.Name = $"{i}.{j}";
                    lb.Cursor = Cursors.Hand;
                    lb.MouseClick += new MouseEventHandler(Field_Click);
                    panel.Controls.Add(lb);

                    Controls.Add(panel);

                    fields[i, j].panel = panel;
                    fields[i, j].isRevealed = false;
                    fields[i, j].minesNearby = 0;
                }
            }
        }

        private void GenerateMines(int x, int y)
        {
            Random random = new Random();

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (random.Next(0, mineChance) == 0)
                    {
                        if(Math.Sqrt(Math.Pow(x-i,2)+ Math.Pow(y - j, 2)) > nonMineRadius) fields[i, j].minesNearby = -1;
                    }

                    if (fields[i, j].minesNearby == -1) IncreaseNeighbours(i, j);
                }
            }
        }

        private void IncreaseNeighbours(int i, int j)
        {
            for (int y = -1; y < 2; y++)
            {
                for (int x = -1; x < 2; x++)
                {
                    if (i + x < width && j + y < height && i + x > -1 && j + y > -1)
                    {
                        if (fields[i + x, j + y].minesNearby != -1) fields[i + x, j + y].minesNearby += 1;
                    }
                }
            }
        }



        private async Task Gameover(int x, int y)
        {
            isGameOver = true;  // stops the timer
            RevealMine(x, y);

            SaveScore();
            DisableBoard();
            GameOverLabel();
            
            ExitButton();
            PlayAgainButton();

            ExplodeMines();
        }

        private async Task DisableBoard()
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    fields[x, y].panel.Controls[0].Enabled = false;
                }
            }
        }

        private async Task SaveScore()
        {
            Program.database.SaveData(Program.player, GameTypes.minesweeper, score);
        }

        private void GameOverLabel()
        {
            Label over = new Label();
            over.Location = new Point(575, 180);
            over.Font = new Font("Bodoni MT Black", 20);
            over.Text = "JÁTÉK VÉGE";
            over.ForeColor = Color.DarkRed;
            over.AutoSize = true;
            Controls.Add(over);
        }

        private void ExitButton()
        {
            Button exit = new Button();
            exit.Location = new Point(580, 230);
            exit.Font = new Font("Ariel", 15);
            exit.Text = "Kilépés";
            exit.ForeColor = Color.DarkRed;
            exit.Padding = new Padding(5);
            exit.Click += new EventHandler(ExitButton_Click);
            exit.AutoSize = true;
            Controls.Add(exit);
        }

        private void ExitButton_Click(object sender, EventArgs args)
        {
            this.Close();
        }

        private void PlayAgainButton()
        {
            Button againB = new Button();
            againB.Location = new Point(700, 230);
            againB.Font = new Font("Ariel", 15);
            againB.Text = "Újra";
            againB.ForeColor = Color.DarkRed;
            againB.Padding = new Padding(5);
            againB.Click += new EventHandler(PlayAgainButton_Click);
            againB.AutoSize = true;
            Controls.Add(againB);
        }

        private void PlayAgainButton_Click(object sender, EventArgs args)
        {
            Program.windowIndex = Windows.MinesweeperWindow;

            this.Close();
        }
    }
}

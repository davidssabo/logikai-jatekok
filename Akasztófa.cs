using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace logikai_jatekok
{
    public partial class Akaszt�fa : Form
    {
        public Akaszt�fa()
        {
            InitializeComponent();
            Beolvas�s();
            Sz�Kiv�laszt();
            GombHozz�ad();
            LabelsHozz�ad();
        }
        public string[] szavak;
        public string[] alapbetuk = {"A","�","B","C","D","E","�","F","G","H","I","�","J","K","L","M","N","O",
            "�","�","�","P","Q","R","S","T","U","�","�","�","V","W","X","Y","Z"};
        public string aktszo;
        public List<Label> labels = new List<Label>();
        public List<string> szerepelt = new List<string>();
        public Random random = new Random();
        public int pontszam;
        public enum HangState
        {
            �res, Alap, F�ggOszlop, VizOszlop, K�t�l, Fej, Test, BalKar, BalK�z, JobbKar, JobbK�z, BalL�b, Jobbl�b
        }
        public HangState AktHangState = HangState.�res;
        public HangState HangStateSize = HangState.Jobbl�b;
        public void Beolvas�s()
        {
            string szavak2 = Properties.Resources.szavak;
            szavak = szavak2.Split(new[] { Environment.NewLine }, StringSplitOptions.None );
        }
        private void Sz�Kiv�laszt()
        {
            int r = random.Next(0, szavak.Length);
            aktszo = szavak[r];
            if (!szerepelt.Contains(aktszo))
            {
                szerepelt.Add(aktszo);
            }
        }
        private void GombHozz�ad()
        {
            for (int i = 0; i < alapbetuk.Length; i++)
            {
                Button b = new Button();
                b.Text = alapbetuk[i];
                b.Parent = flp_buttons;
                b.Font = new Font(FontFamily.GenericSansSerif, 14, FontStyle.Bold);
                b.Size = new Size(30, 30);
                b.BackColor = Color.Lavender;
                b.Click += B_Click;
            }
        }
        private void LabelsHozz�ad()
        {
            gb_kitalalndo.Controls.Clear();
            labels.Clear();
            char[] letters = aktszo.ToCharArray();
            int hossz = letters.Length;
            int hely = gb_kitalalndo.Width / hossz;
            for (int i = 0; i < hossz; i++)
            {
                Label l = new Label();
                l.Text = " __ ";
                l.Location = new Point(10 + i * hely, gb_kitalalndo.Height - 30);
                l.Parent = gb_kitalalndo;
                l.BringToFront();
                labels.Add(l);
            }
            l_szohossz.Text = "A sz� hossza: " + Convert.ToString(hossz);
            l_hibalehetoseg.Text = "Hibalehet�s�g: " + Convert.ToInt32(HangStateSize);
        }
        private void B_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            char betuclicked = b.Text.ToCharArray()[0];
            b.Enabled = false;

            if ((aktszo = aktszo.ToUpper()).Contains(betuclicked))
            {
                l_info.Text = "Fantasztikus!";
                l_info.ForeColor = Color.DarkGreen;
                char[] betuk = aktszo.ToCharArray();
                for (int i = 0; i < aktszo.Length; i++)
                {
                    if (betuk[i] == betuclicked)
                    {
                        labels[i].Text = betuclicked.ToString();
                        labels[i].Font = new Font(FontFamily.GenericSansSerif, 14);
                    }
                }
                if (labels.Where(x => x.Text.Equals(" __ ")).Any())
                {
                    return;
                }
                if ((int)AktHangState >= 10) 
                {
                    pontszam += 2;
                }
                if ((int)AktHangState >= 7 && (int)AktHangState < 10)
                {
                    pontszam += 4;
                }
                if ((int)AktHangState >= 4 && (int)AktHangState < 7)
                {
                    pontszam += 6;
                }
                if ((int)AktHangState >= 1 && (int)AktHangState < 4)
                {
                    pontszam += 8;
                }
                l_info.Text = "Gratul�lok! Nyert�l! :)";
                Program.database.SaveData(Program.player, GameTypes.hangman, pontszam);
                l_info.ForeColor = Color.DarkGreen;
                flp_buttons.Enabled = false;
                flp_word.Enabled = false;
            }
            else
            {
                l_info.Text = "Nem j�!";
                l_info.ForeColor = Color.DarkRed;
                Graphics g = this.CreateGraphics();
                Pen p = new Pen(Color.DarkBlue, 5);
                Pen v = new Pen(Color.DarkBlue, 2);
                if (AktHangState != HangState.Jobbl�b)
                {
                    AktHangState++;
                    if (AktHangState >= HangState.Alap)
                    {
                        //Alap
                        g.DrawLine(p, 600, 350, 775, 350);
                    }
                    if (AktHangState >= HangState.F�ggOszlop)
                    {
                        //F�gg�leges oszlop
                        g.DrawLine(p, 750, 350, 750, 50);
                    }
                    if (AktHangState >= HangState.VizOszlop)
                    {
                        //V�zszintes oszlop
                        g.DrawLine(p, 750, 50, 625, 50);
                    }
                    if (AktHangState >= HangState.K�t�l)
                    {
                        //K�t�l
                        g.DrawLine(p, 650, 50, 650, 100);
                    }
                    if (AktHangState >= HangState.Fej)
                    {
                        //Fej
                        Rectangle fej = new Rectangle(633, 100, 35, 35);
                        g.DrawEllipse(p, fej);
                        Rectangle szem1 = new Rectangle(645, 115, 1, 1);
                        g.DrawEllipse(p, szem1);
                        Rectangle szem2 = new Rectangle(655, 115, 1, 1);
                        g.DrawEllipse(p, szem2);
                        g.DrawLine(v, 645, 125, 656, 125);
                    }
                    if (AktHangState >= HangState.Test)
                    {
                        //Test
                        g.DrawLine(p, 650, 135, 650, 210);
                    }
                    if (AktHangState >= HangState.BalKar)
                    {
                        //Bal kar
                        g.DrawLine(p, 650, 135, 630, 190);
                    }
                    if (AktHangState >= HangState.BalK�z)
                    {
                        //Bal k�z
                        Rectangle bkez = new Rectangle(627, 190, 5, 5);
                        g.DrawEllipse(p, bkez);
                    }
                    if (AktHangState >= HangState.JobbKar)
                    {
                        //Jobb kar
                        g.DrawLine(p, 650, 135, 670, 190);
                    }
                    if (AktHangState >= HangState.JobbK�z)
                    {
                        //Jobb k�z
                        Rectangle jkez = new Rectangle(668, 190, 5, 5);
                        g.DrawEllipse(p, jkez);
                    }
                    if (AktHangState >= HangState.BalL�b)
                    {
                        //Bal l�b
                        g.DrawLine(p, 650, 208, 630, 270);
                    }
                    if (AktHangState >= HangState.Jobbl�b)
                    {
                        //Jobb l�b
                        g.DrawLine(p, 650, 208, 670, 270);
                    }
                }
                l_hibalehetoseg.Text = "Hibalehet�s�g: " + Convert.ToInt32(HangStateSize - AktHangState);
                tb_rosszvalaszok.Text += betuclicked.ToString() + ", ";
                if (AktHangState == HangState.Jobbl�b)
                {
                    l_info.Text = "Vesztett�l!";
                    Program.database.SaveData(Program.player, GameTypes.hangman, pontszam);
                    l_info.ForeColor = Color.DarkRed;
                    flp_buttons.Enabled = false;
                    flp_word.Enabled = false;

                    for (int i = 0; i < aktszo.Length; i++)
                    {
                        if (labels[i].Text.Equals(" __ "))
                        {
                            labels[i].Text = aktszo[i].ToString();
                            labels[i].ForeColor = Color.DarkBlue;
                            labels[i].Font = new Font(FontFamily.GenericSansSerif, 14);
                        }
                    }
                }
            }
        }
        private void b_ujjatek_Click(object sender, EventArgs e)
        {
            flp_buttons.Controls.Clear();
            l_info.Text = " - ";
            tb_rosszvalaszok.Clear();
            flp_buttons.Enabled = true;
            HangStateSize = HangState.Jobbl�b;
            AktHangState = HangState.�res;
            this.Invalidate();
            Sz�Kiv�laszt();
            GombHozz�ad();
            LabelsHozz�ad();
        }
        private void b_kilepes_Click(object sender, EventArgs e)
        {
            szerepelt.Clear();
            this.Close();
        }

        private void Akaszt�fa_Load(object sender, EventArgs e)
        {

        }
    }
}

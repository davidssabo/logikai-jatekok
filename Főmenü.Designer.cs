﻿namespace logikai_jatekok
{
    partial class Főmenü
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_aknakereso = new System.Windows.Forms.Button();
            this.b_mastermind = new System.Windows.Forms.Button();
            this.b_akasztofa = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.b_statisztika = new System.Windows.Forms.Button();
            this.l_szervercim = new System.Windows.Forms.Label();
            this.l_felhasznalonev = new System.Windows.Forms.Label();
            this.l_jelszo = new System.Windows.Forms.Label();
            this.l_portszam = new System.Windows.Forms.Label();
            this.tb_szervercim = new System.Windows.Forms.TextBox();
            this.tb_felhasznalonev = new System.Windows.Forms.TextBox();
            this.tb_jelszo = new System.Windows.Forms.TextBox();
            this.tb_portszam = new System.Windows.Forms.TextBox();
            this.cb_jatekosneve = new System.Windows.Forms.ComboBox();
            this.panel_szerver = new System.Windows.Forms.Panel();
            this.b_mentes = new System.Windows.Forms.Button();
            this.b_nevmentes = new System.Windows.Forms.Button();
            this.panel_szerver.SuspendLayout();
            this.SuspendLayout();
            // 
            // b_aknakereso
            // 
            this.b_aknakereso.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.b_aknakereso.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_aknakereso.Location = new System.Drawing.Point(52, 310);
            this.b_aknakereso.Margin = new System.Windows.Forms.Padding(0);
            this.b_aknakereso.Name = "b_aknakereso";
            this.b_aknakereso.Size = new System.Drawing.Size(129, 43);
            this.b_aknakereso.TabIndex = 0;
            this.b_aknakereso.Text = "Aknakereső";
            this.b_aknakereso.UseVisualStyleBackColor = false;
            this.b_aknakereso.Click += new System.EventHandler(this.b_aknakereso_Click);
            // 
            // b_mastermind
            // 
            this.b_mastermind.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.b_mastermind.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_mastermind.Location = new System.Drawing.Point(228, 310);
            this.b_mastermind.Margin = new System.Windows.Forms.Padding(0);
            this.b_mastermind.Name = "b_mastermind";
            this.b_mastermind.Size = new System.Drawing.Size(129, 43);
            this.b_mastermind.TabIndex = 1;
            this.b_mastermind.Text = "Mastermind";
            this.b_mastermind.UseVisualStyleBackColor = false;
            this.b_mastermind.Click += new System.EventHandler(this.b_mastermind_Click);
            // 
            // b_akasztofa
            // 
            this.b_akasztofa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.b_akasztofa.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_akasztofa.Location = new System.Drawing.Point(423, 310);
            this.b_akasztofa.Margin = new System.Windows.Forms.Padding(0);
            this.b_akasztofa.Name = "b_akasztofa";
            this.b_akasztofa.Size = new System.Drawing.Size(129, 43);
            this.b_akasztofa.TabIndex = 2;
            this.b_akasztofa.Text = "Akasztófa";
            this.b_akasztofa.UseVisualStyleBackColor = false;
            this.b_akasztofa.Click += new System.EventHandler(this.b_akasztofa_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Játékos neve:";
            // 
            // b_statisztika
            // 
            this.b_statisztika.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.b_statisztika.Font = new System.Drawing.Font("Lucida Sans Unicode", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_statisztika.Location = new System.Drawing.Point(613, 310);
            this.b_statisztika.Margin = new System.Windows.Forms.Padding(0);
            this.b_statisztika.Name = "b_statisztika";
            this.b_statisztika.Size = new System.Drawing.Size(129, 43);
            this.b_statisztika.TabIndex = 5;
            this.b_statisztika.Text = "Statisztika";
            this.b_statisztika.UseVisualStyleBackColor = false;
            this.b_statisztika.Click += new System.EventHandler(this.b_statisztika_Click);
            // 
            // l_szervercim
            // 
            this.l_szervercim.AutoSize = true;
            this.l_szervercim.Font = new System.Drawing.Font("Lucida Sans", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.l_szervercim.Location = new System.Drawing.Point(3, 9);
            this.l_szervercim.Name = "l_szervercim";
            this.l_szervercim.Size = new System.Drawing.Size(89, 15);
            this.l_szervercim.TabIndex = 7;
            this.l_szervercim.Text = "Szerver címe";
            // 
            // l_felhasznalonev
            // 
            this.l_felhasznalonev.AutoSize = true;
            this.l_felhasznalonev.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_felhasznalonev.Location = new System.Drawing.Point(3, 41);
            this.l_felhasznalonev.Name = "l_felhasznalonev";
            this.l_felhasznalonev.Size = new System.Drawing.Size(104, 16);
            this.l_felhasznalonev.TabIndex = 8;
            this.l_felhasznalonev.Text = "Felhasználónév";
            // 
            // l_jelszo
            // 
            this.l_jelszo.AutoSize = true;
            this.l_jelszo.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_jelszo.Location = new System.Drawing.Point(3, 71);
            this.l_jelszo.Name = "l_jelszo";
            this.l_jelszo.Size = new System.Drawing.Size(45, 16);
            this.l_jelszo.TabIndex = 9;
            this.l_jelszo.Text = "Jelszó";
            // 
            // l_portszam
            // 
            this.l_portszam.AutoSize = true;
            this.l_portszam.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.l_portszam.Location = new System.Drawing.Point(3, 101);
            this.l_portszam.Name = "l_portszam";
            this.l_portszam.Size = new System.Drawing.Size(70, 16);
            this.l_portszam.TabIndex = 10;
            this.l_portszam.Text = "Port szám";
            // 
            // tb_szervercim
            // 
            this.tb_szervercim.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_szervercim.Location = new System.Drawing.Point(133, 3);
            this.tb_szervercim.Name = "tb_szervercim";
            this.tb_szervercim.Size = new System.Drawing.Size(145, 24);
            this.tb_szervercim.TabIndex = 11;
            // 
            // tb_felhasznalonev
            // 
            this.tb_felhasznalonev.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_felhasznalonev.Location = new System.Drawing.Point(133, 33);
            this.tb_felhasznalonev.Name = "tb_felhasznalonev";
            this.tb_felhasznalonev.Size = new System.Drawing.Size(145, 24);
            this.tb_felhasznalonev.TabIndex = 12;
            // 
            // tb_jelszo
            // 
            this.tb_jelszo.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_jelszo.Location = new System.Drawing.Point(133, 63);
            this.tb_jelszo.Name = "tb_jelszo";
            this.tb_jelszo.Size = new System.Drawing.Size(145, 24);
            this.tb_jelszo.TabIndex = 13;
            // 
            // tb_portszam
            // 
            this.tb_portszam.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tb_portszam.Location = new System.Drawing.Point(133, 93);
            this.tb_portszam.Name = "tb_portszam";
            this.tb_portszam.Size = new System.Drawing.Size(145, 24);
            this.tb_portszam.TabIndex = 14;
            // 
            // cb_jatekosneve
            // 
            this.cb_jatekosneve.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cb_jatekosneve.FormattingEnabled = true;
            this.cb_jatekosneve.Location = new System.Drawing.Point(344, 165);
            this.cb_jatekosneve.Name = "cb_jatekosneve";
            this.cb_jatekosneve.Size = new System.Drawing.Size(146, 24);
            this.cb_jatekosneve.TabIndex = 15;
            // 
            // panel_szerver
            // 
            this.panel_szerver.Controls.Add(this.b_mentes);
            this.panel_szerver.Controls.Add(this.l_szervercim);
            this.panel_szerver.Controls.Add(this.l_felhasznalonev);
            this.panel_szerver.Controls.Add(this.tb_portszam);
            this.panel_szerver.Controls.Add(this.l_jelszo);
            this.panel_szerver.Controls.Add(this.tb_jelszo);
            this.panel_szerver.Controls.Add(this.l_portszam);
            this.panel_szerver.Controls.Add(this.tb_felhasznalonev);
            this.panel_szerver.Controls.Add(this.tb_szervercim);
            this.panel_szerver.Location = new System.Drawing.Point(12, 12);
            this.panel_szerver.Name = "panel_szerver";
            this.panel_szerver.Size = new System.Drawing.Size(409, 137);
            this.panel_szerver.TabIndex = 16;
            // 
            // b_mentes
            // 
            this.b_mentes.Location = new System.Drawing.Point(318, 98);
            this.b_mentes.Name = "b_mentes";
            this.b_mentes.Size = new System.Drawing.Size(75, 23);
            this.b_mentes.TabIndex = 15;
            this.b_mentes.Text = "Mentés";
            this.b_mentes.UseVisualStyleBackColor = true;
            this.b_mentes.Click += new System.EventHandler(this.b_mentes_Click);
            // 
            // b_nevmentes
            // 
            this.b_nevmentes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.b_nevmentes.Location = new System.Drawing.Point(496, 165);
            this.b_nevmentes.Name = "b_nevmentes";
            this.b_nevmentes.Size = new System.Drawing.Size(95, 24);
            this.b_nevmentes.TabIndex = 17;
            this.b_nevmentes.Text = "Kiválasztás";
            this.b_nevmentes.UseVisualStyleBackColor = true;
            this.b_nevmentes.Click += new System.EventHandler(this.b_nevmentes_Click);
            // 
            // Főmenü
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.b_nevmentes);
            this.Controls.Add(this.panel_szerver);
            this.Controls.Add(this.cb_jatekosneve);
            this.Controls.Add(this.b_statisztika);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.b_akasztofa);
            this.Controls.Add(this.b_mastermind);
            this.Controls.Add(this.b_aknakereso);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(816, 489);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "Főmenü";
            this.Text = "Főmenü";
            this.Load += new System.EventHandler(this.Főmenü_Load);
            this.panel_szerver.ResumeLayout(false);
            this.panel_szerver.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_aknakereso;
        private System.Windows.Forms.Button b_mastermind;
        private System.Windows.Forms.Button b_akasztofa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button b_statisztika;
        private System.Windows.Forms.Label l_szervercim;
        private System.Windows.Forms.Label l_felhasznalonev;
        private System.Windows.Forms.Label l_jelszo;
        private System.Windows.Forms.Label l_portszam;
        private System.Windows.Forms.TextBox tb_szervercim;
        private System.Windows.Forms.TextBox tb_felhasznalonev;
        private System.Windows.Forms.TextBox tb_jelszo;
        private System.Windows.Forms.TextBox tb_portszam;
        private System.Windows.Forms.ComboBox cb_jatekosneve;
        private System.Windows.Forms.Panel panel_szerver;
        private System.Windows.Forms.Button b_mentes;
        private System.Windows.Forms.Button b_nevmentes;
    }
}
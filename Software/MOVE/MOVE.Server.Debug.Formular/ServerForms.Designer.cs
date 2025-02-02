﻿namespace MOVE.Server.Debug.Formular
{
    partial class ServerForms
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerForms));
            this.dgv_playfieldclient = new System.Windows.Forms.DataGridView();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.points2 = new System.Windows.Forms.Label();
            this.points1 = new System.Windows.Forms.Label();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.btn_Start = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.lbl_Client = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.rBFrequenz = new System.Windows.Forms.RadioButton();
            this.rBSound = new System.Windows.Forms.RadioButton();
            this.rbKeyboard = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Ball = new System.Windows.Forms.PictureBox();
            this.pbx_downlocal = new System.Windows.Forms.PictureBox();
            this.pbx_upnetwork = new System.Windows.Forms.PictureBox();
            this.lblSchrittDrei = new System.Windows.Forms.Label();
            this.lblSchrittEins = new System.Windows.Forms.Label();
            this.lblSchrittZwei = new System.Windows.Forms.Label();
            this.cbSprachmodul = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downlocal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_upnetwork)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_playfieldclient
            // 
            this.dgv_playfieldclient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_playfieldclient.BackgroundColor = System.Drawing.Color.Black;
            this.dgv_playfieldclient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_playfieldclient.Location = new System.Drawing.Point(68, 50);
            this.dgv_playfieldclient.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_playfieldclient.Name = "dgv_playfieldclient";
            this.dgv_playfieldclient.Size = new System.Drawing.Size(1689, 652);
            this.dgv_playfieldclient.TabIndex = 1;
            this.dgv_playfieldclient.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_playfieldclient_CellContentClick);
            this.dgv_playfieldclient.Click += new System.EventHandler(this.dgv_playfieldclient_Click);
            this.dgv_playfieldclient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgv_playfieldclient_KeyDown);
            // 
            // timer2
            // 
            this.timer2.Interval = 1;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // points2
            // 
            this.points2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.points2.AutoSize = true;
            this.points2.BackColor = System.Drawing.Color.Black;
            this.points2.Font = new System.Drawing.Font("Courier New", 60F);
            this.points2.ForeColor = System.Drawing.Color.Lime;
            this.points2.Location = new System.Drawing.Point(1530, 565);
            this.points2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.points2.Name = "points2";
            this.points2.Size = new System.Drawing.Size(105, 107);
            this.points2.TabIndex = 34;
            this.points2.Text = "0";
            // 
            // points1
            // 
            this.points1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.points1.AutoSize = true;
            this.points1.BackColor = System.Drawing.Color.Black;
            this.points1.Font = new System.Drawing.Font("Courier New", 60F);
            this.points1.ForeColor = System.Drawing.Color.Blue;
            this.points1.Location = new System.Drawing.Point(1525, 71);
            this.points1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.points1.Name = "points1";
            this.points1.Size = new System.Drawing.Size(105, 107);
            this.points1.TabIndex = 33;
            this.points1.Text = "0";
            // 
            // btn_Connect
            // 
            this.btn_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Connect.BackColor = System.Drawing.Color.Yellow;
            this.btn_Connect.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Connect.Location = new System.Drawing.Point(623, 710);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(249, 44);
            this.btn_Connect.TabIndex = 55;
            this.btn_Connect.Text = "Verbinden";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click_1);
            // 
            // btn_Start
            // 
            this.btn_Start.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_Start.BackColor = System.Drawing.Color.Orange;
            this.btn_Start.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btn_Start.Location = new System.Drawing.Point(345, 710);
            this.btn_Start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(269, 44);
            this.btn_Start.TabIndex = 60;
            this.btn_Start.Text = "Start";
            this.btn_Start.UseVisualStyleBackColor = false;
            this.btn_Start.Click += new System.EventHandler(this.btn_Start_Click_1);
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.BackColor = System.Drawing.Color.Green;
            this.btnStart.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStart.Location = new System.Drawing.Point(977, 710);
            this.btnStart.Margin = new System.Windows.Forms.Padding(4);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(251, 44);
            this.btnStart.TabIndex = 69;
            this.btnStart.Text = "Move it!";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lbl_Client
            // 
            this.lbl_Client.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lbl_Client.AutoSize = true;
            this.lbl_Client.BackColor = System.Drawing.Color.Black;
            this.lbl_Client.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F);
            this.lbl_Client.ForeColor = System.Drawing.Color.Lime;
            this.lbl_Client.Location = new System.Drawing.Point(785, 788);
            this.lbl_Client.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Client.Name = "lbl_Client";
            this.lbl_Client.Size = new System.Drawing.Size(162, 54);
            this.lbl_Client.TabIndex = 72;
            this.lbl_Client.Text = "Server";
            this.lbl_Client.Click += new System.EventHandler(this.lbl_Client_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSettings.BackColor = System.Drawing.Color.Red;
            this.btnSettings.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.btnSettings.Location = new System.Drawing.Point(76, 710);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(4);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(261, 44);
            this.btnSettings.TabIndex = 74;
            this.btnSettings.Text = "Einstellungen";
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // rBFrequenz
            // 
            this.rBFrequenz.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBFrequenz.AutoSize = true;
            this.rBFrequenz.BackColor = System.Drawing.Color.Purple;
            this.rBFrequenz.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rBFrequenz.Location = new System.Drawing.Point(1397, 716);
            this.rBFrequenz.Margin = new System.Windows.Forms.Padding(4);
            this.rBFrequenz.Name = "rBFrequenz";
            this.rBFrequenz.Size = new System.Drawing.Size(171, 35);
            this.rBFrequenz.TabIndex = 82;
            this.rBFrequenz.TabStop = true;
            this.rBFrequenz.Text = "Frequenz";
            this.rBFrequenz.UseVisualStyleBackColor = false;
            this.rBFrequenz.CheckedChanged += new System.EventHandler(this.rBFrequenz_CheckedChanged);
            // 
            // rBSound
            // 
            this.rBSound.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rBSound.AutoSize = true;
            this.rBSound.BackColor = System.Drawing.Color.Blue;
            this.rBSound.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rBSound.Location = new System.Drawing.Point(1243, 716);
            this.rBSound.Margin = new System.Windows.Forms.Padding(4);
            this.rBSound.Name = "rBSound";
            this.rBSound.Size = new System.Drawing.Size(120, 35);
            this.rBSound.TabIndex = 81;
            this.rBSound.TabStop = true;
            this.rBSound.Text = "Sound";
            this.rBSound.UseVisualStyleBackColor = false;
            // 
            // rbKeyboard
            // 
            this.rbKeyboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.rbKeyboard.AutoSize = true;
            this.rbKeyboard.BackColor = System.Drawing.Color.Pink;
            this.rbKeyboard.Font = new System.Drawing.Font("Courier New", 16.2F, System.Drawing.FontStyle.Bold);
            this.rbKeyboard.Location = new System.Drawing.Point(1584, 716);
            this.rbKeyboard.Margin = new System.Windows.Forms.Padding(4);
            this.rbKeyboard.Name = "rbKeyboard";
            this.rbKeyboard.Size = new System.Drawing.Size(171, 35);
            this.rbKeyboard.TabIndex = 83;
            this.rbKeyboard.TabStop = true;
            this.rbKeyboard.Text = "Tastatur";
            this.rbKeyboard.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(1804, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(11, 898);
            this.panel1.TabIndex = 84;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Red;
            this.panel2.Location = new System.Drawing.Point(1788, 12);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(11, 898);
            this.panel2.TabIndex = 85;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.Color.Red;
            this.panel3.Location = new System.Drawing.Point(1772, 12);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(11, 898);
            this.panel3.TabIndex = 86;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Red;
            this.panel5.Location = new System.Drawing.Point(12, 12);
            this.panel5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(11, 898);
            this.panel5.TabIndex = 91;
            this.panel5.Paint += new System.Windows.Forms.PaintEventHandler(this.panel5_Paint);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Red;
            this.panel6.Location = new System.Drawing.Point(28, 12);
            this.panel6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(11, 898);
            this.panel6.TabIndex = 90;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.Red;
            this.panel7.Location = new System.Drawing.Point(44, 12);
            this.panel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(11, 898);
            this.panel7.TabIndex = 89;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.Red;
            this.panel4.Location = new System.Drawing.Point(12, 12);
            this.panel4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1803, 10);
            this.panel4.TabIndex = 90;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.Red;
            this.panel8.Location = new System.Drawing.Point(44, 28);
            this.panel8.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1739, 10);
            this.panel8.TabIndex = 91;
            // 
            // Ball
            // 
            this.Ball.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Ball.BackColor = System.Drawing.Color.Magenta;
            this.Ball.Location = new System.Drawing.Point(1433, 169);
            this.Ball.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ball.Name = "Ball";
            this.Ball.Size = new System.Drawing.Size(51, 50);
            this.Ball.TabIndex = 76;
            this.Ball.TabStop = false;
            // 
            // pbx_downlocal
            // 
            this.pbx_downlocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbx_downlocal.BackColor = System.Drawing.Color.Lime;
            this.pbx_downlocal.Location = new System.Drawing.Point(93, 636);
            this.pbx_downlocal.Margin = new System.Windows.Forms.Padding(4);
            this.pbx_downlocal.Name = "pbx_downlocal";
            this.pbx_downlocal.Size = new System.Drawing.Size(247, 33);
            this.pbx_downlocal.TabIndex = 4;
            this.pbx_downlocal.TabStop = false;
            // 
            // pbx_upnetwork
            // 
            this.pbx_upnetwork.BackColor = System.Drawing.Color.Blue;
            this.pbx_upnetwork.Location = new System.Drawing.Point(93, 71);
            this.pbx_upnetwork.Margin = new System.Windows.Forms.Padding(4);
            this.pbx_upnetwork.Name = "pbx_upnetwork";
            this.pbx_upnetwork.Size = new System.Drawing.Size(247, 33);
            this.pbx_upnetwork.TabIndex = 3;
            this.pbx_upnetwork.TabStop = false;
            // 
            // lblSchrittDrei
            // 
            this.lblSchrittDrei.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSchrittDrei.AutoSize = true;
            this.lblSchrittDrei.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSchrittDrei.Location = new System.Drawing.Point(73, 823);
            this.lblSchrittDrei.Name = "lblSchrittDrei";
            this.lblSchrittDrei.Size = new System.Drawing.Size(252, 17);
            this.lblSchrittDrei.TabIndex = 97;
            this.lblSchrittDrei.Text = "Übertragung der Schlägerkoordinaten:";
            // 
            // lblSchrittEins
            // 
            this.lblSchrittEins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSchrittEins.AutoSize = true;
            this.lblSchrittEins.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSchrittEins.Location = new System.Drawing.Point(73, 770);
            this.lblSchrittEins.Name = "lblSchrittEins";
            this.lblSchrittEins.Size = new System.Drawing.Size(227, 17);
            this.lblSchrittEins.TabIndex = 96;
            this.lblSchrittEins.Text = "Korrektes IP-Netzwerk ausgewählt:";
            // 
            // lblSchrittZwei
            // 
            this.lblSchrittZwei.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSchrittZwei.AutoSize = true;
            this.lblSchrittZwei.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lblSchrittZwei.Location = new System.Drawing.Point(73, 795);
            this.lblSchrittZwei.Name = "lblSchrittZwei";
            this.lblSchrittZwei.Size = new System.Drawing.Size(213, 17);
            this.lblSchrittZwei.TabIndex = 95;
            this.lblSchrittZwei.Text = "Verbindung zu Client hergestellt:";
            // 
            // cbSprachmodul
            // 
            this.cbSprachmodul.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbSprachmodul.AutoSize = true;
            this.cbSprachmodul.Checked = true;
            this.cbSprachmodul.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSprachmodul.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.cbSprachmodul.Location = new System.Drawing.Point(76, 847);
            this.cbSprachmodul.Name = "cbSprachmodul";
            this.cbSprachmodul.Size = new System.Drawing.Size(166, 21);
            this.cbSprachmodul.TabIndex = 98;
            this.cbSprachmodul.Text = "Sprachmodul aktiviert";
            this.cbSprachmodul.UseVisualStyleBackColor = true;
            // 
            // ServerForms
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1827, 922);
            this.Controls.Add(this.cbSprachmodul);
            this.Controls.Add(this.lblSchrittDrei);
            this.Controls.Add(this.lblSchrittEins);
            this.Controls.Add(this.lblSchrittZwei);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.rbKeyboard);
            this.Controls.Add(this.rBFrequenz);
            this.Controls.Add(this.rBSound);
            this.Controls.Add(this.Ball);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.lbl_Client);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.btn_Connect);
            this.Controls.Add(this.points2);
            this.Controls.Add(this.points1);
            this.Controls.Add(this.pbx_downlocal);
            this.Controls.Add(this.pbx_upnetwork);
            this.Controls.Add(this.dgv_playfieldclient);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ServerForms";
            this.Text = "Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.ServerForms_Activated);
            this.Deactivate += new System.EventHandler(this.ServerForms_Deactivate);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_playfieldclient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_downlocal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbx_upnetwork)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_playfieldclient;
        private System.Windows.Forms.PictureBox pbx_upnetwork;
        private System.Windows.Forms.PictureBox pbx_downlocal;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label points2;
        private System.Windows.Forms.Label points1;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lbl_Client;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox Ball;
        private System.Windows.Forms.RadioButton rBFrequenz;
        private System.Windows.Forms.RadioButton rBSound;
        private System.Windows.Forms.RadioButton rbKeyboard;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lblSchrittDrei;
        private System.Windows.Forms.Label lblSchrittEins;
        private System.Windows.Forms.Label lblSchrittZwei;
        private System.Windows.Forms.CheckBox cbSprachmodul;
    }
}


namespace MySqlWooSyncApp
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtWooUrl;
        private System.Windows.Forms.TextBox txtWooKey;
        private System.Windows.Forms.TextBox txtWooSecret;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.TextBox txtTimeout;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnSyncNow;
        private System.Windows.Forms.Button btnStartAuto;
        private System.Windows.Forms.Button btnStopAuto;
        private System.Windows.Forms.Button btnOpenConfig;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtWooUrl = new System.Windows.Forms.TextBox();
            this.txtWooKey = new System.Windows.Forms.TextBox();
            this.txtWooSecret = new System.Windows.Forms.TextBox();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.txtTimeout = new System.Windows.Forms.TextBox();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.btnSyncNow = new System.Windows.Forms.Button();
            this.btnStartAuto = new System.Windows.Forms.Button();
            this.btnStopAuto = new System.Windows.Forms.Button();
            this.btnOpenConfig = new System.Windows.Forms.Button();
            this.btnSoloAct = new System.Windows.Forms.Button();
            this.rdbAct = new System.Windows.Forms.RadioButton();
            this.rdbActCarg = new System.Windows.Forms.RadioButton();
            this.btnActAuto = new System.Windows.Forms.Button();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUrl = new System.Windows.Forms.Label();
            this.lblWebKey = new System.Windows.Forms.Label();
            this.lblSecWeb = new System.Windows.Forms.Label();
            this.lblPort = new System.Windows.Forms.Label();
            this.lblPass = new System.Windows.Forms.Label();
            this.lblBD = new System.Windows.Forms.Label();
            this.lblIntervalo = new System.Windows.Forms.Label();
            this.lblCorte = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(140, 12);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(220, 23);
            this.txtHost.TabIndex = 0;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(440, 12);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(80, 23);
            this.txtPort.TabIndex = 1;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(590, 12);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(180, 23);
            this.txtDatabase.TabIndex = 2;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(140, 45);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(220, 23);
            this.txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(440, 45);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(180, 23);
            this.txtPassword.TabIndex = 4;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // txtWooUrl
            // 
            this.txtWooUrl.Location = new System.Drawing.Point(140, 78);
            this.txtWooUrl.Name = "txtWooUrl";
            this.txtWooUrl.Size = new System.Drawing.Size(380, 23);
            this.txtWooUrl.TabIndex = 5;
            // 
            // txtWooKey
            // 
            this.txtWooKey.Location = new System.Drawing.Point(140, 111);
            this.txtWooKey.Name = "txtWooKey";
            this.txtWooKey.Size = new System.Drawing.Size(380, 23);
            this.txtWooKey.TabIndex = 6;
            // 
            // txtWooSecret
            // 
            this.txtWooSecret.Location = new System.Drawing.Point(140, 144);
            this.txtWooSecret.Name = "txtWooSecret";
            this.txtWooSecret.Size = new System.Drawing.Size(380, 23);
            this.txtWooSecret.TabIndex = 7;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(640, 78);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(60, 23);
            this.txtInterval.TabIndex = 8;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(640, 111);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.Size = new System.Drawing.Size(60, 23);
            this.txtTimeout.TabIndex = 9;
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(15, 205);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtQuery.Size = new System.Drawing.Size(1135, 170);
            this.txtQuery.TabIndex = 10;
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(15, 463);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1135, 275);
            this.txtLog.TabIndex = 11;
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.Location = new System.Drawing.Point(15, 424);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(130, 32);
            this.btnSaveConfig.TabIndex = 12;
            this.btnSaveConfig.Text = "Guardar config";
            this.btnSaveConfig.Click += new System.EventHandler(this.btnSaveConfig_Click);
            // 
            // btnSyncNow
            // 
            this.btnSyncNow.Location = new System.Drawing.Point(295, 424);
            this.btnSyncNow.Name = "btnSyncNow";
            this.btnSyncNow.Size = new System.Drawing.Size(140, 32);
            this.btnSyncNow.TabIndex = 14;
            this.btnSyncNow.Text = "Sincronizar manual";
            this.btnSyncNow.Click += new System.EventHandler(this.btnSyncNow_Click);
            // 
            // btnStartAuto
            // 
            this.btnStartAuto.Location = new System.Drawing.Point(445, 424);
            this.btnStartAuto.Name = "btnStartAuto";
            this.btnStartAuto.Size = new System.Drawing.Size(140, 32);
            this.btnStartAuto.TabIndex = 15;
            this.btnStartAuto.Text = "Sincro automático";
            this.btnStartAuto.Click += new System.EventHandler(this.btnStartAuto_Click);
            // 
            // btnStopAuto
            // 
            this.btnStopAuto.Location = new System.Drawing.Point(861, 425);
            this.btnStopAuto.Name = "btnStopAuto";
            this.btnStopAuto.Size = new System.Drawing.Size(140, 32);
            this.btnStopAuto.TabIndex = 16;
            this.btnStopAuto.Text = "Detener automático";
            this.btnStopAuto.Click += new System.EventHandler(this.btnStopAuto_Click);
            // 
            // btnOpenConfig
            // 
            this.btnOpenConfig.Location = new System.Drawing.Point(155, 424);
            this.btnOpenConfig.Name = "btnOpenConfig";
            this.btnOpenConfig.Size = new System.Drawing.Size(130, 32);
            this.btnOpenConfig.TabIndex = 13;
            this.btnOpenConfig.Text = "Abrir config";
            this.btnOpenConfig.Click += new System.EventHandler(this.btnOpenConfig_Click);
            // 
            // btnSoloAct
            // 
            this.btnSoloAct.Location = new System.Drawing.Point(591, 424);
            this.btnSoloAct.Name = "btnSoloAct";
            this.btnSoloAct.Size = new System.Drawing.Size(130, 32);
            this.btnSoloAct.TabIndex = 17;
            this.btnSoloAct.Text = "Actualizar manual";
            this.btnSoloAct.Click += new System.EventHandler(this.btnSoloAct_Click);
            // 
            // rdbAct
            // 
            this.rdbAct.AutoSize = true;
            this.rdbAct.Checked = true;
            this.rdbAct.Location = new System.Drawing.Point(15, 392);
            this.rdbAct.Name = "rdbAct";
            this.rdbAct.Size = new System.Drawing.Size(128, 19);
            this.rdbAct.TabIndex = 18;
            this.rdbAct.TabStop = true;
            this.rdbAct.Tag = "Datos";
            this.rdbAct.Text = "SOLO ACTUALIZAR";
            this.rdbAct.UseVisualStyleBackColor = true;
            this.rdbAct.CheckedChanged += new System.EventHandler(this.rdbAct_CheckedChanged);
            // 
            // rdbActCarg
            // 
            this.rdbActCarg.AutoSize = true;
            this.rdbActCarg.Location = new System.Drawing.Point(149, 392);
            this.rdbActCarg.Name = "rdbActCarg";
            this.rdbActCarg.Size = new System.Drawing.Size(154, 19);
            this.rdbActCarg.TabIndex = 19;
            this.rdbActCarg.Tag = "Datos";
            this.rdbActCarg.Text = "ACTUALIZAR Y CARGAR";
            this.rdbActCarg.UseVisualStyleBackColor = true;
            // 
            // btnActAuto
            // 
            this.btnActAuto.Location = new System.Drawing.Point(727, 424);
            this.btnActAuto.Name = "btnActAuto";
            this.btnActAuto.Size = new System.Drawing.Size(130, 32);
            this.btnActAuto.TabIndex = 20;
            this.btnActAuto.Text = "Act. automática";
            this.btnActAuto.Click += new System.EventHandler(this.btnActAuto_Click);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(96, 15);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(35, 15);
            this.lblHost.TabIndex = 21;
            this.lblHost.Text = "Host:";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(84, 48);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(50, 15);
            this.lblUser.TabIndex = 22;
            this.lblUser.Text = "Usuario:";
            // 
            // lblUrl
            // 
            this.lblUrl.AutoSize = true;
            this.lblUrl.Location = new System.Drawing.Point(76, 81);
            this.lblUrl.Name = "lblUrl";
            this.lblUrl.Size = new System.Drawing.Size(58, 15);
            this.lblUrl.TabIndex = 23;
            this.lblUrl.Text = "URL Web:";
            // 
            // lblWebKey
            // 
            this.lblWebKey.AutoSize = true;
            this.lblWebKey.Location = new System.Drawing.Point(76, 114);
            this.lblWebKey.Name = "lblWebKey";
            this.lblWebKey.Size = new System.Drawing.Size(56, 15);
            this.lblWebKey.TabIndex = 24;
            this.lblWebKey.Text = "Key Web:";
            // 
            // lblSecWeb
            // 
            this.lblSecWeb.AutoSize = true;
            this.lblSecWeb.Location = new System.Drawing.Point(65, 147);
            this.lblSecWeb.Name = "lblSecWeb";
            this.lblSecWeb.Size = new System.Drawing.Size(69, 15);
            this.lblSecWeb.TabIndex = 25;
            this.lblSecWeb.Text = "Secret Web:";
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(390, 15);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(45, 15);
            this.lblPort.TabIndex = 26;
            this.lblPort.Text = "Puerto:";
            // 
            // lblPass
            // 
            this.lblPass.AutoSize = true;
            this.lblPass.Location = new System.Drawing.Point(401, 48);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(33, 15);
            this.lblPass.TabIndex = 27;
            this.lblPass.Text = "Pass:";
            // 
            // lblBD
            // 
            this.lblBD.AutoSize = true;
            this.lblBD.Location = new System.Drawing.Point(560, 15);
            this.lblBD.Name = "lblBD";
            this.lblBD.Size = new System.Drawing.Size(25, 15);
            this.lblBD.TabIndex = 28;
            this.lblBD.Text = "BD:";
            // 
            // lblIntervalo
            // 
            this.lblIntervalo.AutoSize = true;
            this.lblIntervalo.Location = new System.Drawing.Point(600, 81);
            this.lblIntervalo.Name = "lblIntervalo";
            this.lblIntervalo.Size = new System.Drawing.Size(34, 15);
            this.lblIntervalo.TabIndex = 29;
            this.lblIntervalo.Text = "Inter:";
            // 
            // lblCorte
            // 
            this.lblCorte.AutoSize = true;
            this.lblCorte.Location = new System.Drawing.Point(595, 114);
            this.lblCorte.Name = "lblCorte";
            this.lblCorte.Size = new System.Drawing.Size(44, 15);
            this.lblCorte.TabIndex = 30;
            this.lblCorte.Text = "Espera:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(706, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 15);
            this.label1.TabIndex = 31;
            this.label1.Text = "minutos";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(706, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 15);
            this.label2.TabIndex = 32;
            this.label2.Text = "segundos";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 760);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblCorte);
            this.Controls.Add(this.lblIntervalo);
            this.Controls.Add(this.lblBD);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.lblPort);
            this.Controls.Add(this.lblSecWeb);
            this.Controls.Add(this.lblWebKey);
            this.Controls.Add(this.lblUrl);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.btnActAuto);
            this.Controls.Add(this.rdbActCarg);
            this.Controls.Add(this.rdbAct);
            this.Controls.Add(this.btnSoloAct);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtWooUrl);
            this.Controls.Add(this.txtWooKey);
            this.Controls.Add(this.txtWooSecret);
            this.Controls.Add(this.txtInterval);
            this.Controls.Add(this.txtTimeout);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnSaveConfig);
            this.Controls.Add(this.btnOpenConfig);
            this.Controls.Add(this.btnSyncNow);
            this.Controls.Add(this.btnStartAuto);
            this.Controls.Add(this.btnStopAuto);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "MainForm";
            this.Text = "MySql Woo Sync App";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void AddLabel(string text, int x, int y)
        {
            var label = new System.Windows.Forms.Label();
            label.AutoSize = true;
            label.Text = text;
            label.Left = x;
            label.Top = y + 4;
            this.Controls.Add(label);
        }

        private System.Windows.Forms.Button btnSoloAct;
        private System.Windows.Forms.RadioButton rdbAct;
        private System.Windows.Forms.RadioButton rdbActCarg;
        private System.Windows.Forms.Button btnActAuto;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblUrl;
        private System.Windows.Forms.Label lblWebKey;
        private System.Windows.Forms.Label lblSecWeb;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblPass;
        private System.Windows.Forms.Label lblBD;
        private System.Windows.Forms.Label lblIntervalo;
        private System.Windows.Forms.Label lblCorte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

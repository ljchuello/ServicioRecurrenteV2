﻿
namespace VisualV12
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Resumen = new MetroFramework.Controls.MetroTabControl();
            this.metroTabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblResumen = new MetroFramework.Controls.MetroLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMailSinEnviar = new MetroFramework.Controls.MetroLabel();
            this.txtFechaInicio = new MetroFramework.Controls.MetroLabel();
            this.lblEstado = new MetroFramework.Controls.MetroLabel();
            this.btnEstado = new MetroFramework.Controls.MetroButton();
            this.metroTabPage2 = new MetroFramework.Controls.MetroTabPage();
            this.btnRestaurar = new MetroFramework.Controls.MetroButton();
            this.btnGuardar = new MetroFramework.Controls.MetroButton();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.txtSqlServer = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.txtContrasenia = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.txtUsuario = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.txtUrl = new MetroFramework.Controls.MetroTextBox();
            this.btnCerrar = new MetroFramework.Controls.MetroButton();
            this.lblVersion = new MetroFramework.Controls.MetroLabel();
            this.metroTabPage3 = new MetroFramework.Controls.MetroTabPage();
            this.btnReenviarEmails = new System.Windows.Forms.Button();
            this.Resumen.SuspendLayout();
            this.metroTabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.metroTabPage2.SuspendLayout();
            this.metroTabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Resumen
            // 
            this.Resumen.Controls.Add(this.metroTabPage1);
            this.Resumen.Controls.Add(this.metroTabPage2);
            this.Resumen.Controls.Add(this.metroTabPage3);
            this.Resumen.Location = new System.Drawing.Point(10, 64);
            this.Resumen.Name = "Resumen";
            this.Resumen.SelectedIndex = 2;
            this.Resumen.Size = new System.Drawing.Size(322, 344);
            this.Resumen.TabIndex = 0;
            this.Resumen.UseSelectable = true;
            // 
            // metroTabPage1
            // 
            this.metroTabPage1.Controls.Add(this.groupBox2);
            this.metroTabPage1.Controls.Add(this.groupBox1);
            this.metroTabPage1.HorizontalScrollbarBarColor = true;
            this.metroTabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.HorizontalScrollbarSize = 10;
            this.metroTabPage1.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage1.Name = "metroTabPage1";
            this.metroTabPage1.Size = new System.Drawing.Size(314, 302);
            this.metroTabPage1.TabIndex = 0;
            this.metroTabPage1.Text = "Resumen";
            this.metroTabPage1.VerticalScrollbarBarColor = true;
            this.metroTabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage1.VerticalScrollbarSize = 10;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox2.Controls.Add(this.lblResumen);
            this.groupBox2.Location = new System.Drawing.Point(0, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(311, 190);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Resumen";
            // 
            // lblResumen
            // 
            this.lblResumen.AutoSize = true;
            this.lblResumen.Location = new System.Drawing.Point(10, 20);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(0, 0);
            this.lblResumen.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Controls.Add(this.lblMailSinEnviar);
            this.groupBox1.Controls.Add(this.txtFechaInicio);
            this.groupBox1.Controls.Add(this.lblEstado);
            this.groupBox1.Controls.Add(this.btnEstado);
            this.groupBox1.Location = new System.Drawing.Point(1, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(310, 107);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Servicio";
            // 
            // lblMailSinEnviar
            // 
            this.lblMailSinEnviar.AutoSize = true;
            this.lblMailSinEnviar.Location = new System.Drawing.Point(9, 84);
            this.lblMailSinEnviar.Name = "lblMailSinEnviar";
            this.lblMailSinEnviar.Size = new System.Drawing.Size(136, 19);
            this.lblMailSinEnviar.TabIndex = 6;
            this.lblMailSinEnviar.Text = "Emails sin enviar: N/D";
            // 
            // txtFechaInicio
            // 
            this.txtFechaInicio.AutoSize = true;
            this.txtFechaInicio.Location = new System.Drawing.Point(9, 65);
            this.txtFechaInicio.Name = "txtFechaInicio";
            this.txtFechaInicio.Size = new System.Drawing.Size(80, 19);
            this.txtFechaInicio.TabIndex = 5;
            this.txtFechaInicio.Text = "Fecha inicio:";
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(9, 47);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(51, 19);
            this.lblEstado.TabIndex = 3;
            this.lblEstado.Text = "Estado:";
            // 
            // btnEstado
            // 
            this.btnEstado.Location = new System.Drawing.Point(6, 17);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(298, 23);
            this.btnEstado.TabIndex = 2;
            this.btnEstado.Text = "XxXx";
            this.btnEstado.UseSelectable = true;
            this.btnEstado.Click += new System.EventHandler(this.btnEstado_Click);
            // 
            // metroTabPage2
            // 
            this.metroTabPage2.Controls.Add(this.btnRestaurar);
            this.metroTabPage2.Controls.Add(this.btnGuardar);
            this.metroTabPage2.Controls.Add(this.metroLabel4);
            this.metroTabPage2.Controls.Add(this.txtSqlServer);
            this.metroTabPage2.Controls.Add(this.metroLabel3);
            this.metroTabPage2.Controls.Add(this.txtContrasenia);
            this.metroTabPage2.Controls.Add(this.metroLabel2);
            this.metroTabPage2.Controls.Add(this.txtUsuario);
            this.metroTabPage2.Controls.Add(this.metroLabel1);
            this.metroTabPage2.Controls.Add(this.txtUrl);
            this.metroTabPage2.HorizontalScrollbarBarColor = true;
            this.metroTabPage2.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.HorizontalScrollbarSize = 10;
            this.metroTabPage2.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage2.Name = "metroTabPage2";
            this.metroTabPage2.Size = new System.Drawing.Size(314, 302);
            this.metroTabPage2.TabIndex = 1;
            this.metroTabPage2.Text = "Configuracion";
            this.metroTabPage2.VerticalScrollbarBarColor = true;
            this.metroTabPage2.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage2.VerticalScrollbarSize = 10;
            // 
            // btnRestaurar
            // 
            this.btnRestaurar.Location = new System.Drawing.Point(9, 262);
            this.btnRestaurar.Name = "btnRestaurar";
            this.btnRestaurar.Size = new System.Drawing.Size(300, 23);
            this.btnRestaurar.TabIndex = 11;
            this.btnRestaurar.Text = "Restaurar";
            this.btnRestaurar.UseSelectable = true;
            this.btnRestaurar.Click += new System.EventHandler(this.btnRestaurar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(9, 236);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(300, 23);
            this.btnGuardar.TabIndex = 10;
            this.btnGuardar.Text = "Validar y Guardar";
            this.btnGuardar.UseSelectable = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(6, 176);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(75, 19);
            this.metroLabel4.TabIndex = 9;
            this.metroLabel4.Text = "SQL Server";
            // 
            // txtSqlServer
            // 
            // 
            // 
            // 
            this.txtSqlServer.CustomButton.Image = null;
            this.txtSqlServer.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtSqlServer.CustomButton.Name = "";
            this.txtSqlServer.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtSqlServer.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtSqlServer.CustomButton.TabIndex = 1;
            this.txtSqlServer.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtSqlServer.CustomButton.UseSelectable = true;
            this.txtSqlServer.CustomButton.Visible = false;
            this.txtSqlServer.Lines = new string[0];
            this.txtSqlServer.Location = new System.Drawing.Point(7, 199);
            this.txtSqlServer.MaxLength = 32767;
            this.txtSqlServer.Name = "txtSqlServer";
            this.txtSqlServer.PasswordChar = '\0';
            this.txtSqlServer.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtSqlServer.SelectedText = "";
            this.txtSqlServer.SelectionLength = 0;
            this.txtSqlServer.SelectionStart = 0;
            this.txtSqlServer.ShortcutsEnabled = true;
            this.txtSqlServer.Size = new System.Drawing.Size(302, 23);
            this.txtSqlServer.TabIndex = 8;
            this.txtSqlServer.UseSelectable = true;
            this.txtSqlServer.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtSqlServer.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(6, 120);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(75, 19);
            this.metroLabel3.TabIndex = 7;
            this.metroLabel3.Text = "Contraseña";
            // 
            // txtContrasenia
            // 
            // 
            // 
            // 
            this.txtContrasenia.CustomButton.Image = null;
            this.txtContrasenia.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtContrasenia.CustomButton.Name = "";
            this.txtContrasenia.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtContrasenia.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtContrasenia.CustomButton.TabIndex = 1;
            this.txtContrasenia.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtContrasenia.CustomButton.UseSelectable = true;
            this.txtContrasenia.CustomButton.Visible = false;
            this.txtContrasenia.Lines = new string[0];
            this.txtContrasenia.Location = new System.Drawing.Point(7, 143);
            this.txtContrasenia.MaxLength = 32767;
            this.txtContrasenia.Name = "txtContrasenia";
            this.txtContrasenia.PasswordChar = '*';
            this.txtContrasenia.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtContrasenia.SelectedText = "";
            this.txtContrasenia.SelectionLength = 0;
            this.txtContrasenia.SelectionStart = 0;
            this.txtContrasenia.ShortcutsEnabled = true;
            this.txtContrasenia.Size = new System.Drawing.Size(302, 23);
            this.txtContrasenia.TabIndex = 6;
            this.txtContrasenia.UseSelectable = true;
            this.txtContrasenia.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtContrasenia.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(6, 65);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(181, 19);
            this.metroLabel2.TabIndex = 5;
            this.metroLabel2.Text = "Usuario (admin@admin.com)";
            // 
            // txtUsuario
            // 
            // 
            // 
            // 
            this.txtUsuario.CustomButton.Image = null;
            this.txtUsuario.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtUsuario.CustomButton.Name = "";
            this.txtUsuario.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUsuario.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUsuario.CustomButton.TabIndex = 1;
            this.txtUsuario.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUsuario.CustomButton.UseSelectable = true;
            this.txtUsuario.CustomButton.Visible = false;
            this.txtUsuario.Lines = new string[0];
            this.txtUsuario.Location = new System.Drawing.Point(7, 88);
            this.txtUsuario.MaxLength = 32767;
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.PasswordChar = '\0';
            this.txtUsuario.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUsuario.SelectedText = "";
            this.txtUsuario.SelectionLength = 0;
            this.txtUsuario.SelectionStart = 0;
            this.txtUsuario.ShortcutsEnabled = true;
            this.txtUsuario.Size = new System.Drawing.Size(302, 23);
            this.txtUsuario.TabIndex = 4;
            this.txtUsuario.UseSelectable = true;
            this.txtUsuario.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUsuario.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(8, 14);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(130, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Url (http://localhost/)";
            // 
            // txtUrl
            // 
            // 
            // 
            // 
            this.txtUrl.CustomButton.Image = null;
            this.txtUrl.CustomButton.Location = new System.Drawing.Point(280, 1);
            this.txtUrl.CustomButton.Name = "";
            this.txtUrl.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtUrl.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtUrl.CustomButton.TabIndex = 1;
            this.txtUrl.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtUrl.CustomButton.UseSelectable = true;
            this.txtUrl.CustomButton.Visible = false;
            this.txtUrl.Lines = new string[0];
            this.txtUrl.Location = new System.Drawing.Point(9, 37);
            this.txtUrl.MaxLength = 32767;
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.PasswordChar = '\0';
            this.txtUrl.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtUrl.SelectedText = "";
            this.txtUrl.SelectionLength = 0;
            this.txtUrl.SelectionStart = 0;
            this.txtUrl.ShortcutsEnabled = true;
            this.txtUrl.Size = new System.Drawing.Size(302, 23);
            this.txtUrl.TabIndex = 2;
            this.txtUrl.UseSelectable = true;
            this.txtUrl.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtUrl.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Location = new System.Drawing.Point(250, 26);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(75, 23);
            this.btnCerrar.TabIndex = 4;
            this.btnCerrar.Text = "Cerrar ☠️";
            this.btnCerrar.UseSelectable = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(247, 54);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(65, 19);
            this.lblVersion.TabIndex = 7;
            this.lblVersion.Text = "lblVersion";
            // 
            // metroTabPage3
            // 
            this.metroTabPage3.Controls.Add(this.btnReenviarEmails);
            this.metroTabPage3.HorizontalScrollbarBarColor = true;
            this.metroTabPage3.HorizontalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.HorizontalScrollbarSize = 10;
            this.metroTabPage3.Location = new System.Drawing.Point(4, 38);
            this.metroTabPage3.Name = "metroTabPage3";
            this.metroTabPage3.Size = new System.Drawing.Size(314, 302);
            this.metroTabPage3.TabIndex = 2;
            this.metroTabPage3.Text = "Reenvio de emails";
            this.metroTabPage3.VerticalScrollbarBarColor = true;
            this.metroTabPage3.VerticalScrollbarHighlightOnWheel = false;
            this.metroTabPage3.VerticalScrollbarSize = 10;
            // 
            // btnReenviarEmails
            // 
            this.btnReenviarEmails.Location = new System.Drawing.Point(10, 14);
            this.btnReenviarEmails.Name = "btnReenviarEmails";
            this.btnReenviarEmails.Size = new System.Drawing.Size(288, 23);
            this.btnReenviarEmails.TabIndex = 2;
            this.btnReenviarEmails.Text = "Reenviar Emails";
            this.btnReenviarEmails.UseVisualStyleBackColor = true;
            this.btnReenviarEmails.Click += new System.EventHandler(this.btnReenviarEmails_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 408);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.Resumen);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Resumen.ResumeLayout(false);
            this.metroTabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.metroTabPage2.ResumeLayout(false);
            this.metroTabPage2.PerformLayout();
            this.metroTabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroTabControl Resumen;
        private MetroFramework.Controls.MetroTabPage metroTabPage1;
        private MetroFramework.Controls.MetroTabPage metroTabPage2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox txtContrasenia;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTextBox txtUsuario;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroTextBox txtUrl;
        private MetroFramework.Controls.MetroButton btnRestaurar;
        private MetroFramework.Controls.MetroButton btnGuardar;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroTextBox txtSqlServer;
        private MetroFramework.Controls.MetroButton btnEstado;
        private MetroFramework.Controls.MetroButton btnCerrar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private MetroFramework.Controls.MetroLabel txtFechaInicio;
        private MetroFramework.Controls.MetroLabel lblEstado;
        private MetroFramework.Controls.MetroLabel lblResumen;
        private MetroFramework.Controls.MetroLabel lblVersion;
        private MetroFramework.Controls.MetroLabel lblMailSinEnviar;
        private MetroFramework.Controls.MetroTabPage metroTabPage3;
        private System.Windows.Forms.Button btnReenviarEmails;
    }
}


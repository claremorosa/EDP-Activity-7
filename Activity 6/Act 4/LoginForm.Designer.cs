namespace Act_4
{
    partial class Form1
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
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.txtpassword = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnLoGin = new System.Windows.Forms.Button();
            this.txtusername = new System.Windows.Forms.TextBox();
            this.RecoverPassword = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.AutoSize = true;
            this.username.BackColor = System.Drawing.SystemColors.HighlightText;
            this.username.Location = new System.Drawing.Point(376, 121);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(55, 13);
            this.username.TabIndex = 0;
            this.username.Text = "Username";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.Location = new System.Drawing.Point(379, 175);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(53, 13);
            this.password.TabIndex = 1;
            this.password.Text = "Password";
            // 
            // txtpassword
            // 
            this.txtpassword.Location = new System.Drawing.Point(465, 175);
            this.txtpassword.Name = "txtpassword";
            this.txtpassword.PasswordChar = '*';
            this.txtpassword.Size = new System.Drawing.Size(131, 20);
            this.txtpassword.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Image = global::Act_4.Properties.Resources.pngtree_avatar_icon_profile_icon_member_login_vector_isolated_png_image_1978396;
            this.pictureBox1.Location = new System.Drawing.Point(97, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(488, 318);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 39);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "Connect to MySQL";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnLoGin
            // 
            this.btnLoGin.Location = new System.Drawing.Point(488, 230);
            this.btnLoGin.Name = "btnLoGin";
            this.btnLoGin.Size = new System.Drawing.Size(75, 23);
            this.btnLoGin.TabIndex = 9;
            this.btnLoGin.Text = "Login";
            this.btnLoGin.UseVisualStyleBackColor = true;
            this.btnLoGin.Click += new System.EventHandler(this.btnLoGin_Click_1);
            // 
            // txtusername
            // 
            this.txtusername.Location = new System.Drawing.Point(465, 121);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(131, 20);
            this.txtusername.TabIndex = 10;
            // 
            // RecoverPassword
            // 
            this.RecoverPassword.AutoSize = true;
            this.RecoverPassword.Location = new System.Drawing.Point(485, 279);
            this.RecoverPassword.Name = "RecoverPassword";
            this.RecoverPassword.Size = new System.Drawing.Size(97, 13);
            this.RecoverPassword.TabIndex = 11;
            this.RecoverPassword.TabStop = true;
            this.RecoverPassword.Text = "Recover Password";
            this.RecoverPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.RecoverPassword_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RecoverPassword);
            this.Controls.Add(this.txtusername);
            this.Controls.Add(this.btnLoGin);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txtpassword);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "LogIn";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox txtpassword;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnLoGin;
        private System.Windows.Forms.TextBox txtusername;
        private System.Windows.Forms.LinkLabel RecoverPassword;
    }
}


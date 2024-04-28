namespace Act_4
{
    partial class RecoverPassword
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
            this.btnRecoverPassword = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textbox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRecoverPassword
            // 
            this.btnRecoverPassword.Location = new System.Drawing.Point(493, 242);
            this.btnRecoverPassword.Name = "btnRecoverPassword";
            this.btnRecoverPassword.Size = new System.Drawing.Size(146, 33);
            this.btnRecoverPassword.TabIndex = 0;
            this.btnRecoverPassword.Text = "Recover Password";
            this.btnRecoverPassword.UseVisualStyleBackColor = true;
            this.btnRecoverPassword.Click += new System.EventHandler(this.btnRecoverPassword_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Username";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(539, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(439, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "What is your age?";
            // 
            // textbox2
            // 
            this.textbox2.Location = new System.Drawing.Point(539, 160);
            this.textbox2.Name = "textbox2";
            this.textbox2.Size = new System.Drawing.Size(100, 20);
            this.textbox2.TabIndex = 4;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.Image = global::Act_4.Properties.Resources.pngtree_avatar_icon_profile_icon_member_login_vector_isolated_png_image_1978396;
            this.pictureBox1.Location = new System.Drawing.Point(142, 86);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(207, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // RecoverPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textbox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnRecoverPassword);
            this.Name = "RecoverPassword";
            this.ShowIcon = false;
            this.Text = "RecoverPassword";
            this.Load += new System.EventHandler(this.RecoverPassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRecoverPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textbox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
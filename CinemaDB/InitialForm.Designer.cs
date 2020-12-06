namespace CinemaDB
{
    partial class InitialForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.siTab = new System.Windows.Forms.TabPage();
            this.siButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.siPassword = new System.Windows.Forms.TextBox();
            this.siLogin = new System.Windows.Forms.TextBox();
            this.suTab = new System.Windows.Forms.TabPage();
            this.suPost = new System.Windows.Forms.ComboBox();
            this.suButton = new System.Windows.Forms.Button();
            this.suPassword2 = new System.Windows.Forms.TextBox();
            this.suPassword1 = new System.Windows.Forms.TextBox();
            this.suLogin = new System.Windows.Forms.TextBox();
            this.suName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.siTab.SuspendLayout();
            this.suTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.siTab);
            this.tabControl.Controls.Add(this.suTab);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(486, 243);
            this.tabControl.TabIndex = 0;
            // 
            // siTab
            // 
            this.siTab.Controls.Add(this.siButton);
            this.siTab.Controls.Add(this.label2);
            this.siTab.Controls.Add(this.label1);
            this.siTab.Controls.Add(this.siPassword);
            this.siTab.Controls.Add(this.siLogin);
            this.siTab.Location = new System.Drawing.Point(4, 25);
            this.siTab.Name = "siTab";
            this.siTab.Padding = new System.Windows.Forms.Padding(3);
            this.siTab.Size = new System.Drawing.Size(478, 214);
            this.siTab.TabIndex = 0;
            this.siTab.Text = "Sign In";
            this.siTab.UseVisualStyleBackColor = true;
            // 
            // siButton
            // 
            this.siButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.siButton.Location = new System.Drawing.Point(97, 97);
            this.siButton.Name = "siButton";
            this.siButton.Size = new System.Drawing.Size(75, 28);
            this.siButton.TabIndex = 4;
            this.siButton.Text = "Sign In";
            this.siButton.UseVisualStyleBackColor = true;
            this.siButton.Click += new System.EventHandler(this.siButtonClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 60);
            this.label2.MinimumSize = new System.Drawing.Size(73, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.MinimumSize = new System.Drawing.Size(73, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Login:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // siPassword
            // 
            this.siPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.siPassword.Location = new System.Drawing.Point(97, 57);
            this.siPassword.Name = "siPassword";
            this.siPassword.PasswordChar = '*';
            this.siPassword.Size = new System.Drawing.Size(373, 22);
            this.siPassword.TabIndex = 1;
            // 
            // siLogin
            // 
            this.siLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.siLogin.Location = new System.Drawing.Point(97, 17);
            this.siLogin.Name = "siLogin";
            this.siLogin.Size = new System.Drawing.Size(373, 22);
            this.siLogin.TabIndex = 0;
            // 
            // suTab
            // 
            this.suTab.Controls.Add(this.suPost);
            this.suTab.Controls.Add(this.suButton);
            this.suTab.Controls.Add(this.suPassword2);
            this.suTab.Controls.Add(this.suPassword1);
            this.suTab.Controls.Add(this.suLogin);
            this.suTab.Controls.Add(this.suName);
            this.suTab.Controls.Add(this.label7);
            this.suTab.Controls.Add(this.label6);
            this.suTab.Controls.Add(this.label5);
            this.suTab.Controls.Add(this.label4);
            this.suTab.Controls.Add(this.label3);
            this.suTab.Location = new System.Drawing.Point(4, 25);
            this.suTab.Name = "suTab";
            this.suTab.Padding = new System.Windows.Forms.Padding(3);
            this.suTab.Size = new System.Drawing.Size(478, 214);
            this.suTab.TabIndex = 1;
            this.suTab.Text = "Sign Up";
            this.suTab.UseVisualStyleBackColor = true;
            // 
            // suPost
            // 
            this.suPost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suPost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.suPost.FormattingEnabled = true;
            this.suPost.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.suPost.Location = new System.Drawing.Point(97, 177);
            this.suPost.Name = "suPost";
            this.suPost.Size = new System.Drawing.Size(292, 24);
            this.suPost.TabIndex = 9;
            // 
            // suButton
            // 
            this.suButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.suButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.suButton.Location = new System.Drawing.Point(395, 178);
            this.suButton.Name = "suButton";
            this.suButton.Size = new System.Drawing.Size(75, 28);
            this.suButton.TabIndex = 8;
            this.suButton.Text = "Sign Up";
            this.suButton.UseVisualStyleBackColor = true;
            this.suButton.Click += new System.EventHandler(this.suButtonClick);
            // 
            // suPassword2
            // 
            this.suPassword2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suPassword2.Location = new System.Drawing.Point(97, 137);
            this.suPassword2.Name = "suPassword2";
            this.suPassword2.PasswordChar = '*';
            this.suPassword2.Size = new System.Drawing.Size(373, 22);
            this.suPassword2.TabIndex = 7;
            // 
            // suPassword1
            // 
            this.suPassword1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suPassword1.Location = new System.Drawing.Point(97, 97);
            this.suPassword1.Name = "suPassword1";
            this.suPassword1.PasswordChar = '*';
            this.suPassword1.Size = new System.Drawing.Size(373, 22);
            this.suPassword1.TabIndex = 6;
            // 
            // suLogin
            // 
            this.suLogin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suLogin.Location = new System.Drawing.Point(97, 57);
            this.suLogin.Name = "suLogin";
            this.suLogin.Size = new System.Drawing.Size(373, 22);
            this.suLogin.TabIndex = 5;
            // 
            // suName
            // 
            this.suName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.suName.Location = new System.Drawing.Point(97, 17);
            this.suName.Name = "suName";
            this.suName.Size = new System.Drawing.Size(373, 22);
            this.suName.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 180);
            this.label7.MinimumSize = new System.Drawing.Size(73, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Post:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 140);
            this.label6.MinimumSize = new System.Drawing.Size(73, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Confirm:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 100);
            this.label5.MinimumSize = new System.Drawing.Size(73, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Password:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 60);
            this.label4.MinimumSize = new System.Drawing.Size(73, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Login:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 20);
            this.label3.MinimumSize = new System.Drawing.Size(73, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 243);
            this.Controls.Add(this.tabControl);
            this.MinimumSize = new System.Drawing.Size(500, 290);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl.ResumeLayout(false);
            this.siTab.ResumeLayout(false);
            this.siTab.PerformLayout();
            this.suTab.ResumeLayout(false);
            this.suTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage siTab;
        private System.Windows.Forms.TabPage suTab;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox siPassword;
        private System.Windows.Forms.TextBox siLogin;
        private System.Windows.Forms.Button siButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button suButton;
        private System.Windows.Forms.TextBox suPassword2;
        private System.Windows.Forms.TextBox suPassword1;
        private System.Windows.Forms.TextBox suLogin;
        private System.Windows.Forms.TextBox suName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox suPost;
    }
}


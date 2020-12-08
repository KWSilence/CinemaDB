namespace CinemaDB
{
    partial class DecoratorForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.profileEditClose = new System.Windows.Forms.Button();
            this.profileEdit = new System.Windows.Forms.Button();
            this.profileExit = new System.Windows.Forms.Button();
            this.profileAbout = new System.Windows.Forms.TextBox();
            this.profileContact = new System.Windows.Forms.TextBox();
            this.profileName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelPost = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.profileEditClose);
            this.tabPage1.Controls.Add(this.profileEdit);
            this.tabPage1.Controls.Add(this.profileExit);
            this.tabPage1.Controls.Add(this.profileAbout);
            this.tabPage1.Controls.Add(this.profileContact);
            this.tabPage1.Controls.Add(this.profileName);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.labelPost);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Profile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // profileEditClose
            // 
            this.profileEditClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.profileEditClose.Location = new System.Drawing.Point(159, 376);
            this.profileEditClose.Name = "profileEditClose";
            this.profileEditClose.Size = new System.Drawing.Size(75, 30);
            this.profileEditClose.TabIndex = 25;
            this.profileEditClose.Text = "Close";
            this.profileEditClose.UseVisualStyleBackColor = true;
            this.profileEditClose.Visible = false;
            this.profileEditClose.Click += new System.EventHandler(this.closeProfileEdit);
            // 
            // profileEdit
            // 
            this.profileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.profileEdit.Location = new System.Drawing.Point(78, 376);
            this.profileEdit.Name = "profileEdit";
            this.profileEdit.Size = new System.Drawing.Size(75, 30);
            this.profileEdit.TabIndex = 24;
            this.profileEdit.Text = "Edit";
            this.profileEdit.UseVisualStyleBackColor = true;
            this.profileEdit.Click += new System.EventHandler(this.editProfile);
            // 
            // profileExit
            // 
            this.profileExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.profileExit.Location = new System.Drawing.Point(709, 376);
            this.profileExit.Name = "profileExit";
            this.profileExit.Size = new System.Drawing.Size(75, 30);
            this.profileExit.TabIndex = 23;
            this.profileExit.Text = "Exit";
            this.profileExit.UseVisualStyleBackColor = true;
            this.profileExit.Click += new System.EventHandler(this.exitToInitial);
            // 
            // profileAbout
            // 
            this.profileAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileAbout.Location = new System.Drawing.Point(78, 132);
            this.profileAbout.Multiline = true;
            this.profileAbout.Name = "profileAbout";
            this.profileAbout.ReadOnly = true;
            this.profileAbout.Size = new System.Drawing.Size(706, 228);
            this.profileAbout.TabIndex = 20;
            // 
            // profileContact
            // 
            this.profileContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileContact.Location = new System.Drawing.Point(78, 92);
            this.profileContact.Name = "profileContact";
            this.profileContact.ReadOnly = true;
            this.profileContact.Size = new System.Drawing.Size(706, 22);
            this.profileContact.TabIndex = 21;
            // 
            // profileName
            // 
            this.profileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileName.Location = new System.Drawing.Point(78, 52);
            this.profileName.Name = "profileName";
            this.profileName.ReadOnly = true;
            this.profileName.Size = new System.Drawing.Size(706, 22);
            this.profileName.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "About:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Contact:";
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(10, 15);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(44, 17);
            this.labelPost.TabIndex = 17;
            this.labelPost.Text = "Post: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 18;
            this.label1.Text = "Name:";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Scene";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Decoration";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(792, 421);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Place";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // DecoratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Name = "DecoratorForm";
            this.Text = "DecoratorForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button profileEditClose;
        private System.Windows.Forms.Button profileEdit;
        private System.Windows.Forms.Button profileExit;
        private System.Windows.Forms.TextBox profileAbout;
        private System.Windows.Forms.TextBox profileContact;
        private System.Windows.Forms.TextBox profileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelPost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage4;
    }
}
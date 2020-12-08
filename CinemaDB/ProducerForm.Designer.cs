namespace CinemaDB
{
    partial class ProducerForm
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
            this.components = new System.ComponentModel.Container();
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
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.cfGenresList = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cfDescription = new System.Windows.Forms.TextBox();
            this.cfOrigin = new System.Windows.Forms.TextBox();
            this.cfName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.fSelect = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.fName = new System.Windows.Forms.TextBox();
            this.fOrigin = new System.Windows.Forms.TextBox();
            this.fDescription = new System.Windows.Forms.TextBox();
            this.fEdit = new System.Windows.Forms.Button();
            this.fClose = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cSelect = new System.Windows.Forms.ComboBox();
            this.cCreate = new System.Windows.Forms.Button();
            this.cReset = new System.Windows.Forms.Button();
            this.cEdit = new System.Windows.Forms.Button();
            this.dataChar = new System.Windows.Forms.DataGridView();
            this.dataScenario = new System.Windows.Forms.DataGridView();
            this.dataScenarioAdd = new System.Windows.Forms.DataGridView();
            this.cAdd = new System.Windows.Forms.Button();
            this.sInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scenarioAddBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsCharacter = new CinemaDB.dsCharacter();
            this.characterBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scenarioBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scenarioInfoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scenarioDocDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.requirementsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataScenario)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataScenarioAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenarioAddBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCharacter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenarioBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Controls.Add(this.tabPage4);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(752, 612);
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
            this.tabPage1.Size = new System.Drawing.Size(744, 583);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Profile";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // profileEditClose
            // 
            this.profileEditClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.profileEditClose.Location = new System.Drawing.Point(159, 545);
            this.profileEditClose.Name = "profileEditClose";
            this.profileEditClose.Size = new System.Drawing.Size(75, 30);
            this.profileEditClose.TabIndex = 15;
            this.profileEditClose.Text = "Close";
            this.profileEditClose.UseVisualStyleBackColor = true;
            this.profileEditClose.Visible = false;
            this.profileEditClose.Click += new System.EventHandler(this.closeProfileEdit);
            // 
            // profileEdit
            // 
            this.profileEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.profileEdit.Location = new System.Drawing.Point(78, 545);
            this.profileEdit.Name = "profileEdit";
            this.profileEdit.Size = new System.Drawing.Size(75, 30);
            this.profileEdit.TabIndex = 14;
            this.profileEdit.Text = "Edit";
            this.profileEdit.UseVisualStyleBackColor = true;
            this.profileEdit.Click += new System.EventHandler(this.editProfile);
            // 
            // profileExit
            // 
            this.profileExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.profileExit.Location = new System.Drawing.Point(661, 545);
            this.profileExit.Name = "profileExit";
            this.profileExit.Size = new System.Drawing.Size(75, 30);
            this.profileExit.TabIndex = 13;
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
            this.profileAbout.Size = new System.Drawing.Size(658, 407);
            this.profileAbout.TabIndex = 10;
            // 
            // profileContact
            // 
            this.profileContact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileContact.Location = new System.Drawing.Point(78, 92);
            this.profileContact.Name = "profileContact";
            this.profileContact.ReadOnly = true;
            this.profileContact.Size = new System.Drawing.Size(658, 22);
            this.profileContact.TabIndex = 11;
            // 
            // profileName
            // 
            this.profileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.profileName.Location = new System.Drawing.Point(78, 52);
            this.profileName.Name = "profileName";
            this.profileName.ReadOnly = true;
            this.profileName.Size = new System.Drawing.Size(658, 22);
            this.profileName.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "About:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "Contact:";
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(10, 15);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(44, 17);
            this.labelPost.TabIndex = 7;
            this.labelPost.Text = "Post: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.cfGenresList);
            this.tabPage5.Controls.Add(this.label7);
            this.tabPage5.Controls.Add(this.cfDescription);
            this.tabPage5.Controls.Add(this.cfOrigin);
            this.tabPage5.Controls.Add(this.cfName);
            this.tabPage5.Controls.Add(this.label6);
            this.tabPage5.Controls.Add(this.label5);
            this.tabPage5.Controls.Add(this.label2);
            this.tabPage5.Location = new System.Drawing.Point(4, 25);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(744, 583);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "CreateFilm";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // cfGenresList
            // 
            this.cfGenresList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cfGenresList.FormattingEnabled = true;
            this.cfGenresList.ItemHeight = 16;
            this.cfGenresList.Location = new System.Drawing.Point(97, 391);
            this.cfGenresList.Name = "cfGenresList";
            this.cfGenresList.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.cfGenresList.Size = new System.Drawing.Size(639, 148);
            this.cfGenresList.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 391);
            this.label7.MinimumSize = new System.Drawing.Size(83, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Genres:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cfDescription
            // 
            this.cfDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cfDescription.Location = new System.Drawing.Point(97, 69);
            this.cfDescription.Multiline = true;
            this.cfDescription.Name = "cfDescription";
            this.cfDescription.Size = new System.Drawing.Size(639, 316);
            this.cfDescription.TabIndex = 5;
            // 
            // cfOrigin
            // 
            this.cfOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cfOrigin.Location = new System.Drawing.Point(97, 41);
            this.cfOrigin.Name = "cfOrigin";
            this.cfOrigin.Size = new System.Drawing.Size(639, 22);
            this.cfOrigin.TabIndex = 4;
            // 
            // cfName
            // 
            this.cfName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cfName.Location = new System.Drawing.Point(97, 13);
            this.cfName.Name = "cfName";
            this.cfName.Size = new System.Drawing.Size(639, 22);
            this.cfName.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Description:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 44);
            this.label5.MinimumSize = new System.Drawing.Size(83, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Origin:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 16);
            this.label2.MinimumSize = new System.Drawing.Size(83, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.cAdd);
            this.tabPage2.Controls.Add(this.dataScenarioAdd);
            this.tabPage2.Controls.Add(this.dataScenario);
            this.tabPage2.Controls.Add(this.dataChar);
            this.tabPage2.Controls.Add(this.cEdit);
            this.tabPage2.Controls.Add(this.cReset);
            this.tabPage2.Controls.Add(this.cCreate);
            this.tabPage2.Controls.Add(this.cSelect);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.fClose);
            this.tabPage2.Controls.Add(this.fEdit);
            this.tabPage2.Controls.Add(this.fDescription);
            this.tabPage2.Controls.Add(this.fOrigin);
            this.tabPage2.Controls.Add(this.fName);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.fSelect);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(744, 583);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Films";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(744, 583);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Staff";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(744, 583);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Tasks";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(661, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 30);
            this.button1.TabIndex = 8;
            this.button1.Text = "Create";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.createFilm);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 15);
            this.label8.MinimumSize = new System.Drawing.Size(83, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Film:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fSelect
            // 
            this.fSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fSelect.FormattingEnabled = true;
            this.fSelect.Location = new System.Drawing.Point(97, 12);
            this.fSelect.Name = "fSelect";
            this.fSelect.Size = new System.Drawing.Size(639, 24);
            this.fSelect.TabIndex = 1;
            this.fSelect.SelectedIndexChanged += new System.EventHandler(this.fChange);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 45);
            this.label9.MinimumSize = new System.Drawing.Size(83, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Name:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Description:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 73);
            this.label11.MinimumSize = new System.Drawing.Size(83, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 17);
            this.label11.TabIndex = 2;
            this.label11.Text = "Origin:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // fName
            // 
            this.fName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fName.Location = new System.Drawing.Point(97, 42);
            this.fName.Name = "fName";
            this.fName.ReadOnly = true;
            this.fName.Size = new System.Drawing.Size(639, 22);
            this.fName.TabIndex = 3;
            // 
            // fOrigin
            // 
            this.fOrigin.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fOrigin.Location = new System.Drawing.Point(97, 70);
            this.fOrigin.Name = "fOrigin";
            this.fOrigin.ReadOnly = true;
            this.fOrigin.Size = new System.Drawing.Size(639, 22);
            this.fOrigin.TabIndex = 4;
            // 
            // fDescription
            // 
            this.fDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fDescription.Location = new System.Drawing.Point(97, 98);
            this.fDescription.Multiline = true;
            this.fDescription.Name = "fDescription";
            this.fDescription.ReadOnly = true;
            this.fDescription.Size = new System.Drawing.Size(639, 60);
            this.fDescription.TabIndex = 5;
            // 
            // fEdit
            // 
            this.fEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fEdit.Location = new System.Drawing.Point(661, 164);
            this.fEdit.Name = "fEdit";
            this.fEdit.Size = new System.Drawing.Size(75, 30);
            this.fEdit.TabIndex = 6;
            this.fEdit.Text = "Edit";
            this.fEdit.UseVisualStyleBackColor = true;
            this.fEdit.Click += new System.EventHandler(this.editFilm);
            // 
            // fClose
            // 
            this.fClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fClose.Location = new System.Drawing.Point(582, 164);
            this.fClose.Name = "fClose";
            this.fClose.Size = new System.Drawing.Size(75, 30);
            this.fClose.TabIndex = 7;
            this.fClose.Text = "Close";
            this.fClose.UseVisualStyleBackColor = true;
            this.fClose.Click += new System.EventHandler(this.closeFilmEdit);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 213);
            this.label12.MinimumSize = new System.Drawing.Size(83, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(83, 17);
            this.label12.TabIndex = 8;
            this.label12.Text = "Character:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cSelect
            // 
            this.cSelect.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cSelect.FormattingEnabled = true;
            this.cSelect.Location = new System.Drawing.Point(97, 210);
            this.cSelect.Name = "cSelect";
            this.cSelect.Size = new System.Drawing.Size(558, 24);
            this.cSelect.TabIndex = 9;
            this.cSelect.SelectedIndexChanged += new System.EventHandler(this.cChange);
            // 
            // cCreate
            // 
            this.cCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cCreate.Location = new System.Drawing.Point(661, 210);
            this.cCreate.Name = "cCreate";
            this.cCreate.Size = new System.Drawing.Size(75, 30);
            this.cCreate.TabIndex = 10;
            this.cCreate.Text = "Create";
            this.cCreate.UseVisualStyleBackColor = true;
            this.cCreate.Click += new System.EventHandler(this.createCharacter);
            // 
            // cReset
            // 
            this.cReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cReset.Location = new System.Drawing.Point(580, 545);
            this.cReset.Name = "cReset";
            this.cReset.Size = new System.Drawing.Size(75, 30);
            this.cReset.TabIndex = 11;
            this.cReset.Text = "Reset";
            this.cReset.UseVisualStyleBackColor = true;
            this.cReset.Click += new System.EventHandler(this.resetEdited);
            // 
            // cEdit
            // 
            this.cEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cEdit.Location = new System.Drawing.Point(661, 545);
            this.cEdit.Name = "cEdit";
            this.cEdit.Size = new System.Drawing.Size(75, 30);
            this.cEdit.TabIndex = 11;
            this.cEdit.Text = "Edit";
            this.cEdit.UseVisualStyleBackColor = true;
            this.cEdit.Click += new System.EventHandler(this.EditCharacter);
            // 
            // dataChar
            // 
            this.dataChar.AllowUserToAddRows = false;
            this.dataChar.AllowUserToDeleteRows = false;
            this.dataChar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataChar.AutoGenerateColumns = false;
            this.dataChar.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataChar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataChar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.requirementsDataGridViewTextBoxColumn});
            this.dataChar.DataSource = this.characterBindingSource;
            this.dataChar.Location = new System.Drawing.Point(264, 246);
            this.dataChar.Name = "dataChar";
            this.dataChar.RowHeadersWidth = 51;
            this.dataChar.RowTemplate.Height = 24;
            this.dataChar.Size = new System.Drawing.Size(472, 86);
            this.dataChar.TabIndex = 12;
            // 
            // dataScenario
            // 
            this.dataScenario.AllowUserToAddRows = false;
            this.dataScenario.AllowUserToDeleteRows = false;
            this.dataScenario.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataScenario.AutoGenerateColumns = false;
            this.dataScenario.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataScenario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataScenario.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn1,
            this.scenarioInfoDataGridViewTextBoxColumn,
            this.scenarioDocDataGridViewTextBoxColumn});
            this.dataScenario.DataSource = this.scenarioBindingSource;
            this.dataScenario.Location = new System.Drawing.Point(264, 338);
            this.dataScenario.Name = "dataScenario";
            this.dataScenario.RowHeadersWidth = 51;
            this.dataScenario.RowTemplate.Height = 24;
            this.dataScenario.Size = new System.Drawing.Size(472, 200);
            this.dataScenario.TabIndex = 13;
            // 
            // dataScenarioAdd
            // 
            this.dataScenarioAdd.AllowUserToAddRows = false;
            this.dataScenarioAdd.AllowUserToDeleteRows = false;
            this.dataScenarioAdd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataScenarioAdd.AutoGenerateColumns = false;
            this.dataScenarioAdd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataScenarioAdd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataScenarioAdd.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sInfoDataGridViewTextBoxColumn,
            this.sDocDataGridViewTextBoxColumn});
            this.dataScenarioAdd.DataSource = this.scenarioAddBindingSource;
            this.dataScenarioAdd.Location = new System.Drawing.Point(11, 246);
            this.dataScenarioAdd.Name = "dataScenarioAdd";
            this.dataScenarioAdd.RowHeadersWidth = 51;
            this.dataScenarioAdd.RowTemplate.Height = 24;
            this.dataScenarioAdd.Size = new System.Drawing.Size(247, 292);
            this.dataScenarioAdd.TabIndex = 14;
            // 
            // cAdd
            // 
            this.cAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cAdd.Location = new System.Drawing.Point(11, 545);
            this.cAdd.Name = "cAdd";
            this.cAdd.Size = new System.Drawing.Size(247, 30);
            this.cAdd.TabIndex = 15;
            this.cAdd.Text = "Add Scenario";
            this.cAdd.UseVisualStyleBackColor = true;
            this.cAdd.Click += new System.EventHandler(this.addScenario);
            // 
            // sInfoDataGridViewTextBoxColumn
            // 
            this.sInfoDataGridViewTextBoxColumn.DataPropertyName = "SInfo";
            this.sInfoDataGridViewTextBoxColumn.HeaderText = "SInfo";
            this.sInfoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sInfoDataGridViewTextBoxColumn.Name = "sInfoDataGridViewTextBoxColumn";
            this.sInfoDataGridViewTextBoxColumn.Width = 69;
            // 
            // sDocDataGridViewTextBoxColumn
            // 
            this.sDocDataGridViewTextBoxColumn.DataPropertyName = "SDoc";
            this.sDocDataGridViewTextBoxColumn.HeaderText = "SDoc";
            this.sDocDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.sDocDataGridViewTextBoxColumn.Name = "sDocDataGridViewTextBoxColumn";
            this.sDocDataGridViewTextBoxColumn.Width = 71;
            // 
            // scenarioAddBindingSource
            // 
            this.scenarioAddBindingSource.DataMember = "ScenarioAdd";
            this.scenarioAddBindingSource.DataSource = this.dsCharacter;
            // 
            // dsCharacter
            // 
            this.dsCharacter.DataSetName = "dsCharacter";
            this.dsCharacter.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // characterBindingSource
            // 
            this.characterBindingSource.DataMember = "Character";
            this.characterBindingSource.DataSource = this.dsCharacter;
            // 
            // scenarioBindingSource
            // 
            this.scenarioBindingSource.DataMember = "Scenario";
            this.scenarioBindingSource.DataSource = this.dsCharacter;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            this.idDataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn1.HeaderText = "id";
            this.idDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            this.idDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idDataGridViewTextBoxColumn1.Width = 48;
            // 
            // scenarioInfoDataGridViewTextBoxColumn
            // 
            this.scenarioInfoDataGridViewTextBoxColumn.DataPropertyName = "ScenarioInfo";
            this.scenarioInfoDataGridViewTextBoxColumn.HeaderText = "ScenarioInfo";
            this.scenarioInfoDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.scenarioInfoDataGridViewTextBoxColumn.Name = "scenarioInfoDataGridViewTextBoxColumn";
            this.scenarioInfoDataGridViewTextBoxColumn.Width = 116;
            // 
            // scenarioDocDataGridViewTextBoxColumn
            // 
            this.scenarioDocDataGridViewTextBoxColumn.DataPropertyName = "ScenarioDoc";
            this.scenarioDocDataGridViewTextBoxColumn.HeaderText = "ScenarioDoc";
            this.scenarioDocDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.scenarioDocDataGridViewTextBoxColumn.Name = "scenarioDocDataGridViewTextBoxColumn";
            this.scenarioDocDataGridViewTextBoxColumn.Width = 118;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Width = 48;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "name";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 72;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 106;
            // 
            // requirementsDataGridViewTextBoxColumn
            // 
            this.requirementsDataGridViewTextBoxColumn.DataPropertyName = "requirements";
            this.requirementsDataGridViewTextBoxColumn.HeaderText = "requirements";
            this.requirementsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.requirementsDataGridViewTextBoxColumn.Name = "requirementsDataGridViewTextBoxColumn";
            this.requirementsDataGridViewTextBoxColumn.Width = 120;
            // 
            // ProducerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 612);
            this.Controls.Add(this.tabControl);
            this.Name = "ProducerForm";
            this.Text = "ProducerForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.onClose);
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataChar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataScenario)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataScenarioAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenarioAddBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsCharacter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.characterBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scenarioBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
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
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox cfDescription;
        private System.Windows.Forms.TextBox cfOrigin;
        private System.Windows.Forms.TextBox cfName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox cfGenresList;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox fDescription;
        private System.Windows.Forms.TextBox fOrigin;
        private System.Windows.Forms.TextBox fName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox fSelect;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button fClose;
        private System.Windows.Forms.Button fEdit;
        private System.Windows.Forms.Button cEdit;
        private System.Windows.Forms.Button cReset;
        private System.Windows.Forms.Button cCreate;
        private System.Windows.Forms.ComboBox cSelect;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dataChar;
        private System.Windows.Forms.DataGridViewTextBoxColumn requireDataGridViewTextBoxColumn;
        private dsCharacter dsCharacter;
        private System.Windows.Forms.DataGridView dataScenario;
        private System.Windows.Forms.DataGridView dataScenarioAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn sInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource scenarioAddBindingSource;
        private System.Windows.Forms.Button cAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn scenarioInfoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scenarioDocDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource scenarioBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn requirementsDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource characterBindingSource;
    }
}
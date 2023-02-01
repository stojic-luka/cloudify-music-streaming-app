
namespace C1oudify
{
    partial class login_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login_form));
            Utilities.BunifuPages.BunifuAnimatorNS.Animation animation1 = new Utilities.BunifuPages.BunifuAnimatorNS.Animation();
            this.top_panel = new System.Windows.Forms.Panel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.green_button_tray = new Bunifu.UI.WinForms.BunifuImageButton();
            this.red_button_exit = new Bunifu.UI.WinForms.BunifuImageButton();
            this.startup_login_pages = new Bunifu.UI.WinForms.BunifuPages();
            this.login_page = new System.Windows.Forms.TabPage();
            this.show_hide_password = new System.Windows.Forms.Button();
            this.goto_signin_page = new System.Windows.Forms.Button();
            this.login_button = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.bad_input_login_label = new System.Windows.Forms.Label();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.login_password_textbox = new System.Windows.Forms.TextBox();
            this.signin_page = new System.Windows.Forms.TabPage();
            this.show_hide_signin_confirm_password = new System.Windows.Forms.Button();
            this.show_hide_signin_password = new System.Windows.Forms.Button();
            this.signin_button = new System.Windows.Forms.Button();
            this.goto_login_page = new System.Windows.Forms.Button();
            this.login_check_indicator = new System.Windows.Forms.PictureBox();
            this.bad_input_signin_label = new System.Windows.Forms.Label();
            this.username_already_exist_label = new System.Windows.Forms.Label();
            this.passwords_not_match_labes = new System.Windows.Forms.Label();
            this.pass_confirm_textbox_singin = new System.Windows.Forms.TextBox();
            this.pass_textbox_singin = new System.Windows.Forms.TextBox();
            this.email_textbox_signin = new System.Windows.Forms.TextBox();
            this.username_textbox_signin = new System.Windows.Forms.TextBox();
            this.email_confirm_page = new System.Windows.Forms.TabPage();
            this.check_email_confirm_code_button = new System.Windows.Forms.Button();
            this.wrong_code_label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.confirmation_code_textbox = new System.Windows.Forms.TextBox();
            this.phone_bday_page = new System.Windows.Forms.TabPage();
            this.phone_and_bday_skip_button = new System.Windows.Forms.Button();
            this.phone_and_bday_finish = new System.Windows.Forms.Button();
            this.phone_num_textbox = new System.Windows.Forms.TextBox();
            this.year_dropdown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.month_dropdown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.day_dropdown = new Bunifu.UI.WinForms.BunifuDropdown();
            this.account_made_page = new System.Windows.Forms.TabPage();
            this.top_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.startup_login_pages.SuspendLayout();
            this.login_page.SuspendLayout();
            this.signin_page.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_check_indicator)).BeginInit();
            this.email_confirm_page.SuspendLayout();
            this.phone_bday_page.SuspendLayout();
            this.SuspendLayout();
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.top_panel.Controls.Add(this.pictureBox2);
            this.top_panel.Controls.Add(this.green_button_tray);
            this.top_panel.Controls.Add(this.red_button_exit);
            this.top_panel.Dock = System.Windows.Forms.DockStyle.Top;
            this.top_panel.Location = new System.Drawing.Point(2, 2);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(956, 30);
            this.top_panel.TabIndex = 1;
            this.top_panel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.top_panel_MouseDown);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::C1oudify.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(74, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(23, 23);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // green_button_tray
            // 
            this.green_button_tray.ActiveImage = null;
            this.green_button_tray.AllowAnimations = true;
            this.green_button_tray.AllowBuffering = false;
            this.green_button_tray.AllowToggling = false;
            this.green_button_tray.AllowZooming = false;
            this.green_button_tray.AllowZoomingOnFocus = false;
            this.green_button_tray.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.green_button_tray.BackColor = System.Drawing.Color.Transparent;
            this.green_button_tray.DialogResult = System.Windows.Forms.DialogResult.None;
            this.green_button_tray.ErrorImage = ((System.Drawing.Image)(resources.GetObject("green_button_tray.ErrorImage")));
            this.green_button_tray.FadeWhenInactive = false;
            this.green_button_tray.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.green_button_tray.Image = global::C1oudify.Properties.Resources.green_button;
            this.green_button_tray.ImageActive = null;
            this.green_button_tray.ImageLocation = null;
            this.green_button_tray.ImageMargin = 0;
            this.green_button_tray.ImageSize = new System.Drawing.Size(17, 17);
            this.green_button_tray.ImageZoomSize = new System.Drawing.Size(17, 17);
            this.green_button_tray.ImeMode = System.Windows.Forms.ImeMode.On;
            this.green_button_tray.InitialImage = ((System.Drawing.Image)(resources.GetObject("green_button_tray.InitialImage")));
            this.green_button_tray.Location = new System.Drawing.Point(908, 6);
            this.green_button_tray.Name = "green_button_tray";
            this.green_button_tray.Rotation = 0;
            this.green_button_tray.ShowActiveImage = true;
            this.green_button_tray.ShowCursorChanges = true;
            this.green_button_tray.ShowImageBorders = true;
            this.green_button_tray.ShowSizeMarkers = false;
            this.green_button_tray.Size = new System.Drawing.Size(17, 17);
            this.green_button_tray.TabIndex = 15;
            this.green_button_tray.ToolTipText = "";
            this.green_button_tray.WaitOnLoad = false;
            this.green_button_tray.Zoom = 0;
            this.green_button_tray.ZoomSpeed = 10;
            this.green_button_tray.Click += new System.EventHandler(this.green_button_tray_Click);
            // 
            // red_button_exit
            // 
            this.red_button_exit.ActiveImage = null;
            this.red_button_exit.AllowAnimations = true;
            this.red_button_exit.AllowBuffering = false;
            this.red_button_exit.AllowToggling = false;
            this.red_button_exit.AllowZooming = false;
            this.red_button_exit.AllowZoomingOnFocus = false;
            this.red_button_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.red_button_exit.BackColor = System.Drawing.Color.Transparent;
            this.red_button_exit.DialogResult = System.Windows.Forms.DialogResult.None;
            this.red_button_exit.ErrorImage = ((System.Drawing.Image)(resources.GetObject("red_button_exit.ErrorImage")));
            this.red_button_exit.FadeWhenInactive = false;
            this.red_button_exit.Flip = Bunifu.UI.WinForms.BunifuImageButton.FlipOrientation.Normal;
            this.red_button_exit.Image = global::C1oudify.Properties.Resources.red_button;
            this.red_button_exit.ImageActive = null;
            this.red_button_exit.ImageLocation = null;
            this.red_button_exit.ImageMargin = 0;
            this.red_button_exit.ImageSize = new System.Drawing.Size(17, 17);
            this.red_button_exit.ImageZoomSize = new System.Drawing.Size(17, 17);
            this.red_button_exit.ImeMode = System.Windows.Forms.ImeMode.On;
            this.red_button_exit.InitialImage = ((System.Drawing.Image)(resources.GetObject("red_button_exit.InitialImage")));
            this.red_button_exit.Location = new System.Drawing.Point(933, 6);
            this.red_button_exit.Name = "red_button_exit";
            this.red_button_exit.Rotation = 0;
            this.red_button_exit.ShowActiveImage = true;
            this.red_button_exit.ShowCursorChanges = true;
            this.red_button_exit.ShowImageBorders = true;
            this.red_button_exit.ShowSizeMarkers = false;
            this.red_button_exit.Size = new System.Drawing.Size(17, 17);
            this.red_button_exit.TabIndex = 13;
            this.red_button_exit.ToolTipText = "";
            this.red_button_exit.WaitOnLoad = false;
            this.red_button_exit.Zoom = 0;
            this.red_button_exit.ZoomSpeed = 10;
            this.red_button_exit.Click += new System.EventHandler(this.red_button_exit_Click);
            // 
            // startup_login_pages
            // 
            this.startup_login_pages.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.startup_login_pages.AllowTransitions = false;
            this.startup_login_pages.Controls.Add(this.login_page);
            this.startup_login_pages.Controls.Add(this.signin_page);
            this.startup_login_pages.Controls.Add(this.email_confirm_page);
            this.startup_login_pages.Controls.Add(this.phone_bday_page);
            this.startup_login_pages.Controls.Add(this.account_made_page);
            this.startup_login_pages.Location = new System.Drawing.Point(0, 34);
            this.startup_login_pages.Multiline = true;
            this.startup_login_pages.Name = "startup_login_pages";
            this.startup_login_pages.Page = this.phone_bday_page;
            this.startup_login_pages.PageIndex = 3;
            this.startup_login_pages.PageName = "phone_bday_page";
            this.startup_login_pages.PageTitle = "Phone and Bday";
            this.startup_login_pages.SelectedIndex = 0;
            this.startup_login_pages.Size = new System.Drawing.Size(960, 540);
            this.startup_login_pages.TabIndex = 8;
            animation1.AnimateOnlyDifferences = false;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 0F;
            this.startup_login_pages.Transition = animation1;
            this.startup_login_pages.TransitionType = Utilities.BunifuPages.BunifuAnimatorNS.AnimationType.Custom;
            this.startup_login_pages.SelectedIndexChanged += new System.EventHandler(this.startup_login_pages_SelectedIndexChanged);
            this.startup_login_pages.Click += new System.EventHandler(this.click_to_search_login);
            // 
            // login_page
            // 
            this.login_page.BackColor = System.Drawing.Color.Black;
            this.login_page.BackgroundImage = global::C1oudify.Properties.Resources.login_background;
            this.login_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.login_page.Controls.Add(this.show_hide_password);
            this.login_page.Controls.Add(this.goto_signin_page);
            this.login_page.Controls.Add(this.login_button);
            this.login_page.Controls.Add(this.button3);
            this.login_page.Controls.Add(this.bad_input_login_label);
            this.login_page.Controls.Add(this.username_textbox);
            this.login_page.Controls.Add(this.login_password_textbox);
            this.login_page.Location = new System.Drawing.Point(4, 4);
            this.login_page.Name = "login_page";
            this.login_page.Padding = new System.Windows.Forms.Padding(3);
            this.login_page.Size = new System.Drawing.Size(952, 514);
            this.login_page.TabIndex = 0;
            this.login_page.Text = "Login";
            // 
            // show_hide_password
            // 
            this.show_hide_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.show_hide_password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.show_hide_password.BackgroundImage = global::C1oudify.Properties.Resources.close_eye;
            this.show_hide_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show_hide_password.FlatAppearance.BorderSize = 0;
            this.show_hide_password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_hide_password.Location = new System.Drawing.Point(544, 213);
            this.show_hide_password.Name = "show_hide_password";
            this.show_hide_password.Size = new System.Drawing.Size(22, 22);
            this.show_hide_password.TabIndex = 50;
            this.show_hide_password.UseVisualStyleBackColor = false;
            this.show_hide_password.Click += new System.EventHandler(this.show_hide_password_Click);
            // 
            // goto_signin_page
            // 
            this.goto_signin_page.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.goto_signin_page.BackColor = System.Drawing.Color.Gainsboro;
            this.goto_signin_page.Location = new System.Drawing.Point(459, 250);
            this.goto_signin_page.Name = "goto_signin_page";
            this.goto_signin_page.Size = new System.Drawing.Size(118, 29);
            this.goto_signin_page.TabIndex = 23;
            this.goto_signin_page.Text = "confirm email";
            this.goto_signin_page.UseVisualStyleBackColor = false;
            this.goto_signin_page.Click += new System.EventHandler(this.goto_signin_page_Click);
            // 
            // login_button
            // 
            this.login_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login_button.BackColor = System.Drawing.Color.Gainsboro;
            this.login_button.Location = new System.Drawing.Point(331, 248);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(118, 29);
            this.login_button.TabIndex = 22;
            this.login_button.Text = "confirm email";
            this.login_button.UseVisualStyleBackColor = false;
            this.login_button.Click += new System.EventHandler(this.click_to_search_login);
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button3.BackColor = System.Drawing.Color.Maroon;
            this.button3.ForeColor = System.Drawing.Color.DimGray;
            this.button3.Location = new System.Drawing.Point(643, 329);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // bad_input_login_label
            // 
            this.bad_input_login_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bad_input_login_label.AutoSize = true;
            this.bad_input_login_label.BackColor = System.Drawing.Color.Transparent;
            this.bad_input_login_label.ForeColor = System.Drawing.Color.White;
            this.bad_input_login_label.Location = new System.Drawing.Point(375, 149);
            this.bad_input_login_label.Name = "bad_input_login_label";
            this.bad_input_login_label.Size = new System.Drawing.Size(169, 13);
            this.bad_input_login_label.TabIndex = 13;
            this.bad_input_login_label.Text = "Username or password not correct";
            this.bad_input_login_label.Visible = false;
            // 
            // username_textbox
            // 
            this.username_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.username_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.username_textbox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.username_textbox.Location = new System.Drawing.Point(336, 184);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(234, 20);
            this.username_textbox.TabIndex = 8;
            this.username_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_to_search_login);
            // 
            // login_password_textbox
            // 
            this.login_password_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login_password_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.login_password_textbox.ForeColor = System.Drawing.SystemColors.InfoText;
            this.login_password_textbox.Location = new System.Drawing.Point(335, 213);
            this.login_password_textbox.Name = "login_password_textbox";
            this.login_password_textbox.Size = new System.Drawing.Size(231, 20);
            this.login_password_textbox.TabIndex = 9;
            this.login_password_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_to_search_login);
            // 
            // signin_page
            // 
            this.signin_page.BackColor = System.Drawing.Color.Black;
            this.signin_page.BackgroundImage = global::C1oudify.Properties.Resources.login_background;
            this.signin_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.signin_page.Controls.Add(this.show_hide_signin_confirm_password);
            this.signin_page.Controls.Add(this.show_hide_signin_password);
            this.signin_page.Controls.Add(this.signin_button);
            this.signin_page.Controls.Add(this.goto_login_page);
            this.signin_page.Controls.Add(this.login_check_indicator);
            this.signin_page.Controls.Add(this.bad_input_signin_label);
            this.signin_page.Controls.Add(this.username_already_exist_label);
            this.signin_page.Controls.Add(this.passwords_not_match_labes);
            this.signin_page.Controls.Add(this.pass_confirm_textbox_singin);
            this.signin_page.Controls.Add(this.pass_textbox_singin);
            this.signin_page.Controls.Add(this.email_textbox_signin);
            this.signin_page.Controls.Add(this.username_textbox_signin);
            this.signin_page.Location = new System.Drawing.Point(4, 4);
            this.signin_page.Name = "signin_page";
            this.signin_page.Padding = new System.Windows.Forms.Padding(3);
            this.signin_page.Size = new System.Drawing.Size(952, 514);
            this.signin_page.TabIndex = 1;
            this.signin_page.Text = "Sign In";
            // 
            // show_hide_signin_confirm_password
            // 
            this.show_hide_signin_confirm_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.show_hide_signin_confirm_password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.show_hide_signin_confirm_password.BackgroundImage = global::C1oudify.Properties.Resources.close_eye;
            this.show_hide_signin_confirm_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show_hide_signin_confirm_password.FlatAppearance.BorderSize = 0;
            this.show_hide_signin_confirm_password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_hide_signin_confirm_password.Location = new System.Drawing.Point(528, 275);
            this.show_hide_signin_confirm_password.Name = "show_hide_signin_confirm_password";
            this.show_hide_signin_confirm_password.Size = new System.Drawing.Size(22, 22);
            this.show_hide_signin_confirm_password.TabIndex = 50;
            this.show_hide_signin_confirm_password.UseVisualStyleBackColor = false;
            this.show_hide_signin_confirm_password.Click += new System.EventHandler(this.show_hide_password_Click);
            // 
            // show_hide_signin_password
            // 
            this.show_hide_signin_password.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.show_hide_signin_password.BackColor = System.Drawing.Color.WhiteSmoke;
            this.show_hide_signin_password.BackgroundImage = global::C1oudify.Properties.Resources.close_eye;
            this.show_hide_signin_password.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.show_hide_signin_password.FlatAppearance.BorderSize = 0;
            this.show_hide_signin_password.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.show_hide_signin_password.Location = new System.Drawing.Point(526, 248);
            this.show_hide_signin_password.Name = "show_hide_signin_password";
            this.show_hide_signin_password.Size = new System.Drawing.Size(22, 22);
            this.show_hide_signin_password.TabIndex = 49;
            this.show_hide_signin_password.UseVisualStyleBackColor = false;
            this.show_hide_signin_password.Click += new System.EventHandler(this.show_hide_password_Click);
            // 
            // signin_button
            // 
            this.signin_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.signin_button.BackColor = System.Drawing.Color.Gainsboro;
            this.signin_button.Location = new System.Drawing.Point(437, 317);
            this.signin_button.Name = "signin_button";
            this.signin_button.Size = new System.Drawing.Size(118, 29);
            this.signin_button.TabIndex = 48;
            this.signin_button.Text = "confirm email";
            this.signin_button.UseVisualStyleBackColor = false;
            this.signin_button.Click += new System.EventHandler(this.click_to_search_singin);
            // 
            // goto_login_page
            // 
            this.goto_login_page.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.goto_login_page.BackColor = System.Drawing.Color.Gainsboro;
            this.goto_login_page.Location = new System.Drawing.Point(311, 318);
            this.goto_login_page.Name = "goto_login_page";
            this.goto_login_page.Size = new System.Drawing.Size(118, 29);
            this.goto_login_page.TabIndex = 47;
            this.goto_login_page.Text = "confirm email";
            this.goto_login_page.UseVisualStyleBackColor = false;
            this.goto_login_page.Click += new System.EventHandler(this.goto_login_page_Click);
            // 
            // login_check_indicator
            // 
            this.login_check_indicator.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.login_check_indicator.BackColor = System.Drawing.Color.WhiteSmoke;
            this.login_check_indicator.BackgroundImage = global::C1oudify.Properties.Resources.red_x;
            this.login_check_indicator.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.login_check_indicator.Location = new System.Drawing.Point(525, 194);
            this.login_check_indicator.Name = "login_check_indicator";
            this.login_check_indicator.Size = new System.Drawing.Size(22, 22);
            this.login_check_indicator.TabIndex = 28;
            this.login_check_indicator.TabStop = false;
            // 
            // bad_input_signin_label
            // 
            this.bad_input_signin_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bad_input_signin_label.AutoSize = true;
            this.bad_input_signin_label.BackColor = System.Drawing.Color.Transparent;
            this.bad_input_signin_label.ForeColor = System.Drawing.Color.White;
            this.bad_input_signin_label.Location = new System.Drawing.Point(322, 113);
            this.bad_input_signin_label.Name = "bad_input_signin_label";
            this.bad_input_signin_label.Size = new System.Drawing.Size(229, 13);
            this.bad_input_signin_label.TabIndex = 25;
            this.bad_input_signin_label.Text = "Bad input, make sure there are no empty boxes";
            this.bad_input_signin_label.Visible = false;
            // 
            // username_already_exist_label
            // 
            this.username_already_exist_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.username_already_exist_label.AutoSize = true;
            this.username_already_exist_label.BackColor = System.Drawing.Color.Transparent;
            this.username_already_exist_label.ForeColor = System.Drawing.Color.White;
            this.username_already_exist_label.Location = new System.Drawing.Point(371, 137);
            this.username_already_exist_label.Name = "username_already_exist_label";
            this.username_already_exist_label.Size = new System.Drawing.Size(116, 13);
            this.username_already_exist_label.TabIndex = 23;
            this.username_already_exist_label.Text = "Username already exist";
            this.username_already_exist_label.Visible = false;
            // 
            // passwords_not_match_labes
            // 
            this.passwords_not_match_labes.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.passwords_not_match_labes.AutoSize = true;
            this.passwords_not_match_labes.BackColor = System.Drawing.Color.Transparent;
            this.passwords_not_match_labes.ForeColor = System.Drawing.Color.White;
            this.passwords_not_match_labes.Location = new System.Drawing.Point(369, 162);
            this.passwords_not_match_labes.Name = "passwords_not_match_labes";
            this.passwords_not_match_labes.Size = new System.Drawing.Size(123, 13);
            this.passwords_not_match_labes.TabIndex = 22;
            this.passwords_not_match_labes.Text = "Passwords do not match";
            this.passwords_not_match_labes.Visible = false;
            // 
            // pass_confirm_textbox_singin
            // 
            this.pass_confirm_textbox_singin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass_confirm_textbox_singin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pass_confirm_textbox_singin.Location = new System.Drawing.Point(320, 276);
            this.pass_confirm_textbox_singin.Name = "pass_confirm_textbox_singin";
            this.pass_confirm_textbox_singin.Size = new System.Drawing.Size(229, 20);
            this.pass_confirm_textbox_singin.TabIndex = 19;
            this.pass_confirm_textbox_singin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_to_search_signin);
            // 
            // pass_textbox_singin
            // 
            this.pass_textbox_singin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pass_textbox_singin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pass_textbox_singin.Location = new System.Drawing.Point(320, 250);
            this.pass_textbox_singin.Name = "pass_textbox_singin";
            this.pass_textbox_singin.Size = new System.Drawing.Size(229, 20);
            this.pass_textbox_singin.TabIndex = 18;
            this.pass_textbox_singin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_to_search_signin);
            // 
            // email_textbox_signin
            // 
            this.email_textbox_signin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.email_textbox_signin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.email_textbox_signin.Location = new System.Drawing.Point(319, 222);
            this.email_textbox_signin.Name = "email_textbox_signin";
            this.email_textbox_signin.Size = new System.Drawing.Size(229, 20);
            this.email_textbox_signin.TabIndex = 17;
            this.email_textbox_signin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_to_search_signin);
            // 
            // username_textbox_signin
            // 
            this.username_textbox_signin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.username_textbox_signin.BackColor = System.Drawing.Color.WhiteSmoke;
            this.username_textbox_signin.Location = new System.Drawing.Point(318, 195);
            this.username_textbox_signin.Name = "username_textbox_signin";
            this.username_textbox_signin.Size = new System.Drawing.Size(229, 20);
            this.username_textbox_signin.TabIndex = 16;
            this.username_textbox_signin.TextChanged += new System.EventHandler(this.username_textbox_signin_TextChanged);
            this.username_textbox_signin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enter_to_search_signin);
            // 
            // email_confirm_page
            // 
            this.email_confirm_page.BackColor = System.Drawing.Color.Black;
            this.email_confirm_page.BackgroundImage = global::C1oudify.Properties.Resources.login_background;
            this.email_confirm_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.email_confirm_page.Controls.Add(this.check_email_confirm_code_button);
            this.email_confirm_page.Controls.Add(this.wrong_code_label);
            this.email_confirm_page.Controls.Add(this.label2);
            this.email_confirm_page.Controls.Add(this.confirmation_code_textbox);
            this.email_confirm_page.Location = new System.Drawing.Point(4, 4);
            this.email_confirm_page.Name = "email_confirm_page";
            this.email_confirm_page.Padding = new System.Windows.Forms.Padding(3);
            this.email_confirm_page.Size = new System.Drawing.Size(952, 514);
            this.email_confirm_page.TabIndex = 2;
            this.email_confirm_page.Text = "Email Confirm";
            // 
            // check_email_confirm_code_button
            // 
            this.check_email_confirm_code_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.check_email_confirm_code_button.BackColor = System.Drawing.Color.Gainsboro;
            this.check_email_confirm_code_button.Location = new System.Drawing.Point(384, 242);
            this.check_email_confirm_code_button.Name = "check_email_confirm_code_button";
            this.check_email_confirm_code_button.Size = new System.Drawing.Size(118, 29);
            this.check_email_confirm_code_button.TabIndex = 21;
            this.check_email_confirm_code_button.Text = "confirm email";
            this.check_email_confirm_code_button.UseVisualStyleBackColor = false;
            this.check_email_confirm_code_button.Click += new System.EventHandler(this.check_email_confirm_code_button_button_Click);
            // 
            // wrong_code_label
            // 
            this.wrong_code_label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.wrong_code_label.AutoSize = true;
            this.wrong_code_label.BackColor = System.Drawing.Color.Transparent;
            this.wrong_code_label.ForeColor = System.Drawing.Color.White;
            this.wrong_code_label.Location = new System.Drawing.Point(399, 113);
            this.wrong_code_label.Name = "wrong_code_label";
            this.wrong_code_label.Size = new System.Drawing.Size(66, 13);
            this.wrong_code_label.TabIndex = 20;
            this.wrong_code_label.Text = "Wrong code";
            this.wrong_code_label.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(358, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Please enter the code we sent you";
            // 
            // confirmation_code_textbox
            // 
            this.confirmation_code_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.confirmation_code_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.confirmation_code_textbox.Location = new System.Drawing.Point(330, 206);
            this.confirmation_code_textbox.Name = "confirmation_code_textbox";
            this.confirmation_code_textbox.Size = new System.Drawing.Size(229, 20);
            this.confirmation_code_textbox.TabIndex = 17;
            // 
            // phone_bday_page
            // 
            this.phone_bday_page.BackColor = System.Drawing.Color.Black;
            this.phone_bday_page.BackgroundImage = global::C1oudify.Properties.Resources.login_background;
            this.phone_bday_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.phone_bday_page.Controls.Add(this.phone_and_bday_skip_button);
            this.phone_bday_page.Controls.Add(this.phone_and_bday_finish);
            this.phone_bday_page.Controls.Add(this.phone_num_textbox);
            this.phone_bday_page.Controls.Add(this.year_dropdown);
            this.phone_bday_page.Controls.Add(this.month_dropdown);
            this.phone_bday_page.Controls.Add(this.day_dropdown);
            this.phone_bday_page.Location = new System.Drawing.Point(4, 4);
            this.phone_bday_page.Name = "phone_bday_page";
            this.phone_bday_page.Padding = new System.Windows.Forms.Padding(3);
            this.phone_bday_page.Size = new System.Drawing.Size(952, 514);
            this.phone_bday_page.TabIndex = 3;
            this.phone_bday_page.Text = "Phone and Bday";
            // 
            // phone_and_bday_skip_button
            // 
            this.phone_and_bday_skip_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.phone_and_bday_skip_button.BackColor = System.Drawing.Color.Gainsboro;
            this.phone_and_bday_skip_button.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.phone_and_bday_skip_button.ForeColor = System.Drawing.Color.Black;
            this.phone_and_bday_skip_button.Location = new System.Drawing.Point(378, 278);
            this.phone_and_bday_skip_button.Name = "phone_and_bday_skip_button";
            this.phone_and_bday_skip_button.Size = new System.Drawing.Size(75, 23);
            this.phone_and_bday_skip_button.TabIndex = 20;
            this.phone_and_bday_skip_button.Text = "skip";
            this.phone_and_bday_skip_button.UseVisualStyleBackColor = false;
            this.phone_and_bday_skip_button.Click += new System.EventHandler(this.send_sign_in_info);
            // 
            // phone_and_bday_finish
            // 
            this.phone_and_bday_finish.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.phone_and_bday_finish.BackColor = System.Drawing.Color.Gainsboro;
            this.phone_and_bday_finish.Location = new System.Drawing.Point(498, 281);
            this.phone_and_bday_finish.Name = "phone_and_bday_finish";
            this.phone_and_bday_finish.Size = new System.Drawing.Size(75, 23);
            this.phone_and_bday_finish.TabIndex = 19;
            this.phone_and_bday_finish.Text = "finish";
            this.phone_and_bday_finish.UseVisualStyleBackColor = false;
            this.phone_and_bday_finish.Click += new System.EventHandler(this.send_sign_in_info);
            // 
            // phone_num_textbox
            // 
            this.phone_num_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.phone_num_textbox.BackColor = System.Drawing.Color.WhiteSmoke;
            this.phone_num_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.phone_num_textbox.Location = new System.Drawing.Point(354, 235);
            this.phone_num_textbox.Name = "phone_num_textbox";
            this.phone_num_textbox.Size = new System.Drawing.Size(250, 20);
            this.phone_num_textbox.TabIndex = 18;
            // 
            // year_dropdown
            // 
            this.year_dropdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.year_dropdown.BackColor = System.Drawing.Color.Transparent;
            this.year_dropdown.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.year_dropdown.BorderColor = System.Drawing.Color.Silver;
            this.year_dropdown.BorderRadius = 1;
            this.year_dropdown.Color = System.Drawing.Color.Silver;
            this.year_dropdown.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.year_dropdown.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.year_dropdown.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.year_dropdown.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.year_dropdown.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.year_dropdown.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.year_dropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.year_dropdown.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.year_dropdown.DropDownHeight = 75;
            this.year_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.year_dropdown.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.year_dropdown.FillDropDown = true;
            this.year_dropdown.FillIndicator = false;
            this.year_dropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.year_dropdown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.year_dropdown.ForeColor = System.Drawing.Color.Black;
            this.year_dropdown.FormattingEnabled = true;
            this.year_dropdown.Icon = null;
            this.year_dropdown.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.year_dropdown.IndicatorColor = System.Drawing.Color.Gray;
            this.year_dropdown.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.year_dropdown.IntegralHeight = false;
            this.year_dropdown.ItemBackColor = System.Drawing.Color.White;
            this.year_dropdown.ItemBorderColor = System.Drawing.Color.White;
            this.year_dropdown.ItemForeColor = System.Drawing.Color.Black;
            this.year_dropdown.ItemHeight = 17;
            this.year_dropdown.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.year_dropdown.ItemHighLightForeColor = System.Drawing.Color.White;
            this.year_dropdown.ItemTopMargin = 3;
            this.year_dropdown.Location = new System.Drawing.Point(539, 158);
            this.year_dropdown.Name = "year_dropdown";
            this.year_dropdown.Size = new System.Drawing.Size(65, 23);
            this.year_dropdown.TabIndex = 2;
            this.year_dropdown.Text = null;
            this.year_dropdown.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.year_dropdown.TextLeftMargin = 5;
            // 
            // month_dropdown
            // 
            this.month_dropdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.month_dropdown.BackColor = System.Drawing.Color.Transparent;
            this.month_dropdown.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.month_dropdown.BorderColor = System.Drawing.Color.Silver;
            this.month_dropdown.BorderRadius = 1;
            this.month_dropdown.Color = System.Drawing.Color.Silver;
            this.month_dropdown.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.month_dropdown.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.month_dropdown.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.month_dropdown.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.month_dropdown.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.month_dropdown.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.month_dropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.month_dropdown.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.month_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.month_dropdown.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.month_dropdown.FillDropDown = true;
            this.month_dropdown.FillIndicator = false;
            this.month_dropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.month_dropdown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.month_dropdown.ForeColor = System.Drawing.Color.Black;
            this.month_dropdown.FormattingEnabled = true;
            this.month_dropdown.Icon = null;
            this.month_dropdown.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.month_dropdown.IndicatorColor = System.Drawing.Color.Gray;
            this.month_dropdown.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.month_dropdown.IntegralHeight = false;
            this.month_dropdown.ItemBackColor = System.Drawing.Color.White;
            this.month_dropdown.ItemBorderColor = System.Drawing.Color.White;
            this.month_dropdown.ItemForeColor = System.Drawing.Color.Black;
            this.month_dropdown.ItemHeight = 17;
            this.month_dropdown.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.month_dropdown.ItemHighLightForeColor = System.Drawing.Color.White;
            this.month_dropdown.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.month_dropdown.ItemTopMargin = 3;
            this.month_dropdown.Location = new System.Drawing.Point(356, 164);
            this.month_dropdown.Name = "month_dropdown";
            this.month_dropdown.Size = new System.Drawing.Size(65, 23);
            this.month_dropdown.TabIndex = 1;
            this.month_dropdown.Text = null;
            this.month_dropdown.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.month_dropdown.TextLeftMargin = 5;
            this.month_dropdown.SelectedValueChanged += new System.EventHandler(this.month_dropdown_SelectedValueChanged);
            // 
            // day_dropdown
            // 
            this.day_dropdown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.day_dropdown.BackColor = System.Drawing.Color.Transparent;
            this.day_dropdown.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.day_dropdown.BorderColor = System.Drawing.Color.Silver;
            this.day_dropdown.BorderRadius = 1;
            this.day_dropdown.Color = System.Drawing.Color.Silver;
            this.day_dropdown.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.day_dropdown.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.day_dropdown.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.day_dropdown.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.day_dropdown.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.day_dropdown.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.day_dropdown.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.day_dropdown.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.day_dropdown.DropDownHeight = 75;
            this.day_dropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.day_dropdown.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.day_dropdown.FillDropDown = true;
            this.day_dropdown.FillIndicator = false;
            this.day_dropdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.day_dropdown.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.day_dropdown.ForeColor = System.Drawing.Color.Black;
            this.day_dropdown.FormattingEnabled = true;
            this.day_dropdown.Icon = null;
            this.day_dropdown.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.day_dropdown.IndicatorColor = System.Drawing.Color.Gray;
            this.day_dropdown.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.day_dropdown.IntegralHeight = false;
            this.day_dropdown.ItemBackColor = System.Drawing.Color.White;
            this.day_dropdown.ItemBorderColor = System.Drawing.Color.White;
            this.day_dropdown.ItemForeColor = System.Drawing.Color.Black;
            this.day_dropdown.ItemHeight = 17;
            this.day_dropdown.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.day_dropdown.ItemHighLightForeColor = System.Drawing.Color.White;
            this.day_dropdown.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.day_dropdown.ItemTopMargin = 3;
            this.day_dropdown.Location = new System.Drawing.Point(445, 164);
            this.day_dropdown.Name = "day_dropdown";
            this.day_dropdown.Size = new System.Drawing.Size(65, 23);
            this.day_dropdown.TabIndex = 0;
            this.day_dropdown.Text = null;
            this.day_dropdown.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.day_dropdown.TextLeftMargin = 5;
            // 
            // account_made_page
            // 
            this.account_made_page.BackColor = System.Drawing.Color.Black;
            this.account_made_page.BackgroundImage = global::C1oudify.Properties.Resources.login_background;
            this.account_made_page.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.account_made_page.Location = new System.Drawing.Point(4, 4);
            this.account_made_page.Name = "account_made_page";
            this.account_made_page.Padding = new System.Windows.Forms.Padding(3);
            this.account_made_page.Size = new System.Drawing.Size(952, 514);
            this.account_made_page.TabIndex = 4;
            this.account_made_page.Text = "Account made";
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(960, 570);
            this.Controls.Add(this.startup_login_pages);
            this.Controls.Add(this.top_panel);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(66)))), ((int)(((byte)(66)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximumSize = new System.Drawing.Size(960, 570);
            this.MinimumSize = new System.Drawing.Size(960, 570);
            this.Name = "login_form";
            this.Opacity = 0D;
            this.Padding = new System.Windows.Forms.Padding(2);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "C1oudify Login or Signin";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(0)))), ((int)(((byte)(3)))));
            this.Load += new System.EventHandler(this.login_form_Load);
            this.top_panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.startup_login_pages.ResumeLayout(false);
            this.login_page.ResumeLayout(false);
            this.login_page.PerformLayout();
            this.signin_page.ResumeLayout(false);
            this.signin_page.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.login_check_indicator)).EndInit();
            this.email_confirm_page.ResumeLayout(false);
            this.email_confirm_page.PerformLayout();
            this.phone_bday_page.ResumeLayout(false);
            this.phone_bday_page.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel top_panel;
        private Bunifu.UI.WinForms.BunifuImageButton green_button_tray;
        private Bunifu.UI.WinForms.BunifuImageButton red_button_exit;
        private Bunifu.UI.WinForms.BunifuPages startup_login_pages;
        private System.Windows.Forms.TabPage login_page;
        private System.Windows.Forms.TabPage signin_page;
        private System.Windows.Forms.Label bad_input_login_label;
        private System.Windows.Forms.Label passwords_not_match_labes;
        private System.Windows.Forms.TabPage email_confirm_page;
        private System.Windows.Forms.TextBox confirmation_code_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label username_already_exist_label;
        private System.Windows.Forms.Label bad_input_signin_label;
        private System.Windows.Forms.TabPage phone_bday_page;
        private Bunifu.UI.WinForms.BunifuDropdown day_dropdown;
        private Bunifu.UI.WinForms.BunifuDropdown month_dropdown;
        private Bunifu.UI.WinForms.BunifuDropdown year_dropdown;
        private System.Windows.Forms.TextBox phone_num_textbox;
        private System.Windows.Forms.TabPage account_made_page;
        private System.Windows.Forms.Button phone_and_bday_finish;
        private System.Windows.Forms.Label wrong_code_label;
        private System.Windows.Forms.Button phone_and_bday_skip_button;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button check_email_confirm_code_button;
        private System.Windows.Forms.PictureBox login_check_indicator;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.TextBox login_password_textbox;
        private System.Windows.Forms.TextBox pass_confirm_textbox_singin;
        private System.Windows.Forms.TextBox pass_textbox_singin;
        private System.Windows.Forms.TextBox email_textbox_signin;
        private System.Windows.Forms.TextBox username_textbox_signin;
        private System.Windows.Forms.Button goto_signin_page;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.Button signin_button;
        private System.Windows.Forms.Button goto_login_page;
        private System.Windows.Forms.Button show_hide_signin_confirm_password;
        private System.Windows.Forms.Button show_hide_signin_password;
        private System.Windows.Forms.Button show_hide_password;
    }
}
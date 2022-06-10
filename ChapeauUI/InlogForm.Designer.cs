
namespace ChapeauUI
{
    partial class InlogForm
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
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userListView = new System.Windows.Forms.ListView();
            this.startMenuPnl = new System.Windows.Forms.Panel();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.staffCodeTextBox = new System.Windows.Forms.TextBox();
            this.inlogBtn = new System.Windows.Forms.Button();
            this.loginBackgroundLbl = new System.Windows.Forms.Label();
            this.topBarLabel = new System.Windows.Forms.Label();
            this.startMenuPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.Location = new System.Drawing.Point(186, 667);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(290, 52);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // userListView
            // 
            this.userListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userListView.FullRowSelect = true;
            this.userListView.HideSelection = false;
            this.userListView.Location = new System.Drawing.Point(78, 130);
            this.userListView.MultiSelect = false;
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(543, 331);
            this.userListView.TabIndex = 4;
            this.userListView.UseCompatibleStateImageBehavior = false;
            this.userListView.SelectedIndexChanged += new System.EventHandler(this.userListView_SelectedIndexChanged);
            // 
            // startMenuPnl
            // 
            this.startMenuPnl.BackColor = System.Drawing.Color.Transparent;
            this.startMenuPnl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.startMenuPnl.Controls.Add(this.passwordLbl);
            this.startMenuPnl.Controls.Add(this.usernameLbl);
            this.startMenuPnl.Controls.Add(this.staffCodeTextBox);
            this.startMenuPnl.Controls.Add(this.inlogBtn);
            this.startMenuPnl.Controls.Add(this.passwordTextBox);
            this.startMenuPnl.Controls.Add(this.userListView);
            this.startMenuPnl.Controls.Add(this.loginBackgroundLbl);
            this.startMenuPnl.Location = new System.Drawing.Point(0, 51);
            this.startMenuPnl.Name = "startMenuPnl";
            this.startMenuPnl.Size = new System.Drawing.Size(700, 1390);
            this.startMenuPnl.TabIndex = 19;
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.passwordLbl.Font = new System.Drawing.Font("Trebuchet MS", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLbl.ForeColor = System.Drawing.Color.White;
            this.passwordLbl.Location = new System.Drawing.Point(221, 603);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(219, 52);
            this.passwordLbl.TabIndex = 23;
            this.passwordLbl.Text = "PASSWORD";
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.usernameLbl.Font = new System.Drawing.Font("Trebuchet MS", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameLbl.ForeColor = System.Drawing.Color.White;
            this.usernameLbl.Location = new System.Drawing.Point(221, 481);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(221, 52);
            this.usernameLbl.TabIndex = 22;
            this.usernameLbl.Text = "USERNAME";
            // 
            // staffCodeTextBox
            // 
            this.staffCodeTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.staffCodeTextBox.Location = new System.Drawing.Point(186, 536);
            this.staffCodeTextBox.Name = "staffCodeTextBox";
            this.staffCodeTextBox.Size = new System.Drawing.Size(290, 52);
            this.staffCodeTextBox.TabIndex = 6;
            this.staffCodeTextBox.TextChanged += new System.EventHandler(this.staffCodeTextBox_TextChanged);
            // 
            // inlogBtn
            // 
            this.inlogBtn.BackColor = System.Drawing.Color.Transparent;
            this.inlogBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.inlogBtn.FlatAppearance.BorderSize = 10;
            this.inlogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inlogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inlogBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.inlogBtn.Location = new System.Drawing.Point(78, 752);
            this.inlogBtn.Margin = new System.Windows.Forms.Padding(60);
            this.inlogBtn.Name = "inlogBtn";
            this.inlogBtn.Size = new System.Drawing.Size(543, 106);
            this.inlogBtn.TabIndex = 5;
            this.inlogBtn.Text = "LOG IN";
            this.inlogBtn.UseVisualStyleBackColor = false;
            this.inlogBtn.Click += new System.EventHandler(this.inlogBtn_Click);
            // 
            // loginBackgroundLbl
            // 
            this.loginBackgroundLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.loginBackgroundLbl.Location = new System.Drawing.Point(62, 119);
            this.loginBackgroundLbl.Name = "loginBackgroundLbl";
            this.loginBackgroundLbl.Size = new System.Drawing.Size(575, 622);
            this.loginBackgroundLbl.TabIndex = 21;
            this.loginBackgroundLbl.Text = "emptyString";
            // 
            // topBarLabel
            // 
            this.topBarLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.topBarLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarLabel.Location = new System.Drawing.Point(0, 0);
            this.topBarLabel.Name = "topBarLabel";
            this.topBarLabel.Size = new System.Drawing.Size(700, 51);
            this.topBarLabel.TabIndex = 20;
            this.topBarLabel.Text = "emptyString";
            // 
            // InlogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.BackgroundImage = global::ChapeauUI.Properties.Resources.achtergrond;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(720, 1097);
            this.Controls.Add(this.topBarLabel);
            this.Controls.Add(this.startMenuPnl);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InlogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InlogForm";
            this.startMenuPnl.ResumeLayout(false);
            this.startMenuPnl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.Panel startMenuPnl;
        private System.Windows.Forms.Button inlogBtn;
        private System.Windows.Forms.Label topBarLabel;
        private System.Windows.Forms.TextBox staffCodeTextBox;
        private System.Windows.Forms.Label loginBackgroundLbl;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label passwordLbl;
    }
}

namespace ChapeauUI
{
    partial class LogInDesktop
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
            this.inlogBtn = new System.Windows.Forms.Button();
            this.staffCodeTextBox = new System.Windows.Forms.TextBox();
            this.topBarLabel = new System.Windows.Forms.Label();
            this.loginBackgroundLbl = new System.Windows.Forms.Label();
            this.usernameLbl = new System.Windows.Forms.Label();
            this.passwordLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordTextBox.Location = new System.Drawing.Point(721, 720);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(500, 52);
            this.passwordTextBox.TabIndex = 1;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // userListView
            // 
            this.userListView.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userListView.FullRowSelect = true;
            this.userListView.HideSelection = false;
            this.userListView.Location = new System.Drawing.Point(421, 120);
            this.userListView.MultiSelect = false;
            this.userListView.Name = "userListView";
            this.userListView.Size = new System.Drawing.Size(1100, 366);
            this.userListView.TabIndex = 5;
            this.userListView.UseCompatibleStateImageBehavior = false;
            this.userListView.SelectedIndexChanged += new System.EventHandler(this.userListView_SelectedIndexChanged);
            // 
            // inlogBtn
            // 
            this.inlogBtn.BackColor = System.Drawing.Color.Transparent;
            this.inlogBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.inlogBtn.FlatAppearance.BorderSize = 10;
            this.inlogBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.inlogBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.inlogBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.inlogBtn.Location = new System.Drawing.Point(696, 886);
            this.inlogBtn.Margin = new System.Windows.Forms.Padding(60);
            this.inlogBtn.Name = "inlogBtn";
            this.inlogBtn.Size = new System.Drawing.Size(550, 100);
            this.inlogBtn.TabIndex = 6;
            this.inlogBtn.Text = "LOG IN";
            this.inlogBtn.UseVisualStyleBackColor = false;
            this.inlogBtn.Click += new System.EventHandler(this.inlogBtn_Click);
            // 
            // staffCodeTextBox
            // 
            this.staffCodeTextBox.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.staffCodeTextBox.Location = new System.Drawing.Point(721, 570);
            this.staffCodeTextBox.Name = "staffCodeTextBox";
            this.staffCodeTextBox.Size = new System.Drawing.Size(500, 52);
            this.staffCodeTextBox.TabIndex = 7;
            // 
            // topBarLabel
            // 
            this.topBarLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.topBarLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topBarLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.topBarLabel.Location = new System.Drawing.Point(0, 0);
            this.topBarLabel.Name = "topBarLabel";
            this.topBarLabel.Size = new System.Drawing.Size(1924, 51);
            this.topBarLabel.TabIndex = 8;
            this.topBarLabel.Text = "emptyString";
            // 
            // loginBackgroundLbl
            // 
            this.loginBackgroundLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.loginBackgroundLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.loginBackgroundLbl.Location = new System.Drawing.Point(371, 100);
            this.loginBackgroundLbl.Name = "loginBackgroundLbl";
            this.loginBackgroundLbl.Size = new System.Drawing.Size(1200, 750);
            this.loginBackgroundLbl.TabIndex = 22;
            this.loginBackgroundLbl.Text = "emptyString";
            // 
            // usernameLbl
            // 
            this.usernameLbl.AutoSize = true;
            this.usernameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.usernameLbl.Font = new System.Drawing.Font("Trebuchet MS", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.usernameLbl.ForeColor = System.Drawing.Color.White;
            this.usernameLbl.Location = new System.Drawing.Point(860, 495);
            this.usernameLbl.Name = "usernameLbl";
            this.usernameLbl.Size = new System.Drawing.Size(221, 52);
            this.usernameLbl.TabIndex = 23;
            this.usernameLbl.Text = "USERNAME";
            // 
            // passwordLbl
            // 
            this.passwordLbl.AutoSize = true;
            this.passwordLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.passwordLbl.Font = new System.Drawing.Font("Trebuchet MS", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.passwordLbl.ForeColor = System.Drawing.Color.White;
            this.passwordLbl.Location = new System.Drawing.Point(859, 645);
            this.passwordLbl.Name = "passwordLbl";
            this.passwordLbl.Size = new System.Drawing.Size(219, 52);
            this.passwordLbl.TabIndex = 24;
            this.passwordLbl.Text = "PASSWORD";
            // 
            // LogInDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.BackgroundImage = global::ChapeauUI.Properties.Resources.winebgdesktop;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1924, 1033);
            this.Controls.Add(this.passwordLbl);
            this.Controls.Add(this.usernameLbl);
            this.Controls.Add(this.topBarLabel);
            this.Controls.Add(this.staffCodeTextBox);
            this.Controls.Add(this.inlogBtn);
            this.Controls.Add(this.userListView);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.loginBackgroundLbl);
            this.DoubleBuffered = true;
            this.Name = "LogInDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogInDesktop";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.ListView userListView;
        private System.Windows.Forms.Button inlogBtn;
        private System.Windows.Forms.TextBox staffCodeTextBox;
        private System.Windows.Forms.Label topBarLabel;
        private System.Windows.Forms.Label loginBackgroundLbl;
        private System.Windows.Forms.Label usernameLbl;
        private System.Windows.Forms.Label passwordLbl;
    }
}

namespace ChapeauUI
{
    partial class ChapeauUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.testView = new System.Windows.Forms.ListView();
            this.billButton = new System.Windows.Forms.Button();
            this.menuButton = new System.Windows.Forms.Button();
            this.orderBtn = new System.Windows.Forms.Button();
            this.staffBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // testView
            // 
            this.testView.GridLines = true;
            this.testView.HideSelection = false;
            this.testView.Location = new System.Drawing.Point(74, 54);
            this.testView.Name = "testView";
            this.testView.Size = new System.Drawing.Size(627, 335);
            this.testView.TabIndex = 0;
            this.testView.UseCompatibleStateImageBehavior = false;
            // 
            // billButton
            // 
            this.billButton.Location = new System.Drawing.Point(74, 19);
            this.billButton.Name = "billButton";
            this.billButton.Size = new System.Drawing.Size(94, 29);
            this.billButton.TabIndex = 1;
            this.billButton.Text = "Bill";
            this.billButton.UseVisualStyleBackColor = true;
            this.billButton.Click += new System.EventHandler(this.billButton_Click);
            // 
            // menuButton
            // 
            this.menuButton.Location = new System.Drawing.Point(175, 19);
            this.menuButton.Name = "menuButton";
            this.menuButton.Size = new System.Drawing.Size(94, 29);
            this.menuButton.TabIndex = 2;
            this.menuButton.Text = "Menu";
            this.menuButton.UseVisualStyleBackColor = true;
            this.menuButton.Click += new System.EventHandler(this.menuButton_Click);
            // 
            // orderBtn
            // 
            this.orderBtn.Location = new System.Drawing.Point(276, 19);
            this.orderBtn.Name = "orderBtn";
            this.orderBtn.Size = new System.Drawing.Size(94, 29);
            this.orderBtn.TabIndex = 3;
            this.orderBtn.Text = "Order";
            this.orderBtn.UseVisualStyleBackColor = true;
            this.orderBtn.Click += new System.EventHandler(this.orderBtn_Click);
            // 
            // staffBtn
            // 
            this.staffBtn.Location = new System.Drawing.Point(377, 19);
            this.staffBtn.Name = "staffBtn";
            this.staffBtn.Size = new System.Drawing.Size(94, 29);
            this.staffBtn.TabIndex = 4;
            this.staffBtn.Text = "Staff";
            this.staffBtn.UseVisualStyleBackColor = true;
            this.staffBtn.Click += new System.EventHandler(this.staffBtn_Click);
            // 
            // ChapeauUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.staffBtn);
            this.Controls.Add(this.orderBtn);
            this.Controls.Add(this.menuButton);
            this.Controls.Add(this.billButton);
            this.Controls.Add(this.testView);
            this.Name = "ChapeauUI";
            this.Text = "Chapeau";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView testView;
        private System.Windows.Forms.Button billButton;
        private System.Windows.Forms.Button menuButton;
        private System.Windows.Forms.Button orderBtn;
        private System.Windows.Forms.Button staffBtn;
    }
}


namespace final_programming_project
{
    partial class MainForm
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
            UsernameLabel = new Label();
            btnLogout = new Button();
            mngUsersBtn = new Button();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(17, 14);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(74, 20);
            UsernameLabel.TabIndex = 0;
            UsernameLabel.Text = "UserLabel";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(17, 37);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(94, 29);
            btnLogout.TabIndex = 1;
            btnLogout.Text = "Odhlásit se";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // mngUsersBtn
            // 
            mngUsersBtn.Location = new Point(651, 14);
            mngUsersBtn.Name = "mngUsersBtn";
            mngUsersBtn.Size = new Size(137, 29);
            mngUsersBtn.TabIndex = 2;
            mngUsersBtn.Text = "Správa uživatelů";
            mngUsersBtn.UseVisualStyleBackColor = true;
            mngUsersBtn.Click += mngUsersBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(mngUsersBtn);
            Controls.Add(btnLogout);
            Controls.Add(UsernameLabel);
            Name = "MainForm";
            Text = "Správa zakázek";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Button btnLogout;
        private Button mngUsersBtn;
    }
}
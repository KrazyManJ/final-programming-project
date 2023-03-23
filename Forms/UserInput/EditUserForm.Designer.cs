namespace final_programming_project
{
    partial class EditUserForm
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
            InputUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            InputPassword = new TextBox();
            label3 = new Label();
            InputConfirmPassword = new TextBox();
            label4 = new Label();
            ComboBoxRole = new ComboBox();
            ActionButton = new Button();
            ChangePassCheck = new CheckBox();
            SuspendLayout();
            // 
            // InputUsername
            // 
            InputUsername.Location = new Point(32, 53);
            InputUsername.Name = "InputUsername";
            InputUsername.Size = new Size(280, 27);
            InputUsername.TabIndex = 0;
            InputUsername.TextChanged += UnputChanged;
            InputUsername.KeyDown += OnKeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 30);
            label1.Name = "label1";
            label1.Size = new Size(129, 20);
            label1.TabIndex = 1;
            label1.Text = "Uživatelské jméno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(32, 205);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 3;
            label2.Text = "Heslo";
            // 
            // InputPassword
            // 
            InputPassword.Enabled = false;
            InputPassword.Location = new Point(32, 228);
            InputPassword.Name = "InputPassword";
            InputPassword.PasswordChar = '●';
            InputPassword.Size = new Size(280, 27);
            InputPassword.TabIndex = 2;
            InputPassword.TextChanged += UnputChanged;
            InputPassword.KeyDown += OnKeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 269);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 5;
            label3.Text = "Heslo znovu";
            // 
            // InputConfirmPassword
            // 
            InputConfirmPassword.Enabled = false;
            InputConfirmPassword.Location = new Point(32, 292);
            InputConfirmPassword.Name = "InputConfirmPassword";
            InputConfirmPassword.PasswordChar = '●';
            InputConfirmPassword.Size = new Size(280, 27);
            InputConfirmPassword.TabIndex = 4;
            InputConfirmPassword.TextChanged += UnputChanged;
            InputConfirmPassword.KeyDown += OnKeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 91);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 7;
            label4.Text = "Role";
            // 
            // ComboBoxRole
            // 
            ComboBoxRole.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxRole.FormattingEnabled = true;
            ComboBoxRole.Location = new Point(32, 114);
            ComboBoxRole.Name = "ComboBoxRole";
            ComboBoxRole.Size = new Size(280, 28);
            ComboBoxRole.TabIndex = 8;
            ComboBoxRole.SelectedIndexChanged += UnputChanged;
            ComboBoxRole.KeyDown += OnKeyDown;
            // 
            // ActionButton
            // 
            ActionButton.Location = new Point(77, 368);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(189, 29);
            ActionButton.TabIndex = 9;
            ActionButton.Text = "Upravit Uživatele";
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButtonClick;
            // 
            // ChangePassCheck
            // 
            ChangePassCheck.AutoSize = true;
            ChangePassCheck.Location = new Point(32, 168);
            ChangePassCheck.Name = "ChangePassCheck";
            ChangePassCheck.Size = new Size(121, 24);
            ChangePassCheck.TabIndex = 10;
            ChangePassCheck.Text = "Upravit Heslo";
            ChangePassCheck.UseVisualStyleBackColor = true;
            ChangePassCheck.CheckedChanged += ChangePassCheckChanged;
            ChangePassCheck.KeyDown += OnKeyDown;
            // 
            // EditUserForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(349, 406);
            Controls.Add(ChangePassCheck);
            Controls.Add(ActionButton);
            Controls.Add(ComboBoxRole);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(InputConfirmPassword);
            Controls.Add(label2);
            Controls.Add(InputPassword);
            Controls.Add(label1);
            Controls.Add(InputUsername);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "EditUserForm";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Úprava Uživatele";
            KeyDown += OnKeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button ActionButton;
        internal TextBox InputUsername;
        internal TextBox InputPassword;
        internal TextBox InputConfirmPassword;
        internal ComboBox ComboBoxRole;
        private CheckBox ChangePassCheck;
    }
}
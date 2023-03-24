namespace final_programming_project.Forms
{
    partial class LoginForm
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
            InputName = new TextBox();
            InputPassword = new TextBox();
            LoginButton = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // InputName
            // 
            InputName.Location = new Point(26, 34);
            InputName.Name = "InputName";
            InputName.Size = new Size(248, 27);
            InputName.TabIndex = 0;
            InputName.TextChanged += UpdateLoginBtnState;
            InputName.KeyDown += OnKeyDown;
            // 
            // InputPassword
            // 
            InputPassword.Location = new Point(26, 85);
            InputPassword.Name = "InputPassword";
            InputPassword.PasswordChar = '●';
            InputPassword.Size = new Size(248, 27);
            InputPassword.TabIndex = 1;
            InputPassword.TextChanged += UpdateLoginBtnState;
            InputPassword.KeyDown += OnKeyDown;
            // 
            // LoginButton
            // 
            LoginButton.Location = new Point(100, 142);
            LoginButton.Name = "LoginButton";
            LoginButton.Size = new Size(94, 29);
            LoginButton.TabIndex = 2;
            LoginButton.Text = "Přihlásit se";
            LoginButton.UseVisualStyleBackColor = true;
            LoginButton.Click += LoginButtonClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 18);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 3;
            label1.Text = "Jméno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 66);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 4;
            label2.Text = "Heslo";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(311, 197);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(LoginButton);
            Controls.Add(InputPassword);
            Controls.Add(InputName);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Přihlášení";
            KeyDown += OnKeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox InputName;
        private TextBox InputPassword;
        private Button LoginButton;
        private Label label1;
        private Label label2;
    }
}
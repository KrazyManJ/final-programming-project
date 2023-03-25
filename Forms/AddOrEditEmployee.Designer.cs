namespace final_programming_project.Forms
{
    partial class AddOrEditEmployee
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
            FirstNameInput = new TextBox();
            LastNameInput = new TextBox();
            BirthDatePicker = new DateTimePicker();
            EmailInput = new TextBox();
            PhoneNumberInput = new TextBox();
            ActionButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // FirstNameInput
            // 
            FirstNameInput.Location = new Point(47, 50);
            FirstNameInput.Name = "FirstNameInput";
            FirstNameInput.Size = new Size(250, 27);
            FirstNameInput.TabIndex = 0;
            FirstNameInput.TextChanged += AnyTextBoxChanged;
            // 
            // LastNameInput
            // 
            LastNameInput.Location = new Point(47, 116);
            LastNameInput.Name = "LastNameInput";
            LastNameInput.Size = new Size(250, 27);
            LastNameInput.TabIndex = 1;
            LastNameInput.TextChanged += AnyTextBoxChanged;
            // 
            // BirthDatePicker
            // 
            BirthDatePicker.CustomFormat = "";
            BirthDatePicker.Location = new Point(47, 185);
            BirthDatePicker.Name = "BirthDatePicker";
            BirthDatePicker.Size = new Size(250, 27);
            BirthDatePicker.TabIndex = 2;
            BirthDatePicker.Value = new DateTime(2023, 3, 25, 22, 1, 8, 0);
            // 
            // EmailInput
            // 
            EmailInput.Location = new Point(47, 249);
            EmailInput.Name = "EmailInput";
            EmailInput.Size = new Size(250, 27);
            EmailInput.TabIndex = 3;
            EmailInput.TextChanged += AnyTextBoxChanged;
            // 
            // PhoneNumberInput
            // 
            PhoneNumberInput.Location = new Point(47, 311);
            PhoneNumberInput.Name = "PhoneNumberInput";
            PhoneNumberInput.Size = new Size(250, 27);
            PhoneNumberInput.TabIndex = 4;
            PhoneNumberInput.TextChanged += AnyTextBoxChanged;
            // 
            // ActionButton
            // 
            ActionButton.Enabled = false;
            ActionButton.Location = new Point(47, 381);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(250, 29);
            ActionButton.TabIndex = 5;
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 27);
            label1.Name = "label1";
            label1.Size = new Size(52, 20);
            label1.TabIndex = 6;
            label1.Text = "Jméno";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 93);
            label2.Name = "label2";
            label2.Size = new Size(63, 20);
            label2.TabIndex = 7;
            label2.Text = "Příjmení";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(47, 162);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 8;
            label3.Text = "Datum narození";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(47, 226);
            label4.Name = "label4";
            label4.Size = new Size(46, 20);
            label4.TabIndex = 9;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(47, 288);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 10;
            label5.Text = "Telefonní číslo";
            // 
            // AddOrEditEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(363, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ActionButton);
            Controls.Add(PhoneNumberInput);
            Controls.Add(EmailInput);
            Controls.Add(BirthDatePicker);
            Controls.Add(LastNameInput);
            Controls.Add(FirstNameInput);
            Name = "AddOrEditEmployee";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FirstNameInput;
        private TextBox LastNameInput;
        private DateTimePicker BirthDatePicker;
        private TextBox EmailInput;
        private TextBox PhoneNumberInput;
        private Button ActionButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }
}
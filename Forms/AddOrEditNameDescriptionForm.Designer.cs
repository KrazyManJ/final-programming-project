namespace final_programming_project.Forms
{
    partial class AddOrEditNameDescriptionForm<T>
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
            NameInput = new TextBox();
            DescriptionInput = new TextBox();
            NameLabel = new Label();
            DescriptionLabel = new Label();
            ActionButton = new Button();
            SuspendLayout();
            // 
            // NameInput
            // 
            NameInput.Location = new Point(33, 51);
            NameInput.Name = "NameInput";
            NameInput.Size = new Size(230, 27);
            NameInput.TabIndex = 0;
            NameInput.TextChanged += UpdateButtonStatus;
            NameInput.KeyDown += OnKeyDown;
            // 
            // DescriptionInput
            // 
            DescriptionInput.Location = new Point(33, 116);
            DescriptionInput.Multiline = true;
            DescriptionInput.Name = "DescriptionInput";
            DescriptionInput.Size = new Size(230, 116);
            DescriptionInput.TabIndex = 1;
            DescriptionInput.TextChanged += UpdateButtonStatus;
            DescriptionInput.KeyDown += OnKeyDown;
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(33, 28);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(0, 20);
            NameLabel.TabIndex = 2;
            NameLabel.Text = "Název";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(33, 93);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(0, 20);
            DescriptionLabel.TabIndex = 3;
            DescriptionLabel.Text = "Popis";
            // 
            // ActionButton
            // 
            ActionButton.Enabled = false;
            ActionButton.Location = new Point(33, 260);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(230, 29);
            ActionButton.TabIndex = 4;
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // AddOrEditNameDescriptionForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 318);
            Controls.Add(ActionButton);
            Controls.Add(DescriptionLabel);
            Controls.Add(NameLabel);
            Controls.Add(DescriptionInput);
            Controls.Add(NameInput);
            Name = "AddOrEditNameDescriptionForm";
            StartPosition = FormStartPosition.CenterScreen;
            KeyDown += OnKeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox NameInput;
        private TextBox DescriptionInput;
        private Label NameLabel;
        private Label DescriptionLabel;
        private Button ActionButton;
    }
}
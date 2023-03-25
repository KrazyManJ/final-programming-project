namespace final_programming_project.Forms
{
    partial class AddContractForm
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
            CustomerInput = new TextBox();
            DescriptionInput = new TextBox();
            label1 = new Label();
            label2 = new Label();
            AddButton = new Button();
            SuspendLayout();
            // 
            // CustomerInput
            // 
            CustomerInput.Location = new Point(33, 51);
            CustomerInput.Name = "CustomerInput";
            CustomerInput.Size = new Size(230, 27);
            CustomerInput.TabIndex = 0;
            CustomerInput.TextChanged += UpdateButtonStatus;
            CustomerInput.KeyDown += OnKeyDown;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 28);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 2;
            label1.Text = "Zákazník";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 93);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 3;
            label2.Text = "Popis zakázky";
            // 
            // AddButton
            // 
            AddButton.Enabled = false;
            AddButton.Location = new Point(33, 260);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(230, 29);
            AddButton.TabIndex = 4;
            AddButton.Text = "Přidat";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // AddContractForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 318);
            Controls.Add(AddButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(DescriptionInput);
            Controls.Add(CustomerInput);
            Name = "AddContractForm";
            Text = "Přidat zakázku";
            KeyDown += OnKeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox CustomerInput;
        private TextBox DescriptionInput;
        private Label label1;
        private Label label2;
        private Button AddButton;
    }
}
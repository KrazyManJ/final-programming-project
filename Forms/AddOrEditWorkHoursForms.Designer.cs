namespace final_programming_project.Forms
{
    partial class AddOrEditWorkHoursForms
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
            EmployeeComboBox = new ComboBox();
            WorkTypeComboBox = new ComboBox();
            HoursNumeric = new NumericUpDown();
            ActionButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)HoursNumeric).BeginInit();
            SuspendLayout();
            // 
            // EmployeeComboBox
            // 
            EmployeeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            EmployeeComboBox.FormattingEnabled = true;
            EmployeeComboBox.Location = new Point(53, 51);
            EmployeeComboBox.Name = "EmployeeComboBox";
            EmployeeComboBox.Size = new Size(239, 28);
            EmployeeComboBox.TabIndex = 0;
            EmployeeComboBox.SelectedIndexChanged += ComboBoxValueUpdate;
            // 
            // WorkTypeComboBox
            // 
            WorkTypeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            WorkTypeComboBox.FormattingEnabled = true;
            WorkTypeComboBox.Location = new Point(52, 134);
            WorkTypeComboBox.Name = "WorkTypeComboBox";
            WorkTypeComboBox.Size = new Size(238, 28);
            WorkTypeComboBox.TabIndex = 1;
            WorkTypeComboBox.SelectedIndexChanged += ComboBoxValueUpdate;
            // 
            // HoursNumeric
            // 
            HoursNumeric.ImeMode = ImeMode.NoControl;
            HoursNumeric.Location = new Point(53, 217);
            HoursNumeric.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            HoursNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            HoursNumeric.Name = "HoursNumeric";
            HoursNumeric.Size = new Size(237, 27);
            HoursNumeric.TabIndex = 2;
            HoursNumeric.Value = new decimal(new int[] { 8, 0, 0, 0 });
            // 
            // ActionButton
            // 
            ActionButton.Enabled = false;
            ActionButton.Location = new Point(53, 299);
            ActionButton.Name = "ActionButton";
            ActionButton.Size = new Size(239, 29);
            ActionButton.TabIndex = 3;
            ActionButton.UseVisualStyleBackColor = true;
            ActionButton.Click += ActionButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(53, 28);
            label1.Name = "label1";
            label1.Size = new Size(97, 20);
            label1.TabIndex = 4;
            label1.Text = "Zaměstnanec";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 111);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 5;
            label2.Text = "Pracovní činnost";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(53, 194);
            label3.Name = "label3";
            label3.Size = new Size(192, 20);
            label3.TabIndex = 6;
            label3.Text = "Počet odpracovaných hodin";
            // 
            // AddOrEditWorkHoursForms
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(358, 384);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ActionButton);
            Controls.Add(HoursNumeric);
            Controls.Add(WorkTypeComboBox);
            Controls.Add(EmployeeComboBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "AddOrEditWorkHoursForms";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)HoursNumeric).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox EmployeeComboBox;
        private ComboBox WorkTypeComboBox;
        private NumericUpDown HoursNumeric;
        private Button ActionButton;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}
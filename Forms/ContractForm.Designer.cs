namespace final_programming_project.Forms
{
    partial class ContractForm
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
            TitleLabel = new Label();
            DescriptionLabel = new Label();
            WorkHoursListView = new Toolbox.SortableListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            EditContractInfoButton = new Button();
            UpdateDataButton = new Button();
            SuspendLayout();
            // 
            // TitleLabel
            // 
            TitleLabel.AutoSize = true;
            TitleLabel.Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point);
            TitleLabel.Location = new Point(12, 9);
            TitleLabel.Name = "TitleLabel";
            TitleLabel.Size = new Size(68, 35);
            TitleLabel.TabIndex = 0;
            TitleLabel.Text = "Title";
            // 
            // DescriptionLabel
            // 
            DescriptionLabel.AutoSize = true;
            DescriptionLabel.Location = new Point(12, 46);
            DescriptionLabel.MaximumSize = new Size(770, 0);
            DescriptionLabel.MinimumSize = new Size(770, 0);
            DescriptionLabel.Name = "DescriptionLabel";
            DescriptionLabel.Size = new Size(770, 20);
            DescriptionLabel.TabIndex = 1;
            DescriptionLabel.Text = "Description";
            // 
            // WorkHoursListView
            // 
            WorkHoursListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WorkHoursListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            WorkHoursListView.FullRowSelect = true;
            WorkHoursListView.GridLines = true;
            WorkHoursListView.Location = new Point(12, 81);
            WorkHoursListView.MultiSelect = false;
            WorkHoursListView.Name = "WorkHoursListView";
            WorkHoursListView.Size = new Size(776, 322);
            WorkHoursListView.TabIndex = 2;
            WorkHoursListView.UseCompatibleStateImageBehavior = false;
            WorkHoursListView.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Zaměstnanec";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Pracovní činnost";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Odpracované hodiny";
            columnHeader4.Width = 200;
            // 
            // EditContractInfoButton
            // 
            EditContractInfoButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditContractInfoButton.Location = new Point(584, 9);
            EditContractInfoButton.Name = "EditContractInfoButton";
            EditContractInfoButton.Size = new Size(204, 29);
            EditContractInfoButton.TabIndex = 3;
            EditContractInfoButton.Text = "Upravit informace zakázky";
            EditContractInfoButton.UseVisualStyleBackColor = true;
            EditContractInfoButton.Click += EditContractInfoButton_Click;
            // 
            // UpdateDataButton
            // 
            UpdateDataButton.Location = new Point(612, 409);
            UpdateDataButton.Name = "UpdateDataButton";
            UpdateDataButton.Size = new Size(176, 29);
            UpdateDataButton.TabIndex = 4;
            UpdateDataButton.Text = "Aktualizovat Data";
            UpdateDataButton.UseVisualStyleBackColor = true;
            UpdateDataButton.Click += UpdateDataButton_Click;
            // 
            // ContractForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UpdateDataButton);
            Controls.Add(EditContractInfoButton);
            Controls.Add(WorkHoursListView);
            Controls.Add(DescriptionLabel);
            Controls.Add(TitleLabel);
            Name = "ContractForm";
            Text = "Podrobnosti Zakázky";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleLabel;
        private Label DescriptionLabel;
        private Toolbox.SortableListView WorkHoursListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button EditContractInfoButton;
        private Button UpdateDataButton;
    }
}
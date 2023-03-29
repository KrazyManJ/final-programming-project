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
            columnHeader6 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            EditContractInfoButton = new Button();
            UpdateDataButton = new Button();
            AddWorkHoursButton = new Button();
            EditWorkHoursButton = new Button();
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
            WorkHoursListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader6, columnHeader2, columnHeader4, columnHeader3, columnHeader5 });
            WorkHoursListView.FullRowSelect = true;
            WorkHoursListView.GridLines = true;
            WorkHoursListView.Location = new Point(12, 81);
            WorkHoursListView.MultiSelect = false;
            WorkHoursListView.Name = "WorkHoursListView";
            WorkHoursListView.Size = new Size(955, 322);
            WorkHoursListView.TabIndex = 2;
            WorkHoursListView.UseCompatibleStateImageBehavior = false;
            WorkHoursListView.View = View.Details;
            WorkHoursListView.SelectedIndexChanged += WorkHoursListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Datum vložení";
            columnHeader6.Width = 150;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Zaměstnanec";
            columnHeader2.Width = 170;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Hodiny";
            columnHeader4.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Činnost";
            columnHeader3.Width = 120;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Popis Pracovní Činnosti";
            columnHeader5.Width = 350;
            // 
            // EditContractInfoButton
            // 
            EditContractInfoButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EditContractInfoButton.Location = new Point(763, 9);
            EditContractInfoButton.Name = "EditContractInfoButton";
            EditContractInfoButton.Size = new Size(204, 29);
            EditContractInfoButton.TabIndex = 3;
            EditContractInfoButton.Text = "Upravit informace zakázky";
            EditContractInfoButton.UseVisualStyleBackColor = true;
            EditContractInfoButton.Click += EditContractInfoButton_Click;
            // 
            // UpdateDataButton
            // 
            UpdateDataButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            UpdateDataButton.Location = new Point(822, 409);
            UpdateDataButton.Name = "UpdateDataButton";
            UpdateDataButton.Size = new Size(145, 29);
            UpdateDataButton.TabIndex = 4;
            UpdateDataButton.Text = "Aktualizovat Data";
            UpdateDataButton.UseVisualStyleBackColor = true;
            UpdateDataButton.Click += UpdateDataButton_Click;
            // 
            // AddWorkHoursButton
            // 
            AddWorkHoursButton.Location = new Point(12, 409);
            AddWorkHoursButton.Name = "AddWorkHoursButton";
            AddWorkHoursButton.Size = new Size(129, 29);
            AddWorkHoursButton.TabIndex = 5;
            AddWorkHoursButton.Text = "Přidat záznam";
            AddWorkHoursButton.UseVisualStyleBackColor = true;
            AddWorkHoursButton.Click += AddWorkHoursButton_Click;
            // 
            // EditWorkHoursButton
            // 
            EditWorkHoursButton.Enabled = false;
            EditWorkHoursButton.Location = new Point(147, 409);
            EditWorkHoursButton.Name = "EditWorkHoursButton";
            EditWorkHoursButton.Size = new Size(129, 29);
            EditWorkHoursButton.TabIndex = 6;
            EditWorkHoursButton.Text = "Upravit záznam";
            EditWorkHoursButton.UseVisualStyleBackColor = true;
            EditWorkHoursButton.Click += EditWorkHoursButton_Click;
            // 
            // ContractForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 450);
            Controls.Add(EditWorkHoursButton);
            Controls.Add(AddWorkHoursButton);
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
        private Button AddWorkHoursButton;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Button EditWorkHoursButton;
    }
}
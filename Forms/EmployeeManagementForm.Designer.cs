namespace final_programming_project.Forms
{
    partial class EmployeeManagementForm
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
            EmployeeListView = new Toolbox.SortableListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            columnHeader5 = new ColumnHeader();
            columnHeader6 = new ColumnHeader();
            AddButton = new Button();
            EditButton = new Button();
            RemoveButton = new Button();
            SearchInput = new TextBox();
            UpdateDataButton = new Button();
            SuspendLayout();
            // 
            // EmployeeListView
            // 
            EmployeeListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            EmployeeListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4, columnHeader5, columnHeader6 });
            EmployeeListView.FullRowSelect = true;
            EmployeeListView.GridLines = true;
            EmployeeListView.Location = new Point(12, 45);
            EmployeeListView.MultiSelect = false;
            EmployeeListView.Name = "EmployeeListView";
            EmployeeListView.Size = new Size(776, 358);
            EmployeeListView.TabIndex = 0;
            EmployeeListView.UseCompatibleStateImageBehavior = false;
            EmployeeListView.View = View.Details;
            EmployeeListView.SelectedIndexChanged += EmployeeListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Jméno";
            columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Příjmení";
            columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Datum Narození";
            columnHeader4.Width = 150;
            // 
            // columnHeader5
            // 
            columnHeader5.Text = "Email";
            columnHeader5.Width = 200;
            // 
            // columnHeader6
            // 
            columnHeader6.Text = "Telefon";
            columnHeader6.Width = 150;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddButton.Location = new Point(12, 409);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(170, 29);
            AddButton.TabIndex = 1;
            AddButton.Text = "Přidat Zaměstnance";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // EditButton
            // 
            EditButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            EditButton.Enabled = false;
            EditButton.Location = new Point(402, 409);
            EditButton.Name = "EditButton";
            EditButton.Size = new Size(190, 29);
            EditButton.TabIndex = 2;
            EditButton.Text = "Upravit Zaměstnance";
            EditButton.UseVisualStyleBackColor = true;
            EditButton.Click += EditButton_Click;
            // 
            // RemoveButton
            // 
            RemoveButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RemoveButton.Enabled = false;
            RemoveButton.Location = new Point(598, 409);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(190, 29);
            RemoveButton.TabIndex = 3;
            RemoveButton.Text = "Vymazat Zaměstnance";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // SearchInput
            // 
            SearchInput.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SearchInput.Location = new Point(12, 12);
            SearchInput.Name = "SearchInput";
            SearchInput.PlaceholderText = "Hledat...";
            SearchInput.Size = new Size(625, 27);
            SearchInput.TabIndex = 4;
            SearchInput.TextChanged += SearchInput_TextChanged;
            // 
            // UpdateDataButton
            // 
            UpdateDataButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UpdateDataButton.Location = new Point(643, 11);
            UpdateDataButton.Name = "UpdateDataButton";
            UpdateDataButton.Size = new Size(145, 29);
            UpdateDataButton.TabIndex = 5;
            UpdateDataButton.Text = "Aktualizovat Data";
            UpdateDataButton.UseVisualStyleBackColor = true;
            UpdateDataButton.Click += UpdateDataButton_Click;
            // 
            // EmployeeManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UpdateDataButton);
            Controls.Add(SearchInput);
            Controls.Add(RemoveButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(EmployeeListView);
            Name = "EmployeeManagementForm";
            Text = "Správa Zaměstnanců";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Toolbox.SortableListView EmployeeListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Button AddButton;
        private Button EditButton;
        private Button RemoveButton;
        private TextBox SearchInput;
        private Button UpdateDataButton;
    }
}
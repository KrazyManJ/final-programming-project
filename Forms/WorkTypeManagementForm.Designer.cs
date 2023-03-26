namespace final_programming_project.Forms
{
    partial class WorkTypeManagementForm
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
            WorkTypeListView = new Toolbox.SortableListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            AddButton = new Button();
            EditButton = new Button();
            RemoveButton = new Button();
            SearchInput = new TextBox();
            UpdateDataButton = new Button();
            SuspendLayout();
            // 
            // WorkTypeListView
            // 
            WorkTypeListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            WorkTypeListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            WorkTypeListView.FullRowSelect = true;
            WorkTypeListView.GridLines = true;
            WorkTypeListView.Location = new Point(12, 45);
            WorkTypeListView.MultiSelect = false;
            WorkTypeListView.Name = "WorkTypeListView";
            WorkTypeListView.Size = new Size(776, 358);
            WorkTypeListView.TabIndex = 0;
            WorkTypeListView.UseCompatibleStateImageBehavior = false;
            WorkTypeListView.View = View.Details;
            WorkTypeListView.SelectedIndexChanged += EmployeeListView_SelectedIndexChanged;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Název";
            columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Popis";
            columnHeader3.Width = 550;
            // 
            // AddButton
            // 
            AddButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddButton.Location = new Point(12, 409);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(170, 29);
            AddButton.TabIndex = 1;
            AddButton.Text = "Přidat Činnost";
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
            EditButton.Text = "Upravit Činnost";
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
            RemoveButton.Text = "Vymazat Činnost";
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
            // WorkTypeManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UpdateDataButton);
            Controls.Add(SearchInput);
            Controls.Add(RemoveButton);
            Controls.Add(EditButton);
            Controls.Add(AddButton);
            Controls.Add(WorkTypeListView);
            Name = "WorkTypeManagementForm";
            Text = "Správa Pracovních Činností";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Toolbox.SortableListView WorkTypeListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private Button AddButton;
        private Button EditButton;
        private Button RemoveButton;
        private TextBox SearchInput;
        private Button UpdateDataButton;
    }
}
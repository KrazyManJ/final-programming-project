using final_programming_project.Toolbox;

namespace final_programming_project.Forms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UsernameLabel = new Label();
            LogoutButton = new Button();
            ManageUsersButton = new Button();
            ContractsListView = new SortableListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            SearchInput = new TextBox();
            UpdateDataButton = new Button();
            AddContractButton = new Button();
            SuspendLayout();
            // 
            // UsernameLabel
            // 
            UsernameLabel.AutoSize = true;
            UsernameLabel.Location = new Point(112, 14);
            UsernameLabel.Name = "UsernameLabel";
            UsernameLabel.Size = new Size(0, 20);
            UsernameLabel.TabIndex = 0;
            // 
            // LogoutButton
            // 
            LogoutButton.Location = new Point(12, 10);
            LogoutButton.Name = "LogoutButton";
            LogoutButton.Size = new Size(94, 29);
            LogoutButton.TabIndex = 1;
            LogoutButton.Text = "Odhlásit se";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // ManageUsersButton
            // 
            ManageUsersButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ManageUsersButton.Location = new Point(651, 10);
            ManageUsersButton.Name = "ManageUsersButton";
            ManageUsersButton.Size = new Size(137, 29);
            ManageUsersButton.TabIndex = 2;
            ManageUsersButton.Text = "Správa uživatelů";
            ManageUsersButton.UseVisualStyleBackColor = true;
            ManageUsersButton.Click += ManageUsersButton_Click;
            // 
            // ContractsListView
            // 
            ContractsListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ContractsListView.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3 });
            ContractsListView.FullRowSelect = true;
            ContractsListView.GridLines = true;
            ContractsListView.Location = new Point(12, 86);
            ContractsListView.MultiSelect = false;
            ContractsListView.Name = "ContractsListView";
            ContractsListView.Size = new Size(776, 397);
            ContractsListView.TabIndex = 3;
            ContractsListView.UseCompatibleStateImageBehavior = false;
            ContractsListView.View = View.Details;
            ContractsListView.DoubleClick += ContractsListView_DoubleClick;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Zákazník";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Popis";
            columnHeader3.Width = 300;
            // 
            // SearchInput
            // 
            SearchInput.Location = new Point(12, 49);
            SearchInput.Name = "SearchInput";
            SearchInput.PlaceholderText = "Hledat zakázku...";
            SearchInput.Size = new Size(260, 27);
            SearchInput.TabIndex = 4;
            SearchInput.TextChanged += SearchInput_TextChanged;
            // 
            // UpdateDataButton
            // 
            UpdateDataButton.Location = new Point(278, 48);
            UpdateDataButton.Name = "UpdateDataButton";
            UpdateDataButton.Size = new Size(117, 29);
            UpdateDataButton.TabIndex = 5;
            UpdateDataButton.Text = "Aktualizovat";
            UpdateDataButton.UseVisualStyleBackColor = true;
            UpdateDataButton.Click += UpdateDataButton_Click;
            // 
            // AddContractButton
            // 
            AddContractButton.Location = new Point(12, 489);
            AddContractButton.Name = "AddContractButton";
            AddContractButton.Size = new Size(179, 29);
            AddContractButton.TabIndex = 6;
            AddContractButton.Text = "Přidat zakázku";
            AddContractButton.UseVisualStyleBackColor = true;
            AddContractButton.Click += AddContractButton_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 530);
            Controls.Add(AddContractButton);
            Controls.Add(UpdateDataButton);
            Controls.Add(SearchInput);
            Controls.Add(ContractsListView);
            Controls.Add(ManageUsersButton);
            Controls.Add(LogoutButton);
            Controls.Add(UsernameLabel);
            Name = "MainForm";
            Text = "Správa zakázek";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label UsernameLabel;
        private Button LogoutButton;
        private Button ManageUsersButton;
        private SortableListView ContractsListView;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private TextBox SearchInput;
        private Button UpdateDataButton;
        private Button AddContractButton;
    }
}
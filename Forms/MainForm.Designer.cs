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
            EmployeeMngButton = new Button();
            WorkTypeMngButton = new Button();
            label1 = new Label();
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
            LogoutButton.TabIndex = 0;
            LogoutButton.Text = "Odhlásit se";
            LogoutButton.UseVisualStyleBackColor = true;
            LogoutButton.Click += LogoutButton_Click;
            // 
            // ManageUsersButton
            // 
            ManageUsersButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ManageUsersButton.Location = new Point(767, 10);
            ManageUsersButton.Name = "ManageUsersButton";
            ManageUsersButton.Size = new Size(137, 29);
            ManageUsersButton.TabIndex = 3;
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
            ContractsListView.Size = new Size(892, 397);
            ContractsListView.TabIndex = 5;
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
            columnHeader3.Width = 600;
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
            UpdateDataButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            UpdateDataButton.Location = new Point(700, 489);
            UpdateDataButton.Name = "UpdateDataButton";
            UpdateDataButton.Size = new Size(204, 29);
            UpdateDataButton.TabIndex = 7;
            UpdateDataButton.Text = "Aktualizovat Data";
            UpdateDataButton.UseVisualStyleBackColor = true;
            UpdateDataButton.Click += UpdateDataButton_Click;
            // 
            // AddContractButton
            // 
            AddContractButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            AddContractButton.Location = new Point(12, 489);
            AddContractButton.Name = "AddContractButton";
            AddContractButton.Size = new Size(179, 29);
            AddContractButton.TabIndex = 6;
            AddContractButton.Text = "Přidat zakázku";
            AddContractButton.UseVisualStyleBackColor = true;
            AddContractButton.Click += AddContractButton_Click;
            // 
            // EmployeeMngButton
            // 
            EmployeeMngButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EmployeeMngButton.Location = new Point(600, 10);
            EmployeeMngButton.Name = "EmployeeMngButton";
            EmployeeMngButton.Size = new Size(161, 29);
            EmployeeMngButton.TabIndex = 2;
            EmployeeMngButton.Text = "Správa zaměstnanců";
            EmployeeMngButton.UseVisualStyleBackColor = true;
            EmployeeMngButton.Click += EmployeeMngButton_Click;
            // 
            // WorkTypeMngButton
            // 
            WorkTypeMngButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            WorkTypeMngButton.Location = new Point(394, 10);
            WorkTypeMngButton.Name = "WorkTypeMngButton";
            WorkTypeMngButton.Size = new Size(200, 29);
            WorkTypeMngButton.TabIndex = 1;
            WorkTypeMngButton.Text = "Správa pracovních činností";
            WorkTypeMngButton.UseVisualStyleBackColor = true;
            WorkTypeMngButton.Click += WorkTypeMngButton_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 8F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(494, 64);
            label1.Name = "label1";
            label1.Size = new Size(410, 19);
            label1.TabIndex = 9;
            label1.Text = "Pro zobrazení detailů určité zakázky stačí na ní dvakrát kliknout";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(916, 530);
            Controls.Add(label1);
            Controls.Add(WorkTypeMngButton);
            Controls.Add(EmployeeMngButton);
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
        private Button EmployeeMngButton;
        private Button WorkTypeMngButton;
        private Label label1;
    }
}
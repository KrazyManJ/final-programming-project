namespace final_programming_project
{
    partial class UserManagementForm
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
            UserListView = new ListView();
            id = new ColumnHeader();
            name = new ColumnHeader();
            role = new ColumnHeader();
            regUserBtn = new Button();
            EditBtn = new Button();
            RemoveBtn = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // userView
            // 
            UserListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            UserListView.Columns.AddRange(new ColumnHeader[] { id, name, role });
            UserListView.FullRowSelect = true;
            UserListView.Location = new Point(10, 10);
            UserListView.Margin = new Padding(10);
            UserListView.MultiSelect = false;
            UserListView.Name = "userView";
            UserListView.Size = new Size(780, 385);
            UserListView.TabIndex = 0;
            UserListView.UseCompatibleStateImageBehavior = false;
            UserListView.View = View.Details;
            UserListView.ColumnClick += userView_ColumnClick;
            UserListView.SelectedIndexChanged += UserSelectionChanged;
            // 
            // id
            // 
            id.Text = "ID";
            id.Width = 70;
            // 
            // name
            // 
            name.Text = "Uživatelské jméno";
            name.Width = 200;
            // 
            // role
            // 
            role.Text = "Role";
            role.Width = 200;
            // 
            // regUserBtn
            // 
            regUserBtn.Location = new Point(3, 8);
            regUserBtn.Name = "regUserBtn";
            regUserBtn.Size = new Size(238, 29);
            regUserBtn.TabIndex = 1;
            regUserBtn.Text = "Registrovat Nového Uživatele";
            regUserBtn.UseVisualStyleBackColor = true;
            regUserBtn.Click += regUserBtn_Click;
            // 
            // EditBtn
            // 
            EditBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            EditBtn.Enabled = false;
            EditBtn.Location = new Point(463, 8);
            EditBtn.Name = "EditBtn";
            EditBtn.Size = new Size(154, 29);
            EditBtn.TabIndex = 2;
            EditBtn.Text = "Upravit uživatele";
            EditBtn.UseVisualStyleBackColor = true;
            EditBtn.Click += EditBtn_Click;
            // 
            // RemoveBtn
            // 
            RemoveBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            RemoveBtn.Enabled = false;
            RemoveBtn.Location = new Point(623, 8);
            RemoveBtn.Name = "RemoveBtn";
            RemoveBtn.Size = new Size(154, 29);
            RemoveBtn.TabIndex = 3;
            RemoveBtn.Text = "Vymazat Uživatele";
            RemoveBtn.UseVisualStyleBackColor = true;
            RemoveBtn.Click += RemoveBtn_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(regUserBtn);
            panel1.Controls.Add(RemoveBtn);
            panel1.Controls.Add(EditBtn);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(10, 400);
            panel1.Name = "panel1";
            panel1.Size = new Size(780, 40);
            panel1.TabIndex = 4;
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Controls.Add(UserListView);
            MinimumSize = new Size(600, 240);
            Name = "UserManagementForm";
            Padding = new Padding(10);
            Text = "Správá uživatelů";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView UserListView;
        private ColumnHeader id;
        private ColumnHeader name;
        private ColumnHeader role;
        private Button regUserBtn;
        private Button EditBtn;
        private Button RemoveBtn;
        private Panel panel1;
    }
}
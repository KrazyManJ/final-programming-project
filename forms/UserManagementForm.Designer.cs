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
            userView = new ListView();
            id = new ColumnHeader();
            name = new ColumnHeader();
            role = new ColumnHeader();
            regUserBtn = new Button();
            SuspendLayout();
            // 
            // userView
            // 
            userView.Columns.AddRange(new ColumnHeader[] { id, name, role });
            userView.Location = new Point(12, 12);
            userView.Name = "userView";
            userView.Size = new Size(440, 274);
            userView.Sorting = SortOrder.Ascending;
            userView.TabIndex = 0;
            userView.UseCompatibleStateImageBehavior = false;
            userView.View = View.Details;
            // 
            // id
            // 
            id.Text = "ID";
            id.Width = 31;
            // 
            // name
            // 
            name.Text = "Username";
            name.Width = 78;
            // 
            // role
            // 
            role.Text = "Role";
            role.Width = 326;
            // 
            // regUserBtn
            // 
            regUserBtn.Location = new Point(12, 409);
            regUserBtn.Name = "regUserBtn";
            regUserBtn.Size = new Size(179, 29);
            regUserBtn.TabIndex = 1;
            regUserBtn.Text = "Register New User";
            regUserBtn.UseVisualStyleBackColor = true;
            regUserBtn.Click += regUserBtn_Click;
            // 
            // UserManagementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(regUserBtn);
            Controls.Add(userView);
            Name = "UserManagementForm";
            Text = "UserManagementForm";
            ResumeLayout(false);
        }

        #endregion

        private ListView userView;
        private ColumnHeader id;
        private ColumnHeader name;
        private ColumnHeader role;
        private Button regUserBtn;
    }
}
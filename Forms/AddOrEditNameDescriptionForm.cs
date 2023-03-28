using final_programming_project.Source;

namespace final_programming_project.Forms
{
    public partial class AddOrEditNameDescriptionForm<T> : Form where T : ISQLNameDescObject<T>
    {

        public TableName Table { get; set; }
        public T? Value { get; set; }

        public AddOrEditNameDescriptionForm(string formName,  TableName name)
        {
            InitializeComponent();
            Table = name;
            Text = formName;
            ActionButton.Text = "Přidat";
        }

        public AddOrEditNameDescriptionForm(string formName, TableName name, T value)
        {
            InitializeComponent();
            Table = name;
            Value = value;
            Text = formName;
            ActionButton.Text = "Upravit";
            NameInput.Text = value.Name;
            DescriptionInput.Text = value.Description;
        }


        public void UpdateButtonStatus(object sender, EventArgs e)
        {
            ActionButton.Enabled = NameInput.Text != string.Empty && DescriptionInput.Text != string.Empty;
        }

        private void Process()
        {
            T? value = ISQLNameDescObject<T>.Construct(NameInput.Text, DescriptionInput.Text);
            if (value == null) return;
            if (Value == null) SQLManager.Insert(Table, value);
            else SQLManager.Update(Table, Value.ID, value);
            Value = value;
            Close();
        }

        private void ActionButton_Click(object sender, EventArgs e) => Process();
        

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && ActionButton.Enabled) Process();
        }
    }
}

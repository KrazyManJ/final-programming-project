namespace final_programming_project.Source
{
    public class MSGBoxes
    {
        public static void Error(string text) =>
            MessageBox.Show(text, "Chyba!", MessageBoxButtons.OK, MessageBoxIcon.Error);

        public static bool AskConfirm(string caption, string text) =>
            MessageBox.Show(text, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;

    }
}

using System.Windows.Forms;

namespace XShort
{
    public partial class ProgressForm : Form
    {
        bool close = false;
        public ProgressForm()
        {
            InitializeComponent();
            circularProgressBar1.Text = "Loading...";
        }


        public void ChangeDisplay(int phase)
        {
            switch (phase)
            {
                case 1:
                    circularProgressBar1.Text = "Loading name";
                    return;
                case 2:
                    circularProgressBar1.Text = "Loading path";
                    return;
                case 3:
                    circularProgressBar1.Text = "Loading para";
                    return;
                case 4:
                    circularProgressBar1.Text = "Saving...";
                    return;
                case 5:
                    circularProgressBar1.Text = "Scanning...";
                    return;
                default:
                    circularProgressBar1.Text = "Checking...";
                    return;
            }
        }

        public void CloseForm()
        {
            close = true;
            this.Close();
            this.Dispose();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != true)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}

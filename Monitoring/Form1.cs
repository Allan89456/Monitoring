namespace Monitoring {
    public partial class Form1 : Form {
        private TaskManager manager = new();

        public Form1() {
            InitializeComponent();
        }

        /// <summary>
        /// Change the value of TopMost.
        /// </summary>
        private void ChangeTopMost(object sender, EventArgs e) {
            TopMost = !TopMost;
        }

        /// <summary>
        /// Launch the Task Manager when the form is shown.
        /// </summary>
        private void Form1_Shown(object sender, EventArgs e) {
            Controls.Add(manager.mainPanel);
        }

        /// <summary>
        /// Stop the Utility Manager when the form is closed.
        /// </summary>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            manager.Stop();
        }
    }
}
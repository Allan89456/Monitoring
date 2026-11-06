namespace Configuration {
    public partial class Form1 : Form {
        PanelManager menu = new();

        public Form1() {
            InitializeComponent();
            Controls.Add(menu.mainPanel);
        }

        /// <summary>
        /// Save the configuration when the form is closed.
        /// ID string generated is "M:Configuration.Form1.Form1_FormClosing".
        /// </summary
        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            menu.Save();
        }
    }
}
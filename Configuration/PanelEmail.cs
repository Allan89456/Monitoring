namespace Configuration {
    /// <summary>
    /// Class used for managing email panel.
    /// ID string generated is "T:Configuration.PanelEmail".
    /// </summary>
    public partial class PanelEmail : MyPanel {
        private MonitoringConfig config;

        /// <summary>
        /// Build a Email Panel.
        /// ID string generated is "M:Configuration.PanelEmail.#ctor(CopyAndBackupConfig)".
        /// </summary>
        /// <param name="config">Configuration from a JSON file.</param>
        public PanelEmail(MonitoringConfig config) {
            Name = "panelEmail";
            this.config = config;
        }

        public override void InitializeComponent() {
            Create();
            Add();
            InitializeComboBox();
        }

        public override void Reset() {
            if (Controls.Count != 0) {
                textBoxEmailSource.ResetText();
                textBoxEmailDestination.ResetText();
                textBoxEmailPassword.ResetText();
                textBoxEmailRelay.ResetText();
                comboBoxEmailPort.SelectedItem = config.emailPort;
                checkBoxEmailSSL.Checked = config.emailSSL;
            }
        }

        /// <summary>
        /// Initialize the ComboBox.
        /// ID string generated is "M:Configuration.PanelEmail.InitializeComboBox".
        /// </summary>
        private void InitializeComboBox() {
            comboBoxEmailPort.Items.Add(25);
            comboBoxEmailPort.Items.Add(465);
            comboBoxEmailPort.Items.Add(587);
            comboBoxEmailPort.SelectedItem = config.emailPort;
        }

        /// <summary>
        /// Occurs when the sourceemail is changed.
        /// ID string generated is "M:Configuration.PanelEmail.emailSourceChanged".
        /// </summary>
        private void emailSourceChanged(object sender, EventArgs e) {
            config.SetEmailSource(textBoxEmailSource.Text);
        }

        /// <summary>
        /// Occurs when the email destination is changed.
        /// ID string generated is "M:Configuration.PanelEmail.emailDestinationChanged".
        /// </summary>
        private void emailDestinationChanged(object sender, EventArgs e) {
            config.SetEmailDestination(textBoxEmailDestination.Text);
        }

        /// <summary>
        /// Occurs when the password of the email is changed.
        /// ID string generated is "M:Configuration.PanelEmail.emailPasswordChanged".
        /// </summary>
        private void emailPasswordChanged(object sender, EventArgs e) {
            config.SetEmailPassword(textBoxEmailPassword.Text);
        }

        /// <summary>
        /// Occurs when the relay of the email is changed.
        /// ID string generated is "M:Configuration.PanelEmail.emailRelayChanged".
        /// </summary>
        private void emailRelayChanged(object sender, EventArgs e) {
            config.SetEmailRelay(textBoxEmailRelay.Text);
        }

        /// <summary>
        /// Occurs when the port of the email is changed.
        /// ID string generated is "M:Configuration.PanelEmail.emailPortChanged".
        /// </summary>
        private void emailPortChanged(object sender, EventArgs e) {
            config.SetEmailPort((int) comboBoxEmailPort.SelectedItem);
        }

        /// <summary>
        /// Occurs when the SSL of the email is changed.
        /// ID string generated is "M:Configuration.PanelEmail.emailSSLChanged".
        /// </summary>
        private void emailSSLChanged(object sender, EventArgs e) {
            config.SetEmailSSL(checkBoxEmailSSL.Checked);
        }
    }
}
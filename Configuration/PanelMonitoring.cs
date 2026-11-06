namespace Configuration {
    /// <summary>
    /// Class used for managing monitoring panel.
    /// ID string generated is "T:Configuration.PanelMonitoring".
    /// </summary>
    public partial class PanelMonitoring : MyPanel {
        private MonitoringConfig config;
        private Machine currentMachine = new();
        private int selectedIndex;

        /// <summary>
        /// Build a Monitoring Panel.
        /// ID string generated is "M:Configuration.PanelMonitoring.#ctor(MonitoringConfig)".
        /// </summary>
        /// <param name="config">Configuration from a JSON file.</param>
        public PanelMonitoring(MonitoringConfig config) {
            Name = "PanelMonitoring";
            this.config = config;
            VisibleChanged += VisibilityChanged;
        }

        public override void InitializeComponent() {
            Create();
            Add();
            HideForm();
        }

        public override void Reset() {
            listBoxMachines.Items.Clear();
            if (Controls.Count != 0) {
                HideForm();
                buttonAddMachine.Show();
                UpdateLabelNbMachines();
            }
        }

        /// <summary>
        /// Sort the ListBox when the panel is visible.
        /// ID string generated is "M:Configuration.PanelCopy.VisibilityChanged".
        /// </summary>
        private void VisibilityChanged(object sender, EventArgs e) {
            if (Visible) {
                config.SortMachines();
                UpdateListBox();
                HideForm();
            }
        }

        /// <summary>
        /// Add a machine to the list box.
        /// ID string generated is "M:Configuration.PanelCopy.buttonAddMachine_Click".
        /// </summary>
        private void buttonAddMachine_Click(object sender, EventArgs e) {
            if (config.AddMachine(new Machine())) {
                UpdateLabelNbMachines();
                UpdateListBox();
                if (config.machines.Count == MonitoringConfig.GetNbMachinesMax()) {
                    buttonAddMachine.Hide();
                }
                listBoxMachines.SelectedIndex = config.Find(new Machine());
                listBoxMachines_Click(this, new EventArgs());
            } 
        }

        /// <summary>
        /// Remove an item from the list box containing the machines.
        /// ID string generated is "M:Configuration.PanelMonitoring.buttonRemoveMachine_Click".
        /// </summary>
        private void buttonRemoveMachine_Click(object sender, EventArgs e) {
            config.RemoveMachine(selectedIndex);
            listBoxMachines.Items.RemoveAt(selectedIndex);
            buttonAddMachine.Show();
            HideForm();
            UpdateLabelNbMachines();
        }

        /// <summary>
        /// Select an item from the list box containing the machines.
        /// ID string generated is "M:Configuration.PanelMonitoring.listBoxMachines_Click".
        /// </summary>
        private void listBoxMachines_Click(object sender, EventArgs e) {
            if (listBoxMachines.SelectedItem != null) {
                currentMachine = new(listBoxMachines.SelectedItem);
                selectedIndex = listBoxMachines.SelectedIndex;
                CopyMachine();
                ShowForm();
                VerifyIP();
            }
        }

        /// <summary>
        /// Copy the currentMachine in the form.
        /// ID string generated is "M:Configuration.PanelMonitoring.CopyMachine".
        /// </summary>
        private void CopyMachine() {
            textBoxMachineName.Text = currentMachine.name;
            textBoxMachineIPAddress.Text = currentMachine.ipAddress;
            numericUpDownMachineInterval.Value = currentMachine.interval;
        }

        /// <summary>
        /// Verify the IP entered and indicate if it's not valid.
        /// ID string generated is "M:Configuration.PanelMonitoring.VerifyIP".
        /// </summary>
        private void VerifyIP() {
            if (Machine.IsIPValid(currentMachine.ipAddress)) {
                labelInvalidIP.Hide();
                textBoxMachineIPAddress.BackColor = Color.White;
                textBoxMachineIPAddress.ForeColor = Color.Black;
            } else {
                labelInvalidIP.Show();
                textBoxMachineIPAddress.BackColor = Color.Red;
                textBoxMachineIPAddress.ForeColor = Color.White;
            }
        }

        /// <summary>
        /// Occurs when the name of the machine is changed.
        /// ID string generated is "M:Configuration.PanelMonitoring.machineNameChanged".
        /// </summary>
        private void machineNameChanged(object sender, EventArgs e) {
            currentMachine.name = textBoxMachineName.Text;
            ChangeMachine();
        }

        /// <summary>
        /// Occurs when the IP address of the machine is changed.
        /// ID string generated is "M:Configuration.PanelMonitoring.machineIPAddressChanged".
        /// </summary>
        private void machineIPAddressChanged(object sender, EventArgs e) {
            currentMachine.ipAddress = textBoxMachineIPAddress.Text;
            ChangeMachine();
            VerifyIP();
        }

        /// <summary>
        /// Occurs when the interval of the machine is changed.
        /// ID string generated is "M:Configuration.PanelMonitoring.machineIntervalChanged".
        /// </summary>
        private void machineIntervalChanged(object sender, EventArgs e) {
            currentMachine.interval = (uint)numericUpDownMachineInterval.Value;
            ChangeMachine();
        }

        /// <summary>
        /// Change a machine from the ListBox.
        /// ID string generated is "M:Configuration.PanelMonitoring.ChangeMachine".
        /// </summary>
        private void ChangeMachine() {
            config.ChangeMachine(currentMachine, selectedIndex);
            UpdateListBox();
        }

        /// <summary>
        /// Update the ListBox.
        /// ID string generated is "M:Configuration.PanelMonitoring.UpdateListBox".
        /// </summary>
        private void UpdateListBox() {
            listBoxMachines.Items.Clear();
            foreach (var path in config.machines) {
                listBoxMachines.Items.Add(path);
            }
        }

        /// <summary>
        /// Update the Label of the number of machines.
        /// ID string generated is "M:Configuration.PanelMonitoring.UpdateLabelNbMachines".
        /// </summary>
        private void UpdateLabelNbMachines() {
            labelNbMachinesCurrent.Text = $"{config.machines.Count}";
        }

        /// <summary>
        /// Hide the form for editing a machine's info.
        /// ID string generated is "M:Configuration.PanelMonitoring.HideForm".
        /// </summary
        private void HideForm() {
            for (var i = 0; i < 3; i++)
                labelsMachine[i].Hide();
            textBoxMachineName.Hide();
            textBoxMachineIPAddress.Hide();
            numericUpDownMachineInterval.Hide();
            buttonRemoveMachine.Hide();
            labelInvalidIP.Hide();
        }

        /// <summary>
        /// Show the form for editing a machine's info.
        /// ID string generated is "M:Configuration.PanelMonitoring.ShowForm".
        /// </summary>
        private void ShowForm() {
            for (var i = 0; i < 3; i++)
                labelsMachine[i].Show();
            textBoxMachineName.Show();
            textBoxMachineIPAddress.Show();
            numericUpDownMachineInterval.Show();
            buttonRemoveMachine.Show();
        }
    }
}
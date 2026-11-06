using System.Diagnostics;

namespace Configuration {
    public partial class PanelMenu : MyPanel {
        MonitoringConfig config;
        private string monitoringPath = "../../../../Monitoring/bin/Debug/net10.0-windows/Monitoring.exe";

        /// <summary>
        /// Build a Menu Panel.
        /// ID string generated is "M:Configuration.PanelMenu.#ctor(MonitoringConfig)".
        /// </summary>
        /// <param name="config">Configuration from a JSON file.</param>
        public PanelMenu(MonitoringConfig config) {
            Name = "PanelMenu";
            this.config = config;
            VisibleChanged += VisibilityChanged;
        }

        public override void InitializeComponent() {
            Create();
            Add();
            ManageDisplay();
        }

        public override void Reset() {
            HideReset();
            HideMonitor();
        }

        /// <summary>
        /// Manage the display of the buttons when the panel is visible.
        /// ID string generated is "M:Configuration.PanelMenu.VisibilityChanged".
        /// </summary>
        private void VisibilityChanged(object sender, EventArgs e) {
            if (Visible) {
                ManageDisplay();
            }
        }

        /// <summary>
        /// Manage the display of the buttons.
        /// ID string generated is "M:Configuration.PanelMenu.ManageDisplay".
        /// </summary>
        public void ManageDisplay() {
            if (CheckExistingConf()) {
                ShowReset();
                if (CheckMachineData()) {
                    ShowMonitor();
                } else {
                    HideMonitor();
                }
            } else {
                HideReset();
                HideMonitor();
            }
        }

        /// <summary>
        /// Check that there is an existing configuration.
        /// ID string generated is "M:Configuration.PanelMenu.CheckExistingConf".
        /// </summary>
        /// <returns>True if the config file is not empty.</returns>
        private bool CheckExistingConf() {
            return !config.IsEmpty();
        }

        /// <summary>
        /// Check that there is complete data for at least one machine.
        /// ID string generated is "M:Configuration.PanelMenu.CheckMachineData".
        /// </summary>
        /// <returns>True if there is complete data for at least one machine.</returns>
        private bool CheckMachineData() {
            bool isOneValid = false;
            for (var i = 0; i < config.machines.Count && !isOneValid; i++) {
                Machine machine = config.machines[i];
                isOneValid = machine.IsComplete();
            }
            return isOneValid;
        }

        /// <summary>
        /// Hide the reset button.
        /// ID string generated is "M:Configuration.PanelMenu.HideReset".
        /// </summary>
        private void HideReset() {
            buttonReset.Hide();
        }

        /// <summary>
        /// Show the reset button.
        /// ID string generated is "M:Configuration.PanelMenu.ShowReset".
        /// </summary>
        private void ShowReset() {
            buttonReset.Show();
        }

        /// <summary>
        /// Hide the monitor button.
        /// ID string generated is "M:Configuration.PanelMenu.HideMonitor".
        /// </summary>
        private void HideMonitor() {
            buttonMonitor.Hide();
        }

        /// <summary>
        /// Show the monitor button.
        /// ID string generated is "M:Configuration.PanelMenu.ShowMonitor".
        /// </summary>
        private void ShowMonitor() {
            buttonMonitor.Show();
        }

        /// <summary>
        /// Exit and launch the monitoring application when the button is pressed.
        /// ID string generated is "M:Configuration.PanelMenu.buttonMonitor_Click".
        /// </summary>
        private void buttonMonitor_Click(object sender, EventArgs e) {
            var p = new Process();
            p.StartInfo.FileName = monitoringPath;
            p.Start();
            ExitApp();
        }

        /// <summary>
        /// Exit the application when the button is pressed.
        /// ID string generated is "M:Configuration.PanelMenu.buttonLeave_Click".
        /// </summary>
        private void buttonLeave_Click(object sender, EventArgs e) {
            ExitApp();
        }

        /// <summary>
        /// Exit the application.
        /// ID string generated is "M:Configuration.PanelMenu.ExitApp".
        /// </summary>
        private void ExitApp() {
            Application.Exit();
        }
    }
}
using System.Text.Json;

namespace Configuration {
    /// <summary>
    /// Class used for managing panels.
    /// ID string generated is "T:Configuration.PanelManager".
    /// </summary>
    public partial class PanelManager {
        private MonitoringConfig config;
        private string fileName = "../../../../settings/config.json";

        /// <summary>
        /// Build a Panel Manager.
        /// ID string generated is "M:Configuration.PanelManager.#ctor".
        /// </summary>
        public PanelManager() {
            ReadJson();
            Add();
            Create();
            Show(panels.Values.First());
        }

        /// <summary>
        /// Read the JSON file and fill in the config..
        /// ID string generated is "M:Configuration.PanelManager.ReadJson".
        /// </summary>
        private void ReadJson() {
            try {
                string jsonString = File.ReadAllText(fileName);
                config = JsonSerializer.Deserialize<MonitoringConfig>(jsonString)!;
            } catch (Exception) {
                config = new();
            }
            config.dateLastModificationModified += updateDateModification;
        }

        /// <summary>
        /// Display the panel with the monitoring configuration.
        /// ID string generated is "M:Configuration.PanelManager.ShowMonitor".
        /// </summary>
        private void ShowMonitor(object sender, EventArgs e) {
            Show(panels.Values.Where(panel => panel is PanelMonitoring).First());
        }

        /// <summary>
        /// Display the panel with the autor's informations.
        /// ID string generated is "M:Configuration.PanelManager.ShowAbout".
        /// </summary>
        private void ShowAbout(object sender, EventArgs e) {
            Show(panels.Values.Where(panel => panel is PanelAbout).First());
        }

        /// <summary>
        /// Display the panel with the monitoring configuration.
        /// ID string generated is "M:Configuration.PanelManager.ShowMonitor".
        /// </summary>
        private void ResetData(object sender, EventArgs e) {
            config.Reset();
            foreach (var panel in panels.Values) {
                panel.Reset();
            }
        }

        /// <summary>
        /// Display the panel selected by the clicked button.
        /// ID string generated is "M:Configuration.PanelManager.buttonClick".
        /// </summary>
        private void buttonClick(object sender, EventArgs e) {
            Show(panels[(Button)sender]);
        }

        /// <summary>
        /// Show a panel on the form.
        /// ID string generated is "M:Configuration.PanelManager.Show(MyPanel)".
        /// </summary>
        /// <param name="panel">The panel to show.</param>
        public void Show(MyPanel panel) {
            HideAll();
            if (panel.Controls.Count == 0) {
                panel.InitializeComponent();
            }

            if (panel is PanelMenu) {
                HideNavbar();
            } else {
                ShowNavBar();
            }

            panel.Show();
        }

        /// <summary>
        /// Hide all the panels to the form.
        /// ID string generated is "M:Configuration.PanelManager.HideAll".
        /// </summary>
        private void HideAll() {
            foreach (var panel in panels) {
                panel.Value.Hide();
            }
        }

        /// <summary>
        /// Hide all the buttons of the navbar to the form.
        /// ID string generated is "M:Configuration.PanelManager.HideNavbar".
        /// </summary>
        private void HideNavbar() {
            foreach (var panel in panels) {
                panel.Key.Hide();
            }
        }

        /// <summary>
        /// Hide all the buttons of the navbar to the form.
        /// ID string generated is "M:Configuration.PanelManager.ShowNavBar".
        /// </summary>
        private void ShowNavBar() {
            foreach (var panel in panels) {
                panel.Key.Show();
            }
        }

        /// <summary>
        /// Save data in a JSON file.
        /// ID string generated is "M:Configuration.PanelManager.Save".
        /// </summary>
        public void Save() {
            config.SortMachines();
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(fileName, jsonString);
        }

        /// <summary>
        /// Update the label of the last modification.
        /// ID string generated is "M:Configuration.PanelManager.updateDateModification".
        /// </summary>
        private void updateDateModification(object sender, EventArgs e) {
            labelDateLastChange.Text = $"{config.dateLastModification:HH:mm dd/MM/yyyy}";
            if (!labelLastChange.Visible) {
                labelLastChange.Show();
                labelDateLastChange.Show();
            }
        }
    }
}
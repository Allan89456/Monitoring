namespace Configuration {
    partial class PanelManager {
        public Panel mainPanel { get; private set; } = new();
        private Panel panelNavbar = new();
        private Dictionary<Button, MyPanel> panels = new();
        private Label labelLastChange = new();
        private Label labelDateLastChange = new();

        /// <summary>
        /// Add buttons and panels to the dictionary.
        /// ID string generated is "M:Configuration.PanelManager.Add".
        /// </summary>
        private void Add() {
            panels.Add(new Button(), new PanelMenu(config));
            ((PanelMenu)panels.Values.First()).buttonConfig_Click += ShowMonitor;
            ((PanelMenu)panels.Values.First()).buttonAbout_Click += ShowAbout;
            ((PanelMenu)panels.Values.First()).resetData += ResetData;

            panels.Add(new Button(), new PanelMonitoring(config));
            panels.Add(new Button(), new PanelEmail(config));
            panels.Add(new Button(), new PanelAbout());
            AddMainPanel();
        }

        /// <summary>
        /// Add buttons and panels to the main panel.
        /// ID string generated is "M:Configuration.PanelManager.AddMainPanel".
        /// </summary>
        private void AddMainPanel() {
            foreach (var panel in panels) {
                mainPanel.Controls.Add(panel.Key);
                mainPanel.Controls.Add(panel.Value);
            }
            mainPanel.Controls.Add(labelLastChange);
            mainPanel.Controls.Add(labelDateLastChange);
        }

        /// <summary>
        /// Create tools.
        /// ID string generated is "M:Configuration.PanelManager.Create".
        /// </summary>
        private void Create() {
            CreateMainPanel();
            int i = 50;
            foreach (var panel in panels) {
                CreatePanel(panel.Value);
                string name = panel.Value.GetType().ToString().Remove(0, 19);
                CreateButton(panel.Key, i, $"button{name}", name);
                i += 200;
            }
            CreateAllLabels();
        }

        /// <summary>
        /// Create the main panel.
        /// ID string generated is "M:Configuration.PanelManager.CreateMainPanel".
        /// </summary>
        private void CreateMainPanel() {
            mainPanel.Location = new Point(0, 0);
            mainPanel.Size = new Size(918, 597);
        }

        /// <summary>
        /// Create a panel.
        /// ID string generated is "M:Configuration.PanelManager.Create(MyPanel)".
        /// </summary>
        /// <param name="panel">The panel to create.</param>
        private void CreatePanel(MyPanel panel) {
            panel.Location = new Point(12, 87);
            panel.Size = new Size(775, 394);
        }

        /// <summary>
        /// Create a Button.
        /// ID string generated is "M:Configuration.PanelManager.CreateButton(Button, int, string, string)".
        /// </summary>
        /// <param name="button">The Button to create.</param>
        /// <param name="point">The location of the Button.</param>
        /// <param name="name">The name of the Button.</param>
        /// <param name="text">The text of the Button.</param>
        private void CreateButton(Button button, int point, string name, string text) {
            button.Location = new Point(point, 30);
            button.Name = name;
            button.Size = new Size(95, 30);
            button.Text = text;
            button.Click += buttonClick;
        }

        /// <summary>
        /// Create all Label.
        /// ID string generated is "M:Configuration.PanelManager.CreateAllLabels".
        /// </summary>
        private void CreateAllLabels() {
            CreateLabel(labelLastChange, new Point(495, 0), "labelLastChange", "Last change saved on :");
            CreateLabel(labelDateLastChange, new Point(650, 0), "labelDateLastChange",
                $"{config.dateLastModification:HH:mm dd/MM/yyyy}");

            if (config.dateLastModification.Year < 2026) {
                labelLastChange.Hide();
                labelDateLastChange.Hide();
            }
        }

        /// <summary>
        /// Create a Label.
        /// ID string generated is "M:Configuration.PanelManager.CreateLabel(Label, Point, string, string)".
        /// </summary>
        /// <param name="label">The label to create.</param>
        /// <param name="point">The location of the Label.</param>
        /// <param name="name">The name of the Label.</param>
        /// <param name="text">The text of the Label.</param>
        private void CreateLabel(Label label, Point point, string name, string text) {
            label.AutoSize = true;
            label.Location = point;
            label.Name = name;
            label.Size = new Size(364, 20);
            label.Text = text;
        }
    }
}
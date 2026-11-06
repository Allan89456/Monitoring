namespace Configuration {
    partial class PanelMenu {
        private Button buttonConfig;
        private Button buttonMonitor;
        private Button buttonLeave;
        private Button buttonReset;
        private Button buttonAbout;

        public event EventHandler buttonConfig_Click;
        public event EventHandler buttonAbout_Click;
        public event EventHandler resetData;

        /// <summary>
        /// Add tools to the Menu Panel.
        /// ID string generated is "M:Configuration.PanelMenu.Add".
        /// </summary>
        private void Add() {
            Controls.Add(buttonMonitor);
            Controls.Add(buttonReset);
            Controls.Add(buttonConfig);
            Controls.Add(buttonLeave);
            Controls.Add(buttonAbout);
        }

        /// <summary>
        /// Create tools.
        /// ID string generated is "M:Configuration.PanelMenu.Create".
        /// </summary>
        private void Create() {
            CreateAllButtons();
        }

        /// <summary>
        /// Only create buttons to create a configuration.
        /// ID string generated is "M:Configuration.PanelMenu.CreateAllButtons".
        /// </summary>
        private void CreateAllButtons() {
            buttonConfig = CreateButton(45, "buttonConfig", "Configuration");
            buttonConfig.Click += buttonConfig_Click;

            buttonLeave = CreateButton(95, "buttonLeave", "Leave");
            buttonLeave.Click += buttonLeave_Click;

            buttonMonitor = CreateButton(145, "buttonMonitor", "Leave and monitor");
            buttonMonitor.Click += buttonMonitor_Click;

            buttonReset = CreateButton(195, "buttonReset", "Reset");
            buttonReset.Click += resetData;
            buttonReset.BackColor = Color.Red;
            buttonReset.ForeColor = Color.White;

            buttonAbout = CreateButton(245, "buttonAbout", "About");
            buttonAbout.Click += buttonAbout_Click;
        }

        /// <summary>
        /// Create a Button.
        /// ID string generated is "M:Configuration.PanelMenu.CreateButton(Point, string, string)".
        /// </summary>
        /// <param name="point">The y location of the Button.</param>
        /// <param name="name">The name of the Button.</param>
        /// <param name="text">The text of the Button.</param>
        /// <returns>The Button create.</returns>
        private Button CreateButton(int point, string name, string text) {
            return new Button {
                Location = new Point(320, point),
                Name = name,
                Size = new Size(150, 30),
                Text = text
            };
        }
    }
}
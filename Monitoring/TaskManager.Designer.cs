namespace Monitoring {
    partial class TaskManager {
        public Panel mainPanel { get; private set; } = new();
        private Label labelErrorConfig = new();
        private Button buttonConfig = new();
        private Button buttonLeave = new();
        private Button buttonStop = new();
        private Button buttonResume = new();
        private Button buttonReport = new();
        private Label monitoringInfos = new();
        
        /// <summary>
        /// Add panels in the main panel.
        /// ID string generated is "M:Monitoring.TaskManager.AddMonitoring".
        /// </summary>
        private void AddMonitoring() {
            AddAlwaysDisplay();
            mainPanel.Controls.Add(buttonStop);
            mainPanel.Controls.Add(buttonResume);
            mainPanel.Controls.Add(buttonReport);
            mainPanel.Controls.Add(monitoringInfos);
        }

        /// <summary>
        /// Add tools that are always displayed in the main panel.
        /// ID string generated is "M:Monitoring.TaskManager.AddAlwaysDisplay".
        /// </summary>
        private void AddAlwaysDisplay() {
            mainPanel.Controls.Add(buttonConfig);
            mainPanel.Controls.Add(buttonLeave);
        }

        /// <summary>
        /// Create panels.
        /// ID string generated is "M:Monitoring.TaskManager.CreateMonitoring".
        /// </summary>
        private void CreateMonitoring() {
            CreateAlawaysDisplay();
            CreateStopButton();
            CreateResumeButton();
            CreateReportButton();
            CreateLabelMonitoring();
        }

        /// <summary>
        /// Create tools that are always displayed in the main panel.
        /// ID string generated is "M:Monitoring.TaskManager.CreateMonitoring".
        /// </summary>
        private void CreateAlawaysDisplay() {
            CreateMainPanel();
            CreateConfigButton();
            CreateLeaveButton();
        }

        /// <summary>
        /// Add error label in the main panel.
        /// ID string generated is "M:Monitoring.TaskManager.AddError".
        /// </summary>
        private void AddError() {
            AddAlwaysDisplay();
            mainPanel.Controls.Add(labelErrorConfig);
        }

        /// <summary>
        /// Create error label.
        /// ID string generated is "M:Monitoring.TaskManager.CreateError".
        /// </summary>
        private void CreateError() {
            CreateAlawaysDisplay();
            CreateLabelError();
        }

        /// <summary>
        /// Create the main panel.
        /// ID string generated is "M:Monitoring.TaskManager.CreateMainPanel".
        /// </summary>
        private void CreateMainPanel() {
            mainPanel.Location = new Point(0, 0);
            mainPanel.Size = new Size(1200, 620);
        }

        /// <summary>
        /// Create the config button.
        /// ID string generated is "M:Monitoring.TaskManager.CreateConfigButton".
        /// </summary>
        private void CreateConfigButton() {
            CreateButton(buttonConfig, 100, "buttonConfig", "Leave and configure");
            buttonConfig.Click += buttonConfig_Click;
        }

        /// <summary>
        /// Create the leave button.
        /// ID string generated is "M:Monitoring.TaskManager.CreateLeaveButton".
        /// </summary>
        private void CreateLeaveButton() {
            CreateButton(buttonLeave, 140, "buttonLeave", "Leave");
            buttonLeave.Click += buttonLeave_Click;
        }

        /// <summary>
        /// Create the stop button.
        /// ID string generated is "M:Monitoring.TaskManager.CreateStopButton".
        /// </summary>
        private void CreateStopButton() {
            CreateButton(buttonStop, 180, "buttonStop", "Stop");
            buttonStop.Click += buttonStop_Click;
        }

        /// <summary>
        /// Create the resume button.
        /// ID string generated is "M:Monitoring.TaskManager.CreateResumeButton".
        /// </summary>
        private void CreateResumeButton() {
            CreateButton(buttonResume, 180, "buttonResume", "Resume");
            buttonResume.Click += buttonResume_Click;
        }

        /// <summary>
        /// Create the report button.
        /// ID string generated is "M:Monitoring.TaskManager.CreateReportButton".
        /// </summary>
        private void CreateReportButton() {
            CreateButton(buttonReport, 260, "buttonReport", "Send report now");
            buttonReport.Click += buttonReport_Click;
        }

        /// <summary>
        /// Create a Button.
        /// ID string generated is "M:Configuration.PanelManager.CreateButton(Button, Point, string, string)".
        /// </summary>
        /// <param name="button">The Button to create.</param>
        /// <param name="point">The y location of the Button.</param>
        /// <param name="name">The name of the Button.</param>
        /// <param name="text">The text of the Button.</param>
        private void CreateButton(Button button, int point, string name, string text) {
            button.Location = new Point(500, point + GetEndPlacement());
            button.Name = name;
            button.Size = new Size(200, 30);
            button.Text = text;
        }

        /// <summary>
        /// Create the error Label.
        /// ID string generated is "M:Monitoring.TaskManager.CreateLabelError".
        /// </summary>
        private void CreateLabelError() {
            labelErrorConfig.AutoSize = true;
            labelErrorConfig.MaximumSize = new Size(400, 0);
            labelErrorConfig.Location = new Point(450, 40);
            labelErrorConfig.Name = "labelErrorConfig";
            labelErrorConfig.Text = "There are no valid machines in the configuration file. Please launch the configuration application first.";
            labelErrorConfig.ForeColor = Color.Red;
        }

        /// <summary>
        /// Create the monitoring Label.
        /// ID string generated is "M:Monitoring.TaskManager.CreateLabelMonitoring".
        /// </summary>
        private void CreateLabelMonitoring() {
            monitoringInfos.AutoSize = true;
            monitoringInfos.Location = new Point(140, 0);
            monitoringInfos.Name = "monitoringInfos";
            monitoringInfos.Text = "Name" + new string(' ', 52) + "IPv4" + new string(' ', 32) + "State" + new string(' ', 15)
                + "Interval remaining" + new string(' ', 8) + "Uptime link" + new string(' ', 8) + "Successive failure"
                + new string(' ', 8) + "Total failures";
        }
    }
}
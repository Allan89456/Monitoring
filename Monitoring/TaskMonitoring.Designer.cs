namespace Monitoring {
    partial class TaskMonitoring {
        public Panel panelMachine { get; private set; } = new();
        private volatile Label machineInfos;
        private volatile Label machineState;
        private volatile Label machineTimer;
        private volatile Label machineUptimeLink;
        private volatile Label machineNbSuccessiveFailure;
        private volatile Label machineNbTotalFailure;

        /// <summary>
        /// Add tools to the Machine Panel.
        /// ID string generated is "M:Monitoring.TaskMonitoring.Add".
        /// </summary>
        private void Add() {
            panelMachine.Controls.Add(machineInfos);
            panelMachine.Controls.Add(machineState);
            panelMachine.Controls.Add(machineTimer);
            panelMachine.Controls.Add(machineUptimeLink);
            panelMachine.Controls.Add(machineNbSuccessiveFailure);
            panelMachine.Controls.Add(machineNbTotalFailure);
        }

        /// <summary>
        /// Create tools.
        /// ID string generated is "M:Monitoring.TaskMonitoring.Create".
        /// </summary>
        private void Create() {
            CreateAllLabels();
        }

        /// <summary>
        /// Create all Label.
        /// ID string generated is "M:Monitoring.TaskMonitoring.CreateAllLabels".
        /// </summary>
        private void CreateAllLabels() {
            machineInfos = CreateLabel(0, "machineInfos", machine.ToString());
            machineState = CreateLabel(460, "machineState", "Not initiated");
            machineTimer = CreateLabel(640, "machineTimer", machine.interval.ToString());
            machineUptimeLink = CreateLabel(780, "machineUptimeLink", "0");
            machineNbSuccessiveFailure = CreateLabel(910, "machineNbSuccessiveFailure", "0");
            machineNbTotalFailure = CreateLabel(1040, "machineNbTotalFailure", "0");
        }

        /// <summary>
        /// Create a Label.
        /// ID string generated is "M:Monitoring.TaskMonitoring.CreateLabel(int, string, string)".
        /// </summary>
        /// <param name="point">The x location of the Label.</param>
        /// <param name="name">The name of the Label.</param>
        /// <param name="text">The text of the Label.</param>
        /// <returns>The created label.</returns>
        private Label CreateLabel(int point, string name, string text) {
            Label label = new Label {
                AutoSize = true,
                Location = new Point(point, 0),
                Name = name,
                Text = text
            };
            label.Font = new Font(FontFamily.GenericMonospace, label.Font.Size);
            return label;
        }

        /// <summary>
        /// Create the panel.
        /// ID string generated is "M:Monitoring.TaskMonitoring.CreatePanel".
        /// </summary>
        private void CreatePanel() {
            panelMachine.Location = new Point(40, 40 + (40 * num));
            panelMachine.Size = new Size(1100, 40);
        }
    }
}
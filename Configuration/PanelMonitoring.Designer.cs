namespace Configuration {
    partial class PanelMonitoring {
        private const uint INTERVAL_MAX = 3600;
        private TextBox textBoxMachineName;
        private TextBox textBoxMachineIPAddress;
        private NumericUpDown numericUpDownMachineInterval;
        private List<Label> labelsMachine = new();
        private Label labelNbMachinesCurrent;
        private Label labelInvalidIP;
        private ListBox listBoxMachines = new();
        private Button buttonAddMachine;
        private Button buttonRemoveMachine;
        /// <summary>
        /// Add tools to the Machine Panel.
        /// ID string generated is "M:Configuration.PanelMonitoring.Add".
        /// </summary>
        private void Add() {
            foreach (Label label in labelsMachine)
                Controls.Add(label);
            Controls.Add(numericUpDownMachineInterval);
            Controls.Add(labelInvalidIP);
            Controls.Add(labelNbMachinesCurrent);
            Controls.Add(textBoxMachineIPAddress);
            Controls.Add(textBoxMachineName);
            Controls.Add(listBoxMachines);
            Controls.Add(buttonAddMachine);
            Controls.Add(buttonRemoveMachine);
            labelNbMachinesCurrent.BringToFront();
        }

        /// <summary>
        /// Create tools.
        /// ID string generated is "M:Configuration.PanelMonitoring.Create".
        /// </summary>
        private void Create() {
            CreateAllTextBox();
            for (var i = 0; i < 5; i++)
                labelsMachine.Add(new Label());
            CreateAllLabels();
            CreateNumericUpDown();
            CreateListBox();
            CreateAllButtons();
        }

        /// <summary>
        /// Create all TextBox.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateAllTextBox".
        /// </summary>
        private void CreateAllTextBox() {
            textBoxMachineName = CreateTextBox(200, "textBoxMachineName", Machine.GetMaxNameSize());
            textBoxMachineName.Leave += machineNameChanged;
            textBoxMachineIPAddress = CreateTextBox(240, "textBoxMachineIPAddress", Machine.GetMaxIPSize());
            textBoxMachineIPAddress.Leave += machineIPAddressChanged;
        }

        /// <summary>
        /// Create a TextBox.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateTextBox(int, string, int)".
        /// </summary>
        /// <param name="point">The location of the TextBox.</param>
        /// <param name="name">The name of the TextBox.</param>
        /// <param name="length">The length of the TextBox.</param>
        /// <returns>The created textbox.</returns>
        private TextBox CreateTextBox(int point, string name, int length) {
            return new TextBox {
                Location = new Point(415, point),
                Name = name,
                Size = new Size(246, 27),
                MaxLength = length
            };
        }

        /// <summary>
        /// Create the NumericUpDown for the interval.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateNumericUpDown".
        /// </summary>
        private void CreateNumericUpDown() {
            numericUpDownMachineInterval = new NumericUpDown {
                Location = new Point(415, 280),
                Name = "numericUpDownMachineInterval",
                Size = new Size(100, 27),
                Value = 5,
                Maximum = INTERVAL_MAX
            };
            numericUpDownMachineInterval.Leave += machineIntervalChanged;
        }

        /// <summary>
        /// Create all Label.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateAllLabels".
        /// </summary>
        private void CreateAllLabels() {
            CreateLabelsList();
            labelNbMachinesCurrent = CreateLabel(new Point(595, 130), "labelNbMachinesCurrent",
                $"{config.machines.Count}");
            labelInvalidIP = CreateLabel(new Point(250, 325), "labelInvalidIP",
                "This is not a valid IPv4 address.");
            labelInvalidIP.ForeColor = Color.Red;
            labelInvalidIP.Hide();
        }

        /// <summary>
        /// Create the TextBox labels.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateLabelsList".
        /// </summary>
        private void CreateLabelsList() {
            ushort i = 0;
            labelsMachine[i++] = CreateLabel(new Point(135, 205), "labelMachineName",
                $"The name of the machine ({Machine.GetMaxNameSize()} char max):");
            labelsMachine[i++] = CreateLabel(new Point(185, 245), "labelMachineIPAddress",
                "The IPv4 address of the machine:");
            labelsMachine[i++] = CreateLabel(new Point(40, 285), "labelMachineInterval",
                $"The interval in seconds between two pings ({INTERVAL_MAX} max):");
            labelsMachine[i++] = CreateLabel(new Point(200, 0), "labelListBoxInfo",
                "Name" + new string(' ', 50) + "IPv4" + new string(' ', 22) + "Interval");
            labelsMachine[i++] = CreateLabel(new Point(450, 130), "labelNbMachinesTotal",
                $"Number of machines:    /{MonitoringConfig.GetNbMachinesMax()}");
        }

        /// <summary>
        /// Create a Label.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateLabel(Point, string, string)".
        /// </summary>
        /// <param name="point">The location of the Label.</param>
        /// <param name="name">The name of the Label.</param>
        /// <param name="text">The text of the Label.</param>
        /// <returns>The created label.</returns>
        private Label CreateLabel(Point point, string name, string text) {
            return new Label {
                AutoSize = true,
                Location = point,
                Name = name,
                Text = text
            };
        }

        /// <summary>
        /// Create a ListBox.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateListBox".
        /// </summary>
        private void CreateListBox() {
            listBoxMachines.FormattingEnabled = true;
            listBoxMachines.Location = new Point(100, 25);
            listBoxMachines.Name = "listBoxMachines";
            listBoxMachines.Size = new Size(550, 105);
            listBoxMachines.HorizontalScrollbar = true;
            listBoxMachines.Click += listBoxMachines_Click;
            listBoxMachines.Font = new Font(FontFamily.GenericMonospace, listBoxMachines.Font.Size);
            foreach (var path in config.machines)
                listBoxMachines.Items.Add(path);
        }

        /// <summary>
        /// Create all Button.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateAllButtons".
        /// </summary>
        private void CreateAllButtons() {
            CreateAddButton();
            CreateRemoveButton();
        }

        /// <summary>
        /// Create the add Button.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateAddButton".
        /// </summary>
        private void CreateAddButton() {
            buttonAddMachine = CreateButton(200, "buttonAddMachine", "Add");
            buttonAddMachine.Click += buttonAddMachine_Click;
            if (config.machines.Count == MonitoringConfig.GetNbMachinesMax())
                buttonAddMachine.Hide();
        }

        /// <summary>
        /// Create the add Button.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateRemoveButton".
        /// </summary>
        private void CreateRemoveButton() {
            buttonRemoveMachine = CreateButton(300, "buttonRemoveMachine", "Remove");
            buttonRemoveMachine.Click += buttonRemoveMachine_Click;
            buttonRemoveMachine.Hide();
        }

        /// <summary>
        /// Create a Button.
        /// ID string generated is "M:Configuration.PanelMonitoring.CreateButton(int, string, string)".
        /// </summary>
        /// <param name="point">The y location of the Button.</param>
        /// <param name="name">The name of the Button.</param>
        /// <param name="text">The text of the Button.</param>
        /// <returns>The created button.</returns>
        private Button CreateButton(int point, string name, string text) {
            return new Button {
                Location = new Point(point, 140),
                Name = name,
                Size = new Size(95, 30),
                Text = text
            };
        }
    }
}
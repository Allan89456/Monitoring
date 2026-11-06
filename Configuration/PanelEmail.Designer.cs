namespace Configuration {
    partial class PanelEmail {
        private TextBox textBoxEmailSource;
        private TextBox textBoxEmailDestination;
        private TextBox textBoxEmailPassword;
        private TextBox textBoxEmailRelay;
        private List<Label> labelsEmail = new();
        private ComboBox comboBoxEmailPort;
        private CheckBox checkBoxEmailSSL;

        /// <summary>
        /// Add tools to the Email Panel.
        /// ID string generated is "M:Configuration.PanelEmail.Add".
        /// </summary>
        private void Add() {
            foreach (Label label in labelsEmail) {
                Controls.Add(label);
            }
            Controls.Add(textBoxEmailPassword);
            Controls.Add(textBoxEmailDestination);
            Controls.Add(textBoxEmailSource);
            Controls.Add(textBoxEmailRelay);
            Controls.Add(comboBoxEmailPort);
            Controls.Add(checkBoxEmailSSL);
        }

        /// <summary>
        /// Create tools.
        /// ID string generated is "M:Configuration.PanelEmail.Create".
        /// </summary>
        private void Create() {
            CreateAllTextBox();
            for (var i = 0; i < 5; i++) {
                labelsEmail.Add(new Label());
            }
            CreateAllLabels();
            CreateComboBox();
            CreateCheckBox();
        }

        /// <summary>
        /// Create all TextBox.
        /// ID string generated is "M:Configuration.PanelEmail.CreateAllTextBox".
        /// </summary>
        private void CreateAllTextBox() {
            var i = 1;
            var yPos = 40;
            textBoxEmailSource = CreateTextBox(yPos * i++, "textBoxEmailSource",
                "example@gmail.com", config.emailSource);
            textBoxEmailSource.Leave += emailSourceChanged;

            textBoxEmailPassword = CreateTextBox(yPos * i++, "textBoxEmailPassword", "", "");
            textBoxEmailPassword.PasswordChar = '*';
            textBoxEmailPassword.Leave += emailPasswordChanged;

            textBoxEmailRelay = CreateTextBox(yPos * i++, "textBoxEmailRelay",
                "smtp.gmail.com", config.emailRelay);
            textBoxEmailRelay.Leave += emailRelayChanged;

            textBoxEmailDestination = CreateTextBox(yPos * i++, "textBoxEmailDestination",
                "example@proton.me", config.emailDestination);
            textBoxEmailDestination.Leave += emailDestinationChanged;
        }

        /// <summary>
        /// Create a TextBox.
        /// ID string generated is "M:Configuration.PanelEmail.CreateTextBox(int, string, string, string)".
        /// </summary>
        /// <param name="point">The y location of the TextBox.</param>
        /// <param name="name">The name of the TextBox.</param>
        /// <param name="placeholderText">The placeholderText of the TextBox.</param>
        /// <param name="text">The text of the TextBox.</param>
        /// <returns>The TextBox create.</returns>
        private TextBox CreateTextBox(int point, string name, string placeholderText, string text) {
            return new TextBox {
                Location = new Point(435, point),
                Name = name,
                PlaceholderText = placeholderText,
                Text = text,
                Size = new Size(246, 27)
            };
        }

        /// <summary>
        /// Create all Label.
        /// ID string generated is "M:Configuration.PanelEmail.CreateAllLabels".
        /// </summary>
        private void CreateAllLabels() {
            var i = 0;
            var yPos = 40;
            labelsEmail[i++] = CreateLabel(new Point(70, yPos * i + 5), "labelEmailSource",
                "The email address that will be used to send the email:");

            labelsEmail[i++] = CreateLabel(new Point(185, yPos * i + 5), "labelEmailPassword",
                "The password for the sender's email:");

            labelsEmail[i++] = CreateLabel(new Point(185, yPos * i + 5), "labelEmailRelay",
                "The relay from which to send emails:");

            labelsEmail[i++] = CreateLabel(new Point(130, yPos * i + 5), "labelEmailDestination",
                "The email address that will receive the email:");

            labelsEmail[i++] = CreateLabel(new Point(355, yPos * i + 5), "labelEmailPort",
                "SMTP port:");
        }

        /// <summary>
        /// Create a Label.
        /// ID string generated is "M:Configuration.PanelEmail.CreateLabel(Point, string, string)".
        /// </summary>
        /// <param name="point">The location of the Label.</param>
        /// <param name="name">The name of the Label.</param>
        /// <param name="text">The text of the Label.</param>
        /// <returns>The Label create.</returns>
        private Label CreateLabel(Point point, string name, string text) {
            return new Label {
                AutoSize = true,
                Location = point,
                Name = name,
                Text = text
            };
        }

        /// <summary>
        /// Create a ComboBox.
        /// ID string generated is "M:Configuration.PanelEmail.CreateComboBox".
        /// </summary>
        private void CreateComboBox() {
            comboBoxEmailPort = new ComboBox {
                FormattingEnabled = true,
                Location = new Point(435, 200),
                Name = "comboBoxEmailPort",
                Size = new Size(100, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            comboBoxEmailPort.SelectedIndexChanged += emailPortChanged;
        }

        /// <summary>
        /// Create a CheckBox.
        /// ID string generated is "M:Configuration.PanelRecovery.CreateCheckBox".
        /// </summary>
        private void CreateCheckBox() {
            checkBoxEmailSSL = new CheckBox {
                AutoSize = true,
                Location = new Point(345, 260),
                Size = new Size(215, 25),
                Name = "checkBoxEmailSSL",
                Text = "Enable SSL",
                Checked = config.emailSSL
            };
            checkBoxEmailSSL.Click += emailSSLChanged;
        }
    }
}
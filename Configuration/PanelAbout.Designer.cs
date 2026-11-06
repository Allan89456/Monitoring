namespace Configuration {
    partial class PanelAbout {
        private List<Label> labelsAbout = new();
        private Button buttonMenu;

        /// <summary>
        /// Add tools to the Email Panel.
        /// ID string generated is "M:Configuration.PanelAbout.Add".
        /// </summary>
        private void Add() {
            foreach (Label label in labelsAbout) {
                Controls.Add(label);
            }
        }

        /// <summary>
        /// Create tools.
        /// ID string generated is "M:Configuration.PanelAbout.Create".
        /// </summary>
        private void Create() {
            for (var i = 0; i < 5; i++) {
                labelsAbout.Add(new Label());
            }
            CreateAllLabels();
        }

        /// <summary>
        /// Create all Label.
        /// ID string generated is "M:Configuration.PanelAbout.CreateAllLabels".
        /// </summary>
        private void CreateAllLabels() {
            var i = 0;
            var yPos = 40;
            labelsAbout[i++] = CreateLabel(new Point(285, yPos * i + 5), "labelsAboutAutor",
                "Allan André");

            labelsAbout[i++] = CreateLabel(new Point(285, yPos * i + 5), "labelsAboutYear",
                "2025-2026");

            labelsAbout[i++] = CreateLabel(new Point(230, yPos * i + 5), "labelsAboutSchool",
                "Haute Ecole Robert Schuman");

            labelsAbout[i++] = CreateLabel(new Point(230, yPos * i + 5), "labelsAboutBachelor",
                "Bachelor in Computer Science");

            labelsAbout[i++] = CreateLabel(new Point(220, yPos * i + 5), "labelsAboutFramework",
                ".NET 10 - support end 14 nov. 2028");
        }

        /// <summary>
        /// Create a Label.
        /// ID string generated is "M:Configuration.PanelAbout.CreateLabel(Point, string, string)".
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
    }
}
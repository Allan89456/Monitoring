namespace Configuration {
    /// <summary>
    /// Class used for displaying informations about the autor.
    /// ID string generated is "T:Configuration.PanelAbout".
    /// </summary>
    public partial class PanelAbout : MyPanel {

        /// <summary>
        /// Build a About Panel.
        /// ID string generated is "M:Configuration.PanelAbout.#ctor".
        /// </summary>
        public PanelAbout() {
            Name = "PanelAbout";
        }

        public override void InitializeComponent() {
            Create();
            Add();
        }

        public override void Reset() {
            
        }
    }
}
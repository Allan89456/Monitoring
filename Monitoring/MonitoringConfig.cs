namespace Monitoring {
    /// <summary>
    /// Class used for interacting with a JSON file.
    /// ID string generated is "T:Monitoring.MonitoringConfig".
    /// </summary>
    public class MonitoringConfig {
        public DateTime dateLastModification { get; set; }
        public string emailSource { get; set; } = "";
        public string emailDestination { get; set; } = "";
        public string emailPassword { get; set; } = "";
        public string emailRelay { get; set; } = "";
        public int emailPort { get; set; } = 587;
        public bool emailSSL { get; set; } = false;
        public List<Machine> machines { get; set; } = new();

        /// <summary>
        /// Check if there is a configuration for an email address.
        /// ID string generated is "M:Monitoring.MonitoringConfig.IsEmailInfos".
        /// </summary>
        /// <returns>True if the email config is not empty; otherwise false.</returns>
        public bool IsEmailInfos() {
            return !emailSource.IsWhiteSpace() && !emailDestination.IsWhiteSpace() &&
            !emailPassword.IsWhiteSpace() && !emailRelay.IsWhiteSpace();
        }
    }
}
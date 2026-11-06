namespace Configuration {
    /// <summary>
    /// Class used for interacting with a JSON file.
    /// ID string generated is "T:Configuration.MonitoringConfig".
    /// </summary>
    public class MonitoringConfig {
        public DateTime dateLastModification { get; set; }
        public string emailSource { get; set; } = "";
        public string emailDestination { get; set; } = "";
        public string emailPassword { get; set; } = "";
        public string emailRelay { get; set; } = "";
        public int emailPort { get; set; } = 587;
        public bool emailSSL { get; set; } = false;

        private const ushort NB_MACHINES_MAX = 8;
        public List<Machine> machines { get; set; } = new();

        public event EventHandler dateLastModificationModified;

        /// <summary>
        /// Get the maximum number of authorized machines.
        /// ID string generated is "M:Configuration.MonitoringConfig.GetNbMachinesMax".
        /// </summary>
        /// <returns>The maximum number of authorized machines.</returns>
        public static int GetNbMachinesMax() {
            return NB_MACHINES_MAX;
        }

        /// <summary>
        /// Set the email source and update the last modification date if the new email source is not equal to the old one.
        /// ID string generated is "M:Configuration.MonitoringConfig.SetEmailSource(string)".
        /// </summary>
        /// <param name="emailSource">The new email source.</param>
        public void SetEmailSource(string emailSource) {
            if (!emailSource.Equals(this.emailSource)) {
                this.emailSource = emailSource;
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Set the email destination and update the last modification date if the new email destination is not equal to the old one.
        /// ID string generated is "M:Configuration.MonitoringConfig.SetEmailDestination(string)".
        /// </summary>
        /// <param name="emailDestination">The new email destination.</param>
        public void SetEmailDestination(string emailDestination) {
            if (!emailDestination.Equals(this.emailDestination)) {
                this.emailDestination = emailDestination;
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Set the email password and update the last modification date if the new email password is not equal to the old one.
        /// ID string generated is "M:Configuration.MonitoringConfig.SetEmailPassword(string)".
        /// </summary>
        /// <param name="emailPassword">The new email password.</param>
        public void SetEmailPassword(string emailPassword) {
            if (!emailPassword.Equals(this.emailPassword)) {
                this.emailPassword = emailPassword;
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Set the email relay and update the last modification date if the new email relay is not equal to the old one.
        /// ID string generated is "M:Configuration.MonitoringConfig.SetEmailRelay(string)".
        /// </summary>
        /// <param name="emailRelay">The new email relay.</param>
        public void SetEmailRelay(string emailRelay) {
            if (!emailRelay.Equals(this.emailRelay)) {
                this.emailRelay = emailRelay;
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Set the email port and update the last modification date if the new email port is not equal to the old one.
        /// ID string generated is "M:Configuration.MonitoringConfig.SetEmailPort(int)".
        /// </summary>
        /// <param name="emailPort">The new email port.</param>
        public void SetEmailPort(int emailPort) {
            if (emailPort != this.emailPort) {
                this.emailPort = emailPort;
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Set the email SSL and update the last modification date if the new email SLL is not equal to the old one.
        /// ID string generated is "M:Configuration.MonitoringConfig.SetEmailSSL(bool)".
        /// </summary>
        /// <param name="emailSSL">The new email SLL.</param>
        public void SetEmailSSL(bool emailSSL) {
            if (emailSSL != this.emailSSL) {
                this.emailSSL = emailSSL;
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Add a machine to the list.
        /// ID string generated is "M:Configuration.MonitoringConfig.AddMachine(Machine)".
        /// </summary>
        /// <param name="newMachine">The machine to add.</param>
        /// <returns>True if the machine was added.</returns>
        public bool AddMachine(Machine newMachine) {
            if (machines.Count < NB_MACHINES_MAX) {
                machines.Add(newMachine);
                UpdateLastModification();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Remove a machine from the list.
        /// ID string generated is "M:Configuration.MonitoringConfig.RemoveMachine(Machine)".
        /// </summary>
        /// <param name="index">Index of the machine to remove.</param>
        public void RemoveMachine(int index) {
            if (index >= 0 && index < machines.Count) {
                machines.RemoveAt(index);
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Sort the list.
        /// ID string generated is "M:Configuration.MonitoringConfig.SortMachines".
        /// </summary>
        public void SortMachines() {
            machines.Sort((machine1, machine2) => machine1.CompareTo(machine2));
        }

        /// <summary>
        /// Change a machine from the list.
        /// ID string generated is "M:Configuration.MonitoringConfig.ChangeMachine(Machine, int)".
        /// </summary>
        /// <param name="newMachine">The new machine.</param>
        /// <param name="index">The index of the old machine.</param>
        public void ChangeMachine(Machine newMachine, int index) {
            if (index >= 0 && index < machines.Count && !newMachine.Equals(machines[index])) {
                machines[index] = new(newMachine);
                UpdateLastModification();
            }
        }

        /// <summary>
        /// Find the index of a machine from the list.
        /// ID string generated is "M:Configuration.MonitoringConfig.Find(Machine)".
        /// </summary>
        /// <param name="machine">The machine to find.</param>
        /// <returns>The index of the machine if found; otherwise -1.</returns>
        public int Find(Machine machine) {
            return machines.IndexOf(machine);
        }

        /// <summary>
        /// Update the date of the last modification.
        /// ID string generated is "M:Configuration.MonitoringConfig.UpdateLastModification".
        /// </summary>
        private void UpdateLastModification() {
            dateLastModification = DateTime.Now;
            dateLastModificationModified(this, new EventArgs());
        }

        /// <summary>
        /// Reset data.
        /// ID string generated is "M:Configuration.MonitoringConfig.Reset".
        /// </summary>
        public void Reset() {
            emailSource = "";
            emailDestination = "";
            emailPassword = "";
            emailRelay = "";
            emailSSL = false;
            emailPort = 587;
            machines = new();
            UpdateLastModification();
        }

        /// <summary>
        /// Check if the config is empty.
        /// ID string generated is "M:Configuration.MonitoringConfig.IsEmpty".
        /// </summary>
        /// <returns>True if the config is empty; otherwise false.</returns>
        public bool IsEmpty() {
            return emailSource.IsWhiteSpace() && emailDestination.IsWhiteSpace() &&
            emailPassword.IsWhiteSpace() && emailRelay.IsWhiteSpace() &&
            !emailSSL && emailPort == 587 && machines.Count == 0;
        }
    }
}
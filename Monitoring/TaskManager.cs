using System.Diagnostics;
using System.Text.Json;

namespace Monitoring {
    /// <summary>
    /// Class used for managing tasks.
    /// ID string generated is "T:Monitoring.TaskManager".
    /// </summary>
    public partial class TaskManager {
        private MonitoringConfig config;
        private string fileName = "../../../../settings/config.json";
        private string configurationPath = "../../../../Configuration/bin/Debug/net10.0-windows/Configuration.exe";
        private List<MyTask> tasks = new();
        private Email emailReport;

        /// <summary>
        /// Build a Task Manager.
        /// ID string generated is "M:Monitoring.TaskManager.#ctor".
        /// </summary>
        public TaskManager() {
            try {
                string jsonString = File.ReadAllText(fileName);
                config = JsonSerializer.Deserialize<MonitoringConfig>(jsonString)!;

                if (CheckMachineData() != 0) {
                    DisplayMonitoring();
                    LaunchMonitoring();
                    emailReport = new(config);
                } else {
                    DisplayError();
                }
            } catch (Exception) {
                DisplayError();
            }
        }

        /// <summary>
        /// Check the number of machines for which there is complete data.
        /// ID string generated is "M:Monitoring.TaskManager.CheckMachineData".
        /// </summary>
        /// <returns>The number of valid machines.</returns>
        private int CheckMachineData() {
            int nbValid = 0;
            foreach (var machine in config.machines) {
                if (machine.IsComplete()) {
                    PrepareMonitoring(nbValid, machine);
                    nbValid++;
                }
            }
            return nbValid;
        }

        /// <summary>
        /// Prepare a task monitor for the provided machine.
        /// ID string generated is "M:Monitoring.TaskManager.PrepareMonitoring".
        /// </summary>
        /// <param name="num">The number of the machine.</param>
        /// <param name="machine">The machine to monitor.</param>
        private void PrepareMonitoring(int num, Machine machine) {
            Email email = new(config);
            TaskMonitoring newTask = new(machine, num, email);
            tasks.Add(newTask);
            mainPanel.Controls.Add(newTask.panelMachine);
        }

        /// <summary>
        /// Display the monitoring information.
        /// ID string generated is "M:Monitoring.TaskManager.DisplayMonitoring".
        /// </summary>
        private void DisplayMonitoring() {
            AddMonitoring();
            CreateMonitoring();
        }

        /// <summary>
        /// Launch monitoring for the machines in the list.
        /// ID string generated is "M:Monitoring.TaskManager.LaunchMonitoring".
        /// </summary>
        private void LaunchMonitoring() {
            List<Task> toDoList = new();
            foreach (var task in tasks) {
                toDoList.Add(Task.Run(() => task.Run()));
            }
        }

        /// <summary>
        /// Display the error information.
        /// ID string generated is "M:Monitoring.TaskManager.DisplayError".
        /// </summary>
        private void DisplayError() {
            AddError();
            CreateError();
        }

        /// <summary>
        /// Exit and launch the configuration application when the button is pressed.
        /// ID string generated is "M:Monitoring.TaskManager.buttonConfig_Click".
        /// </summary>
        private void buttonConfig_Click(object sender, EventArgs e) {
            var p = new Process();
            p.StartInfo.FileName = configurationPath;
            p.Start();
            ExitApp();
        }

        /// <summary>
        /// Exit the application when the button is pressed.
        /// ID string generated is "M:Monitoring.TaskManager.buttonLeave_Click".
        /// </summary>
        private void buttonLeave_Click(object sender, EventArgs e) {
            ExitApp();
        }

        /// <summary>
        /// Stop tasks when the button is pressed.
        /// ID string generated is "M:Monitoring.TaskManager.buttonStop_Click".
        /// </summary>
        private void buttonStop_Click(object sender, EventArgs e) {
            Stop();
            buttonResume.BringToFront();
        }

        /// <summary>
        /// Resume tasks when the button is pressed; the timer will be reset.
        /// ID string generated is "M:Monitoring.TaskManager.buttonResume_Click".
        /// </summary>
        private void buttonResume_Click(object sender, EventArgs e) {
            LaunchMonitoring();
            buttonStop.BringToFront();
        }

        /// <summary>
        /// Send a report when the button is pressed.
        /// ID string generated is "M:Monitoring.TaskManager.buttonReport_Click".
        /// </summary>
        private void buttonReport_Click(object sender, EventArgs e) {
            string infos = "";
            foreach (var task in tasks) {
                infos += "\n" + task.Infos();
            }
            emailReport.SendReport(infos);
        }

        /// <summary>
        /// Exit the application.
        /// ID string generated is "M:Monitoring.TaskManager.ExitApp".
        /// </summary>
        private void ExitApp() {
            Stop();
            Application.Exit();
            emailReport.Dispose();
        }

        /// <summary>
        /// Get the placement at the end of the page according to the number of machines.
        /// ID string generated is "M:Monitoring.TaskManager.GetEndPlacement".
        /// </summary>
        /// <returns>The number of tasks.</returns>
        public int GetEndPlacement() {
            return 40 * tasks.Count;
        }

        /// <summary>
        /// Stop tasks.
        /// ID string generated is "M:Monitoring.TaskManager.Stop".
        /// </summary>
        public void Stop() {
            foreach (var task in tasks) {
                task.Stop();
            }
        }

        /// <summary>
        /// Release all resources used.
        /// ID string generated is "M:Monitoring.TaskManager.Dispose".
        /// </summary>
        public void Dispose() {
            foreach (var task in tasks) {
                task.Dispose();
            }
        }
    }
}
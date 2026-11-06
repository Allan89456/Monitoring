using System.Net.NetworkInformation;
using System.Text;

namespace Monitoring {
    /// <summary>
    /// Class used for monitoring a machine.
    /// ID string generated is "T:Monitoring.TaskMonitoring".
    /// </summary>
    public partial class TaskMonitoring : MyTask {
        private Machine machine;
        private int num = 0;
        private uint nbSuccessiveFailure = 0;
        private uint nbTotalFailure = 0;
        private Email email;
        private uint interval;
        private uint uptimeLink = 0;

        /// <summary>
        /// Build a Task Monitoring.
        /// ID string generated is "M:Monitoring.TaskMonitoring.#ctor(Machine)".
        /// </summary>
        /// <param name="machine">The machine to monitor.</param>
        public TaskMonitoring(Machine machine) {
            this.machine = machine;
            interval = machine.interval;
        }

        /// <summary>
        /// Build a Task Monitoring.
        /// ID string generated is "M:Monitoring.TaskMonitoring.#ctor(Machine, int)".
        /// </summary>
        /// <param name="machine">The machine to monitor.</param>
        /// <param name="num">The number of the machine to monitor.</param>
        /// <param name="email">The email address.</param>
        public TaskMonitoring(Machine machine, int num, Email email) {
            this.machine = machine;
            interval = machine.interval;
            this.num = num;
            this.email = email;
            Create();
            Add();
            CreatePanel();
        }

        public override void Run() {
            isRunning = true;
            while (isRunning) {
                Thread.Sleep(1000);
                panelMachine.Invoke((MethodInvoker)(() => ChangeTimer()));
                interval--;
                
                if (interval == 0) {
                    interval = machine.interval;
                    TestMachine();
                }
            }
        }

        private void ChangeTimer() {
            machineTimer.Text = interval.ToString();
            if (machineState.BackColor.Equals(Color.LightGreen)) {
                uptimeLink++;
                machineUptimeLink.Text = uptimeLink.ToString();
            }
            }

        /// <summary>
        /// Test the machine.
        /// ID string generated is "M:Monitoring.TaskMonitoring.TestMachine".
        /// </summary>
        private void TestMachine() {
            try {
                if (PerformPing()) {
                    panelMachine.Invoke((MethodInvoker)(() => DisplayPingSuccess()));
                } else {
                    panelMachine.Invoke((MethodInvoker)(() => DisplayPingFailure()));
                }
            } catch (PingException) {
                panelMachine.Invoke((MethodInvoker)(() => DisplayPingFailure()));
            }
        }

        /// <summary>
        /// Perform a ping to the machine's address.
        /// ID string generated is "M:Monitoring.TaskMonitoring.PerformPing".
        /// </summary>
        /// <returns>True if the machine answers; false otherwise.</returns>
        public bool PerformPing() {
            Ping pingSender = new Ping();
            PingOptions options = new PingOptions();

            options.DontFragment = true;

            string data = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 120;
            PingReply reply = pingSender.Send(machine.ipAddress, timeout, buffer, options);

            return reply.Status == IPStatus.Success;
        }

        /// <summary>
        /// Update the label with the successful ping.
        /// ID string generated is "M:Monitoring.TaskMonitoring.DisplayPingSuccess".
        /// </summary>
        private void DisplayPingSuccess() {
            if (!machineState.BackColor.Equals(Color.LightGreen)) {
                if (machineState.ForeColor.Equals(Color.Red)) {
                    email.SendReconnection(machine, nbSuccessiveFailure);
                }
                machineState.Text = "functional";
                machineState.BackColor = Color.LightGreen;
                machineState.ForeColor = Color.Black;
                nbSuccessiveFailure = 0;
                machineNbSuccessiveFailure.Text = nbSuccessiveFailure.ToString();
            }
        }

        /// <summary>
        /// Update the label with the failed ping.
        /// ID string generated is "M:Monitoring.TaskMonitoring.DisplayPingFailure".
        /// </summary>
        private void DisplayPingFailure() {
            if (nbSuccessiveFailure == 0) {
                machineState.Text = "non-functional";
                machineState.BackColor = Color.Red;
                machineState.ForeColor = Color.White;
                email.SendLostConnection(machine);
                uptimeLink = 0;
                machineTimer.Text = "0";
            }
            nbSuccessiveFailure++;
            machineNbSuccessiveFailure.Text = nbSuccessiveFailure.ToString();
            nbTotalFailure++;
            machineNbTotalFailure.Text = nbTotalFailure.ToString();
        }

        public override void Stop() {
            isRunning = false;
        }

        public override void Dispose() {
            Stop();
            email.Dispose();
        }

        public override string Infos() {
            return machine.name + "  " + machine.ipAddress + "  Uptime link : " + uptimeLink + " sec";
        }
    }
}
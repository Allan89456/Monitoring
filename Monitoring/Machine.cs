using System.Net;
using System.Text.RegularExpressions;

namespace Monitoring {
    /// <summary>
    /// Class used to save information about a machine.
    /// ID string generated is "T:Monitoring.Machine".
    /// </summary>
    public class Machine {
        public string name { get; set; } = "loopback";
        public string ipAddress { get; set; } = "127.0.0.1";
        public uint interval { get; set; } = 5;

        public Machine() { }

        /// <summary>
        /// Build a Machine.
        /// ID string generated is "M:Monitoring.Machine.#ctor(string, string, uint)".
        /// </summary>
        /// <param name="name">The name of the machine.</param>
        /// <param name="ipAddress">The IP address of the machine.</param>
        /// <param name="interval">The interval between two pings for the machine.</param>
        public Machine(string name, string ipAddress, uint interval) {
            this.name = name;
            this.ipAddress = ipAddress;
            this.interval = interval;
        }

        /// <summary>
        /// Check that the data is complete.
        /// ID string generated is "M:Monitoring.Machine.isComplete".
        /// </summary>
        /// <returns>True if the data is complete; otherwise false.</returns>
        public bool IsComplete() {
            bool res = !name.Equals("");
            if (res) {
                res = IsIPValid(ipAddress);
            }
            return res;
        }

        /// <summary>
        /// Check that the IP is valid.
        /// ID string generated is "M:Monitoring.Machine.IsIPValid(string)".
        /// </summary>
        /// <param name="ipAddress">The ip to check.</param>
        /// <returns>True if the IP is valid; otherwise false.</returns>
        public static bool IsIPValid(string ipAddress) {
            IPAddress address;
            if (IPAddress.TryParse(ipAddress, out address)) {
                Regex ipPattern = new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b");
                return address.AddressFamily is System.Net.Sockets.AddressFamily.InterNetwork
                    && ipPattern.IsMatch(ipAddress);
            }
            return false;
        }

        /// <summary>
        /// Compare two machines.
        /// ID string generated is "M:Monitoring.Machine.Equals(Machine)".
        /// </summary>
        /// <param name="other">The machine to compare.</param>
        /// <returns>True if the two machines are euals; otherwise false.</returns>
        public bool Equals(Machine other) {
            if (other == null) {
                return false;
            }
            if (other == this) {
                return true;
            }
            return name.Equals(other.name) && ipAddress.Equals(other.ipAddress) && interval.Equals(other.interval);
        }

        public override string ToString() {
            return String.Format("{0} {1}", name.PadRight(32), ipAddress.PadRight(17));
        }
    }
}
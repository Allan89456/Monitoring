using System.Net;
using System.Text.RegularExpressions;

namespace Configuration {
    /// <summary>
    /// Class used to save information about a machine.
    /// ID string generated is "T:Configuration.Machine".
    /// </summary>
    public class Machine {
        private string privateName = "loopback";
        private const int MAX_NAME_SIZE = 30;
        public string name {
            get { return privateName; }
            set {
                if (value.Length > MAX_NAME_SIZE) {
                    privateName = value.Substring(0, MAX_NAME_SIZE);
                } else {
                    privateName = value;
                }
            }
        }

        private string privateIPAddress = "127.0.0.1";
        private const int MAX_IP_SIZE = 15;
        public string ipAddress {
            get { return privateIPAddress; }
            set {
                if (value.Length > MAX_IP_SIZE) {
                    privateIPAddress = value.Substring(0, MAX_IP_SIZE);
                } else {
                    privateIPAddress = value;
                }
            }
        }

        public uint interval { get; set; } = 5;

        public Machine() {}

        /// <summary>
        /// Copy constructor of a Machine.
        /// ID string generated is "M:Configuration.Machine.#ctor(object)".
        /// </summary>
        /// <param name="infos">The object to copy.</param>
        public Machine(object infos) {
            if (infos is Machine) {
                Machine copy = (Machine) infos;
                name = copy.name;
                ipAddress = copy.ipAddress;
                interval = copy.interval;
            }
        }

        /// <summary>
        /// Get the maximum size of the machine name.
        /// ID string generated is "M:Configuration.Machine.GetMaxNameSize".
        /// </summary>
        /// <returns>The maximum size of the machine name.</returns>
        public static int GetMaxNameSize() {
            return MAX_NAME_SIZE;
        }

        /// <summary>
        /// Get the maximum size of the machine IP address.
        /// ID string generated is "M:Configuration.Machine.GetMaxIPSize".
        /// </summary>
        /// <returns>The maximum size of the machine IP address.</returns>
        public static int GetMaxIPSize() {
            return MAX_IP_SIZE;
        }

        /// <summary>
        /// Compare two machines.
        /// ID string generated is "M:Configuration.Machine.CompareTo(Machine)".
        /// </summary>
        /// <param name="other">The machine to compare.</param>
        /// <returns>Less than 0 if this instance precedes other; 0 if this instance equals other; Greater than 0 if this instance follows other.</returns>
        public int CompareTo(Machine other) {
            int res = name.CompareTo(other.name);
            if (res == 0) {
                res = ipAddress.CompareTo(other.ipAddress);
                if (res == 0) {
                    res = interval.CompareTo(other.interval);
                }
            }
            return res;
        }

        /// <summary>
        /// Check that the data is complete.
        /// ID string generated is "M:Configuration.Machine.isComplete".
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
        /// ID string generated is "M:Configuration.Machine.IsIPValid(string)".
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
        /// ID string generated is "M:Configuration.Machine.Equals(Machine)".
        /// </summary>
        /// <param name="other">The machine to compare.</param>
        /// <returns>True if the two machines are equals; otherwise false.</returns>
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
            return String.Format("{0} {1} {2}sec", name.PadRight(MAX_NAME_SIZE + 2), ipAddress.PadRight(MAX_IP_SIZE + 2), interval);
        }
    }
}
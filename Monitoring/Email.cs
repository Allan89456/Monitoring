using System.Net;
using System.Net.Mail;

namespace Monitoring {
    /// <summary>
    /// Class used to send emails.
    /// ID string generated is "T:Monitoring.Email".
    /// </summary>
    public class Email {
        private MailMessage mail = new();
        private SmtpClient smtp;
        private bool isValide = false;

        /// <summary>
        /// Constructor of a SendEmail.
        /// ID string generated is "M:Monitoring.Email.#ctor(MonitoringConfig)".
        /// </summary>
        /// <param name="config">The config of the email info.</param>
        public Email(MonitoringConfig config) {
            if (config.IsEmailInfos()) {
                try {
                    mail.From = new MailAddress(config.emailSource);
                    mail.To.Clear();
                    mail.To.Add(config.emailDestination);

                    smtp = new SmtpClient(config.emailRelay, config.emailPort);
                    smtp.Credentials = new NetworkCredential(config.emailSource, config.emailPassword);
                    smtp.EnableSsl = config.emailSSL;

                    isValide = true;
                } catch (Exception) {
                    isValide = false;
                    Dispose();
                }
            }
        }

        /// <summary>
        /// Send a successful reconnection email.
        /// ID string generated is "M:Monitoring.Email.SendReconnection(Machine)".
        /// </summary>
        /// <param name="machine">The machine reconnected.</param>
        /// <param name="nbSuccessiveFailure">The number of consecutive failure(s).</param>
        public void SendReconnection(Machine machine, uint nbSuccessiveFailure) {
            if (isValide) {
                mail.Subject = "Functional again";
                mail.Body = $"The machine '{machine.name}' with the IP {machine.ipAddress} is functional again after after {nbSuccessiveFailure} consecutive failure(s).";
                SendEmail();
            }
        }

        /// <summary>
        /// Send the email.
        /// ID string generated is "M:Monitoring.Email.SendEmail".
        /// </summary>
        private void SendEmail() {
            try {
                smtp.SendMailAsync(mail);
            } catch (Exception) {
                isValide = false;
                Dispose();
            }
        }

        /// <summary>
        /// Send a lost connection email.
        /// ID string generated is "M:Monitoring.Email.SendLostConnection(Machine)".
        /// </summary>
        /// <param name="machine">The machine disconnected.</param>
        public void SendLostConnection(Machine machine) {
            if (isValide) {
                mail.Subject = "Non-functional";
                mail.Body = $"The machine '{machine.name}' with the IP {machine.ipAddress} is non-functional.";
                SendEmail();
            }
        }

        /// <summary>
        /// Send a lost connection email.
        /// ID string generated is "M:Monitoring.Email.SendLostConnection(Machine)".
        /// </summary>
        /// <param name="machine">The machine disconnected.</param>
        public void SendReport(string body) {
            if (isValide) {
                mail.Subject = "Report";
                mail.Body = $"{DateTime.Now:HH:mm dd/MM/yyyy} {body}.";
                SendEmail();
            }
        }

        /// <summary>
        /// Release all resources used.
        /// ID string generated is "M:Monitoring.Email.Dispose".
        /// </summary>
        public void Dispose() {
            if (smtp != null) {
                isValide = false;
                smtp.Dispose();
                mail.Dispose();
            }
        }
    }
}
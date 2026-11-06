namespace Monitoring {
    public abstract class MyTask {
        protected volatile bool isRunning = true;

        /// <summary>
        /// Run the task.
        /// ID string generated is "M:Monitoring.MyTask.Run".
        /// </summary>
        public abstract void Run();

        /// <summary>
        /// Stop the task.
        /// ID string generated is "M:Monitoring.MyTask.Stop".
        /// </summary>
        public abstract void Stop();

        /// <summary>
        /// Release all resources used.
        /// ID string generated is "M:Monitoring.MyTask.Dispose".
        /// </summary>
        public abstract void Dispose();

        /// <summary>
        /// Obtain the infos of the task.
        /// ID string generated is "M:Monitoring.MyTask.Infos".
        /// </summary>
        public abstract string Infos();
    }
}
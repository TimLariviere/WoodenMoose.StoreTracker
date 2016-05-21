using System.Threading.Tasks;

namespace WoodenMoose.Core.Utilities
{
    /// <summary>
    /// Utility methods for Task
    /// </summary>
    public static class TaskUtilities
    {
        /// <summary>
        /// Completed task
        /// </summary>
        private static Task _completedTask;

        /// <summary>
        /// Get a completed task
        /// </summary>
        public static Task CompletedTask
        {
            get { return _completedTask ?? (_completedTask = Task.Factory.StartNew(() => { })); }
        }
    }
}

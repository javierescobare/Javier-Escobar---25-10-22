using System;
using System.Threading.Tasks;

namespace TodoApp.Helpers
{
    public static class TaskExtensions
    {
        /// <summary>
        /// Configures a task to be safely executed asynchronously in background.
        /// 
        /// Extracted from Microsoft official docs:
        /// https://docs.microsoft.com/en-us/xamarin/xamarin-forms/data-cloud/data/databases#the-safefireandforget-extension-method
        /// </summary>
        public static async void SafeFireAndForget(this Task task,
            bool returnToCallingContext,
            Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}

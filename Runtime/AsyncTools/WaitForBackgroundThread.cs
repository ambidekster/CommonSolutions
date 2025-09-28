using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CommonSolutions.Runtime.AsyncTools
{
    public class WaitForBackgroundThread
    {
        public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter GetAwaiter()
        {
            return Task.Run(() => {}).ConfigureAwait(false).GetAwaiter();
        }
    }
}

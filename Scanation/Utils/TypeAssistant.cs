using System;
using System.Threading;

namespace Scanation.Utils
{
    internal class TypeAssistant
    {
        public event EventHandler Idled = delegate { };
        public int WaitingMilliseconds { get; set; }
        readonly Timer _waitingTimer;

        public TypeAssistant(int waitingMilliseconds = 600)
        {
            WaitingMilliseconds = waitingMilliseconds;
            _waitingTimer = new Timer(p =>
            {
                Idled(this, EventArgs.Empty);
            });
        }
        public void TextChanged()
        {
            _waitingTimer.Change(WaitingMilliseconds, Timeout.Infinite);
        }
    }
}

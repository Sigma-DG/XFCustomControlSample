using System;
using System.Threading.Tasks;
using XFCustomControlSample.Common;

namespace XFCustomControlSample.Proxy
{
    public class NotificationKernel
    {
        private Task _scheduler, _runner;
        private int _secondCounter = 0;

        public VoidEventHandler OnMinuteTicked, OnSecondTicked;

        public static Lazy<NotificationKernel> Current { get; } = new Lazy<NotificationKernel>();

        public NotificationKernel()
        {
            _runner = new Task(async () => {
                while (true)
                {
                    if (_scheduler == null || _scheduler.Status != TaskStatus.Running ||
                    _scheduler.IsCanceled || _scheduler.IsCompleted || _scheduler.IsFaulted)
                        InitTask();
                    await Task.Delay(5000).ConfigureAwait(false);
                }
            });
        }

        private void InitTask()
        {
            if(_scheduler != null)
            {
                _scheduler.Dispose();
            }

            _scheduler = new Task(async() => {
                while(true)
                {
                    tick();
                    await Task.Delay(1000).ConfigureAwait(false);
                }
            });

            _scheduler.Start();
        }

        private void tick()
        {
            OnSecondTicked?.Invoke();
            if(_secondCounter>=60)
            {
                _secondCounter = 0;
                OnMinuteTicked?.Invoke();
            }
            else
                _secondCounter++;
        }
    }
}

using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class Timer : ITimer
    {
        public int TimeRemaining { get; private set; }

        public event EventHandler Expired;
        public event EventHandler TimerTick;

        //made public
        public System.Timers.Timer timer { get; private set; }

        public Timer()
        {
            timer = new System.Timers.Timer();
            // Bind OnTimerEvent with an object of this, and set up the event
            timer.Elapsed += OnTimerEvent;
            timer.Interval = 1000; // 1 second intervals
            timer.AutoReset = true;  // Repeatable timer
        }


        public void Start(int time)
        {
            TimeRemaining = time;
            timer.Enabled = true;
        }

        public void Stop()
        {
            timer.Enabled = false;
        }

        private void Expire()
        {
            timer.Enabled = false;
            Expired?.Invoke(this, System.EventArgs.Empty);
        }

        public void AddTime(int time)
        {
            TimeRemaining = time;
        }

        private void OnTimerEvent(object sender, System.Timers.ElapsedEventArgs args)
        {
            // One tick has passed
            // Do what I should
            TimeRemaining -= 1;
            TimerTick?.Invoke(this, EventArgs.Empty);

            if (TimeRemaining <= 0)
            {
                Expire();
            }
        }

        //public void ChangeTime(string value)
        //{
        //    if (value == "+")
        //    {
        //        TimeRemaining += 5;
        //    }

        //    else if (value == "-")
        //    {
        //        if (TimeRemaining <= 5)
        //        {
        //            Expire();
        //        }
        //        else
        //        {
        //            TimeRemaining -= 5;
        //        }
        //    }
        //}

        public void AddTime()
        {
            TimeRemaining += 5;
        }

        public void SubstractTime()
        {
            TimeRemaining -= 5;
            if (TimeRemaining <= 0)
            {
                Expire();
            }
        }

    }
}
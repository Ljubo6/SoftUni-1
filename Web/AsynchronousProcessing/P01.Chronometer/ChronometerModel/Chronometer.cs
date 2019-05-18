using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace P01.Chronometer.ChronometerModel
{
    public class Chronometer : IChronometer
    {
        private long milliseconds;
        private bool isRunning;

        public Chronometer()
        {
            this.Laps = new List<string>();
            this.isRunning = false;
        }

        public string GetTime => $"{milliseconds / 60_000:D2}:{milliseconds / 1_000:D2}:{milliseconds % 1_000:D4}";

        public List<string> Laps { get; private set; }

        public string Lap()
        {
            var currentLap = this.GetTime;

            if (this.milliseconds > 0 && this.isRunning)
            {
                this.Laps.Add(currentLap);
            }
            
            return currentLap;
        }

        public void Reset()
        {
            this.Stop();
            this.milliseconds = 0;
            this.Laps.Clear();
        }

        public void Start()
        {
            this.isRunning = true;
            Task.Run(() => this.IncrementTime());
        }

        public void Stop()
        {
            this.isRunning = false; 
        }

        public string GetLaps()
        {
            if(this.Laps.Count == 0)
            {
                return "Laps: no laps";
            }

            var sb = new StringBuilder();
            sb.AppendLine("Laps:");
            for (int i = 0; i < this.Laps.Count; i++)
            {
                sb.AppendLine($"{i}. {this.Laps[i]}");
            }

            return sb.ToString().TrimEnd();
        }

        private void IncrementTime()
        {
            if (this.isRunning)
            {
                while (this.isRunning)
                {
                    Thread.Sleep(1);
                    this.milliseconds++;
                }
            }
        }
    }
}

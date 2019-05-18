using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Chronometer.ChronometerModel
{
    public interface IChronometer
    {
        string GetTime { get; }
        List<string> Laps { get; }
        void Start();
        void Stop();
        string Lap();
        void Reset();
    }
}

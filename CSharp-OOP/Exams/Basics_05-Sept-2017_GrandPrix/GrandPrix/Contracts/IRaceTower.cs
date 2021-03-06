﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public interface IRaceTower
{
    void SetTrackInfo(int lapsNumber, int trackLength);
    void RegisterDriver(List<string> commandArgs);
    void DriverBoxes(List<string> commandArgs);
    string CompleteLaps(List<string> commandArgs);
    string GetLeaderboard();
    void ChangeWeather(List<string> commandArgs);

}

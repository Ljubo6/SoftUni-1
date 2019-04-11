using GrandPrix.Core.Factories;
using GrandPrix.CustomExceptions;
using GrandPrix.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower : IRaceTower
{
    private int totalLaps;
    private int currentLap;
    private int trackLength;
    private Weather weather;

    private TyreFactory tyreFactory;
    private DriverFactory driverFactory;

    private Dictionary<string, Driver> competingDrivers;
    private List<Driver> failedDrivers;

    public RaceTower()
    {
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
        this.competingDrivers = new Dictionary<string, Driver>();
        this.failedDrivers = new List<Driver>();
        this.weather = Weather.Sunny;
    }

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.totalLaps = lapsNumber;
        this.trackLength = trackLength;
    }

    public void RegisterDriver(List<string> commandArgs)
    {
        Driver driver;
        Car car;
        Tyre tyre;

        string driverType = commandArgs[0];
        string driverName = commandArgs[1];
        int carHp = int.Parse(commandArgs[2]);
        double carFuelAmount = double.Parse(commandArgs[3]);
        string tyreType = commandArgs[4];
        double tyreHardness = double.Parse(commandArgs[5]);

        if (commandArgs.Count == 7)
        {
            double grip = double.Parse(commandArgs[6]);
            tyre = tyreFactory.CreateTyre(tyreType, tyreHardness, grip);
        }
        else
        {
            tyre = tyreFactory.CreateTyre(tyreType, tyreHardness);
        }

        car = new Car(carHp, carFuelAmount, tyre);
        driver = driverFactory.CreateDriver(driverType, driverName, car);
        this.competingDrivers.Add(driverName, driver);
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reason = commandArgs[0];
        string driverName = commandArgs[1];
        var driver = this.GetDriver(driverName);

        if (driver == null)
        {
            return;
        }

        driver.IncreaseTotalTime(20);

        if (reason == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);
            driver.Car.Refuel(fuelAmount);
        }
        else if (reason == "ChangeTyres")
        {
            Tyre newTyre;
            string type = commandArgs[2];
            var tyreHardness = double.Parse(commandArgs[3]);

            if (type == "UltraSoft")
            {
                var grip = double.Parse(commandArgs[4]);
                newTyre = tyreFactory.CreateTyre(type, tyreHardness, grip);
            }
            else
            {
                newTyre = tyreFactory.CreateTyre(type, tyreHardness);
            }

            driver.Car.ChangeTyre(newTyre);
        }

    }

    public string CompleteLaps(List<string> commandArgs)
    {
        string output = null;

        var numberOfLaps = int.Parse(commandArgs[0]);

        if (totalLaps - currentLap < numberOfLaps)
        {
            return $"There is no time! On lap {currentLap}.";
        }



        for (int i = 0; i < numberOfLaps; i++)
        {
            List<Driver> toDisqualifyTyre = new List<Driver>();
            List<Driver> toDisqualifyFuel = new List<Driver>();

            foreach (var driver in this.competingDrivers.Values)
            {
                var currentLapTime = 60 / (trackLength / driver.Speed);
                driver.IncreaseTotalTime(currentLapTime);
                try
                {
                    driver.Car.ReduceFuel(trackLength * driver.FuelConsumptionPerKm);
                    driver.Car.Tyre.ReduceDegradation();
                }
                catch (OutOfFuelException)
                {
                    toDisqualifyFuel.Add(driver);
                }
                catch (BlownTyreException)
                {
                    toDisqualifyTyre.Add(driver);
                }
            }

            foreach (var driver in toDisqualifyFuel)
            {
                this.DisqualifyDriver(driver, "Out of fuel");
            }

            foreach (var driver in toDisqualifyTyre)
            {
                this.DisqualifyDriver(driver, "Blown Tyre");
            }

            this.currentLap++;

            var overtakingHelperCollection = this.competingDrivers.Values.OrderByDescending(d => d.TotalTime).Reverse().Select(d => d.Name).ToArray();

            for (int j = overtakingHelperCollection.Length - 1; j >= 1; j--)
            {
                var overtakingName = overtakingHelperCollection[j];
                var overtakenName = overtakingHelperCollection[j - 1];

                var overtakingDriver = this.competingDrivers[overtakingName];
                var overtakenDriver = this.competingDrivers[overtakenName];

                if (overtakingDriver is AggressiveDriver
                    && overtakingDriver.Car.Tyre is UltrasoftTyre
                    && overtakingDriver.TotalTime - overtakenDriver.TotalTime <= 3)
                {
                    if (this.weather == Weather.Foggy)
                    {
                        this.DisqualifyDriver(overtakingDriver, "Crashed");
                    }
                    else
                    {
                        overtakingDriver.DecreaseTotalTime(3);
                        overtakenDriver.IncreaseTotalTime(3);
                        output = $"{overtakingName} has overtaken {overtakenName} on lap {this.currentLap}.";
                    }
                }

                else if (overtakingDriver is EnduranceDriver
                    && overtakingDriver.Car.Tyre is HardTyre
                    && overtakingDriver.TotalTime - overtakenDriver.TotalTime <= 3)
                {
                    if (this.weather == Weather.Rainy)
                    {
                        this.DisqualifyDriver(overtakingDriver, "Crashed");
                    }
                    else
                    {
                        overtakingDriver.DecreaseTotalTime(3);
                        overtakenDriver.IncreaseTotalTime(3);
                        output = $"{overtakingName} has overtaken {overtakenName} on lap {this.currentLap}.";
                    }
                }

                else if (overtakingDriver.TotalTime - overtakenDriver.TotalTime <= 2)
                {
                    overtakingDriver.DecreaseTotalTime(2);
                    overtakenDriver.IncreaseTotalTime(2);
                    output = $"{overtakingName} has overtaken {overtakenName} on lap {this.currentLap}.";
                }
                j--;
            }
        }
        return output;
    }

    private void DisqualifyDriver(Driver driver, string failureReason)
    {
        string driverName = driver.Name;
        driver.FailureReason = failureReason;
        this.failedDrivers.Add(driver);
        this.competingDrivers.Remove(driverName);
    }

    public string GetLeaderboard()
    {
        var info = new StringBuilder();
        info.AppendLine($"Lap {this.currentLap}/{this.totalLaps}");

        int position = 1;
        foreach (var driver in this.competingDrivers.Values.OrderBy(d => d.TotalTime))
        {
            info.AppendLine($"{position++} {driver.Name} {driver.TotalTime:f3}");
        }

        if (this.failedDrivers.Count > 0)
        {
            for (int i = this.failedDrivers.Count - 1; i >= 0; i--)
            {
                var driver = this.failedDrivers[i];
                info.AppendLine($"{position++} {driver.Name} {driver.FailureReason}");
            }
        }

        return info.ToString().TrimEnd();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        var weatherString = commandArgs[0];
        this.weather = (Weather)Enum.Parse(typeof(Weather), weatherString);
    }

    public bool IsFinished => this.currentLap == this.totalLaps;

    public string PrintWinner()
    {
        Driver winner = this.competingDrivers.Values.OrderBy(d => d.TotalTime).First();

        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }

    private Driver GetDriver(string driverName)
    {
        if (!this.competingDrivers.ContainsKey(driverName))
        {
            return null;
        }

        return this.competingDrivers[driverName];
    }

}

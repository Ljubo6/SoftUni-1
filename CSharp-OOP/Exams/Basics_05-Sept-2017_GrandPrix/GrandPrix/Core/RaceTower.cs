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

    private List<Driver> competingDrivers;
    private List<Driver> failedDrivers;

    public RaceTower()
    {
        this.tyreFactory = new TyreFactory();
        this.driverFactory = new DriverFactory();
        this.competingDrivers = new List<Driver>();
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
        try
        {
            string[] tyreArgs = commandArgs.Skip(4).ToArray();
            Tyre tyre = tyreFactory.CreateTyre(tyreArgs);

            int carHp = int.Parse(commandArgs[2]);
            double carFuelAmount = double.Parse(commandArgs[3]);
            Car car = new Car(carHp, carFuelAmount, tyre);

            string driverType = commandArgs[0];
            string driverName = commandArgs[1];
            Driver driver = driverFactory.CreateDriver(driverType, driverName, car);

            this.competingDrivers.Add(driver);
        }
        catch { }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reason = commandArgs[0];
        string driverName = commandArgs[1];
        var driver = this.GetDriver(driverName);
        driver.IncreaseTotalTime(20);

        if (reason == "Refuel")
        {
            double fuelAmount = double.Parse(commandArgs[2]);
            driver.Car.Refuel(fuelAmount);
        }
        else if (reason == "ChangeTyres")
        {
            string[] newTyreArgs = commandArgs.Skip(2).ToArray();
            Tyre newTyre = tyreFactory.CreateTyre(newTyreArgs);
            driver.Car.ChangeTyre(newTyre);
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        string output = null;

        var numberOfLaps = int.Parse(commandArgs[0]);

        if (totalLaps - currentLap < numberOfLaps)
        {
            throw new WrongLapCountException($"There is no time! On lap {currentLap}.");
        }

        for (int i = 0; i < numberOfLaps; i++)
        {
            List<Driver> driversWithBlownTyre = new List<Driver>();
            List<Driver> driversWithoutFuel = new List<Driver>();

            foreach (var driver in this.competingDrivers)
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
                    driversWithoutFuel.Add(driver);
                }
                catch (BlownTyreException)
                {
                    driversWithBlownTyre.Add(driver);
                }
            }

            foreach (var driver in driversWithoutFuel)
            {
                this.DisqualifyDriver(driver, ErrorMessages.OutOfFuel);
            }

            foreach (var driver in driversWithBlownTyre)
            {
                this.DisqualifyDriver(driver, ErrorMessages.BlownTyre);
            }

            this.currentLap++;

            var overtakingHelperCollection = this.competingDrivers
                .OrderByDescending(d => d.TotalTime)
                .Reverse()
                .ToList();

            for (int j = overtakingHelperCollection.Count - 1; j >= 1; j--)
            {
                var overtakingDriver = overtakingHelperCollection[j];
                var overtakenDriver = overtakingHelperCollection[j - 1];

                if (OvertakingAttempt(overtakingDriver, overtakenDriver))
                {
                    output = $"{overtakingDriver.Name} has overtaken {overtakenDriver.Name} on lap {this.currentLap}.";
                    j--;
                }
                else if(overtakingDriver.FailureReason == "Crashed")
                {
                    overtakingHelperCollection.RemoveAt(j);
                    j++;
                }
            }
        }
        return output;
    }

    private bool OvertakingAttempt(Driver overtakingDriver, Driver overtakenDriver)
    {
        double timeDifference = overtakingDriver.TotalTime - overtakenDriver.TotalTime;

        bool aggressiveDriver = overtakingDriver is AggressiveDriver
                    && overtakingDriver.Car.Tyre is UltrasoftTyre;
                 
        bool enduranceDriver = overtakingDriver is EnduranceDriver
                    && overtakingDriver.Car.Tyre is HardTyre;


        if (aggressiveDriver && timeDifference <= 3)
        {
            if(this.weather == Weather.Foggy)
            {
                this.DisqualifyDriver(overtakingDriver, ErrorMessages.Crashed);
                return false;
            }

            overtakingDriver.DecreaseTotalTime(3);
            overtakenDriver.IncreaseTotalTime(3);
            return true;
        }
        else if(enduranceDriver && timeDifference <= 3)
        {
            if (this.weather == Weather.Rainy)
            {
                this.DisqualifyDriver(overtakingDriver, ErrorMessages.Crashed);
                return false;
            }

            overtakingDriver.DecreaseTotalTime(3);
            overtakenDriver.IncreaseTotalTime(3);
            return true;
        }
        else if(timeDifference <= 2)
        {
            overtakingDriver.DecreaseTotalTime(2);
            overtakenDriver.IncreaseTotalTime(2);
            return true;
        }

        return false;
    }

    private void DisqualifyDriver(Driver driver, string failureReason)
    {
        driver.FailureReason = failureReason;
        this.failedDrivers.Add(driver);
        this.competingDrivers.Remove(driver);
    }

    public string GetLeaderboard()
    {
        var info = new StringBuilder();
        info.AppendLine($"Lap {this.currentLap}/{this.totalLaps}");

        int position = 1;
        foreach (var driver in this.competingDrivers.OrderBy(d => d.TotalTime))
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
        Driver winner = this.competingDrivers.OrderBy(d => d.TotalTime).First();

        return $"{winner.Name} wins the race for {winner.TotalTime:f3} seconds.";
    }

    private Driver GetDriver(string driverName)
    {
        return this.competingDrivers.FirstOrDefault(d => d.Name == driverName);
    }

}

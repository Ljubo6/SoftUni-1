using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Microsystems : IMicrosystem
{
    private Dictionary<int, Computer> byNumber;
    private HashSet<Brand> addedBrands;
    //private Dictionary<Brand, Bag<Computer>> byBrand;

    public Microsystems()
    {
        this.byNumber = new Dictionary<int, Computer>();
        this.addedBrands = new HashSet<Brand>();
        //this.byBrand = new Dictionary<Brand, Bag<Computer>>();
    }

    public bool Contains(int number)
    {
        return this.byNumber.ContainsKey(number);
    }

    public int Count()
    {
        return this.byNumber.Count;
    }

    public void CreateComputer(Computer computer)
    {
        if (this.byNumber.ContainsKey(computer.Number))
        {
            throw new ArgumentException();
        }

        this.byNumber.Add(computer.Number, computer);
        this.addedBrands.Add(computer.Brand);
        //if (!this.byBrand.ContainsKey(computer.Brand))
        //{
        //    this.byBrand.Add(computer.Brand, new Bag<Computer>());
        //}
        //this.byBrand[computer.Brand].Add(computer);
    }

    public IEnumerable<Computer> GetAllFromBrand(Brand brand)
    {
        //if (!this.byBrand.ContainsKey(brand))
        //{
        //    return Enumerable.Empty<Computer>();
        //}
        //return this.byBrand[brand].OrderByDescending(x => x.Price);
        var result = this.byNumber.Values.Where(x => x.Brand == brand).OrderByDescending(x => x.Price);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Computer>();
        }
        return result;
    }

    public IEnumerable<Computer> GetAllWithColor(string color)
    {
        var result = this.byNumber.Values.Where(x => x.Color == color).OrderByDescending(x => x.Price);
        if(result.Count() == 0)
        {
            return Enumerable.Empty<Computer>();
        }
        return result;
    }

    public IEnumerable<Computer> GetAllWithScreenSize(double screenSize)
    {
        var result = this.byNumber.Values.Where(x => x.ScreenSize == screenSize).OrderByDescending(x => x.Number);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Computer>();
        }
        return result;
    }

    public Computer GetComputer(int number)
    {
        if (!this.byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        return this.byNumber[number];
    }

    public IEnumerable<Computer> GetInRangePrice(double minPrice, double maxPrice)
    {
        var result = this.byNumber.Values.Where(x => x.Price >= minPrice && x.Price <= maxPrice).OrderByDescending(x => x.Price);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Computer>();
        }
        return result;
    }

    public void Remove(int number)
    {
        if (!this.byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        this.byNumber.Remove(number);
    }

    public void RemoveWithBrand(Brand brand)
    {
        //if (!this.byBrand.ContainsKey(brand))
        //{
        //    throw new ArgumentException();
        //}

        //var indecies = this.byBrand[brand].Select(x => x.Number);
        //this.byBrand.Remove(brand);
        //foreach (var number in indecies)
        //{
        //    this.byNumber.Remove(number);
        //}

        if (!this.addedBrands.Contains(brand))
        {
            throw new ArgumentException();
        }

        var numbers = this.GetAllFromBrand(brand).Select(x => x.Number);
        foreach (var number in numbers)
        {
            this.byNumber.Remove(number);
        }

        //this.byNumber = this.byNumber.Where(x => x.Value.Brand != brand).ToDictionary(x => x.Key, x => x.Value);
        //this.byNumber = this.byNumber.Where(x => this.addedBrands.Contains(x.Value.Brand)).ToDictionary(x => x.Key, x => x.Value);
        this.addedBrands.Remove(brand);
    }

    public void UpgradeRam(int ram, int number)
    {
        if (!this.byNumber.ContainsKey(number))
        {
            throw new ArgumentException();
        }
        var computer = this.byNumber[number];
        if(computer.RAM < ram)
        {
            computer.RAM = ram;
        }
    }
}

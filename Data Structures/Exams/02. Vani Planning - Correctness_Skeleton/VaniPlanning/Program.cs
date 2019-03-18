using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var agency = new Agency();
        var inputGenerator = new InputGenerator();

        List<Invoice> invoices = inputGenerator.GenerateInvoices(10000);

        foreach (var inv in invoices)
        {
            agency.Create(inv);
        }

        var mostOccur = inputGenerator.MostOccur(invoices, x => x.DueDate);

        DateTime mostOccurDueDate = mostOccur.Key;

        DateTime minDueDate = mostOccurDueDate.AddYears(-1);
        DateTime maxDueDate = mostOccurDueDate.AddYears(1);

        var watch = new Stopwatch();
        watch.Start();
        try
        {
            agency.ThrowInvoiceInPeriod(minDueDate, maxDueDate);
        }
        catch (ArgumentException ignored)
        {

        }
        watch.Stop();

        long elapsedTime = watch.ElapsedMilliseconds;
        System.Console.WriteLine(elapsedTime);
    }
}

public class InputGenerator
{

    private static Random RANDOM = new Random();
    private static string[] COMPANIES = { "HRS", "SoftUni", "Expedia", "SBTech", "Codexio", "VMWare", "Musala", "Chaos Group", "PaySafe", "Motion", "Locktrip" };

    public List<Invoice> GenerateInvoices(int count)
    {
        List<Invoice> generated = new List<Invoice>();
        for (int i = 0; i < count; i++)
        {
            string uuid = Guid.NewGuid().ToString();
            string company = COMPANIES[Math.Abs(RANDOM.Next()) % COMPANIES.Length];
            double subTotal = RANDOM.NextDouble() * Math.Abs(RANDOM.Next());
            var department = (Department)Enum.GetValues(typeof(Department)).GetValue(Math.Abs(RANDOM.Next()) % Enum.GetValues(typeof(Department)).Length);

            DateTime firstDate = GetRandomDate(new DateTime(2010, 1, 1), new DateTime(2015, 1, 1));
            DateTime secondDate = this.GetRandomDate(new DateTime(2018, 1, 1), new DateTime(2020, 1, 1));
            generated.Add(new Invoice(uuid, company, subTotal, department, firstDate, secondDate));

        }
        return generated;
    }

    DateTime GetRandomDate(DateTime dtStart, DateTime dtEnd)
    {
        int cdayRange = (dtEnd - dtStart).Days;

        return dtStart.AddDays(RANDOM.NextDouble() * cdayRange).Date;
    }
    public KeyValuePair<TKey, int> MostOccur<TKey>(IList<Invoice> invoices, Func<Invoice, TKey> selector)
    {
        return invoices.GroupBy(selector).ToDictionary(k => k.Key, v => v.Count()).OrderByDescending(x => x.Key).FirstOrDefault();
    }


}

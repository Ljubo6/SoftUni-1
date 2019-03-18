using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

public class Agency : IAgency
{
    private HashSet<string> paidInvoices;
    private Dictionary<string, Invoice> bySerialNumber;
    private Dictionary<DateTime, Bag<Invoice>> byDueDate;

    public Agency()
    {
        this.bySerialNumber = new Dictionary<string, Invoice>();
        this.byDueDate = new Dictionary<DateTime, Bag<Invoice>>();
        this.paidInvoices = new HashSet<string>();
    }

    public bool Contains(string number)
    {
        return this.bySerialNumber.ContainsKey(number);
    }

    public int Count()
    {
        return this.bySerialNumber.Count;
    }

    public void Create(Invoice invoice)
    {
        if (this.Contains(invoice.SerialNumber))
        {
            throw new ArgumentException();
        }
        this.bySerialNumber.Add(invoice.SerialNumber, invoice);

        if (!this.byDueDate.ContainsKey(invoice.DueDate))
        {
            this.byDueDate.Add(invoice.DueDate, new Bag<Invoice>());
        }
        this.byDueDate[invoice.DueDate].Add(invoice);
    }

    public void ExtendDeadline(DateTime dueDate, int days)
    {
        if (!this.byDueDate.ContainsKey(dueDate))
        {
            throw new ArgumentException();
        }

        var invoices = this.byDueDate[dueDate];
        if (invoices.Count == 0)
        {
            throw new ArgumentException();
        }

        foreach (var invoice in invoices)
        {
            invoice.DueDate = invoice.DueDate.AddDays(days);
        }

    }

    public IEnumerable<Invoice> GetAllByCompany(string company)
    {
        var result = this.bySerialNumber.Values.Where(x => x.CompanyName == company).OrderByDescending(x => x.SerialNumber);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Invoice>();
        }
        return result; ;
    }

    public IEnumerable<Invoice> GetAllFromDepartment(Department department)
    {
        var result = this.bySerialNumber.Values.Where(x => x.Department == department).OrderByDescending(x => x.Subtotal).ThenBy(x => x.IssueDate);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Invoice>();
        }
        return result;
    }

    public IEnumerable<Invoice> GetAllInvoiceInPeriod(DateTime start, DateTime end)
    {
        var result = this.bySerialNumber.Values
            .Where(x => x.IssueDate >= start && x.IssueDate<=end)
            .OrderBy(x => x.IssueDate).ThenBy(x => x.DueDate);
        if (result.Count() == 0)
        {
            return Enumerable.Empty<Invoice>();
        }
        return result;
    }

    public void PayInvoice(DateTime due)
    {
        if (!this.byDueDate.ContainsKey(due))
        {
            throw new ArgumentException();
        }

        var invoices = this.byDueDate[due];
        if (invoices.Count == 0)
        {
            throw new ArgumentException();
        }

        foreach (var invoice in invoices)
        {
            invoice.Subtotal = 0;
            this.paidInvoices.Add(invoice.SerialNumber);
        }
    }

    public IEnumerable<Invoice> SearchBySerialNumber(string serialNumber)
    {
        var result = this.bySerialNumber.Where(x => x.Key.Contains(serialNumber)).Select(x => x.Value).OrderByDescending(x => x.SerialNumber);
        if (result.Count() == 0)
        {
            throw new ArgumentException();
        }
        return result;
    }

    public void ThrowInvoice(string number)
    {
        if (!this.Contains(number))
        {
            throw new ArgumentException();
        }
        this.bySerialNumber.Remove(number);
    }

    public IEnumerable<Invoice> ThrowInvoiceInPeriod(DateTime start, DateTime end)
    {
        var range = this.byDueDate.Where(x => x.Key > start && x.Key < end).SelectMany(x => x.Value);

        if (range.Count() == 0)
        {
            throw new ArgumentException();
        }

        foreach (var invoice in range)
        {
            paidInvoices.Add(invoice.SerialNumber);
            //this.byDueDate.Remove(invoice.DueDate);
        }

        this.ThrowPayed();
        paidInvoices.Clear();
        return range;
    }

    public void ThrowPayed()
    {
        foreach (var serialNumber in paidInvoices)
        {
            var paidInvoice = this.bySerialNumber[serialNumber];
            this.bySerialNumber.Remove(serialNumber);
            this.byDueDate.Remove(paidInvoice.DueDate);
        }
        paidInvoices.Clear();
    }
}

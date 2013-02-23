using System;
using System.Linq;
using System.Collections.Generic;

class CallHistory
{
    // Private Fields
    private readonly List<Call> callHistory = null;

    // Public properties
    public int Count
    {
        get { return this.callHistory.Count; }
    }

    // Construcors
    public CallHistory()
    {
        this.callHistory = new List<Call>();
    }

    // Methods
    public void Add(Call call)
    {
        this.callHistory.Add(call);
    }

    public void Remove(int id)
    {
        this.callHistory.RemoveAll(call => call.Equals(id));
    }

    public void Clear()
    {
        this.callHistory.Clear();
    }

    public Call Get(int id)
    {
        return this.callHistory.Find(call => call.Id == id);
    }

    public Call Max()
    {
        return this.callHistory.Max();
    }

    public int GetStartedMinutes()
    {
        return (int)(this.callHistory.Sum(
            call => Math.Ceiling(call.Duration.TotalSeconds / 60.0)
        ));
    }

    public decimal CalculatePrice(decimal pricePerMinute)
    {
        return GetStartedMinutes() * pricePerMinute;
    }

    public override string ToString()
    {
        if (this.callHistory.Count == 0)
        {
            return "No history available.";
        }

        else
        {
            List<string> info = new List<string>();

            for (int i = 0; i < this.callHistory.Count; i++)
                info.Add(String.Format("Call {0}: {1}", i, this.callHistory[i]));

            return String.Join(Environment.NewLine, info);
        }
    }
}

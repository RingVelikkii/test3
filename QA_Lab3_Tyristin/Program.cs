using System;

class Culture
{
    protected double cost;
    protected double income;

    public void Init(double c, double i)
    {
        cost = c;
        income = i;
    }

    public virtual double calculateProfit()
    {
        return income - cost;
    }
}

class IrrigatedCulture : Culture
{
    private int irrigated;

    public void Init(double c, double i, int flag)
    {
        base.Init(c, i);
        irrigated = flag;
    }

    public override double calculateProfit()
    {      // a
        double p = income - cost;
        if (irrigated == 1)
            p = p * 1.3;
        return p;
    }

    public void setIrrigated(int f) { irrigated = f; }
}

class VillageNew
{
    private string name;
    private Culture cult;
    private IrrigatedCulture irrCult;
    private int tons1, tons2;
    private double extraProfit;

    public void Init(string n, Culture c, IrrigatedCulture ic, int t1, int t2, double extra)
    {
        name = n;
        cult = c;
        irrCult = ic;
        tons1 = t1;
        tons2 = t2;
        extraProfit = extra;
    }

    public void Display()
    {
        Console.WriteLine("Село: " + name);
        Console.WriteLine("Прибыль обычной: " + cult.calculateProfit());
        Console.WriteLine("Прибыль орошаемой: " + irrCult.calculateProfit());
        Console.WriteLine("Общая прибыль: " + calculateTotalProfit());
    }

    public double calculateTotalProfit()
    {           // c
        return extraProfit +
               cult.calculateProfit() * tons1 +
               irrCult.calculateProfit() * tons2;
    }
}

class Program
{
    static void Main()
    {
        Culture wheat = new Culture();
        wheat.Init(5000, 15000);

        IrrigatedCulture corn = new IrrigatedCulture();
        corn.Init(7000, 20000, 1);

        IrrigatedCulture potato = new IrrigatedCulture();
        potato.Init(3000, 10000, 0);

        VillageNew v = new VillageNew();
        v.Init("Солнечное", wheat, corn, 100, 80, 50000);
        v.Display();

        potato.setIrrigated(1);
        VillageNew v2 = new VillageNew();
        v2.Init("Лесное", wheat, potato, 120, 90, 30000);
        v2.Display();
    }
}

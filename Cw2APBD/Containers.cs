namespace Cw2APBD;

public class Containers : IHazardNotifier
{
    public double Kg { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public double Depth { get; set; }
    public double MaxMassKg { get; set; }
    public string SerialNumber { get; set; } = "";
    public int NumberContainer { get; set; }
    public string Type { get; set; } = "";

    public string cargoType { get; set; } = "";


    public Containers(double Kg, double Height, double Weight, double Depth, double MaxMassKg, string SerialNumber,
        string Type, int NumberContainer,
        string cargoType)
    {
        this.Kg = Kg;
        this.Height = Height;
        this.Weight = Weight;
        this.Depth = Depth;
        this.MaxMassKg = MaxMassKg;
        this.SerialNumber = SerialNumber;
        this.NumberContainer = NumberContainer;
        this.Type = Type;
        this.cargoType = cargoType;
    }

    public void ClearContainer()
    {
        Kg = 0;
        Height = 0;
        Weight = 0;
        Depth = 0;
        MaxMassKg = 0;
        NumberContainer = 0;
        SerialNumber = "";
    }

    public double AddMass(double mass, Containers containers)
    {
        double tmp = Kg + mass;
        double newMass = MaxMassKg * 0.1;
        double fiftyPercentOfMaxMass = MaxMassKg * 0.5;
        double ninetyPercentOfMaxMass = MaxMassKg - newMass;
        double ninetyFivePercentOfMaxMass = MaxMassKg - newMass * 0.5;

        if (containers.cargoType == "Save" & containers.Type == "L")
        {
            try
            {
                if (tmp > ninetyPercentOfMaxMass)
                {
                    throw new OverfillException();
                    return Kg;
                }

                Kg += mass;
            }
            catch (OverfillException e)
            {
                Notify();
            }
        }

        if (containers.cargoType == "Danger" & containers.Type == "L")
        {
            try
            {
                if (tmp > fiftyPercentOfMaxMass)
                {
                    throw new OverfillException();
                    return Kg;
                }

                Kg += mass;
            }
            catch (OverfillException e)
            {
                Notify();
            }
        }


        if (containers.cargoType == "Gas" & containers.Type == "G")
        {
            try
            {
                if (tmp > ninetyFivePercentOfMaxMass)
                {
                    throw new OverfillException();
                    return Kg;
                }

                Kg += mass;
            }
            catch (OverfillException e)
            {
                ContainerInfo(containers);
            }
        }

        return Kg;
    }


    public void ColdContainer(Containers containers)
    {
        if (containers.Type != "C")
        {
            Console.WriteLine("Rodzaj produktu nie odnosi się do zimnych produktów ");
            return;
        }
    
        string[] food = new string[]
        {
            "Bananas 13.3°C",
            "Chocolate 18°C",
            "Fish 2°C",
            "Meat -15°C",
            "Ice cream -18°C",
            "Frozen pizza -30°C",
            "Cheese 7.2°C",
            "Sausages 5°C",
            "Butter 20.5°C",
            "Eggs 19°C"
        };

        bool found = false;

        for (int i = 0; i < food.Length; i++)
        {
            if (containers.cargoType == food[i])
            {
                found = true;
                break;  
            }
        }

        if (found)
        {
            Console.WriteLine("Rodzaj produktu i temperatura prawidłowa (" + containers.cargoType + ")");
        }
        else
        {
             
            Console.WriteLine("Rodzaj produktu albo temperatura nie prawidłowa (" + containers.cargoType + ")");
        }
    }

    public void ContainerInfo(Containers containers)
    {
        Console.WriteLine("zajście niebezpieczne " + containers.SerialNumber + "-" + containers.Type + "-" +
                          containers.NumberContainer);
    }

    public void Notify()
    {
        Console.WriteLine("wykonania niebezpiecznej operacji");
    }


    public String ToString()
    {
        return Kg + " " + Height + " " + Weight + " " + Depth + " " + MaxMassKg + " " + NumberContainer + " " +
               SerialNumber;
    }


    public class OverfillException : Exception
    {
    }
}
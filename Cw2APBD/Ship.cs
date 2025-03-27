using System.ComponentModel;

namespace Cw2APBD;

public class Ship 
{
    public string Name { get; set; }
    public double MaxSpeed { get; set; }
    public int MaxContainers { get; set; }
    public double MaxWeight { get; set; }
    private List<Containers> containers;

    public Ship(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        containers = new List<Containers>();
    }

    public bool LoadContainer(Containers container)
    {
        double totalWeight = containers.Sum(c => c.Kg) + container.Kg;
        if (containers.Count >= MaxContainers)
        {
            Console.WriteLine("Maksymalna liczba kontenerów została osiągnięta!");
            return false;
        }

        if (totalWeight > MaxWeight * 1000)
        {
            Console.WriteLine("Przekroczona maksymalna waga kontenerów!");
            return false;
        }

        containers.Add(container);
        Console.WriteLine("Kontener załadowany: " + container.SerialNumber  );
        return true;
    }

    public bool DeleteContainerFromShip(Containers container)
    {
        if (!containers.Contains(container))
        {
            Console.WriteLine("Kontener nie znaleziony");
            return false;
        }
        containers.Remove(container);
        Console.WriteLine("Kontener rozładowany: " + container.SerialNumber );
        return true;
    }
        
    public bool TransferContainer(Containers container, Ship targetShip)
    {
        if (!containers.Contains(container))
        {
            Console.WriteLine("Kontener nie znaleziony");
            return false;
        }
        if (targetShip.LoadContainer(container))
        {
            containers.Remove(container);
            Console.WriteLine("Kontener przeniesiony na statek: " + targetShip.Name);
            return true;
        }
        return false;
    }
    public void PrintShipInfo()
    {
        Console.WriteLine($"Statek: {Name}");
        Console.WriteLine($"Maksymalna prędkość: {MaxSpeed} węzłów");
        Console.WriteLine($"Maksymalna liczba kontenerów: {MaxContainers}");
        Console.WriteLine($"Maksymalna waga ładunku: {MaxWeight} ton");
        Console.WriteLine($"Aktualna liczba kontenerów: {containers.Count}");
        Console.WriteLine($"Aktualna waga ładunku: {containers.Sum(c => c.Kg) / 1000} ton");
    }

    public void PrintContainersInfo()
    {
        Console.WriteLine("\nLista kontenerów na statku:");
        foreach (Containers container in containers)
        {
            Console.WriteLine(container.SerialNumber +" " +container.Kg + "kg");
        }
    }
}
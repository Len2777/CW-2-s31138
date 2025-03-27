using Cw2APBD;

Ship ship1 = new Ship("Titanic", 24, 5, 500);
Ship ship2 = new Ship("Poseidon", 20, 3, 300);

Containers container1 = new Containers(1000, 2.5, 2.5, 6, 5000, "KON-L-1", "Save");
Containers container2 = new Containers(2000, 3, 2.5, 6, 7000, "KON-C-2", "Meat -15°C");
Containers container3 = new Containers(1500, 3, 2.5, 6, 6000, "KON-C-3", "Bananas 5°C");



container1.AddMass(3000, container1);
ship1.LoadContainer(container1);
container1.ColdContainer(container1);

Console.WriteLine("---------------------------");

ship1.LoadContainer(container2);
container2.ColdContainer(container2);

Console.WriteLine("---------------------------");

ship1.LoadContainer(container3);
container3.ColdContainer(container3);

Console.WriteLine("---------------------------");
ship1.PrintShipInfo();

Console.WriteLine("---------------------------");
ship1.PrintContainersInfo();


ship1.TransferContainer(container2, ship2);

Console.WriteLine("---------------------------");
ship1.DeleteContainerFromShip(container3);
container2.ClearContainer();


Console.WriteLine("--------------------------");
ship1.PrintShipInfo();
Console.WriteLine("---------------------------");
ship1.PrintContainersInfo();
Console.WriteLine("---------------------------");
ship2.PrintShipInfo();
Console.WriteLine("---------------------------");
ship2.PrintContainersInfo();
Console.WriteLine("---------------------------");



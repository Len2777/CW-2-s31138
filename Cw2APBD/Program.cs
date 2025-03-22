using Cw2APBD;

Ship ship1 = new Ship("Titanic", 24, 5, 500);
Ship ship2 = new Ship("Poseidon", 20, 3, 300);

Containers container1 = new Containers(1000, 2.5, 2.5, 6, 5000, "KON", "L", 1, "Save");
Containers container2 = new Containers(2000, 3, 2.5, 6, 7000, "KON", "C", 2, "Meat -15°C");
Containers container3 = new Containers(1500, 3, 2.5, 6, 6000, "KON", "C", 3, "Bananas 5°C");


container1.AddMass(1000, container1);
ship1.LoadContainer(container1);
container1.ColdContainer(container1);

ship1.LoadContainer(container2);
container2.ColdContainer(container2);

ship1.LoadContainer(container3);
container3.ColdContainer(container3);

ship1.PrintShipInfo();
ship1.PrintContainersInfo();
ship1.TransferContainer(container2, ship2);

ship1.DeleteContainerFromShip(container3);
container2.ClearContainer();

ship1.PrintShipInfo();
ship1.PrintContainersInfo();
ship2.PrintShipInfo();
ship2.PrintContainersInfo();
namespace ConsoleApp1;

public class ContainerShip
{
    public List<Container> Containers;
    public double MaxSpeed;
    public int MaxContainerCount;
    public double MaxWeight;
    public string Name;

        public ContainerShip(string name, double maxSpeed, int maxContainerCount, double maxWeight)
        {
            Name = name;
            MaxSpeed = maxSpeed;
            MaxContainerCount = maxContainerCount;
            MaxWeight = maxWeight;
            Containers = new List<Container>();
        }

        public bool LoadContainer(Container container)
        {
            if (Containers.Count >= MaxContainerCount)
            {
                Console.WriteLine($"Cannot load container {container.SerialNumber} - ship {Name} is at maximum container capacity.");
                return false;
            }

            double totalWeightKg = Containers.Sum(c => c.Mass + c.TareWeight) + container.Mass + container.TareWeight;

            if (totalWeightKg > MaxWeight * 1000)
            {
                Console.WriteLine($"Cannot load container {container.SerialNumber} - would exceed maximum weight capacity for ship {Name}.");
                return false;
            }

            Containers.Add(container);
            Console.WriteLine($"Container {container.SerialNumber} loaded onto ship {Name}.");
            return true;
        }
        
        public bool LoadContainers(List<Container> containers)
        {
            bool allLoaded = true;
            foreach (var container in containers)
            {
                if (!LoadContainer(container))
                {
                    allLoaded = false;
                }
            }
            return allLoaded;
        }

        public bool RemoveContainer(string serialNumber)
        {
            Container containerToRemove = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (containerToRemove == null)
            {
                Console.WriteLine($"Container {serialNumber} not found on ship {Name}.");
                return false;
            }

            Containers.Remove(containerToRemove);
            Console.WriteLine($"Container {serialNumber} removed from ship {Name}.");
            return true;
        }

        public bool ReplaceContainer(string serialNumber, Container newContainer)
        {
            int index = Containers.FindIndex(c => c.SerialNumber == serialNumber);
            if (index == -1)
            {
                Console.WriteLine($"Container {serialNumber} not found on ship {Name}.");
                return false;
            }

            Containers[index] = newContainer;
            Console.WriteLine($"Container {serialNumber} replaced with {newContainer.SerialNumber} on ship {Name}.");
            return true;
        }

        public void PrintShipInfo()
        {
            Console.WriteLine($"Ship: {Name}");
            Console.WriteLine($"Maximum Speed: {MaxSpeed} knots");
            Console.WriteLine($"Maximum Containers: {MaxContainerCount}");
            Console.WriteLine($"Maximum Weight: {MaxWeight} tons");
            Console.WriteLine($"Current Container Count: {Containers.Count}");

            double totalWeightTons = Containers.Sum(c => c.Mass + c.TareWeight) / 1000.0;
            Console.WriteLine($"Current Total Weight: {totalWeightTons:F2} tons");

            Console.WriteLine("Containers on board:");
            foreach (var container in Containers)
            {
                Console.WriteLine($"- {container.SerialNumber} (Type: {container.SerialNumber.Split('-')[1]})");
            }
        }

        public Container GetContainer(string serialNumber)
        {
            return Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        }

        public void UnloadContainer(string serialNumber)
        {
            Container container = GetContainer(serialNumber);
            if (container != null)
            {
                container.EmptyContainer();
                Console.WriteLine($"Container {serialNumber} on ship {Name} has been unloaded.");
            }
            else
            {
                Console.WriteLine($"Container {serialNumber} not found on ship {Name}.");
            }
        }
        
        public static bool TransferContainer(ContainerShip sourceShip, ContainerShip destinationShip, string serialNumber)
        {
            Container containerToTransfer = sourceShip.Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
            if (containerToTransfer == null)
            {
                Console.WriteLine($"Container {serialNumber} not found on source ship {sourceShip.Name}.");
                return false;
            }

            if (sourceShip.RemoveContainer(serialNumber))
            {
                if (destinationShip.LoadContainer(containerToTransfer))
                {
                    Console.WriteLine($"Container {serialNumber} successfully transferred from {sourceShip.Name} to {destinationShip.Name}.");
                    return true;
                }
                else
                {
                    sourceShip.LoadContainer(containerToTransfer);
                    Console.WriteLine($"Transfer failed, container {serialNumber} returned to {sourceShip.Name}.");
                    return false;
                }
            }
            return false;
        }
    }

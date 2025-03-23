namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Container liquidContainer = new LiquidContainer(0, 250, 500, 300, SerialNumberGenerator.GenerateSerialNumber('L'), 2000, true);
            Container gasContainer = new GasContainer(0, 300, 600, 350, SerialNumberGenerator.GenerateSerialNumber('G'), 1500, 10);
            Container refrigeratedContainer = new RefrigeratedContainer(0, 275, 550, 320, SerialNumberGenerator.GenerateSerialNumber('C'), 1800, "Fish", -12);

        
            liquidContainer.LoadContainer(900);
            gasContainer.LoadContainer(1200);
            refrigeratedContainer.LoadContainer(1500);
           

            ContainerShip ship1 = new ContainerShip("ship1", 25, 5, 5000);
            ContainerShip ship2 = new ContainerShip("ship2", 20, 4, 4000);

            ship1.LoadContainer(liquidContainer);
            ship1.LoadContainer(gasContainer);
            ship1.LoadContainer(refrigeratedContainer);

            ship1.PrintShipInfo();

            ship1.RemoveContainer(liquidContainer.SerialNumber);

            ship1.PrintShipInfo();

            ship1.UnloadContainer(gasContainer.SerialNumber);
            
            Container newContainer = new Container(0, 280, 500, 310, SerialNumberGenerator.GenerateSerialNumber('C'), 1900);
            ship1.ReplaceContainer(refrigeratedContainer.SerialNumber, newContainer);

            ContainerShip.TransferContainer(ship1, ship2, newContainer.SerialNumber);

            ship1.PrintShipInfo();
            ship2.PrintShipInfo();
        }
    }
}
namespace VendingMachineV1
{
    class Coin
    {
        public int Denomination { get; set; }
        public int Count { get; set; }
    }

    class VendingMachine
    {
        private Dictionary<int, int> coins = new Dictionary<int, int>();

        public void AddCoin(int denomination, int count)
        {
            coins[denomination] = count;
        }

        public List<int> CalculateChange(int itemPrice, List<int> paidCoins)
        {
            List<int> change = new List<int>();

            // Calculate the total value of coins paid by the user
            int paidValue = paidCoins.Sum();

            // Calculate the change to be given
            int remainingChange = paidValue - itemPrice;
            if (remainingChange < 0)
            {
                Console.WriteLine("Insufficient payment. Returning paid coins.");
                change.Clear();
                change.AddRange(paidCoins);
                return change;
            }

            // Add the paid coins to the vending machine coins
            foreach (var coin in paidCoins)
            {
                if (coins.ContainsKey(coin))
                {
                    coins[coin]++;
                }
                else
                {
                    coins[coin] = 1;
                }
            }

            // Calculate the total value of coins in the vending machine
            int totalValue = coins.Sum(c => c.Key * c.Value);

            // Iterate through the coins in the vending machine and deduct from the change
            foreach (var coin in coins.OrderByDescending(c => c.Key))
            {
                while (coin.Value > 0 && remainingChange >= coin.Key)
                {
                    change.Add(coin.Key);
                    coins[coin.Key]--;
                    remainingChange -= coin.Key;
                }
            }

            // If there is still remaining change, it means the vending machine does not have enough coins
            if (remainingChange > 0)
            {
                Console.WriteLine("Vending machine does not have enough coins to give the change. Returning paid coins");
                change.Clear();
                change.AddRange(paidCoins);
            }

            if (remainingChange == 0)
            {
                Console.WriteLine("Thank you for your purchase!");
                Console.WriteLine("Don't forget to take your bought product!");
            }

            return change;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create a vending machine
            VendingMachine vendingMachine = new VendingMachine();

            // Load the vending machine with coins
            vendingMachine.AddCoin(5, 100); // 2 x 5ct
            vendingMachine.AddCoin(10, 50); // 2 x 10ct
            vendingMachine.AddCoin(20, 50); // 2 x 20ct
            vendingMachine.AddCoin(50, 50); // 2 x 50ct
            vendingMachine.AddCoin(100, 50); // 2 x 100ct
            vendingMachine.AddCoin(200, 50); // 2 x 200ct

            bool isTurnedOn = true;
            while (isTurnedOn)
            {
                // Display the items and their prices
                Console.WriteLine("Items available for purchase:");
                Console.WriteLine("1. Coke - 100ct");
                Console.WriteLine("2. Chips - 150ct");
                Console.WriteLine("3. Candy - 75ct");
                Console.WriteLine("4. Sparkling water - 80ct");
                Console.WriteLine("5. Still water - 60ct");

                // Get the user's choice of item
                int choice;
                do
                {
                    Console.Write("Enter the number of the item you want to purchase: ");
                } while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5);

                // Get the user's payment
                List<int> paidCoins = new List<int>();
                do
                {
                    Console.Write("Insert a coin (nomination of 5, 10, 20, 50, 100 or 200) or enter 0 to finish: ");
                    int coin;
                    if (!int.TryParse(Console.ReadLine(), out coin) || coin != 5 && coin != 10 && coin != 20 && coin != 50 && coin != 100 && coin != 200 && coin != 0)
                    {
                        Console.WriteLine("Invalid coin. Please insert a valid coin.");
                    }
                    else if (coin == 0)
                    {
                        break;
                    }
                    else
                    {
                        paidCoins.Add(coin);
                    }
                } while (true);

                // Calculate the change to be given
                List<int> change = vendingMachine.CalculateChange(GetItemPrice(choice), paidCoins);

                // Display the change
                Console.Write("Change: ");
                foreach (var coin in change)
                {
                    Console.Write(coin + "ct ");
                }
                Console.WriteLine();
                Console.WriteLine("Do you want to continue? Press y or n");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        break;
                    case ConsoleKey.N:
                        isTurnedOn = false;
                        break;
                }
            }

            static int GetItemPrice(int choice)
            {
                switch (choice)
                {
                    case 1:
                        return 100;
                    case 2:
                        return 150;
                    case 3:
                        return 75;
                    case 4:
                        return 80;
                    case 5:
                        return 60;
                    default:
                        return 0;
                }
            }
        }
    }
}
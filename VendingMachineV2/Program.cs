namespace VendingMachineV2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Items for sale and their prices
            string[] items = { "Coke", "Chips", "Candy", "Water", "Juice" };
            decimal[] prices = { 1.25m, 0.75m, 0.50m, 1.00m, 1.10m };

            // Denominations of coins that are accepted
            decimal[] coinDenominations = { 0.05m, 0.10m, 0.20m, 0.50m, 1.00m, 2.00m };
            int denomLength = coinDenominations.Length;

            // Loading vending machine with denominated coins
            Dictionary<decimal, int> coinCounts = new()
            {
                { 0.05m, 1 },
                { 0.10m, 1 },
                { 0.20m, 1 },
                { 0.50m, 1 },
                { 1.00m, 1 },
                { 2.00m, 1 }
            };

            // Asking to make a selection
            Console.WriteLine("Welcome to the vending machine!");
            bool isTurnedOn = true;
            while (isTurnedOn)
            {
                Console.WriteLine("Please select an item:");

                for (int i = 0; i < items.Length; i++)
                {
                    Console.WriteLine("{0}. {1} (${2})", i + 1, items[i], prices[i]);
                }
                Console.Write("Enter a selection (1-{0}): ", items.Length);

                // Looping until selected valid item
                int selection;
                while (!int.TryParse(Console.ReadLine(), out selection) || (selection < 1 || selection > items.Length))
                {
                    Console.WriteLine("Invalid selection. Please try again.");
                    continue;
                }

                // Get the price of the selected item
                decimal price = prices[selection - 1];
                Console.WriteLine("The price of {0} is ${1}.", items[selection - 1], price);

                // Asking to insert coins
                Console.WriteLine("Please insert coins:");
                decimal total = 0.00m;
                Dictionary<decimal, int> insertedCoins = new();
                while (total < price)
                {
                    decimal coin;
                    Console.Write("Enter a coin ({0}): ", string.Join(", ", coinDenominations));
                    decimal.TryParse(Console.ReadLine(), out coin);

                    // Checking if the coin is valid
                    if (!Array.Exists(coinDenominations, element => element == coin))
                    {
                        Console.WriteLine("Invalid coin. Please try again.");
                        continue;
                    }

                    insertedCoins.TryGetValue(coin, out int coinCount);
                    insertedCoins[coin] = coinCount + 1;

                    total += coin;
                    Console.WriteLine("Total: ${0:F2}", total);
                }

                // Calculating the change and dispensing the item
                decimal change = total - price;
                List<decimal> GetChangeInCoins(decimal change)
                {
                    List<decimal> ans = new List<decimal>();

                    for (int i = denomLength - 1; i >= 0; i--)
                    {
                        while (change >= coinDenominations[i] && coinCounts[coinDenominations[i]] > 0)
                        {
                            change -= coinDenominations[i];
                            ans.Add(coinDenominations[i]);
                            coinCounts[coinDenominations[i]]--;
                        }
                    }

                    return ans;
                }

                if (change > 0)
                {
                    List<decimal> changeCoins = GetChangeInCoins(change);

                    if (changeCoins.Sum() != change || changeCoins.Sum() > total)
                    {
                        Console.WriteLine("Sorry, the vending machine does not have enough coins to give proper change.");
                        Console.WriteLine("Returning all your coins:");

                        foreach (decimal coin in insertedCoins.Keys)
                        {
                            for (int i = 0; i < insertedCoins[coin]; i++)
                            {
                                Console.WriteLine("$" + coin);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Change:");

                        foreach (decimal coin in changeCoins)
                        {
                            Console.WriteLine("$" + coin);
                        }
                        Console.WriteLine("Thank you for your purchase!");
                        Console.WriteLine("Don't forget to take your {0}!", items[selection - 1]);
                    }
                }
                else
                {
                    foreach (decimal coin in insertedCoins.Keys)
                    {
                        for (int i = 0; i < insertedCoins[coin]; i++)
                        {
                            coinCounts[coin]++;
                        }
                    }
                }
                if (change == 0)
                {
                    Console.WriteLine("Thank you for your purchase!");
                    Console.WriteLine("Don't forget to take your {0}!", items[selection - 1]);
                }
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
        }
    }
}
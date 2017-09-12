using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nile.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            do
            {
                char choice = GetInput();
                switch (choice)
                {
                    case 'a':
                    case 'A': AddProduct(); break;
                    case 'b':
                    case 'B': ListProduct(); break;
                    case 'q':
                    case 'Q': quit = true; break;
                };
            } while (!quit);
        }

        private static void ListProduct()
        {
            
            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine().Trim();

            Console.WriteLine("Enter price (> 0): ");
            string price = Console.ReadLine().Trim();

            Console.WriteLine("Enter optional description: ");
            string description = Console.ReadLine().Trim();

            Console.WriteLine("Is it discontinued (Y/N): ");
            string discontinued = Console.ReadLine().Trim();
        }

        private static void AddProduct()
        {
            Console.WriteLine("Enter product name: ");
            string name = Console.ReadLine().Trim();

        }

        static char GetInput()
        {
            while (true)
            {
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10), '-');
                Console.WriteLine("A)dd Product");
                Console.WriteLine("L)ist Product");
                Console.WriteLine("Q)uit");

                string input = Console.ReadLine();
                //if (input == "")
                //if (input != null && input.Length != 0)
                if (String.Compare(input, "A", true) == 0)
                {
                    char letter = Char.ToUpper(input[0]);

                    if (input == "A")
                        return 'A';
                    else if (input == "L")
                        return 'L';
                    else if (input == "Q")
                        return 'Q';
                    // Error
                    Console.WriteLine("Please choose a valid option");
                }
            }
        }

        //Product
        string productName,
               productDescription;
        decimal price;
        char discontinued;

    }
}

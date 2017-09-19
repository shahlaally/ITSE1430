using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Program
    {
        static void Main( string[] args )
        {
            GetMenu();
        }

        private static void GetMenu()
        {
            bool quit = false;
            do
            {
                var choice = GetInput();
                switch (choice)
                {
                    case 'a':
                    case 'A':
                        AddProduct();
                        break;
                    case 'l':
                    case 'L':
                        ListProduct();
                        break;
                    case 'r':
                    case 'R':
                        RemoveProduct();
                        break;
                    case 'q':
                    case 'Q':
                        quit = true;
                        break;
                }

            } while (!quit);

        }

        private static void RemoveProduct()
        { 
            if(movieTitle != "" && movieStatus != false)
            {
            Console.WriteLine("Are you sure you want to delete the movie (Y/N)?");
            movieTitle = "";
            movieDescription = "";
            movieLength = 0;
            movieStatus = false;
            }
        }

        private static void ListProduct()
        {
            Console.WriteLine();
            Console.WriteLine();
            string msg = $"{movieTitle}\n{(!String.IsNullOrEmpty(movieDescription) ? movieDescription + "\n" : "")}{(!String.IsNullOrEmpty(movieLength.ToString()) ? "Run Length = " +movieLength + " mins\n" : "")}{(movieStatus ? "Status = Owned" : "Status = Wishlist")}";

            Console.WriteLine(msg);
            Console.WriteLine();
            //Console.WriteLine("Press ENTER to continue");
            //string enter = Console.ReadKey();
        }

        private static void AddProduct()
        {
            movieTitle = ReadString("Enter a title: ");

            Console.Write("Enter an optional description: ");
            movieDescription = Console.ReadLine().Trim();

            movieLength = ReadInt("Enter the optional length (in minutes) (> 0): ");

            Console.Write("Do you own this movie? (Y/N): ");
            movieStatus = ReadYesNo();
        }

        static string ReadString(string msg)
        {
            do
            {
                Console.Write(msg);
                var input = Console.ReadLine().Trim();
                
                if (!String.IsNullOrEmpty(input))
                    return input;
                else
                Console.WriteLine("You must enter a value");
            } while (true);
        }
            private static char GetInput()
        {
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Main Menu");
                Console.WriteLine("".PadLeft(10, '-'));
                Console.WriteLine("A)dd Movie");
                Console.WriteLine("L)ist Movies");
                Console.WriteLine("R)emove Movie");
                Console.WriteLine("Q)uit");

                var input = Console.ReadLine().Trim();

                
                if (input != null && input.Length != 0)
                {
                    switch (Char.ToUpper(input[0]))
                    {
                        case 'A':
                            return 'A';
                        case 'L':
                            return 'L';
                        case 'R':
                            return 'R';
                        case 'Q':
                            return 'Q';
                    };
                };
          
                Console.WriteLine("Please choose a valid option");
            };

        }

        /// <summary>Reads an int from Console.</summary>
        /// <returns>The int value.</returns>
        static int ReadInt(string msg)
        {
            do
            {
                Console.Write(msg);
                var input = Console.ReadLine();
                //String.IsNullOrEmpty(input) ? return true : 
                
                bool result = Int32.TryParse(input, out var number);

                if (result && number > 0)
                    return number;
                else if (result && number <= 0)
                    Console.WriteLine("You must enter a value > 0");
                
            } while (true);
        }

        /// <summary>Reads a boolean from Console.</summary>
        /// <returns>The boolean value.</returns>
        static bool ReadYesNo()
        {
            do
            {
                var input = Console.ReadLine();

                if (!String.IsNullOrEmpty(input))
                {
                    switch (Char.ToUpper(input[0]))
                    {
                        case 'Y':
                            return true;
                        case 'N':
                            return false;
                    };
                };

                Console.WriteLine("Enter either Y or N");
            } while (true);
        }

        //Movie
        static string movieTitle;
        static int movieLength;
        static string movieDescription;
        static bool movieStatus;
    }
}

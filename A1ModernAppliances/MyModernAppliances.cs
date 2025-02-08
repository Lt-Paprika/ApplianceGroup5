using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;
using static ModernAppliances.Entities.Abstract.Appliance;

namespace ModernAppliances
{
    /// <summary>
    /// Manager class for Modern Appliances
    /// </summary>
    /// <remarks>Author: </remarks>
    /// <remarks>Date: </remarks>
    internal class MyModernAppliances : ModernAppliances
    {
        /// <summary>
        /// Option 1: Performs a checkout
        /// </summary>
        public override void Checkout()
        {
            // Write "Enter the item number of an appliance: "
            Console.WriteLine("Enter the item number of an appliance: ");

            // Create long variable to hold item number
            long itemNumberVar;

            // Get user input as string and assign to variable.
            string UserInput = Console.ReadLine();
            // Convert user input from string to long and store as item number variable.
            if (!long.TryParse(UserInput, out itemNumberVar))
            {
                Console.WriteLine("Invalid item number. Please enter a valid number.");
                return; // Exit the method if the input is invalid
            }

            // Create 'foundAppliance' variable to hold appliance with item number
            // Assign null to foundAppliance (foundAppliance may need to be set as nullable)

            Appliance? foundAppliance = null;

            // Loop through Appliances
            // Test appliance item number equals entered item number
            // Assign appliance in list to foundAppliance variable
            foreach (Appliance appliance in Appliances)
            {
                if (itemNumberVar == appliance.ItemNumber)
                {
                    foundAppliance = appliance;
                    break;
                } 
            }

            // Break out of loop (since we found what need to)


            // Test appliance was not found (foundAppliance is null)
            // Write "No appliances found with that item number."
            if (foundAppliance == null) 
            {
                Console.WriteLine("No appliances found with that item number");
            }
            else
            {
                if (foundAppliance.IsAvailable)
                {
                    foundAppliance.Checkout();
                    Console.WriteLine("Appliance has been checked out.");
                }
                else
                {
                    Console.WriteLine("The appliance is not available to be checked out.");
                }
            }   
            // Otherwise (appliance was found)
                // Test found appliance is available
                    // Checkout found appliance

                    // Write "Appliance has been checked out."
                // Otherwise (appliance isn't available)
                    // Write "The appliance is not available to be checked out."
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            // Write "Enter brand to search for:"
            Console.WriteLine("Enter brand to searchfor:");

            // Create string variable to hold entered brand
            string brand;
            // Get user input as string and assign to variable.
            brand = Console.ReadLine() ?? string.Empty;

            // Create list to hold found Appliance objects
            List<Appliance> found = new List<Appliance>();

            // Iterate through loaded appliances
            // Test current appliance brand matches what user entered
            // Add current appliance in list to found list
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand == brand)
                {
                    found.Add(appliance);
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options: ");

            // Write "0 - Any"
            Console.WriteLine("0 -Any");
            // Write "2 - Double doors"
            Console.WriteLine("2 - Double doors");
            // Write "3 - Three doors"
            Console.WriteLine("3 - Three doors");
            // Write "4 - Four doors"
            Console.WriteLine("4 - Four doors");
            // Write "Enter number of doors: "
            Console.WriteLine("Enter number of doors: ");

            // Create variable to hold entered number of doors
            int numOfDoors;

            // Get user input as string and assign to variable
            

            // Convert user input from string to int and store as number of doors variable.
            
            string? doorChoice = Console.ReadLine();
            int userDoors = Convert.ToInt16(doorChoice);
            // Create list to hold found Appliance objects

            List<Appliance> found = new List<Appliance>();

            // Iterate/loop through Appliances
            // Test that current appliance is a refrigerator
            // Down cast Appliance to Refrigerator
            // Refrigerator refrigerator = (Refrigerator) appliance;
            foreach (Appliance appliance in Appliances)
            {
                var typeCheck = DetermineApplianceTypeFromItemNumber(appliance.ItemNumber);
                if (typeCheck == ApplianceTypes.Refrigerator)
                {
                    Refrigerator refigerator = (Refrigerator)appliance;
                    if (userDoors == 0)
                    {
                        found.Add(refigerator);
                    }
                    if (refigerator.Doors == userDoors)
                    {
                        found.Add(refigerator);
                    }
                }
            }
            // Test user entered 0 or refrigerator doors equals what user entered.
            // Add current appliance in list to found list

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            // Write "Possible options:"
            Console.WriteLine("Possible options:");

            // Write "0 - Any"
            Console.WriteLine("0 - Any");
            // Write "1 - 18 Volt"
            Console.WriteLine("1 - 18");
            // Write "2 - 24 Volt"
            Console.WriteLine("2 - 24");

            // Write "Enter voltage:"
            Console.WriteLine("Enter Voltage: ");
            // Get user input as string
            string? UserInput = Console.ReadLine();
            // Create variable to hold voltage
            int voltage;
            // Test input is "0"
            if (UserInput == "0")
            {
                voltage = 0;
            }
            else if (UserInput == "1")
            {
                voltage = 18;
            }
            else if (UserInput == "2")
            {
                voltage = 24;
            }
            else
            {
                Console.WriteLine("Invalid Option");
                return;
            }

            // Assign 0 to voltage
            // Test input is "1"
            // Assign 18 to voltage
            // Test input is "2"
            // Assign 24 to voltage
            // Otherwise
            // Write "Invalid option."
            // Return to calling (previous) method
            // return;

            // Create found variable to hold list of found appliances.

            List<Appliance> found = new List<Appliance>();

            // Loop through Appliances
            // Check if current appliance is vacuum
            // Down cast current Appliance to Vacuum object
            // Vacuum vacuum = (Vacuum)appliance;
            foreach (Appliance appliance in Appliances)
            {
                if (appliance is Vacuum vacuum) // Proper type check and downcasting
                {
                    if (voltage == 0 || voltage == vacuum.BatteryVoltage)
                    {
                        found.Add(vacuum);
                    }
                }
            }

            // Test grade is "Any" or grade is equal to current vacuum grade and voltage is 0 or voltage is equal to current vacuum voltage
            // Add current appliance in list to found list

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Kitchen"
            // Write "2 - Work site"

            // Write "Enter room type:"

            // Get user input as string and assign to variable

            // Create character variable that holds room type

            // Test input is "0"
            // Assign 'A' to room type variable
            // Test input is "1"
            // Assign 'K' to room type variable
            // Test input is "2"
            // Assign 'W' to room type variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method
            // return;

            // Create variable that holds list of 'found' appliances

            // Loop through Appliances
            // Test current appliance is Microwave
            // Down cast Appliance to Microwave

            // Test room type equals 'A' or microwave room type
            // Add current appliance in list to found list

            // Display found appliances
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            // Write "Possible options:"

            // Write "0 - Any"
            // Write "1 - Quietest"
            // Write "2 - Quieter"
            // Write "3 - Quiet"
            // Write "4 - Moderate"

            // Write "Enter sound rating:"

            // Get user input as string and assign to variable

            // Create variable that holds sound rating

            // Test input is "0"
            // Assign "Any" to sound rating variable
            // Test input is "1"
            // Assign "Qt" to sound rating variable
            // Test input is "2"
            // Assign "Qr" to sound rating variable
            // Test input is "3"
            // Assign "Qu" to sound rating variable
            // Test input is "4"
            // Assign "M" to sound rating variable
            // Otherwise (input is something else)
            // Write "Invalid option."
            // Return to calling method

            // Create variable that holds list of found appliances

            // Loop through Appliances
            // Test if current appliance is dishwasher
            // Down cast current Appliance to Dishwasher

            // Test sound rating is "Any" or equals soundrating for current dishwasher
            // Add current appliance in list to found list

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            // Write "Enter number of items: "
            Console.Write("Enter number of items: ");

            // Get user input as string and assign to variable

            // Convert user input from string to int

            // Create variable to hold list of found appliances

            // Loop through appliances
            // Add current appliance in list to found list

            // Randomize list of found appliances
            // found.Sort(new RandomComparer());

            // Display found appliances (up to max. number inputted)
            // DisplayAppliancesFromList(found, num);
        }
    }
}

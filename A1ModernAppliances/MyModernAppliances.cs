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
            Console.WriteLine ("Enter the item number of an appliance:");
            long itemSelection;
            string? item = Console.ReadLine();
            itemSelection = Convert.ToInt64(item);

            Appliance? foundAppliance = null;

                foreach (Appliance appliance in Appliances)
                {
                    if (itemSelection == appliance.ItemNumber)
                    {
                        foundAppliance = appliance;
                        break;
                    }

                    else
                    {
                        if (itemSelection != appliance.ItemNumber)
                        {
                            foundAppliance = null;
                        }
                    }
                }

                if (foundAppliance == null)
                {
                    Console.WriteLine ("No appliances found with that item number.");
                    return;
                }

                else
                {
                    bool available = foundAppliance.IsAvailable;
                    if (available == true)
                    {
                        foundAppliance.Checkout();
                        Console.WriteLine("Appliance has been checked out.");
                        return;
                    }
                    else if (available == false)
                    {
                        Console.WriteLine ("The appliance isn't available to be checked out.");
                        return;
                    }

                }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine ("Enter the brand to search for:");

            string? brandSearch = Console.ReadLine();

            List<Appliance> found = new List<Appliance>();
            foreach (Appliance appliance in Appliances)
            {
                if (appliance.Brand == brandSearch)
                {
                    found.Add(appliance);
                }
            }

            DisplayAppliancesFromList(found, 0);
            return;
        }

        /// <summary>
        /// Displays Refridgerators
        /// </summary>
        public override void DisplayRefrigerators()
        {
            Console.WriteLine("Possible options:");
            Console.WriteLine("0 - Any");
            Console.WriteLine("2 - Double doors");
            Console.WriteLine("3 - Three doors");
            Console.WriteLine("4 - Four doors");

            Console.WriteLine("Enter number of doors:");
            string? doorChoice = Console.ReadLine();
            int userDoors = Convert.ToInt16(doorChoice);

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                var typeCheck = DetermineApplianceTypeFromItemNumber(appliance.ItemNumber);
                if (typeCheck == ApplianceTypes.Refrigerator)
                {
                    Refrigerator refigerator = (Refrigerator) appliance;
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
            /// Display found appliances
            DisplayAppliancesFromList(found, 0);
            return;
            // DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Displays Vacuums
        /// </summary>
        /// <param name="grade">Grade of vacuum to find (or null for any grade)</param>
        /// <param name="voltage">Vacuum voltage (or 0 for any voltage)</param>
        public override void DisplayVacuums()
        {
            Console.WriteLine("Possible options:");

            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - 18 Volt");
            Console.WriteLine("2 - 24 Volt");

            Console.WriteLine("Enter voltage:");
            int voltageNum = 0;
            string? voltage = Console.ReadLine();

            if (voltage == "0")
            {
                voltageNum = 0;
            }

            if (voltage == "1")
            {
                voltageNum = 18;
            }

            if (voltage == "2")
            {
                voltageNum = 24;
            }

            else
            {
                Console.WriteLine ("Invalid option.");
            }
            
            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                var applianceCheck = DetermineApplianceTypeFromItemNumber(appliance.ItemNumber);
                if (applianceCheck == ApplianceTypes.Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;
                    
                    if (voltageNum == 0)
                    {
                        found.Add(vacuum);
                    }
                    if (voltageNum == vacuum.BatteryVoltage)
                    {
                            found.Add(vacuum);
                    }
                }
            }

            // Display found appliances
            DisplayAppliancesFromList(found, 0);
            return;
        }

        /// <summary>
        /// Displays microwaves
        /// </summary>
        public override void DisplayMicrowaves()
        {
            Console.WriteLine("Possible options:");

            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Kitchen");
            Console.WriteLine("2 - Worksite");

            Console.WriteLine("Enter room type:");
            string? roomInput = Console.ReadLine();
            char roomSelect = 'A';

            if (roomInput == "0")
            {
                roomSelect = 'A';
            }
            if (roomInput == "1")
            {
                roomSelect = 'K';
            }
            if (roomInput == "2")
            {
                roomSelect = 'W';
            }

            else
            {
                Console.WriteLine("Invalid Option");
            }

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                var applianceCheck = DetermineApplianceTypeFromItemNumber(appliance.ItemNumber);
                if (applianceCheck == ApplianceTypes.Microwave)
                {
                    Microwave microwave = (Microwave)appliance;

                    if (roomSelect == 'A')
                    {
                        found.Add(microwave);
                        return;
                    }
                    if (roomSelect == microwave.RoomType)
                    {
                        found.Add(microwave);
                    }
                }
            }

        DisplayAppliancesFromList(found, 0);
        return;
        }

        /// <summary>
        /// Displays dishwashers
        /// </summary>
        public override void DisplayDishwashers()
        {
            Console.WriteLine("Possible options:");

            Console.WriteLine("0 - Any");
            Console.WriteLine("1 - Quietest");
            Console.WriteLine("2 - Quieter");
            Console.WriteLine("3 - Quiet");
            Console.WriteLine("4 - Moderate");

            Console.WriteLine("Enter sound rating");
            string? soundInput = Console.ReadLine();
            string soundChoice = "Any";

            if (soundInput == "0")
            {
                soundChoice = "Any";
            }
            if (soundInput == "1")
            {
                soundChoice = "Qt";
            }
            if (soundInput == "2")
            {
                soundChoice = "Qr";
            }
            if (soundInput == "3")
            {
                soundChoice = "Qu";
            }
            if (soundInput == "4")
            {
                soundChoice = "M";
            }
            else
            {
                Console.WriteLine("Invalid option.");
            }

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                var applianceCheck = DetermineApplianceTypeFromItemNumber(appliance.ItemNumber);
                if (applianceCheck == ApplianceTypes.Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    if (soundChoice == "Any")
                    {
                        found.Add(dishwasher);
                    }
                    if (dishwasher.SoundRating == soundChoice)
                    {
                        found.Add(dishwasher);
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
            return;
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Enter number of items: ");

            string? itemNum = Console.ReadLine();
            int searchCount = Convert.ToInt16(itemNum);

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in Appliances)
            {
                found.Append(appliance);
            }

            found.Sort(new RandomComparer());

            DisplayAppliancesFromList(found, searchCount);
            return;
        }
    }
}
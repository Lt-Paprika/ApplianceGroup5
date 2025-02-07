using ModernAppliances.Entities;
using ModernAppliances.Entities.Abstract;
using ModernAppliances.Helpers;

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
            long itemSelection = 0;

            itemSelection = Convert.ToInt32(Console.ReadLine());

            var foundAppliance = null;
            {
                foreach (Appliance appliance in appliances)
                {
                    if (long itemSelection = appliance.itemNumber)
                    {
                        foundAppliance = appliance;
                        return foundAppliance;
                    }

                    else
                    {
                        if (itemSelection != appliance.itemNumber);
                        foundAppliance = null;
                        return foundAppliance;
                    }
                }

                if (foundAppliance = null)
                {
                    Console.WriteLine ("No appliances found with that item number.")
                }

                else
                {
                    IsAvailable(foundAppliance);
                    if (IsAvailable = true)
                    {
                        Checkout(foundAppliance);
                        Console.WriteLine("Appliance has been checked out.");
                    }
                    else if (IsAvailable = false)
                    {
                        Console.WriteLine ("The appliance isn't available to be checked out.");
                    }

                }
            }
        }

        /// <summary>
        /// Option 2: Finds appliances
        /// </summary>
        public override void Find()
        {
            Console.WriteLine ("Enter the brand to search for:")

            string? brandSearch = Console.ReadLine()

            List<Appliance> found = newList<Appliance>();
            foreach (Appliance appliance in appliances)
            {
                if appliance.Brand = brandSearch;
                found.Append(appliance);
                return found;
            }

            DisplayAppliancesFromList(found, 0);
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

            List<Refridgerator> found = new List<Refridgerator>();

            foreach (Appliance appliance in appliances)
            {
                typeCheck() = DetermineApplianceTypeFromItemNumber(appliance.ItemNumber)
                if (typeCheck = ApplianceTypes.Refridgerator)
                {
                    Refridgerator refridgerator = (Refridgerator) appliance;
                    if (userDoors == 0)
                    {
                        found.Append(refridgerator);
                    }
                    else if (refridgerator.Doors == userDoors)
                    {
                        found.Append(refridgerator);
                    }
                }
                return found;
            }
            /// Display found appliances
            DisplayAppliancesFromList(found, 0);
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

            Console.WriteLine("Enter voltage:")
            int voltageNum;
            string voltageChoice = Console.Readline();

            if (voltageChoice == "0")
            {
                voltageNum = 0;
            }

            elif (voltageChoice == "1")
            {
                voltageNum = 18;
            }

            if (voltageChoice == "2")
            {
                voltageNum = 24;
            }

            else
            {
                Console.WriteLine ("Invalid option.");
            }
            
            List<Vacuum> found = new List<Vacuum>();

            foreach (Appliance vacuum in appliances)
            {
                applianceCheck() = DetermineApplianceTypeFromItemNumber(appliance.itemNumber);
                if (applianceCheck == ApplianceTypes.Vacuum)
                {
                    Vacuum vacuum = (Vacuum)appliance;
                    
                    if ((DisplayVacuums.grade = null) or (DisplayVacuums.grade = vacuum.grade)) and ((voltageNum = 0) or (voltageNum = vacuum.Voltage))
                    {
                        found.Append(vacuum)
                        return found;
                    }
                }
            }

            DisplayAppliancesFromList(found, 0);
            // Display found appliances
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
            char roomSelect;

            if (roomInput == "0")
            {
                roomSelect = 'A';
=            }
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
                return;
            }

            List<Microwave> found = new List<Microwave>();

            foreach (Appliance appliance in appliances)
            {
                applianceCheck() = DetermineApplianceTypeFromItemNumber(appliance.itemNumber);
                if (applianceCheck = ApplianceTypes.Microwave)
                {
                    Microwave microwave = (Microwave)appliance;

                    if (roomSelect == 'A' or (microwave.roomType = roomSelect))
                    {
                        found.Append(microwave)
                        return found;
                    }
                }
            }

        DisplayAppliancesFromList(found, 0);
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
            string soundChoice;

            if (soundInput = "0")
            {
                soundChoice = "Any";
            }
            if (soundInput == "1")
            {
                soundChoice = "Qt";
                return soundChoice;
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
                return;
            }

            List<Dishwasher> found = new List<Dishwasher>

            foreach (Appliance appliance in appliances)
            {
                applianceCheck() = DetermineApplianceTypeFromItemNumber(appliance.itemNumber);
                if (applianceCheck = ApplianceTypes.Dishwasher)
                {
                    Dishwasher dishwasher = (Dishwasher)appliance;

                    if (soundChoice == "Any")
                    {
                        found.Append(dishwasher);
                        return;
                    }
                    if (dishwasher.soundRating == soundchoice)
                    {
                        found.Append(dishwasher);
                        return;
                    }
                }
            }


            DisplayAppliancesFromList(found, 0);
        }

        /// <summary>
        /// Generates random list of appliances
        /// </summary>
        public override void RandomList()
        {
            Console.WriteLine("Enter number of items: ");

            string itemNum = Console.ReadLine();
            int searchCount = Convert.ToInt16(itemNum);

            List<Appliance> found = new List<Appliance>();

            foreach (Appliance appliance in appliances)
            {
                found.Append(appliance);
            }

            found.Sort(new RandomComparer());

            DisplayAppliancesFromList(found, searchCount);
        }
    }
}

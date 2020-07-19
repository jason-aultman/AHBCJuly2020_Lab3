using System;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.Clear();
            Console.WriteLine("Please enter your name: ");
            var personName = Console.ReadLine();
            var personNameStandardized = FormatNameToStandard(personName); //proof of concept
            System.Console.Clear();
            Console.WriteLine($"Hello, {personNameStandardized}");
            Console.WriteLine();

            var again = false;
            do
            {
                AnalyzeInteger(SelectNumber(personNameStandardized));
                again = DoAgain(personNameStandardized);
            } while (again);
        }

        private static bool DoAgain(string personsName)
        {
            Console.WriteLine($"{personsName}, Would you like to go again? y to continue, anything else to end");
            var validInput = true;
            do
            {
                var doAgain = Console.ReadLine();
                validInput = char.TryParse(doAgain, out char doAgainAsChar);
                if (validInput && (char.Parse(doAgainAsChar.ToString().ToLower()) == 'y'))
                {
                    return true;
                }
                else return false;
            } while (!validInput);
        }

        private static string FormatNameToStandard(string personName)
        {
            char firstLetter = personName[0];
            var firstLetterCapitalized = firstLetter.ToString().ToUpper();
            personName = personName.Remove(0, 1);
            var personNameAsStandard = personName.Insert(0, firstLetterCapitalized.ToString());
            return personNameAsStandard;
        }
        private static int SelectNumber(string nameOfPerson)
        {
            bool selectedNumber = false;
            do
            {
                System.Console.Clear();
                Console.WriteLine($"{nameOfPerson}, I would like you to enter an integer between 1 and 100: ");
                
                selectedNumber = int.TryParse(Console.ReadLine(), out int selectedNumberAsInt);
                if (!selectedNumber)
                {
                    Console.WriteLine($"Im sorry {nameOfPerson}, you must enter a valid integer.  Try again!  Press <Enter> key to continue.");
                    Console.ReadLine();
                }                 
                else if (selectedNumber && (selectedNumberAsInt >= 1) && (selectedNumberAsInt <= 100))
                {
                    Console.WriteLine($"Good job {nameOfPerson}, Your input is valid");
                    return selectedNumberAsInt;
                }
                else
                {
                    Console.WriteLine($"{nameOfPerson}, your input was outside the required parameters, try again. Press <Enter> key to continue.....");
                    Console.ReadLine();
                    selectedNumber = false;

                }
            } while (!selectedNumber);
            return 0;
        }
        private static void AnalyzeInteger(int inputAsInteger)
        {
            //If the integer entered is odd, print the number entered and “Odd.”

            if (inputAsInteger%2!=0)
            {
                Console.WriteLine($"{inputAsInteger},  Odd.");
            }
            //If the integer entered is even and in the inclusive range of 2 to 25, print “Even
            //and less than 25.”
            if(inputAsInteger%2==0&&(inputAsInteger>=2 && inputAsInteger<=25))
            {
                Console.WriteLine("Even and less than 25");
            }
            //If the integer entered is even and in the inclusive range of 26 to 60,
            //print “Even.”
            else if (inputAsInteger%2==0 && (inputAsInteger>=26 && inputAsInteger<=60))
            {
                Console.WriteLine("Even.");
            }
            //If the integer entered is even and greater than 60, print the number entered
            //and “Even.”
            else if (inputAsInteger%2==0 && inputAsInteger>60)
            {
                Console.WriteLine($"{inputAsInteger}, Even");
            }
            //If the integer entered is odd and greater than 60, print the number entered
            //and “Odd.”
            //Redundancy....
        }
    }
}

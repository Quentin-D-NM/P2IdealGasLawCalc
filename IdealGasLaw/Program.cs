using System;
using System.IO;

namespace IdealGasLaw
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] gasNames = new string[85];
            double[] molecularWeights = new double[85];
            int count;
            string answer = "y";

            GetMolecularWeights(ref gasNames, ref molecularWeights, out count);
            DisplayGasNames(gasNames, count);

            do
            {
                //variables for calculation
                string gasName;
                IdealGas gas = new IdealGas();

                Console.WriteLine("What gas would you like to calculate the pressure for? ");
                gasName = Console.ReadLine();

                gas.SetMolecularWeight(GetMolecularWeightFromName(gasName, gasNames, molecularWeights, count));

                if (gas.GetMolecularWeight() != -1)
                {

                   

                    //ask user for all needed variables and converts them to doubles with Conver.ToDouble() method
                    Console.WriteLine("Please enter the volume of {0} in cubic meters: ", gasName);
                    gas.SetVolume(Convert.ToDouble(Console.ReadLine()));
                    Console.WriteLine("Please enter the mass of {0} in grams: ", gasName);
                    gas.SetMass(Convert.ToDouble(Console.ReadLine()));
                    Console.WriteLine("Please enter the tmperature of {0} in Celcius: ", gasName);
                    gas.SetTemp(Convert.ToDouble(Console.ReadLine()));

                    ////Call pressure to get pressure in pascals
                    //pressurePascal = Pressure(gasMassGrams, gasVolume, temperature, molecularWeight);

                    ////display pressure in pascals and psi to the user
                    //DisplayPressure(pressurePascal);
                    DisplayPressure(gas.GetPressure());
                }
                else
                {
                    //if the molecularWeight is -1 then the gas was not found
                    Console.WriteLine("Your gas was not found in the list.");
                }

                Console.WriteLine("Would you like to calculate the pressure of another gas? ('y' or 'n') ");
                answer = Console.ReadLine();

            } while (answer == "y" || answer == "Y");
        }

        static void GetMolecularWeights(ref string[] gasNames, ref double[] molecularWeights, out int count)
        {
            count = 0;
            string[] lines = File.ReadAllLines("MolecularWeightsGasesAndVapors.csv");
            for (int i = 0; i < lines.Length; ++i) //runs through all of the lines in the csv file
            {
                if (i != 0)
                {
                    //splits the each line on a ',' and assigns the correct values in the gasNames array, and molecularWeight array
                    string[] gasWeight = lines[i].Split(",");
                    gasNames[count] = gasWeight[0];
                    molecularWeights[count] = Convert.ToDouble(gasWeight[1]);
                    Console.WriteLine(gasNames[i] + molecularWeights[i]);
                    count++;
                }
            }

        }

        private static void DisplayGasNames(string[] gasNames, int countGases)
        {
            for (int i = 0; i < countGases; i += 3) //This would not work if the MolecularWeights File was increase in size
            {
                Console.WriteLine(String.Format("{0, -20} {1, -20} {2, -20}", gasNames[i], gasNames[i + 1], gasNames[i + 2])); //Formats three gasses per line on the console
            }
        }

        private static double GetMolecularWeightFromName(string gasName, string[] gasNames, double[] molecularWeights, int countGases)
        {
            int index = Array.IndexOf(gasNames, gasName); //identify the index of the gas being searched for
            return molecularWeights[index];//return the molecularWeight of that index
        }

        private static void DisplayPressure(double pressure)
        {
            Console.WriteLine("Pascals:" + pressure);//Little bit of formating to make it look nice
            Console.WriteLine("PSI: " + PaToPSI(pressure));
        }

        static double PaToPSI(double pascals)
        {
            return (pascals / 6895); //from what I saw online this is how you convert pascals to psi
        }
    }
}

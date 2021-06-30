using System;
using System.Collections.Generic;
using System.Text;

namespace IdealGasLaw
{
    class IdealGas
    {
        private double mass;
        private double volume;
        private double temp;
        private double molecularWeight;
        private double pressure;

        public double GetTemp()
        {
            return temp;
        }

        public void SetTemp(double value)
        {
            temp = value;
            Calc();
        }

        public double GetVolume()
        {
            return volume;
        }

        public void SetVolume(double value)
        {
            volume = value;
            Calc();
        }

        public double GetMass()
        {
            return mass;
        }

        public void SetMass(double value)
        {
            mass = value;
            Calc();
        }

        public double GetMolecularWeight()
        {
            return molecularWeight;
        }

        public void SetMolecularWeight(double value)
        {
            molecularWeight = value;
            Calc();
        }

        public double GetPressure()
        {
            return pressure;
        }

        private void Calc()
        {
            //vars needed to calc pressure in pascal
            double t = CelsiusToKelvin(temp);
            double n = NumberOfMoles(mass, molecularWeight);
            double pressurePascal;

            pressurePascal = (n * 8.3145 * t) / volume;

            pressure = pressurePascal;
        }

        static double NumberOfMoles(double mass, double molecularWeight)
        {
            return mass / molecularWeight;
        }

        static double CelsiusToKelvin(double celcius)
        {
            return celcius + 273.15;
        }
    }
}

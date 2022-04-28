using System;
using Microwave.Classes.Interfaces;

namespace Microwave.Classes.Boundary
{
    public class PowerTube : IPowerTube
    {
        public int wattPower { get;  set; }

        private IOutput myOutput;

        private bool IsOn = false;

        public PowerTube(IOutput output, int watt)
        {
            myOutput = output;
            this.wattPower = watt;  
        }

        public void TurnOn(int power)
        {
            if (power < 1 || this.wattPower < power)
            {
                throw new ArgumentOutOfRangeException("power", power, ("Must be between 1 and " + this.wattPower));
            }

            if (IsOn)
            {
                throw new ApplicationException("PowerTube.TurnOn: is already on");
            }

            myOutput.OutputLine($"PowerTube works with {power}");
            IsOn = true;
        }

        public void TurnOff()
        {
            if (IsOn)
            {
                myOutput.OutputLine($"PowerTube turned off");
            }

            IsOn = false;
        }
    }
}
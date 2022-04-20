using Microwave.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microwave.Classes.Boundary
{
    internal class Buzzer: IBuzzer
    {
        private IOutput _output;

        private bool IsPlaying = false;

        public Buzzer(IOutput output)
        {
            _output = output;
        }

        public void PlaySound()
        {
            if(!IsPlaying)
            {
                _output.OutputLine("");
            }
        }
    }
}

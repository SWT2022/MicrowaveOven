using Microwave.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microwave.Classes.Boundary
{
    public class Buzzer: IBuzzer
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
                for (int i = 0; i < 2; i++)
                {
                    _output.OutputLine("Beep");
                    IsPlaying = true;
                }

            }

            IsPlaying = false;
        }
    }
}

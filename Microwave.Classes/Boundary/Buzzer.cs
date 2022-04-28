using Microwave.Classes.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microwave.Classes.Boundary
{
    public class Buzzer : IBuzzer
    {
        private IOutput _output;

        public bool IsPlaying { get; private set; } = false;

        public Buzzer(IOutput output)
        {
            _output = output;
        }

        public void PlaySound()
        {
            if(!IsPlaying)
            {
                IsPlaying = true;

                for (int i = 0; i < 3; i++)
                {
                    _output.OutputLine("Beep");
                    
                }

            }

            IsPlaying = false;
        }

    }
}

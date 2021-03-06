using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microwave.Classes.Interfaces
{
    public interface ICookController
    {
        int GetWattPower();
        void StartCooking(int power, int time);
        void Stop();
        void AddTime(object sender, EventArgs e);
        void SubstractTime(object sender, EventArgs e);
    }
}

﻿using System;
using Microwave.Classes.Boundary;
using Microwave.Classes.Controllers;

namespace Microwave.App
{
    class Program
    {
        static void Main(string[] args) 
        {
            Button startCancelButton = new Button();
            Button powerButton = new Button();
            Button timeButton = new Button();

            Door door = new Door();

            Output output = new Output();

            Buzzer buzzer = new Buzzer(output);

            Display display = new Display(output);

            PowerTube powerTube = new PowerTube(output);

            Light light = new Light(output);

            Buzzer buzzer = new Buzzer(output);

            Microwave.Classes.Boundary.Timer timer = new Timer();

            CookController cooker = new CookController(timer, display, powerTube);
            cooker.GetWattPower();

            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, display, light, cooker, buzzer);
            UserInterface ui = new UserInterface(powerButton, timeButton, startCancelButton, door, buzzer, display, light, cooker);
            ui.GetWattPower();


            // Finish the double association
            cooker.UI = ui;

           

            // Simulate a simple sequence

            powerButton.Press();

            timeButton.Press();

            startCancelButton.Press();

            // The simple sequence should now run
            System.Console.WriteLine("Add 5 seconds by pressing '+'");

            System.Console.WriteLine("Substract 5 seconds by pressing '-'");

            System.Console.WriteLine("When you press 'c', the program will stop");
            // Wait for input

            System.Console.ReadLine();

            while (true)
            {
                switch (Console.ReadKey(true).KeyChar)
                {
                    case '+':
                        timer.ChangeTime("+");
                        break;
                    case '-':
                        timer.ChangeTime("-");
                        break;
                    case 'c':
                        Environment.Exit(0);
                        break;
                }
            }

        }
    }
}

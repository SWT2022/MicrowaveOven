using Microwave.Classes.Boundary;
using NUnit.Framework;
using Microwave.Classes.Interfaces;
using NSubstitute;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class BuzzerTest
    {
        private IBuzzer uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();

            uut = new Buzzer(output);
        }

        [Test]
        public void SoundIsPlayingExactlyThreeTimes()
        {
            // We don't need an assert, as an exception would fail the test case
            uut.PlaySound();

            output.Received(3).OutputLine(Arg.Is<string>(str => str.Contains("Beep")));
        }

        //[Test]
        //public void Press_1subscriber_IsNotified()
        //{
        //    bool notified = false;

        //    uut.Pressed += (sender, args) => notified = true;
        //    uut.Press();
        //    Assert.That(notified, Is.EqualTo(true));
        //}
    }
}

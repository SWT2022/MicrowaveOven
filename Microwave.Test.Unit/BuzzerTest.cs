using Microwave.Classes.Boundary;
using NUnit.Framework;
using Microwave.Classes.Interfaces;
using NSubstitute;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class BuzzerTest
    {
        private Buzzer uut;
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

        [Test]
        public void SoundIsPlayingExactlySixTimes()
        {
            // We don't need an assert, as an exception would fail the test case
            uut.PlaySound();

            uut.PlaySound();

            output.Received(6).OutputLine(Arg.Is<string>(str => str.Contains("Beep")));
        }


        [Test]
        public void InitialStateIsFalse()
        {

            Assert.That(uut.IsPlaying == false);
        }

        [Test]
        public void WhilePlayingStateIsTrue()
        {
            uut.PlaySound();
            Assert.That(uut.IsPlaying == false);
        }


    }
}
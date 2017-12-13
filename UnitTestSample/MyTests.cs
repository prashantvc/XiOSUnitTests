using System;
using System.Threading.Tasks;
using Foundation;
using NUnit.Framework;

namespace UnitTestSample
{
    [TestFixture]
    [Preserve(AllMembers = true)]
    public class Test
    {

        bool fixture_setup = false;

        [TestFixtureSetUp]
        public void Setup()
        {
            fixture_setup = true;
        }

        [TestFixtureTearDown]
        public void Teardown()
        {
            fixture_setup = false;
        }

        [Test]
        public void TestFixtureSetUpCalled()
        {
            Assert.True(fixture_setup);
        }

        [Test]
        public void Ok()
        {
            Assert.Null(null);
            Assert.True(true);
            Assert.False(false);
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void ExpectedExceptionException()
        {
            string s = null;
            Assert.That(s.Length, Is.EqualTo(0), "Length");
        }

        [Test]
        [Ignore("don't even execute this one")]
        public void IgnoredByAttribute()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void IgnoreInCode()
        {
            Assert.Ignore("let's forget about this one");
            throw new NotImplementedException();
        }

        [Test]
        public void InconclusiveInCode()
        {
            Assert.Inconclusive("it did not mean anything");
            throw new NotImplementedException();
        }

        [Test]
        public void FailInCode()
        {
            Assert.Fail("that won't do it");
            throw new NotImplementedException();
        }

        [Test]
        public void PassInCode()
        {
            Assert.Pass("good enough");
            throw new NotImplementedException();
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void IgnoredExpectedException()
        {
            Assert.Ignore("ignore [ExpectedException]");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void InconclusiveExpectedException()
        {
            Assert.Inconclusive("inconclusive [ExpectedException]");
        }

        [Test]
        [ExpectedException(typeof(NullReferenceException))]
        public void PassExpectedException()
        {
            Assert.Pass("pass [ExpectedException]");
        }

        Task GetException()
        {
            throw new Exception();
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public async void AsyncException()
        {
            await GetException();
        }

        [Test]
        [Timeout(Int32.MaxValue)]
        public async Task NestedAsync()
        {
            await Task.Run(async () => {
                await Task.Delay(1000);
            });
            Assert.Pass("Delayed");
        }
    }
}

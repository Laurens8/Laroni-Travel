using dal.Data.UnitOfWork;
using FakeItEasy;
using Laroni_Travel.Data;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Laroni_Travel_Tests.ViewModels
{
    [TestFixture]
    public class InlogViewModelTests
    {
        private IUnitOfWork _unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void EmailIsValid()
        {
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$");
            string email = "emma@email.com";

            Assert.IsTrue(regex.IsMatch(email));
        }

        [Test]
        public void ValidatePassword()
        {
            string wachtwoord = "Azerty@123";
            Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            Assert.True(regex.IsMatch(wachtwoord));
        }
    }
}
using dal.Data.UnitOfWork;
using FakeItEasy;
using Laroni_Travel.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel_Tests.ViewModels
{
    public class PersoonViewModelTests
    {
        private IUnitOfWork _unitOfWork = A.Fake<IUnitOfWork>();

        [Test]
        public void GetDeelnemerById()
        {
            //Arrange
            Deelnemer deelnemer = A.Fake<Deelnemer>();

            //Act
            deelnemer = _unitOfWork.DeelnemersRepo.ZoekOpPK(deelnemer.DeelnemerId);

            //Assert
            Assert.NotNull(deelnemer);
            Assert.IsInstanceOf<Deelnemer>(deelnemer);

            A.CallTo(() => _unitOfWork.DeelnemersRepo.ZoekOpPK(deelnemer.DeelnemerId)).MustHaveHappened();
        }

        [Test]
        public void OphalenCollectieMedischeRecordsViaDeelnemerId()
        {
            Deelnemer deelnemer = A.Fake<Deelnemer>();
            deelnemer.DeelnemerId = 1;
            Assert.NotNull(deelnemer);
            //Arrange
            ObservableCollection<Medisch> MedischeRecords;

            //Act
            MedischeRecords = new ObservableCollection<Medisch>(_unitOfWork.MedischeRepo.Ophalen(x => x.DeelnemerId == deelnemer.DeelnemerId));

            //Assert
            Assert.NotNull(MedischeRecords);
            Assert.IsInstanceOf<ObservableCollection<Medisch>>(MedischeRecords);
        }
    }
}
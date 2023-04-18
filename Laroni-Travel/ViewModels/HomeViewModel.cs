using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.ViewModels
{
    public class HomeViewModel : BaseViewmodel, IDisposable
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laronu_TravelContext());

        public override string this[string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

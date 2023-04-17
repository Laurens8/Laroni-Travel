using dal.Data.Repository;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region attributen

        public IRepository<Bestemming> _bestemmingenRepo;
        public IRepository<Deelnemer> _deelnemersRepo;
        public IRepository<DeelnemerGroepsreis> _deelnemerGroepsreisenRepo;
        public IRepository<DeelnemerOpleiding> _deelnemerOpleidingenRepo;
        public IRepository<Groepsreis> _groepsreisenRepo;
        public IRepository<LeeftijdsCategorie> _leeftijdsCategorieenRepo;
        public IRepository<Medisch> _medischeRepo;
        public IRepository<Opleiding> _opleidingenRepo;
        public IRepository<OpleidingBestemming> _opleidingBestemmingenRepo;
        public IRepository<Rol> _rolenRepo;
        public IRepository<Thema> _themasRepo;

        #endregion attributen

        public UnitOfWork(Laronu_TravelContext ctx)
        {
            Context = ctx;
        }

        private Laronu_TravelContext Context { get; }

        #region repositories

        public IRepository<Bestemming> BestemmingenRepo
        {
            get
            {
                if (_bestemmingenRepo == null)
                {
                    _bestemmingenRepo = new Repository<Bestemming>(Context);
                }
                return _bestemmingenRepo;
            }
        }

        public IRepository<Deelnemer> DeelnemersRepo
        {
            get
            {
                if (_deelnemersRepo == null)
                {
                    _deelnemersRepo = new Repository<Deelnemer>(Context);
                }
                return _deelnemersRepo;
            }
        }

        public IRepository<DeelnemerGroepsreis> DeelnemerGroepsreisenRepo
        {
            get
            {
                if (_deelnemerGroepsreisenRepo == null)
                {
                    _deelnemerGroepsreisenRepo = new Repository<DeelnemerGroepsreis>(Context);
                }
                return _deelnemerGroepsreisenRepo;
            }
        }

        public IRepository<DeelnemerOpleiding> DeelnemerOpleidingenRepo
        {
            get
            {
                if (_deelnemerOpleidingenRepo == null)
                {
                    _deelnemerOpleidingenRepo = new Repository<DeelnemerOpleiding>(Context);
                }
                return _deelnemerOpleidingenRepo;
            }
        }

        public IRepository<Groepsreis> GroepsreisenRepo
        {
            get
            {
                if (_groepsreisenRepo == null)
                {
                    _groepsreisenRepo = new Repository<Groepsreis>(Context);
                }
                return _groepsreisenRepo;
            }
        }

        public IRepository<LeeftijdsCategorie> LeeftijdsCategorieenRepo
        {
            get
            {
                if (_leeftijdsCategorieenRepo == null)
                {
                    _leeftijdsCategorieenRepo = new Repository<LeeftijdsCategorie>(Context);
                }
                return _leeftijdsCategorieenRepo;
            }
        }

        public IRepository<Medisch> MedischeRepo
        {
            get
            {
                if (_medischeRepo == null)
                {
                    _medischeRepo = new Repository<Medisch>(Context);
                }
                return _medischeRepo;
            }
        }

        public IRepository<Opleiding> OpleidingenRepo
        {
            get
            {
                if (_opleidingenRepo == null)
                {
                    _opleidingenRepo = new Repository<Opleiding>(Context);
                }
                return _opleidingenRepo;
            }
        }

        public IRepository<OpleidingBestemming> OpleidingBestemmingenRepo
        {
            get
            {
                if (_opleidingBestemmingenRepo == null)
                {
                    _opleidingBestemmingenRepo = new Repository<OpleidingBestemming>(Context);
                }
                return _opleidingBestemmingenRepo;
            }
        }

        public IRepository<Rol> RolenRepo
        {
            get
            {
                if (_rolenRepo == null)
                {
                    _rolenRepo = new Repository<Rol>(Context);
                }
                return _rolenRepo;
            }
        }

        public IRepository<Thema> ThemasRepo
        {
            get
            {
                if (_themasRepo == null)
                {
                    _themasRepo = new Repository<Thema>(Context);
                }
                return _themasRepo;
            }
        }

        #endregion repositories

        public void Dispose()
        {
            Context.Dispose();
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
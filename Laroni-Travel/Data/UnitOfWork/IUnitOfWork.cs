using dal.Data.Repository;
using Laroni_Travel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dal.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Bestemming> BestemmingenRepo { get;}
        IRepository<Deelnemer> DeelnemersRepo { get;}
        IRepository<DeelnemerGroepsreis> DeelnemerGroepsreisenRepo { get; }
        IRepository<DeelnemerOpleiding> DeelnemerOpleidingenRepo { get; }
        IRepository<Groepsreis> GroepsreisenRepo { get; }
        IRepository<LeeftijdsCategorie> LeeftijdsCategorieenRepo { get; }
        IRepository<Medisch> MedischeRepo { get; }
        IRepository<Opleiding> OpleidingenRepo { get; }
        IRepository<OpleidingBestemming> OpleidingBestemmingenRepo { get; }
        IRepository<Rol> RolenRepo { get; }
        IRepository<Thema> ThemasRepo { get; }

        int Save();
    }
}
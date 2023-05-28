using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Medisch : Basisklasse
    {
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Omschrijving" && string.IsNullOrWhiteSpace(Omschrijving))
                {
                    return "Omschrijving moet ingevuld zijn";
                }
                if (columnName == "Medicatie" && string.IsNullOrWhiteSpace(Medicatie))
                {
                    return "Medicatie moet ingevuld zijn";
                }
                if (columnName == "Behandeling" && string.IsNullOrWhiteSpace(Behandeling))
                {
                    return "Behandeling moet ingevuld zijn";
                }
                return "";
            }
        }
    }
}

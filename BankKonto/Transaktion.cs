using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinBankKonto
{
    public  class Transaktion
    {
        public decimal Amount { get;  }

        public DateTime Datum { get;  }

        public string  Anteckning { get;  }

        public Transaktion(decimal amount, DateTime datum, string anteckning)
        {
            Amount = amount;
            Datum = datum;
            Anteckning = anteckning;
        }


    }
}

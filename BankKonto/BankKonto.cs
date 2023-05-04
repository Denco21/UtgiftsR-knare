using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace MinBankKonto
{
    public class BankKonto
    {
        public string Nummer { get;  }
        public string Ägare { get; set; }

        public decimal Balans { 
            
            
            get
            {

                decimal balans = 0;
                foreach (var item in trans) {
                
                balans += item.Amount;
                }
                return balans;
            }
                
                
         }



        private static int kontoNummerSeed = 1234567890;


        public List<Transaktion> trans = new List<Transaktion>();

        public BankKonto(string namn,decimal balans)
        {

           
            Nummer = kontoNummerSeed.ToString();
            kontoNummerSeed++;

            TaIn(balans, DateTime.Now, "Start Saldo");
            Ägare = namn;
           
           
           
        }


        public void TaIn(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be positive");
            }
            var tain = new Transaktion(amount, date, note); // det är en konstruktor som skapar en ny instans av objektet Transaktion 
            trans.Add(tain);
        }

        public void TaUt(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of withdrawal must be positive");
            }
            if (Balans - amount < 0)
            {
                throw new InvalidOperationException("Not sufficient funds for this withdrawal");
            }
            var taut = new Transaktion(-amount, date, note);
            trans.Add(taut);
        }


        //public string GeMigKontoHistorik()
        //{
          

        //    var visa = new StringBuilder(); //StringBuilder är en klass som används för att skapa en sträng som kan ändras utan att skapa en ny strängobjekt. 
        //    visa.AppendLine("Datum\t\t\tBelopp\t\tNoteri");

        //    foreach (var item in trans)
        //    { 
        //        visa.AppendLine($"{item.Datum.ToLocalTime()}\t{item.Amount}\t{item.Anteckning}");

        //    }
          
        //    return visa.ToString();
        //}


    }

 

   
}

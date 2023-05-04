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
                throw new ArgumentOutOfRangeException(nameof(amount), "Depositionsbeloppet måste vara positivt");
            }
            var tain = new Transaktion(amount, date, note); // det är en konstruktor som skapar en ny instans av objektet Transaktion 
            trans.Add(tain);
        }

        public void TaUt(decimal amount, DateTime date, string note)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Beloppet för uttag måste vara positivt");
            }
            if (Balans - amount < 0)
            {
                throw new InvalidOperationException("Inte tillräckliga medel för detta uttag\r\n");
            }
            var taut = new Transaktion(-amount, date, note);
            trans.Add(taut);
        }


    }

 

   
}

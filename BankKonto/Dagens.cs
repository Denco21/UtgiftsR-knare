using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MinBankKonto
{
    public class Dagens
    {

        public static void DagensKöp(BankKonto konto)
        {
            Console.WriteLine("Välkommen till dagens utgifter!");
            string fortsätt = "ja";


            do
            {

                Console.Write("Vad har du köpt idag? ");
                string produkt = Console.ReadLine();

                decimal pris = 0;
                bool validPris = false;

                while (!validPris)
                {
                    Console.Write($"Vad var priset för {produkt} i kr? ");

                    try
                    {
                        pris = Convert.ToDecimal(Console.ReadLine().Replace("kr", ""));
                        validPris = true;
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Ogiltigt belopp, försök igen.");
                    }
                }

                konto.TaUt(pris, DateTime.Now, produkt);

                Console.Write("Vill du lägga till fler köp? (ja/nej) ");
                fortsätt = Console.ReadLine().ToLower();

            } while (fortsätt == "ja");

            Console.Clear();

            decimal totalUttagIdag = konto.trans
                           .Where(t => t.Datum.Date == DateTime.Now.Date && t.Amount < 0)
                           .Sum(t => -t.Amount);
            Console.WriteLine($"Du har spenderat {totalUttagIdag.ToString("C")} idag.");


            VisaTransaktionshistorik(konto.trans);

        }

        public static void VisaTransaktionshistorik(List<Transaktion> trans)
        {
            Console.WriteLine("Transaktionshistorik:");
            Console.WriteLine("Datum\t\t\tBelopp\t\tAnteckning");
            foreach (var transaktion in trans)
            {

                Console.WriteLine($"{transaktion.Datum}\t{transaktion.Amount.ToString("C")}\t{transaktion.Anteckning}");
            }
        }



    }
    }



using MinBankKonto;
using System.Collections.Generic;
using System.Diagnostics;


WälkomenMeddelande.Wälkomen();
BankKonto konto = new BankKonto("Dennis Delija", 30000);
Console.WriteLine($"Ditt konto med nummer {konto.Nummer} med ägare vid namn {konto.Ägare} innehar just nu {konto.Balans.ToString("C")}");
Console.WriteLine($"Ditt saldo på kontot just nu är {konto.Balans} kr");



Dagens.DagensKöp(konto);
Console.WriteLine( "                                                           ");
Console.WriteLine($"Ditt saldo på kontot just nu är {konto.Balans.ToString("C")} ");









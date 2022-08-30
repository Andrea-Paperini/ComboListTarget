using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ComboTarget
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto, questo tool trasformerà una ComboList in una combo target per una email");
            string nomecombo = "combo.txt";
            string percorso = AppDomain.CurrentDomain.BaseDirectory;
            string PercorsoCombo = percorso + nomecombo;
            Console.WriteLine("Percorso combo -> " + PercorsoCombo);
            bool ComboExist = File.Exists(PercorsoCombo);
            if (ComboExist == false)
            {
                Console.WriteLine("ATTENZIONE, NON E' STATO TROVATO IL FILE 'combo.txt'");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            string combo = File.ReadAllText(PercorsoCombo);
            Console.WriteLine("Qual'è l'email desideri inseririre ?");
            string Target = Console.ReadLine();
            while (string.IsNullOrEmpty(Target) || Target.Contains("@") == false)
            {
                if (string.IsNullOrEmpty(Target))
                {
                    Console.WriteLine("L'email non può essere vuota !");
                }
                if (string.IsNullOrEmpty(Target) == false && Target.Contains("@") == false)
                {
                    Console.WriteLine("Formato sbagliato !");
                }
                Target = Console.ReadLine();
            }
            string pattern = @".+?(?=:)";
            string input = combo;
            Regex regex = new Regex(pattern);
            string result = regex.Replace(input, Target);
            File.WriteAllText(percorso + "ComboTarget.txt", result);
            Console.WriteLine(result);
            Console.WriteLine("Terminato");
        }
    }
}

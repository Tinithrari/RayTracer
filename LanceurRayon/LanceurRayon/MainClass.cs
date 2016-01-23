using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanceurRayon
{
    class MainClass
    {
        static void Main(string[] args)
        {
            string[] expression;

            // Contrôle la présence d'un unique argument
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Nombre d'argument insuffisant, attendu: 1");
                System.Environment.Exit(1);
            }

            expression = args[0].Split(',');

            // Contrôle le nombre d'élément contenu dans l'expression mathématiques
            if (expression.Length != 3)
            {
                Console.Error.WriteLine("L'argument entrée n'est pas valide: Doit contenir trois champs séparé par des virgules");
                System.Environment.Exit(1);
            }
        }
    }
}

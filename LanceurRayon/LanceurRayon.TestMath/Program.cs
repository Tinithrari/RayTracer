using System;
using System.Collections.Generic;

using LanceurRayon.Math;
using System.Globalization;

namespace LanceurRayon.TestMath
{
    class Program
    {
        static readonly List<char> OPERANDE = new List<char>() { 'P', 'V', 'C' };

        static readonly List<string> OPERATEURS = new List<string>() { "add", "sub", "mul", "cross", "dot", "times" };

        static Object buildObject(string cpt)
        {
            Object obj;
            string[] arg = cpt.Split(' ');

            try {
                    switch (arg[0][0])
                    {
                        case 'P':
                            obj = new Point(Double.Parse(arg[1], CultureInfo.InvariantCulture), Double.Parse(arg[2], CultureInfo.InvariantCulture), Double.Parse(arg[3], CultureInfo.InvariantCulture));
                            break;

                        case 'V':
                            obj = new Vec3(Double.Parse(arg[1], CultureInfo.InvariantCulture), Double.Parse(arg[2], CultureInfo.InvariantCulture), Double.Parse(arg[3], CultureInfo.InvariantCulture));
                            break;

                        case 'C':
                            obj = new Color(Double.Parse(arg[1], CultureInfo.InvariantCulture), Double.Parse(arg[2], CultureInfo.InvariantCulture), Double.Parse(arg[3], CultureInfo.InvariantCulture));
                            break;
                        default:
                            obj = Double.Parse(cpt, CultureInfo.InvariantCulture);
                        break;
                    }
                    return obj;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        static bool isOperation(string op)
        {
            return OPERATEURS.Contains(op);
        }

        static bool isComponent(string cpnt)
        {
            return OPERANDE.Contains(cpnt[0]);
        }

        static void Main(string[] args)
        {
            string[] expr;
            string op, cmp1;

            // Contrôle la présence d'un unique argument
            if (args.Length != 1)
            {
                Console.Error.WriteLine("Nombre d'argument insuffisant, attendu: 1");
                System.Environment.Exit(1);
            }

            expr = args[0].Split(',');

            // Contrôle le nombre d'élément contenu dans l'expression mathématiques
            if (expr.Length != 3)
            {
                Console.Error.WriteLine("L'argument entrée n'est pas valide: Doit contenir trois champs séparé par des virgules");
                System.Environment.Exit(1);
            }

            cmp1 = expr[0];
            op = expr[1];

            // Vérification de la synthaxe des éléments
            if (! isComponent(cmp1) || ! isOperation(op))
            {
                Console.Error.WriteLine("Erreur de synthaxe, usage : Opérande,Opérateur,Opérande");
                System.Environment.Exit(2);
            }

            // On construit les objets et on affiche "Interdit" en cas d'erreurs
            // Sinon, la chaine corrspondant à l'objet
            try
            {
                Object o1 = buildObject(expr[0]);
                Object o2 = buildObject(expr[2]);

                Object res;

                try {
                    res = o1.GetType().GetMethod(expr[1]).Invoke(o1, new Object[1] { o2 });
                }
                catch (Exception)
                {
                    res = o2.GetType().GetMethod(expr[1]).Invoke(o2, new Object[1] { o1 });
                }
                if (res.GetType().Equals(typeof(Double)))
                    res = ((Double)res).ToString("0.0#", CultureInfo.InvariantCulture);
                Console.WriteLine(res);
                Console.ReadKey();
            }
            catch (Exception)
            {
                Console.WriteLine("Interdit");
                Console.ReadKey();
            }
        }
    }
}

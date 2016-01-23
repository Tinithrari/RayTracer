﻿using System;
using System.Collections.Generic;

using LanceurRayon.Math;

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

            if (arg.Length != 4 || ! isComponent(arg[0]))
                throw new ArgumentException();

            try {
                    switch (arg[0][0])
                    {
                        case 'P':
                            obj = new Point(Double.Parse(arg[1]), Double.Parse(arg[2]), Double.Parse(arg[3]));
                            break;

                        case 'V':
                            obj = new Vec3(Double.Parse(arg[1]), Double.Parse(arg[2]), Double.Parse(arg[3]));
                            break;

                        case 'C':
                            obj = new Color(Double.Parse(arg[1]), Double.Parse(arg[2]), Double.Parse(arg[3]));
                            break;
                    default:
                        throw new ArgumentException();
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
            string op, cmp1, cmp2;

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
            cmp2 = expr[2];

            // Vérification de la synthaxe des éléments
            if (! isComponent(cmp1) || ! isOperation(op) || ! isComponent(cmp2))
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

                Object res = o1.GetType().GetMethod(expr[1]).Invoke(o1, new Object[1] { o2 });

                Console.WriteLine(res);
            }
            catch (Exception e)
            {
                Console.WriteLine("Interdit");
            }
        }
    }
}
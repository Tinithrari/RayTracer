﻿using System;
using System.IO;

namespace LanceurRayon.Renderer
{
    class Program
    {
        static void Main(string[] args)
        {

            ReadFile reader = new ReadFile();
            Scene infos_scene;

            if (args.Length != 1)
            {
                Console.Error.WriteLine("Le lecteur de fichier de scène attend un fichier exactement !!");
                System.Environment.Exit(1);
            }

            try
            {
                infos_scene = reader.Analyze(args[0]);
                Console.WriteLine(infos_scene);
            }

            catch (IOException e)
            {

                Console.WriteLine("Le fichier de sortie n'à pas pu être enregistré !!!");
                Console.Error.WriteLine(e.Message);
                System.Environment.Exit(1);
            }
            catch (ArgumentException f)
            {
                Console.WriteLine(f.Message);
                System.Environment.Exit(1);
            }
            catch (FormatException)
            {
                Console.WriteLine("Un ou plusieurs arguments ne sont pas des nombres !!!");
                System.Environment.Exit(1);
            }
        }
    }
}


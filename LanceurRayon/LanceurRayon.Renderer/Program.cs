using System;
using System.IO;

namespace LanceurRayon.Renderer
{
    class Program
    {
        static void Main(string[] args){

            ReadFile reader=new ReadFile();
            Scene infos_scene = new Scene();

            if (args.Length != 1)
            {
                Console.Error.WriteLine("Le lecteur de fichier de scène attend un fichier exactement !!");
                System.Environment.Exit(1);
            }

            try
            {
              infos_scene= reader.Analyze(args[0]);
            }
            catch (FileNotFoundException e)
            {
                Console.Error.WriteLine(e.Message);
                System.Environment.Exit(1);
            }





        }
    }
}

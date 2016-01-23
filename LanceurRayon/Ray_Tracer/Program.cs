using System;
using System.IO;

namespace LanceurRayon.Comparateur

{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
		if(args.Length !=2){
			Console.Error.WriteLine("Le comparateur attend deux fichiers exactement !!");
			System.Environment.Exit(1);
		}

		try {
			ImgUtility.ImgComparator (args[0], args[1]);
		}
		catch (FileNotFoundException e)
		{
			Console.Error.WriteLine(e.Message);
			System.Environment.Exit(1);
		}

		

	}
}
}

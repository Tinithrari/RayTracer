using System;
namespace Ray_Tracer

{
	class MainClass
	{
		public static void Main (string[] args)
		{
			
		if(args.Length !=2){
			Console.WriteLine("Le comparateur attend deux fichiers exactement !!");
			return;
		}

		ImgUtility.ImgComparator (args[0],args[1]);

		

	}
}
}

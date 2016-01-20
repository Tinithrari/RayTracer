using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Ray_Tracer
{
	public class ImgUtility
	{

		/// <summary>

		/// Permet de comparer deux image pixels par pixels

		/// </summary>
			
		/// <param name="f1">Le nom de fichier de l'image numéro 1</param>
				
		/// <param name="f2">Le nom de fichier de l'image numéro 2</param>


		public static void  ImgComparator(String f1,String f2)
		{
		
		
			int  x,y,nb_pixels_diff=0;

			Color couleur_img1, couleur_img2,couleur_pixel_courant;

		    Bitmap img1,img2;
		   
			//On s'assure que les fichiers passés en paramètre existent.
			try{
				img1 = new Bitmap (Image.FromFile(f1));
				img2 = new Bitmap (Image.FromFile(f2));
				}

			catch(FileNotFoundException e){
				throw new FileNotFoundException ("Le fichier à l'emplacement " + e.Message + " est manquant!!!!");
			}



			Bitmap img_diff = new Bitmap (img1.Size.Width,img1.Size.Height);

			//On s'assure que les images ont la même dimension.
			if(img1.Size != img2.Size) {
				Console.WriteLine("Les images doivent être de taille identiques !!!");
				return ;
			}

			for(y=0;y<img1.Size.Height;y++){
				for(x=0;x<img1.Size.Width;x++){

					//On récupère les couleurs des images.
					couleur_img1 =img1.GetPixel(x,y);
					couleur_img2 =img2.GetPixel(x,y);

					//On effectue la différence des deux couleurs.
					img_diff.SetPixel(x,y, Color.FromArgb( 
					                                      Math.Abs(couleur_img1.R-couleur_img2.R),
					                                      Math.Abs(couleur_img1.G-couleur_img2.G),
					                                      Math.Abs(couleur_img1.B-couleur_img2.B)
					                                      )
					                  );


					couleur_pixel_courant = img_diff.GetPixel (x, y);

					//On vérfie si le pixel obtenu n'est pas noir signe que la couleur des deux images est différente.
					if ( couleur_pixel_courant.A != 255 ||couleur_pixel_courant.R !=0   ||couleur_pixel_courant.G != 0  || couleur_pixel_courant.B != 0   )
						nb_pixels_diff++;
					
				}
			}

			//On sauvegarde l'image différentielle.
			img_diff.Save("diff.png",ImageFormat.Png);


			if(nb_pixels_diff>=1000)
				Console.WriteLine("KO");

			else
				Console.WriteLine("OK");


			Console.WriteLine(nb_pixels_diff);


			return ;
		
		
		}
	}
}


/*
 Roberto G. Rovetto Lluberes
 https://do.linkedin.com/in/robertlluberes
 Structure of a BMP File: http://www.ue.eti.pg.gda.pl/fpgalab/zadania.spartan3/zad_vga_struktura_pliku_bmp_en.html
 */

using System;
using System.IO;


namespace BMP_File_Info_Reader
{
    class Program
    {
        static void Main(string[] args)
        {

            //Variables
            var path = ValidateAndSetPath();
            var width = 0;
            var heigth = 0;
            var bitsPerPixel = 0;
            BinaryReader bmpFile; //BMP File in binary


            bmpFile = new BinaryReader(File.OpenRead(path)); //Lee la ruta como un archivo binario | Reads the path as a binary file

            bmpFile.BaseStream.Seek(18, SeekOrigin.Begin); //Posiciona la "cadena" de bytes en el bit indicado | Set the position in the current stream.

            width = bmpFile.ReadInt32(); //Guarda 4 bytes, correspondiente al ancho de la imagen | Save 4 bytes, of the width of the image
            heigth = bmpFile.ReadInt32();//Guarda 4 bytes, correspondiente al alto de la imagen | Save 4 bytes, of the heigth of the image

            bmpFile.BaseStream.Seek(2, SeekOrigin.Current); //Posiciona la "cadena" de bytes en el bit indicado desde la posicion actual | Set the position in the current stream from the current position

            bitsPerPixel = bmpFile.ReadInt16(); //Guarda 2 bytes correspondientes a los bits por pixeles de la imagen | Save 2 bytes for the Bits por pixels of the imagen 

            Console.WriteLine($"\nAncho | Width: {width}\nAlto | Heigth: {heigth}\nBits por Pixel | Bits per Pixel: {bitsPerPixel} bits");


            bmpFile.Close(); //Cierra el archivo en uso | Close the file


            Console.ReadKey();

        }

        static string ValidateAndSetPath()
        {

            Console.WriteLine("Introduzca la ruta del archivo BMP | Enter the path of the BMP file:");

            var localPath = Console.ReadLine(); //Guarda la ruta introducida | Save the path entered

            //Valida que la ruta y la extension del archivo sean correctas
            //Validate that the path and extension of the file  is correct
            while ((!localPath.Contains(".bmp") && !localPath.Contains(".BMP")) || !File.Exists(localPath))
            {
                Console.WriteLine("\nES: Asegurese de que escribió la ruta y la extension (.bmp) correctamente\nEN: Be sure that the path and extension (.bmp) are correct");

                localPath = Console.ReadLine();
            }

            return localPath;
        }
    }
}

using System;
using tessnet2;
using System.Drawing;  
using System.Drawing.Drawing2D;  
using System.Drawing.Imaging;  

namespace myOcr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learn My OCR");
        }

        private void DoOcr()
        {
            // now add the following C# line in the code page  
            var image = new Bitmap(@"C:\NewProject\demo\image.bmp");  
            var ocr = new Tesseract();  
            ocr.Init(@"Z:\NewProject\How to use Tessnet2 library\C#\tessdata", "eng", false);
            var result = ocr.DoOCR(image, Rectangle.Empty);  
            foreach(tessnet2.Word word in result)  
            {  
                Console.WriteLine(word.text);  
            }
        }
    }    
}

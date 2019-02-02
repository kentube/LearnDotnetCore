using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace learnOcr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Learn OCR!");

            //var testImagePath = "./phototest.tif";
            //var testImagePath = "./learnocr.png";
            var testImagePath = "./learnocr2.png";
            if (args.Length > 0)
            {
                testImagePath = args[0];
            }

            try
            {
                using (var engine = new TesseractEngine(@"./tessdata", "eng", EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(testImagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            var text = page.GetText();
                            Console.WriteLine("Mean confidence: {0}", page.GetMeanConfidence());
                            Console.WriteLine("Text (GetText): \r\n{0}", text);

                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected Error: " + e.Message);
                Console.WriteLine("Details: ");
                Console.WriteLine(e.ToString());
            }
            Console.Write("Press any key to continue . . . ");
            Console.ReadKey(true);

        }
    }
}

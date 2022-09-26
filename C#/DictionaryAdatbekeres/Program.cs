using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyakorlasCsharpKonzol0926
{
    class Program
    {
        static void Main(string[] args)
        {
           

            Dictionary<string, string> felhAdatok = new Dictionary<string, string>();
            List<Dictionary<string, string>> felhLista = new List<Dictionary<string, string>>();
            while (true)
            {
                Adatbekeres("Felhasználónév", felhAdatok);
                Adatbekeres("Születési év", felhAdatok);
                Adatbekeres("Város", felhAdatok);
                Adatbekeres("Email", felhAdatok);
                felhLista.Add(felhAdatok);
                
                Console.WriteLine("Szeretne új adatot? (igen/nem)");
                string ujra = Console.ReadLine();
                if (ujra == "nem")
                {
                    Console.WriteLine("Oké. Ez lett a végleges lista:");
                    Kiiratas(felhLista, felhAdatok);
                    break;
                }
                else
                {
                    Console.WriteLine("Az eddigiek:");
                    Kiiratas(felhLista, felhAdatok);
                }
            }
            Console.ReadKey();
        }
        static void Adatbekeres(string bekerendo, Dictionary<string, string> menteshelye)
        {
            Console.WriteLine($"{bekerendo}: ");
            string adat = Console.ReadLine();
            menteshelye.Add(bekerendo, adat);
        }
        static void Kiiratas(List<Dictionary<string, string>> felhLista, Dictionary<string, string> felhAdatok)
        {
            for (int i = 0; i < felhLista.Count ; i++)
            {
                Console.WriteLine($"{i+1}. felhasználó");
                
                    foreach (var item in felhAdatok)
                    {
                        Console.WriteLine($"{item.Key}: {item.Value}");
                    }                                
            }
            felhAdatok.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyakorlasCsharpKonzol0932
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cimletek = new int[] { 5, 10, 20, 50, 100, 200 };
            int[] kassza = new int[] { 5, 10, 20, 10, 10, 50, 200, 100, 5, 5, 5 };

            /*
            //objektumorientált
            List<Penz> objLista = new List<Penz>();

            foreach (var item in cimletek)
            {
                int db = 0;
                foreach (var item2 in kassza)
                {
                    if (item == item2)
                    {
                        db++;
                    }
                }
                Penz penz = new Penz(item, db);
                objLista.Add(penz);
                db = 0;
            }
            for (int i = 0; i < cimletek.Length; i++)
            {
                Console.WriteLine($"Címlet: {objLista[i].cimlet}, {objLista[i].darab} db");
            }
            */

            //Dictionary
            Dictionary<int, int> cimletDarab = new Dictionary<int, int>();
            foreach (var item in cimletek)
            {
                int db = 0;
                foreach (var item2 in kassza)
                {
                    if (item == item2)
                    {
                        db++;
                    }
                }
                cimletDarab.Add(item, db);
                
                db = 0;
            }
            foreach (var item in cimletDarab)
            {
                Console.WriteLine($"Címlet: {item.Key}, {item.Value} db");
            }
            
            
            
            Console.ReadKey();

        }
    }
}

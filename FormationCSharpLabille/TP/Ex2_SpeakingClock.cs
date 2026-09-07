using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP
{
    public static class SpeakingClock
    {
        public static string GoodDay(int heure)
        {
            string ret = "";
            switch (heure){

                case int _ when heure >= 0 && heure < 6:
                    Console.WriteLine("Merveilleuse Nuit !");
                    break;
                case int _ when heure >= 6 && heure < 12:
                    Console.WriteLine("Bonne matinée !");
                    break;
                case int _ when heure == 12:
                    Console.WriteLine("Bon appétit !");
                    break;
                case int _ when heure >= 13 && heure < 18:
                    Console.WriteLine("Profitez de votre après-midi !");
                    break;
                case int _ when heure == 18:
                    Console.WriteLine("Passez une bonne soirée !");
                    break;
         
            }
            return ret;
        }
    }
}

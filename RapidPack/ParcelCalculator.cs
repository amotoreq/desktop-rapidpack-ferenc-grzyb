using System;

namespace RapidPack.Classes;

public class ParcelCalculator
{
    public static int CalculatePrice(int szerokosc, int wysokosc,int glebokosc, int waga, bool expres, int typPrzesylki)
    {
        double cena = 10.0;

        cena = cena + waga * 2;

        if (expres)
        {
            cena += 15;
        }

        if (typPrzesylki == 1)
        {
            cena += 10;
        }

        if (szerokosc + wysokosc + glebokosc > 150)
        {
            cena *= 1.5;
        }
        if (typPrzesylki == 2)
        {
            cena = 100;
        }

        Math.Floor(cena);
        return (int)cena; 
    }
}

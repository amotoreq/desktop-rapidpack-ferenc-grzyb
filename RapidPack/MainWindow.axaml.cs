using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Interactivity;
using Avalonia.Media;
using RapidPack.Classes;

namespace RapidPack;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    
    ParcelCalculator parcelCalculator = new ParcelCalculator();

    private void CalculatePrice(object? sender, RoutedEventArgs e)
    {
        TextBox[] textBoxes = [Wysokosc, Szerokosc, Glebokosc, Waga];
        TextBlock wycen = Koszt;

        if (textBoxes.All(x => int.TryParse(x.Text, out int result)))
        {
            int wysokosc = int.Parse(Wysokosc.Text);
            int szerokosc = int.Parse(Szerokosc.Text);
            int glebokosc = int.Parse(Glebokosc.Text);
            int waga = int.Parse(Waga.Text);
            bool czyEkspres = Ekspres.IsChecked ?? false;
            int typPrzesylki = TypPrzesylki.SelectedIndex;
            
            int cenaPaczki = parcelCalculator.CalculatePrice(szerokosc, wysokosc, glebokosc, waga, czyEkspres, typPrzesylki);
            wycen.Text = cenaPaczki.ToString();
        }
    }

}

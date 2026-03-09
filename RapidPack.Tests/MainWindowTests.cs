using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Interactivity;

namespace RapidPack.Tests;
using Xunit;

public class MainWindowTests
{
   [AvaloniaFact]
   public void WeightBox_ShouldAlertWhenOver30()
   {
      var window = new MainWindow();
      var Szerokosc = window.FindControl<TextBox>("Szerokosc");
      var Wysokosc = window.FindControl<TextBox>("Wysokosc");
      var Glebokosc = window.FindControl<TextBox>("Glebokosc");
      var Waga = window.FindControl<TextBox>("Waga");
      var Koszt = window.FindControl<TextBlock>("Koszt");
      var button = window.FindControl<Button>("Wycen");
        
      Szerokosc.Text = "20";
      Wysokosc.Text = "20";
      Glebokosc.Text = "20";
      Waga.Text = "35";
      button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
     
      Assert.Equal("Paczka za ciężka",Koszt.Text);
   }
   [AvaloniaFact]
   public void Express_WhenChecked_ShouldAdd15ToPrice()
   {
      var window = new MainWindow();
      var Szerokosc = window.FindControl<TextBox>("Szerokosc");
      var Wysokosc = window.FindControl<TextBox>("Wysokosc");
      var Glebokosc = window.FindControl<TextBox>("Glebokosc");
      var Waga = window.FindControl<TextBox>("Waga");
      var Koszt = window.FindControl<TextBlock>("Koszt");
      var button = window.FindControl<Button>("Wycen");
      var Ekspres = window.FindControl<CheckBox>("Ekspres");
      Szerokosc.Text = "20";
      Wysokosc.Text = "20";
      Glebokosc.Text = "20";
      Waga.Text = "0";
      Ekspres.IsChecked = true;
      Koszt.Text = $"Paczka o wymiarach 50x60x60 o wadze 0kg \n Z opcją eksresową oraz typem \n Wynosi 25zł";
      button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
      
      Assert.Contains("25",Koszt.Text);
   }
   [AvaloniaFact]
   public void ParcelOver150cm_ShouldIncreasePrice()
   {
      var window = new MainWindow();
      var Szerokosc = window.FindControl<TextBox>("Szerokosc");
      var Wysokosc = window.FindControl<TextBox>("Wysokosc");
      var Glebokosc = window.FindControl<TextBox>("Glebokosc");
      var Waga = window.FindControl<TextBox>("Waga");
      var Koszt = window.FindControl<TextBlock>("Koszt");
      var button = window.FindControl<Button>("Wycen");
        
      Szerokosc.Text = "50";
      Wysokosc.Text = "50";
      Glebokosc.Text = "60";
      Waga.Text = "0";
      button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
      Koszt.Text = $"Paczka o wymiarach 50x60x60 o wadze 0kg \n Z typem \n Wynosi 11.5zł";
      Assert.Contains("11.5",Koszt.Text);
   }

   [AvaloniaFact]
   public void ParcelPaleta_ShouldSetPriceTo100()
   {
      var window = new MainWindow();
      var Szerokosc = window.FindControl<TextBox>("Szerokosc");
      var Wysokosc = window.FindControl<TextBox>("Wysokosc");
      var Glebokosc = window.FindControl<TextBox>("Glebokosc");
      var Waga = window.FindControl<TextBox>("Waga");
      var Koszt = window.FindControl<TextBlock>("Koszt");
      var button = window.FindControl<Button>("Wycen");
      var TypPrzesylki = window.FindControl<ComboBox>("TypPrzesylki");  
      Szerokosc.Text = "50";
      Wysokosc.Text = "50";
      Glebokosc.Text = "60";
      Waga.Text = "0";
      TypPrzesylki.SelectedValue = "Paleta";
      button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
      Koszt.Text = $"Paczka o wymiarach 50x60x60 o wadze 0kg \n Z typem paleta \n Wynosi 100zł";
      Assert.Contains("100", Koszt.Text);
      
      
   }
}


   

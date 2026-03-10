using Avalonia.Controls;
using Avalonia.Headless.XUnit;
using Avalonia.Interactivity;
using RapidPack.Classes;

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
      
      var result = ParcelCalculator.CalculatePrice(0,0,0,0,true,0)
         .ToString();
      Assert.Contains("25",result);
   }
   
   
   
   [AvaloniaFact]
   public void ParcelOver150cm_ShouldIncreasePrice()
   {
      var result = ParcelCalculator.CalculatePrice(50, 50, 60, 0,false,0)
         .ToString();
      Assert.Equal("15",result);
   }

   
   [AvaloniaFact]
   public void ParcelPaleta_ShouldSetPriceTo100()
   {
      var result = ParcelCalculator.CalculatePrice(1, 1, 1, 1, false, 2)
         .ToString();
      Assert.Contains("100", result);
   }
}


   

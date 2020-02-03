using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExoAsync
{
    class Pain { }
    class Tranche { }
    class Collation { }

    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            output.Content = $"MAMAN! J'ai faim!!{System.Environment.NewLine}";
        }

        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            start.IsEnabled = false;

            output.Content = $"Je vais te préparer du pain 🍞 avec du beurre 🧀.{System.Environment.NewLine}";

            var faireDuPainTache = FaireDuPainAsync();
            var jeu = CasseTeteAsync();

            Pain pain = await faireDuPainTache;
            output.Content += "Je tranche le pain\n";
            etatPain.Content = "LE PAIN EST TRANCHÉ\n";
            output.Content += "Je beurre le pain\n";
            etatPain.Content = "LA TRANCHE EST BEURRÉE\n";

            output.Content += $"Voila du pain 🍞 avec du beurre 🧀, mon lapin 🐰!{System.Environment.NewLine}";

            start.IsEnabled = true;
        }
        private async Task<Pain> FaireDuPainAsync()
        {
            output.Content += "Je mélange les ingrédients\n";

            output.Content += "Je pétris la pâte\n";
            Task leveeTask = LeverAsync();


            output.Content += "Je lave le bol\n";
            await leveeTask;

            output.Content += "Je pétris la pâte\n";
            leveeTask = LeverAsync();

            await leveeTask;

            output.Content += "Je mets le pain au four\n";

            await CuireAsync();

            return new Pain();
        }


        private async Task LeverAsync()
        {
            etatPain.Content = "LA PÂTE LEVE\n";
            await Task.Delay(5000);
        }
        private async Task CuireAsync()
        {
            etatPain.Content = "LA PÂTE CUIT\n";
            await Task.Delay(2500);
        }

        private async Task CasseTeteAsync()
        {
            for (int i = 0; i < 24; i++)
            {
                etatCasseTete.Content =$"{i + 1} morceaux sur {24}";
                await Task.Delay(500);
            }
        }
     
    }
}

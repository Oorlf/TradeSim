using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
using Newtonsoft.Json;
using System.IO;


namespace Trade_Simulator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Planet> planetsList = JsonConvert.DeserializeObject<List<Planet>>(File.ReadAllText(@"D:\Programming\GitHub\TradeSim\Trade Simulator\Trade Simulator\Planets.json"));
            dgPlanets.ItemsSource = planetsList;
        }

        void AddWoodBtn_Click(object sender, EventArgs e)
        {
            
        }
    }


}

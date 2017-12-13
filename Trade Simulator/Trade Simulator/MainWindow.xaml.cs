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



namespace Trade_Simulator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public int woodAmount = 17;

        public MainWindow()
        {
            InitializeComponent();

            // test goods
            Goods[] goods = new Goods[5]
            {
                new Goods() { Name = "Wood", Amount = woodAmount, Price = 5.2f, Category = GoodsType.Common },
                new Goods() { Name = "Stone", Amount = 20, Price = 8, Category = GoodsType.Common },
                new Goods() { Name = "Food", Amount = 125, Price = 2.1f, Category = GoodsType.Common },
                new Goods() { Name = "Pearls", Amount = 7, Price = 52.54f, Category = GoodsType.Luxury },
                new Goods() { Name = "Diamonds", Amount = 2, Price = 740.02f, Category = GoodsType.Luxury }
            };

            // test planet
            Planet terra = new Planet() { Name = "Terra", PlanetType = "Earthlike", Climate = "Temperate", Goods = goods, Habitability = 100f, Size = 100f, UsableArea = 37f, Wealth = 23721.123f };

            List<Planet> planets = new List<Planet>
            {
                new Planet()  { Name = "Terra", PlanetType = "Earthlike", Climate = "Temperate", Goods = goods, Habitability = 100f, Size = 100f, UsableArea = 37f, Wealth = 23721.123f }
            };

            dgPlanets.ItemsSource = planets;

            // Creating the goods list for testing
            BindingList<Goods> items = new BindingList<Goods>
            {
            new Goods() { Name = "Wood", Amount = woodAmount, Price = 5.2f, Category = GoodsType.Common },
            new Goods() { Name = "Stone", Amount = 20, Price = 8, Category = GoodsType.Common },
            new Goods() { Name = "Food", Amount = 125, Price = 2.1f, Category = GoodsType.Common },
            new Goods() { Name = "Pearls", Amount = 7, Price = 52.54f, Category = GoodsType.Luxury },
            new Goods() { Name = "Diamonds", Amount = 2, Price = 740.02f, Category = GoodsType.Luxury }
            };
            lvTradeGoods.ItemsSource = items;

            // Adding Categories to the listview
            CollectionView view = (CollectionView)CollectionViewSource.GetDefaultView(lvTradeGoods.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("Category");
            view.GroupDescriptions.Add(groupDescription);
        }

        void AddWoodBtn_Click(object sender, EventArgs e)
        {
            
        }

        // sorting the listview when clicking on header
        private void TradeGoodsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if(listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvTradeGoods.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvTradeGoods.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }
    }

    public enum GoodsType { Common, Luxury };

    // Draws the sorting-indicator on the listView header
    public class SortAdorner : Adorner
    {
        private static Geometry ascGeometry = Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

        private static Geometry descGeometry = Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

        public ListSortDirection Direction { get; private set; }

        public SortAdorner(UIElement element, ListSortDirection dir) :base(element)
        {
            this.Direction = dir;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            // wenn das Dreieck schon besteht wird abgebrochen
            if (AdornedElement.RenderSize.Width < 20)
                return;

            TranslateTransform transform = new TranslateTransform (AdornedElement.RenderSize.Width -15, (AdornedElement.RenderSize.Height - 5) / 2);
            drawingContext.PushTransform(transform);

            Geometry geometry = ascGeometry;
            if (this.Direction == ListSortDirection.Descending)
                geometry = descGeometry;
            drawingContext.DrawGeometry(Brushes.Black, null, geometry);

            drawingContext.Pop();
        }
    }
}

using System;
using System.Collections.Generic;
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

namespace Iusico_Laura_Aplicatie
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        KeyValuePair<FlowerType, double>[] PriceList = {
 new KeyValuePair<FlowerType, double>(FlowerType.Bouquet_of_Red_Roses, 150),
 new KeyValuePair<FlowerType, double>(FlowerType.Bouquet_of_White_Roses,160),
 new KeyValuePair<FlowerType, double>(FlowerType.Bouquet_of_Mixed_Roses,180),
 new KeyValuePair<FlowerType, double>(FlowerType.Bouquet_of_Tulips,100),
 new KeyValuePair<FlowerType, double>(FlowerType.Bouquet_of_Mixed_Tulips,130),
 new KeyValuePair<FlowerType, double>(FlowerType.Bouquet_of_Mixed_Flowers, 200),
 new KeyValuePair<FlowerType, double>(FlowerType.Flower_Arrangement_in_box,250),
 new KeyValuePair<FlowerType, double>(FlowerType.Flower_Arrangement_in_basket,300),
 new KeyValuePair<FlowerType, double>(FlowerType.Flower_Arrangement_with_sweets,300),
 new KeyValuePair<FlowerType, double>(FlowerType.Bridal_Bouquet,350),
 new KeyValuePair<FlowerType, double>(FlowerType.Anniversary_Bouquet, 200),
 new KeyValuePair<FlowerType, double>(FlowerType.Flower_Decorations,400)
 };


        private int mBqRedRoses = 5;
        private int mBqWhiteRoses = 5;
        private int mBqMixedRoses = 5;
        private int mBqTulips = 5;
        private int mBqMixedTulips = 5;
        private int mBqMixedFlowers = 5;
        private int mFlArrinbox = 5;
        private int mFlArrinbasket = 5;
        private int mFlArrwithsweets = 5;
        private int mBridalBouquet = 5;
        private int mAnniversaryBouquet = 5;
        private int mFlowerDecorations = 5;
        private double Total = 0;
        private FlowerType selectedFlower;
        private int ValidateQuantity(FlowerType selectedFlower)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedFlower)
            {
                case FlowerType.Bouquet_of_Red_Roses:
                    if (q > mBqRedRoses)
                        r = 0;
                    break;
                case FlowerType.Bouquet_of_White_Roses:
                    if (q > mBqWhiteRoses)
                        r = 0;
                    break;
                case FlowerType.Bouquet_of_Mixed_Roses:
                    if (q > mBqMixedRoses)
                        r = 0;
                    break;
                case FlowerType.Bouquet_of_Tulips:
                    if (q > mBqTulips)
                        r = 0;
                    break;
                case FlowerType.Bouquet_of_Mixed_Tulips:
                    if (q > mBqMixedTulips)
                        r = 0;
                    break;
                case FlowerType.Bouquet_of_Mixed_Flowers:
                    if (q > mBqMixedFlowers)
                        r = 0;
                    break;
                case FlowerType.Flower_Arrangement_in_box:
                    if (q > mFlArrinbox)
                        r = 0;
                    break;
                case FlowerType.Flower_Arrangement_in_basket:
                    if (q > mFlArrinbasket)
                        r = 0;
                    break;
                case FlowerType.Flower_Arrangement_with_sweets:
                    if (q > mFlArrwithsweets)
                        r = 0;
                    break;
                case FlowerType.Bridal_Bouquet:
                    if (q > mBridalBouquet)
                        r = 0;
                    break;
                case FlowerType.Anniversary_Bouquet:
                    if (q > mAnniversaryBouquet)
                        r = 0;
                    break;
                case FlowerType.Flower_Decorations:
                    if (q > mFlowerDecorations)
                        r = 0;
                    break;
            }
            return r;
        }

        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }
        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<FlowerType, double> selectedEntry =
           (KeyValuePair<FlowerType, double>)cmbType.SelectedItem;
            selectedFlower = selectedEntry.Key;
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedFlower) > 0)
            {
                lstOrder.Items.Add(txtQuantity.Text + " " + selectedFlower.ToString() +
               ":" + txtPrice.Text + "=" + double.Parse(txtQuantity.Text) *
               double.Parse(txtPrice.Text));
                Total = 0 + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }


        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            lstOrder.Items.Remove(lstOrder.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstOrder.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
               1))
                {
                    case "Bouquet_of_Red_Roses":
                        mBqRedRoses = mBqRedRoses - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBqRedRoses.Text = mBqRedRoses.ToString(); ;
                        break;
                    case "Bouquet_of_White_Roses":
                        mBqWhiteRoses = mBqWhiteRoses - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBqWhiteRoses.Text = mBqWhiteRoses.ToString(); ;
                        break;
                    case "Bouquet_of_Mixed_Roses":
                        mBqMixedRoses = mBqMixedRoses - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBqMixedRoses.Text = mBqMixedRoses.ToString(); ;
                        break;
                    case "Bouquet_of_Tulips":
                        mBqTulips = mBqTulips - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBqTulips.Text = mBqTulips.ToString(); ;
                        break;
                    case "Bouquet_of_Mixed_Tulips":
                        mBqMixedTulips = mBqMixedTulips - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBqMixedTulips.Text = mBqMixedTulips.ToString(); ;
                        break;
                    case "Bouquet_of_Mixed_Flowers":
                        mBqMixedFlowers = mBqMixedFlowers - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBqMixedFlowers.Text = mBqMixedFlowers.ToString(); ;
                        break;
                    case "Flower_Arrangement_in_box":
                        mFlArrinbox = mFlArrinbox - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtFlwArrBox.Text = mFlArrinbox.ToString(); ;
                        break;
                    case "Flower_Arrangement_in_basket":
                        mFlArrinbasket = mFlArrinbasket - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtFlwArrBasket.Text = mFlArrinbasket.ToString(); ;
                        break;
                    case "Flower_Arrangement_with_sweets":
                        mFlArrwithsweets = mFlArrwithsweets - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtFlwArrSweets.Text = mFlArrwithsweets.ToString(); ;
                        break;
                    case "Bridal_Bouquet":
                        mBridalBouquet = mBridalBouquet - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBridalBq.Text = mBridalBouquet.ToString(); ;
                        break;
                    case "Anniversary_Bouquet":
                        mAnniversaryBouquet = mAnniversaryBouquet - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtAnniversaryBq.Text = mAnniversaryBouquet.ToString(); ;
                        break;
                    case "Flower_Decorations":
                        mFlowerDecorations = mFlowerDecorations - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtFlowerDecorations.Text = mFlowerDecorations.ToString(); ;
                        break;

                }
            }
            lstOrder.Items.Clear();
        }



    }
}
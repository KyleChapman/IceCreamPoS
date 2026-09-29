// Author:  Kyle Chapman
// Created: September 17, 2026
// Updated: September 18, 2026
// Description: Outputs a bill for ice cream cones based
// on what someone selects as the ice cream order.

using System.Windows;

namespace IceCream
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Variable Declarations
        int miniCount = 0;
        int oneScoopCount = 0;
        int twoScoopCount = 0;
        int threeScoopCount = 0;
        int waffleCount = 0;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Constructor for the form.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Increment counters and determine the bill based on which products are selected to order.
        /// </summary>
        private void AddToOrder(object sender, RoutedEventArgs e)
        {
            // Declaration.
            const double MINI_CONE_COST = 2.99;
            const double ONE_SCOOP_COST = 3.99;
            const double TWO_SCOOP_COST = 4.99;
            const double THREE_SCOOP_COST = 5.99;
            const double WAFFLE_CONE_COST = 1.00;
            const double HST = 0.13;
            double subtotal;
            double tax;
            double totalCost;

            // Input. Or is there any? Sort of.

            // Processing.
            if (radioMini.IsChecked == true)
            {
                miniCount++;
            }
            else if (radioOneScoop.IsChecked == true)
            {
                oneScoopCount++;
            }
            else if (radioTwoScoop.IsChecked == true)
            {
                twoScoopCount++;
            }
            else
            {
                threeScoopCount++;
            }

            if (checkWaffle.IsChecked == true)
            {
                waffleCount++;
            }

            subtotal = miniCount * MINI_CONE_COST + oneScoopCount * ONE_SCOOP_COST + twoScoopCount * TWO_SCOOP_COST + threeScoopCount * THREE_SCOOP_COST + waffleCount * WAFFLE_CONE_COST;
            tax = subtotal * HST;
            totalCost = subtotal + tax;
            
            // Output.
            textSubtotal.Text = subtotal.ToString("c");
            textTax.Text = tax.ToString("c");
            textTotal.Text = totalCost.ToString("c");

        }

        /// <summary>
        /// Resets the form to its default state.
        /// </summary>
        private void ResetClick(object sender, RoutedEventArgs e)
        {
            radioMini.IsChecked = true;
            checkWaffle.IsChecked = false;
            textSubtotal.Clear();
            textTax.Clear();
            textTotal.Clear();

            // Reset the counters.
            miniCount = 0;
            oneScoopCount = 0;
            twoScoopCount = 0;
            threeScoopCount = 0;
            waffleCount = 0;
        }
        #endregion
    }
}
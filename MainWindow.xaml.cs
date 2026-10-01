// Author:  Kyle Chapman
// Created: September 17, 2026
// Updated: October 1, 2026
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
        const double MINI_CONE_COST = 2.99;
        const double ONE_SCOOP_COST = 3.99;
        const double TWO_SCOOP_COST = 4.99;
        const double THREE_SCOOP_COST = 5.99;
        const double WAFFLE_CONE_COST = 1.00;
        const double HST = 0.13;

        #endregion

        #region Constructor(s)
        /// <summary>
        /// Constructor for the form.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            ResetForm();
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Increment counters and determine the bill based on which products are selected to order.
        /// </summary>
        private void AddToOrder(object sender, RoutedEventArgs e)
        {
            // Declaration.
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

            // Populate the receipt window.
            textReceipt.Text = GenerateReceipt();
        }

        /// <summary>
        /// Resets the form to its default state.
        /// </summary>
        private void ResetClick(object sender, RoutedEventArgs e)
        {
            ResetForm();
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Resets the form to its default state, including counters used for orders.
        /// </summary>
        private void ResetForm()
        {
            // Reset the input and output fields.
            radioMini.IsChecked = true;
            checkWaffle.IsChecked = false;
            textSubtotal.Clear();
            textTax.Clear();
            textTotal.Clear();
            textReceipt.Clear();

            // Reset the counters.
            miniCount = 0;
            oneScoopCount = 0;
            twoScoopCount = 0;
            threeScoopCount = 0;
            waffleCount = 0;

            // Set focus.
            radioMini.Focus();
        }

        /// <summary>
        /// Generate full receipt text showing quantities ordered and totals.
        /// </summary>
        /// <returns>Multi-line text showing all purchases and total value.</returns>
        private string GenerateReceipt()
        {
            string fullReceipt = "";

            // For each item ordered, add the quantity and value of that item to a big string.
            if (miniCount > 0)
            {
                fullReceipt += miniCount.ToString() + " mini scoops @ " + (miniCount*MINI_CONE_COST).ToString("c") + Environment.NewLine;
            }
            if (oneScoopCount > 0)
            {
                fullReceipt += oneScoopCount.ToString() + " one scoop cones @ " + (oneScoopCount*ONE_SCOOP_COST).ToString("c") + Environment.NewLine;
            }
            if (twoScoopCount > 0)
            {
                fullReceipt += twoScoopCount.ToString() + " two scoop cones @ " + (twoScoopCount*TWO_SCOOP_COST).ToString("c") + Environment.NewLine;
            }
            if (threeScoopCount > 0)
            {
                fullReceipt += threeScoopCount.ToString() + " three scoop cones @ " + (threeScoopCount*THREE_SCOOP_COST).ToString("c") + Environment.NewLine;
            }

            if (waffleCount > 0)
            {
                fullReceipt += waffleCount.ToString() + " add waffle cone @ " + (waffleCount * WAFFLE_CONE_COST).ToString("c") + Environment.NewLine;
            }

            // Add the subtotal, tax and total from existing form elements to the big string.
            fullReceipt += 
                Environment.NewLine + "Subtotal: " + textSubtotal.Text +
                Environment.NewLine + "Tax: " + textTax.Text +
                Environment.NewLine + "Total: " + textTotal.Text;

            return fullReceipt;
        }
        #endregion
    }
}
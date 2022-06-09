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

namespace Proyect1_Calc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    enum SelectedOperation
    {
        Suma, Resta, Multiplicacion, Division,
    }
    public partial class MainWindow : Window
    {
        SelectedOperation selOper;
        private double numberPrev, result;
        public MainWindow()
        {
            InitializeComponent();
            clear.Click += Clear_Click;
            btnNeg.Click += BtnNeg_Click1;
            btnPorcent.Click += BtnPorcent_Click;
            btnequals.Click += Btnequals_Click;
            btnPlus2.Click += BtnPlus2_Click;
            btndot.Click += Btndot_Click;
            btnSqr.Click += BtnSqr_Click;
        }

        private void BtnNeg_Click1(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(results.Text.ToString(), out numberPrev))
            {
                numberPrev *= -1;
                results.Text = $"{numberPrev}";
            }
        }

        private void BtnSqr_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(results.Text.ToString(), out numberPrev))
            {
                results.Text = $"{CCalculate.Sqr(numberPrev)}";
            }
        }

        private void Btndot_Click(object sender, RoutedEventArgs e)
        {
            results.Text = results.Text.ToString().Contains('.')? results.Text: results.Text = $"{results.Text}.";
        }

        private void BtnPlus2_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(results.Text.ToString(), out numberPrev))
            {
                results.Text = $"{CCalculate.Cuadratic(numberPrev)}";
            }

        }

        private void Btnequals_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(results.Text.ToString(), out double newNumber))
            {
                switch (selOper)
                {
                    case SelectedOperation.Suma:
                        result = CCalculate.Sum(numberPrev, newNumber);
                        break;
                    case SelectedOperation.Resta:
                        result = CCalculate.Rest(numberPrev, newNumber);
                        break;
                    case SelectedOperation.Multiplicacion:
                        result = CCalculate.Mult(numberPrev, newNumber);
                        break;
                    case SelectedOperation.Division:
                        result = CCalculate.Div(numberPrev, newNumber);
                        break;
                }
            }
            results.Text = $"{result}";

        }

        private void BtnOperation_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(results.Text.ToString(), out numberPrev))
            {
                results.Text = $"0";
            }
            //Selecciona la operacion que se realizara cuando igualo el igual
            selOper = (sender == btnMult) ? SelectedOperation.Multiplicacion : selOper;
            selOper = (sender == btnDiv) ? SelectedOperation.Division : selOper;
            selOper = (sender == btnSum) ? SelectedOperation.Suma : selOper;
            selOper = (sender == btnRest) ? SelectedOperation.Resta : selOper;
        }


        private void BtnNumbers_Click(object sender, RoutedEventArgs e)
        {
            int selectValue = int.Parse((sender as Button).Content.ToString());
            results.Text = results.Text.ToString() == "0" ? results.Text = $"{selectValue}" : results.Text = $"{results.Text}{selectValue}";
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            //Borrar resultado en pantalla
            results.Text = "0";
        }

        private void BtnPorcent_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(results.Text.ToString(), out numberPrev))
            {
                numberPrev = (numberPrev * 0.01) * 10;
                results.Text = $"{numberPrev}";
            }
        }
    }
}

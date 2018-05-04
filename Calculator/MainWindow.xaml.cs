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

namespace Calculator
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    double lastNumber, result;
    SelectedOperator selectedOperator;

    public MainWindow()
    {
      InitializeComponent();

      acButton.Click += AcButton_Click;
      negativeButton.Click += NegativeButton_Click;
      percentButton.Click += PercentButton_Click;
      equalButton.Click += EqualButton_Click;
    }

    private void EqualButton_Click(object sender, RoutedEventArgs e)
    {
      double newNumber;
      if (double.TryParse(resultLabel.Content.ToString(), out newNumber))
      {
        switch (selectedOperator)
        {
          case SelectedOperator.Addition:
            result = SimpleMath.Add(lastNumber, newNumber);
            break;
          case SelectedOperator.Substraction:
            result = SimpleMath.Substract(lastNumber, newNumber);
            break;
          case SelectedOperator.Multiplication:
            result = SimpleMath.Multiply(lastNumber, newNumber);
            break;
          case SelectedOperator.Division:
            result = SimpleMath.Divide(lastNumber, newNumber);
            break;
        }

        resultLabel.Content = result.ToString();
      }
    }

    private void PercentButton_Click(object sender, RoutedEventArgs e)
    {
      if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
      {
        lastNumber = lastNumber / 100;
        resultLabel.Content = lastNumber.ToString();
      }
    }

    private void NegativeButton_Click(object sender, RoutedEventArgs e)
    {
      if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
      {
        lastNumber = -lastNumber;
        resultLabel.Content = lastNumber.ToString();
      }
    }

    private void AcButton_Click(object sender, RoutedEventArgs e)
    {
      resultLabel.Content = "0";
    }

    private void OperationButton_Click(object sender, RoutedEventArgs e)
    {
      if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
      {
        resultLabel.Content = "0";
      }

      if (sender == multiplyButton)
        selectedOperator = SelectedOperator.Multiplication;
      else if (sender == divideButton)
        selectedOperator = SelectedOperator.Division;
      else if (sender == plusButton)
        selectedOperator = SelectedOperator.Addition;
      else if (sender == minusButton)
        selectedOperator = SelectedOperator.Substraction;
    }

    private void dotButton_Click(object sender, RoutedEventArgs e)
    {
      if (!resultLabel.Content.ToString().Contains("."))
      {
        resultLabel.Content = $"{resultLabel.Content}.";
      }     
    }

    private void NumberButton_Click(object sender, RoutedEventArgs e)
    {
      int selectedValue = 0;

      if (sender == zeroButton)
        selectedValue = 0;
      else if (sender == oneButton)
        selectedValue = 1;
      else if (sender == twoButton)
        selectedValue = 2;
      else if (sender == threeButton)
        selectedValue = 3;
      else if (sender == fourButton)
        selectedValue = 4;
      else if (sender == fiveButton)
        selectedValue = 5;
      else if (sender == sixButton)
        selectedValue = 6;
      else if (sender == sevenButton)
        selectedValue = 7;
      else if (sender == eightButton)
        selectedValue = 8;
      else if (sender == nineButton)
        selectedValue = 9;

      if (resultLabel.Content.ToString() == "0")
      {
        resultLabel.Content = $"{selectedValue}";
      }
      else
      {
        resultLabel.Content = $"{resultLabel.Content}{selectedValue}";
      }
    }
  }

  public enum SelectedOperator
  {
    Addition,
    Substraction,
    Multiplication,
    Division,
  }

  public class SimpleMath
  {
    public static double Add(double n1, double n2)
    {
      return n1 + n2;
    }

    public static double Substract(double n1, double n2)
    {
      return n1 - n2;
    }

    public static double Multiply(double n1, double n2)
    {
      return n1 * n2;
    }

    public static double Divide(double n1, double n2)
    {
      if (n2 == 0)
      {
        MessageBox.Show("Division by 0 is not supported", "Wrong operation",  MessageBoxButton.OK, MessageBoxImage.Error);
        return 0;
      }
      return n1 / n2;
    }
  }
}

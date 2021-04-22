using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace NotationCalc
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Window thisWindow;

        public static TextBlock AnswerBlock10 = new TextBlock()
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(10, 210, 0, 0),
            FontSize = 24
        };

        public static TextBlock AnswerBlock = new TextBlock()
        {
            HorizontalAlignment = HorizontalAlignment.Left,
            VerticalAlignment = VerticalAlignment.Top,
            Margin = new Thickness(10, 247, 0, 0),
            FontSize = 24
        };

        public MainWindow()
        {
            InitializeComponent();
            
            Grid.Children.Add(AnswerBlock10);
            Grid.Children.Add(AnswerBlock);
            thisWindow = this;
        }

        private static readonly Regex _regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        private static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }


        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void PrevTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private void ButtonAdd_OnClick(object sender, RoutedEventArgs e)
        {
            string First = FirstTextBox.Text.Trim();
            string Second = SecondTxtBox.Text.Trim();
            char[] FirstArray = First.ToCharArray();
            char[] SecondArray = Second.ToCharArray();

            int sourceNotation1 = Convert.ToInt32(SourceNotation1ComboBox.Text);
            int sourceNotation2 = Convert.ToInt32(SourceNotation2ComboBox.Text);
            int targetNotation = Convert.ToInt32(TargetNotationComboBox.Text);

            ViewModel.Calculate(FirstArray, SecondArray, sourceNotation1, sourceNotation2, targetNotation, 0);
        }

        private void ButtonMultiply_OnClick(object sender, RoutedEventArgs e)
        {
            string First = FirstTextBox.Text.Trim();
            string Second = SecondTxtBox.Text.Trim();
            char[] FirstArray = First.ToCharArray();
            char[] SecondArray = Second.ToCharArray();

            int sourceNotation1 = Convert.ToInt32(SourceNotation1ComboBox.Text);
            int sourceNotation2 = Convert.ToInt32(SourceNotation2ComboBox.Text);
            int targetNotation = Convert.ToInt32(TargetNotationComboBox.Text);

            ViewModel.Calculate(FirstArray, SecondArray, sourceNotation1, sourceNotation2, targetNotation, 3);
        }

        private void ButtonSubstract_OnClick(object sender, RoutedEventArgs e)
        {
            string First = FirstTextBox.Text.Trim();
            string Second = SecondTxtBox.Text.Trim();
            char[] FirstArray = First.ToCharArray();
            char[] SecondArray = Second.ToCharArray();

            int sourceNotation1 = Convert.ToInt32(SourceNotation1ComboBox.Text);
            int sourceNotation2 = Convert.ToInt32(SourceNotation2ComboBox.Text);
            int targetNotation = Convert.ToInt32(TargetNotationComboBox.Text);

            ViewModel.Calculate(FirstArray, SecondArray, sourceNotation1, sourceNotation2, targetNotation, 1);
        }

        private void ButtonDivide_OnClick(object sender, RoutedEventArgs e)
        {
            string First = FirstTextBox.Text.Trim();
            string Second = SecondTxtBox.Text.Trim();
            char[] FirstArray = First.ToCharArray();
            char[] SecondArray = Second.ToCharArray();

            int sourceNotation1 = Convert.ToInt32(SourceNotation1ComboBox.Text);
            int sourceNotation2 = Convert.ToInt32(SourceNotation2ComboBox.Text);
            int targetNotation = Convert.ToInt32(TargetNotationComboBox.Text);

            if (Convert.ToInt32(Second) <= 0)
            {
                AnswerBlock10.Text = "Ошибка вычислений";
            }
            else
                ViewModel.Calculate(FirstArray, SecondArray, sourceNotation1, sourceNotation2, targetNotation, 2);
        }
    }
}

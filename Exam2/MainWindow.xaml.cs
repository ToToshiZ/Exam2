using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;


namespace Exam2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<СurrencyMy> currencies = new List<СurrencyMy>();
        public MainWindow()
        {
            InitializeComponent();
            ChecXml();
        }
        private void textBox_form(object sender, TextCompositionEventArgs e)
        {
            if (!(Char.IsDigit(e.Text, 0) || (e.Text == ".")
                && (!textBox.Text.Contains(".")
                && textBox.Text.Length != 0)))
            {
                e.Handled = true;
            }
        }


        public void ChecXml()
        {
            Box1.Items.Add("KZT");
            XmlDocument doc = new XmlDocument();
            doc.Load("https://www.nationalbank.kz/rss/rates_all.xml");
            XmlNodeList cl = doc.GetElementsByTagName("item");
            foreach (XmlNode item in cl)
            {
                string title = item["title"].InnerText;
                double description = double.Parse(item["description"].InnerText.Replace('.', ','));
                currencies.Add(new СurrencyMy(title, description));
                Box2.Items.Add(title);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var result = (from t in currencies
                         where t.title == Box2.Text
                         select t).ToList();
            foreach (var elem in result)
            {
                try
                {
                    textBox2.Text = Math.Round((double.Parse(textBox.Text.Replace('.', ',')) / elem.description), 2).ToString();
                }
                catch
                {
                    textBox.Text = "Поле пусто";
                }
            }
        }
    }
}

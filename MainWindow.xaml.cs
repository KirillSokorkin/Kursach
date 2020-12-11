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

namespace Kursach
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Encode_Click(object sender, RoutedEventArgs e)
        {
            LowerText.Text = EvilProg.EvilEncode(UpText.Text, KeyText.Text);
        }

        private void AntiEncode_Click(object sender, RoutedEventArgs e)
        {
            LowerText.Text = EvilProg.EvilAntiEncode(UpText.Text, KeyText.Text);
        }

        private void EncodeFile_Click(object sender, RoutedEventArgs e)
        {
            string start = EvilProg.EvilDownLoadText(StartPath.Text);
            string otvet = EvilProg.EvilEncode(start, KeyText.Text);
            UpText.Text = start;
            if (otvet== "!")
            {
                Error.Text = "Ошибка!";
            }
            else
            {
                LowerText.Text = otvet;
            }
        }

        private void AntiEncodeFile_Click(object sender, RoutedEventArgs e)
        {
            string start = EvilProg.EvilDownLoadText(StartPath.Text);
            string otvet = EvilProg.EvilAntiEncode(start, KeyText.Text);
            UpText.Text = start;
            if (otvet == "!")
            {
                Error.Text = "Ошибка!";
            }
            else
            {
                LowerText.Text = otvet;
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            EvilProg.EvilUpLoadText(FinishPath.Text, LowerText.Text);
        }
    }
}

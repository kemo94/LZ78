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
using System.IO;

namespace Compression
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

        string text = "";
        string nextChar = "";
        int pointer = 0;
        List<string> dic = new List<string>();//dictionary

        // compression
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string CompChar = "";//compare
            int index = 0, retrn = 0 /*to take another char and check it in dictionary*/;
            text = screen.Text;
            screen.Text = "0 " + text[0] + "\n"; // first char
            dic.Add(""); // first element in dictionary is null
            dic.Add(text[0] + "");

            for (int indexText = 1; indexText < text.Length; indexText++)
            {

                CompChar += text[indexText];

                if (dic.IndexOf(CompChar) != -1)
                {
                    index = dic.IndexOf(CompChar);

                    retrn = 1;
                    if (indexText + 1 == text.Length)
                        screen.Text += index + " null\n";

                }
                else
                {
                    if (retrn == 1) 
                        screen.Text += index + " " + CompChar[CompChar.Length - 1] + "\n";

                    else
                        screen.Text += "0 " + CompChar + "\n";

                    dic.Add(CompChar);
                    CompChar = "";


                    retrn = 0;

                }

            }
        }

        // Decompression
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            text = screen.Text;
            string[] CompRslt = screen.Text.Split();
            screen.Text = "";
            for (int i = 0; i < text.Length; i += 2)
            {

                if (CompRslt[i].Length == 0)
                    break;
                // get pointer
                pointer = int.Parse(CompRslt[i]);

                // get char
                nextChar = CompRslt[i + 1];
                if (nextChar != "null")
                    screen.Text += dic[pointer] + nextChar;
                else
                    screen.Text += dic[pointer];

                pointer = 0;
                nextChar = "";

            }

            // defult variable 
            pointer = 0;
            nextChar = "";
            dic.Clear();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

namespace nolik
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
            int turn;
        public List<Button> buttons;
        private List<RadioButton> krornol;
        Random rand = new Random();
        int index;
        public MainWindow() : base()
        {
            this.InitializeComponent();
            disablebuttons();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            turn = 1;
            buttons = new List<Button> { Button1, Button2, Button3, Button4, Button5, Button6, Button7, Button8, Button9 };
            krornol = new List<RadioButton> { krest, nol };
            index = 1;
        }

        private void win(string btnContent)
        {
            if ((Button1.Content == btnContent & Button2.Content == btnContent & Button3.Content == btnContent) | (Button1.Content == btnContent & Button4.Content == btnContent & Button7.Content == btnContent) | (Button1.Content == btnContent & Button5.Content == btnContent & Button9.Content == btnContent) | (Button2.Content == btnContent & Button5.Content == btnContent & Button8.Content == btnContent) | (Button3.Content == btnContent & Button6.Content == btnContent & Button9.Content == btnContent) | (Button4.Content == btnContent & Button5.Content == btnContent & Button6.Content == btnContent) | (Button7.Content == btnContent & Button8.Content == btnContent & Button9.Content == btnContent) | (Button3.Content == btnContent & Button5.Content == btnContent & Button7.Content == btnContent))
            {
                if (btnContent == "O")
                {
                    MessageBox.Show("Выйграл игрок 'O'!");
                }
                else if (btnContent == "X")
                {
                    MessageBox.Show("Выйграл игрок 'X'!");
                }
                disablebuttons();
            }

            else
            {
                foreach (Button btn in wrapPanel1.Children)
                {
                    if (btn.IsEnabled == true)
                        return;
                }
                MessageBox.Show("Ничья!");
            }
        }
        private void disablebuttons()
        {
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.IsEnabled = false;
            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (turn == 1)
            {
                btn.Content = "O";
                Label0.Content = "X";
            }
            else
            {
                btn.Content = "X";
                Label0.Content = "O";
            }
            turn += 1;
            if (turn > 1)
            {
                turn = 0;
            }
            btn.IsEnabled = false;
            win(btn.Content.ToString());
        }
        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            if (index > 1)
            {
                index = 0;
            }
            if (index == 0)
            {
                turn = 0;
            }
            else if (index == 1)
            {
                turn = 1;
            }
            index += 1;
            foreach (Button btn in wrapPanel1.Children)
            {
                btn.Content = "";
                btn.IsEnabled = true;
            }

        }
        private void Vibor(object sender, RoutedEventArgs e)
        {
            RadioButton btn = sender as RadioButton;
            if (krest.IsChecked == true)
            {
                turn = 1;
            }
            else turn = 0;
        }
    }
}

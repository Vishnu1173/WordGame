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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WordGame
{
    /// <summary>
    /// Interaction logic for MainGame.xaml
    /// </summary>
    public partial class MainGame : Window
    {
         
        public MainGame()
        {
            InitializeComponent();
        }        
        List<string> list = new List<string>();
        DispatcherTimer timer = new DispatcherTimer();
        int score = 0;
        int time = 5;
        int word = 0;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            list.Add("Apple");
            list.Add("Sathish");
            list.Add("Vishnu");
            list.Add("Vicky");
            list.Add("Senthil");
            txtbname.Text =list[word].ToString();
            word++;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += timer_Tick;
            timer.Start();
            txtname.Visibility= Visibility.Hidden;
            btnstart.Visibility= Visibility.Hidden; 
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            if (time>0)
            {
                time--;
                lblcount.Content = time;
            }
            else
            {
                timer.Stop();
                txtname.Visibility = Visibility.Visible;
                btnstart.Visibility = Visibility.Visible;
                txtbname.Visibility = Visibility.Hidden;
            }
        }
        private void btnstart_Click(object sender, RoutedEventArgs e)
        {
            if (txtbname.Text == list[word-1].ToString())
            {
                score++;
                txtbscore.Text = score.ToString();
            }
            lblcount.Visibility = Visibility.Visible;
            txtbname.Visibility= Visibility.Visible;

            if (word < list.Count)
            {
                txtbname.Text = list[word].ToString();
                word++;
                txtname.Visibility = Visibility.Hidden;
                btnstart.Visibility = Visibility.Hidden;
                txtname.Clear();
                timer.Start();
            }
           
            else             
            {
                txtbscore.Text = score.ToString();
                MessageBox.Show(txtbscore.Text);
                this.Close();
            }
            
        }

        
    }
}

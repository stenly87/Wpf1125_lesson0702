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

namespace Wpf1125_lesson0702
{
    /// <summary>
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        // обычное свойство
        public int Test { get; set; }

        // свойство, поддерживающее привязку
        public string FIO
        {
            get { return (string)GetValue(FIOProperty); }
            set { SetValue(FIOProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FIO.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FIOProperty =
            DependencyProperty.Register("FIO", typeof(string), typeof(UserControl1), new PropertyMetadata(""));

        public UserControl1()
        {
            InitializeComponent();
            DataContext = this;
        }
    }
}

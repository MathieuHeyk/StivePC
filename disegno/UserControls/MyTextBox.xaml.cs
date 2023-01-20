using System.Windows;
using System.Windows.Controls;

namespace disegno.UserControls
{
    /// <summary>
    /// Logica di interazione per MyTextBox.xaml
    /// </summary>
    public partial class MyTextBox : UserControl
    {
        public MyTextBox()
        {
            InitializeComponent();
        }
        public string Hint
        {
            get { return (string)GetValue(HintProperty); }
            set { SetValue(HintProperty, value); }
        }
        public static readonly DependencyProperty HintProperty = DependencyProperty.Register
            ("hint", typeof(string), typeof(MyTextBox));
    }

}

    
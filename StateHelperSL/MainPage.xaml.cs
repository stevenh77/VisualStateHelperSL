using System.Windows;

namespace StateHelperSL
{
    public partial class MainPage
    {
        private readonly ViewModel vm;

        public MainPage()
        {
            this.InitializeComponent();
            this.vm = new ViewModel();
            this.DataContext = this.vm;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            vm.State = "Gone";
        }
    }
}
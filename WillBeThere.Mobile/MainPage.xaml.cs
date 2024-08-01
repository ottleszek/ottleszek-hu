using WillBeThere.Mobile.ViewModel;
using WillBeThere.Shared.Helper;

namespace WillBeThere.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            this.BindingContext = ServiceHelper.GetService<MainPageViewModel>();
        }
    }
}

namespace MenaDExamen3
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel viewModel = new MainPageViewModel();
        public MainPage()
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            viewModel.AddDispositivo();
        }
    }

}

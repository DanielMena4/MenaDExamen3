namespace MenaDExamen3;

public partial class ListadoPage : ContentPage
{
	public ListadoPage()
	{
		InitializeComponent();
        BindingContext = new ListadoPageViewModel();
    }
}
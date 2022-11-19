namespace ToDo.App;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}
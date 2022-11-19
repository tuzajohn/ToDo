using System.Collections.ObjectModel;

namespace ToDo.App.ViewModel;

public partial class MainViewModel : ObservableObject
{
    readonly IConnectivity connectivity;

    [ObservableProperty]
    ObservableCollection<string> items;

    [ObservableProperty]
    string text;

    [RelayCommand]
    async void Add()
    {
        if (string.IsNullOrEmpty(Text))
            return;

        if (connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh Oh!", "No internet", "Ok");
            return;
        }

        Items.Add(Text);

        Text = string.Empty;
    }

    [RelayCommand]
    void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }

    [RelayCommand]
    async Task Tap(string s)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
    }

    public MainViewModel(IConnectivity connectivity)
    {
        Items = new ObservableCollection<string>();
        this.connectivity = connectivity;
    }

}

﻿using ToDo.App.ViewModel;

namespace ToDo.App;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage(MainViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}


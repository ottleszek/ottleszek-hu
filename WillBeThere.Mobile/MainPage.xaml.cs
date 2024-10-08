﻿using WillBeThere.Mobile.ViewModels;
using WillBeThere.ApplicationLayer.Helpers;

namespace WillBeThere.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainPageViewModel? viewmodel = ServiceHelper.GetService<MainPageViewModel>();
            if (viewmodel is not null)
            {
                this.BindingContext=viewmodel;
            }
        }
    }
}

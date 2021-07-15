using System;
using System.Collections.Generic;
using Nuxiba_testdevjr_1.app.ViewModels;
using Nuxiba_testdevjr_1.Models;
using Xamarin.Forms;

namespace Nuxiba_testdevjr_1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            var vm = this.BindingContext as UsersViewModel;
            vm.Navigation = Navigation;
        }
    }
}

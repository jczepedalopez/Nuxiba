using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Nuxiba_testdevjr_1.Models;
using Xamarin.Forms;

namespace Nuxiba_testdevjr_1.app.ViewModels
{
    public class UsersViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Users> Users { get; set; }

        public UsersViewModel()
        {
            this.Users = new ObservableCollection<Users>();            
        }

        public ICommand SearchUsersCommand
        {
            get
            {
                return new Command(async x => {
                    var list = await new RestService().GetAllUsersAsync();
                    foreach (var item in list)
                    {
                        this.Users.Add(item);
                    }                    
                });
            }
        }

        public ICommand SearchUserCommand
        {
            get
            {
                return new Command(async (user) => {
                    ContentPage userPage = new UserPage();
                    var vm = new UserViewModel(user as Users);
                    vm.Navigation = this.Navigation;
                    userPage.BindingContext = vm;
                    await this.Navigation.PushAsync(userPage);                    
                });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

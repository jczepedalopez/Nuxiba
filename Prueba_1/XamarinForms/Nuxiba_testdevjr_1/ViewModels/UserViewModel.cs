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
    public class UserViewModel : INotifyPropertyChanged
    {
        public Users User { get; set; }
        public INavigation Navigation { get; set; }
        public ObservableCollection<Posts> Posts { get; set; }
        public ObservableCollection<Todos> Todos { get; set; }


        public UserViewModel(Users user)
        {            
            this.User = user;
        }

        public ICommand TodosCommand
        {
            get
            {
                return new Command(async x => {
                    var list = await new RestService().GetAllTodosByUserAsync(this.User);
                    this.Todos = new ObservableCollection<Todos>();
                    foreach (var item in list)
                    {
                        this.Todos.Add(item);
                    }
                    var todosVm = new TodosViewModel();
                    todosVm.Navigation = this.Navigation;
                    todosVm.Todos = this.Todos;
                    ContentPage todosPage = new TodosPage();
                    todosPage.BindingContext = todosVm;
                    await this.Navigation.PushAsync(todosPage);
                });
            }
        }

        public ICommand PostsCommand
        {
            get
            {
                return new Command(async x => {
                    var list = await new RestService().GetAllPostsByUserAsync(this.User);
                    this.Posts = new ObservableCollection<Posts>();
                    foreach (var item in list)
                    {
                        this.Posts.Add(item);
                    }
                    var postVm = new PostsViewModel();
                    postVm.Navigation = this.Navigation;
                    postVm.Posts = this.Posts;
                    ContentPage postsPage = new PostsPage();
                    postsPage.BindingContext = postVm;
                    await this.Navigation.PushAsync(postsPage);
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

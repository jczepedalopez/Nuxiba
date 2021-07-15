using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Nuxiba_testdevjr_1.Models;
using Xamarin.Forms;

namespace Nuxiba_testdevjr_1.app.ViewModels
{
    public class TodosViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Todos> Todos { get; set; }        

        private string _userId;
        public string UserId
        {
            get => _userId;
            private set
            {
                _userId = value;
                OnPropertyChanged();
            }
        }

        private string _id;
        public string Id
        {
            get => _id;
            private set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        private string _title;
        public string Title
        {
            get => _title;
            private set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private bool _completed;
        public bool Completed
        {
            get => _completed;
            private set
            {
                _completed = value;
                OnPropertyChanged();
            }
        }

        private bool _formVisible;
        public bool FormVisible
        {
            get => _formVisible;
            private set
            {
                _formVisible = value;
                OnPropertyChanged();
            }
        }

        public TodosViewModel()
        {
            this.Todos = new ObservableCollection<Todos>();            
        }

        public ICommand AddCommand
        {
            get
            {
                return new Command(async x => {
                    this.FormVisible = !this.FormVisible;
                });
            }
        }

        public ICommand SaveTodoCommand
        {
            get
            {
                return new Command(async x => {
                    this.Id = "1";
                    this.UserId = "1";
                    this.Title = "mi titulo";
                    this.Completed = true;
                    var todo = new Todos { Id = this.Id, UserId = this.UserId, Title = this.Title, Completed = this.Completed };
                    await new RestService().PutTodo(todo);
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

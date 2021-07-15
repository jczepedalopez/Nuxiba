using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Nuxiba_testdevjr_1.Models;
using Xamarin.Forms;

namespace Nuxiba_testdevjr_1.app.ViewModels
{
    public class PostsViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }
        public ObservableCollection<Posts> Posts { get; set; }

        public PostsViewModel()
        {
            this.Posts = new ObservableCollection<Posts>();            
        }        

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

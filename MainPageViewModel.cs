using CommunityToolkit.Mvvm.ComponentModel;
using MAUIPlayListAnimation.Models;
using System.Collections.ObjectModel;

namespace MAUIPlayListAnimation
{
    public partial class MainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<PlayList> recentPlayList = new ObservableCollection<PlayList>();
        public MainPageViewModel()
        {
            RecentPlayList = new ObservableCollection<PlayList>
            {
                new PlayList { Id = 1, ImageURL = "image_1.jpeg"},
                new PlayList { Id = 2, ImageURL = "image_2.jpeg"},
                new PlayList { Id = 3, ImageURL = "image_3.jpeg"},
                new PlayList { Id = 4, ImageURL = "image_4.jpeg"},
            };
        }
    }
}

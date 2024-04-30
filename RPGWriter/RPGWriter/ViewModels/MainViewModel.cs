using ReactiveUI;
using System.Collections.ObjectModel;

namespace RPGWriter.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<ItemViewModel> Topics { get; set; }

        private PageViewModelBase currentPage;

        private SubjectPageViewModel subject;
        private StoryPageViewModel story;
        private RolePageViewModel role;
        private WorldPageViewModel world;

        public MainViewModel()
        {
            Topics = new ObservableCollection<ItemViewModel>()
            {
                new("主题", () => {
                    subject ??= new SubjectPageViewModel();
                    CurrentPage = subject;
                }),
                new("故事", () => { 
                    story ??= new StoryPageViewModel();
                    CurrentPage = story;
                }),
                new("角色", () => { 
                    role ??= new RolePageViewModel();
                    CurrentPage = role;
                }),
                new("世界", () => { 
                    world ??= new WorldPageViewModel();
                    CurrentPage = world;
                }),
            };

            Topics[0].Command.Execute(null);
        }

        public PageViewModelBase CurrentPage
        {
            get { return currentPage; }
            private set { this.RaiseAndSetIfChanged(ref currentPage, value); }
        }

    }
}

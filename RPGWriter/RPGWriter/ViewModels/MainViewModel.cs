using ReactiveUI;
using RPGWriter.Services;
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
        private readonly UnitOfWork unitOfWork;

        public MainViewModel(UnitOfWork unitOfWork)
        {
            Topics = new ObservableCollection<ItemViewModel>()
            {
                new("主题", () => {
                    subject ??= new SubjectPageViewModel(unitOfWork);
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

            this.unitOfWork = unitOfWork;
        }

        public PageViewModelBase CurrentPage
        {
            get { return currentPage; }
            private set { this.RaiseAndSetIfChanged(ref currentPage, value); }
        }

    }
}

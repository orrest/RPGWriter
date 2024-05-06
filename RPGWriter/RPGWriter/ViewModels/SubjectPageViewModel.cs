using ReactiveUI;
using RPGWriter.Models;
using RPGWriter.Services;
using System.Windows.Input;

namespace RPGWriter.ViewModels
{
    public class SubjectPageViewModel : PageViewModelBase
	{
        private readonly UnitOfWork uow;
        private Subject subject;
        private string content;

        public SubjectPageViewModel(UnitOfWork uow)
        {
            this.uow = uow;

            subject = uow.Subjects.FindById(1);

            content = subject.Content;

            SaveCommand = ReactiveCommand.Create(Save);
        }

        public string Content
        {
            get { return content; }
            set { this.RaiseAndSetIfChanged(ref content, value); }
        }

        public ICommand SaveCommand { get; }

        private void Save()
        {
            subject.Content = content;
         
            uow.Transaction(() =>
            {
                var updated = uow.Subjects.Update(1, subject);
                if (!updated)
                {
                    uow.Subjects.Insert(1, subject);
                }
            });
        }
    }
}
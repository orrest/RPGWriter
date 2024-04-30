using ReactiveUI;

namespace RPGWriter.ViewModels
{
    public class SubjectPageViewModel : PageViewModelBase
	{
        private string subject;

        public SubjectPageViewModel()
        {
            subject = "TODO from db";    
        }

        public string Subject
        {
            get { return subject; }
            private set { this.RaiseAndSetIfChanged(ref subject, value); }
        }
    }
}
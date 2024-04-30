namespace RPGWriter.ViewModels
{
    public class SubjectPageViewModel : PageViewModelBase
	{
        /// <summary>
        /// The Title of this page
        /// </summary>
        public string Title => nameof(SubjectPageViewModel);
            
        /// <summary>
        /// The content of this page
        /// </summary>
        public string Message => "Default View";
    }
}
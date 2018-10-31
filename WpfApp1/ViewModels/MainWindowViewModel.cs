namespace WpfApp1.ViewModels
{
    using Prism.Mvvm;

    public class MainWindowViewModel : BindableBase
    {
        private string title;

        public MainWindowViewModel()
        {
            this.title = "@MainWindowViewModel";
        }

        public MainWindowViewModel(string title)
        {
            this.title = title;
        }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }
    }
}

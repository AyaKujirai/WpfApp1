namespace WpfApp1.ViewModels
{
    using System;

    using Prism.Commands;
    using Prism.Ioc;
    using Prism.Mvvm;
    using Prism.Regions;

    using WpfApp1.Views;

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

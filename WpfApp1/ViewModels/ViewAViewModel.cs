using System;

namespace WpfApp1.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;

    public class ViewAViewModel : BindableBase
    {
        private bool isChecked;

        private bool isToggled;

        private string updateText;

        private string title = "ViewA";

        public ViewAViewModel()
        {
            this.ExecuteDelegateCommand = new DelegateCommand(this.Execute, this.CanExecute)
                .ObservesProperty(() => this.IsChecked).ObservesProperty(() => this.IsToggled);
            this.DelegateCommandObservesProperty =
                new DelegateCommand(this.Execute, this.CanExecute).ObservesProperty(() => this.IsChecked);
            this.DelegateCommandObservesCanExecute =
                new DelegateCommand(this.Execute).ObservesCanExecute(() => this.IsChecked);
            this.ExecuteGenericDelegateCommand =
                new DelegateCommand<string>(this.ExecuteGeneric).ObservesCanExecute(() => this.IsChecked);
        }

        public bool IsChecked
        {
            get => this.isChecked;
            set => this.SetProperty(ref this.isChecked, value);
        }

        public bool IsToggled
        {
            get => this.isToggled;
            set => this.SetProperty(ref this.isToggled, value);
        }

        public string UpdateText
        {
            get => this.updateText;
            set => this.SetProperty(ref this.updateText, value);
        }

        public string Title
        {
            get => this.title;
            set => this.SetProperty(ref this.title, value);
        }

        public DelegateCommand ExecuteDelegateCommand { get; }

        public DelegateCommand<string> ExecuteGenericDelegateCommand { get; }

        public DelegateCommand DelegateCommandObservesProperty { get; }

        public DelegateCommand DelegateCommandObservesCanExecute { get; }

        private void Execute() => this.UpdateText = $"Updated: {DateTime.Now}";

        private void ExecuteGeneric(string parameter) => this.UpdateText = parameter;

        private bool CanExecute() => (this.IsChecked && this.IsToggled);
    }
}

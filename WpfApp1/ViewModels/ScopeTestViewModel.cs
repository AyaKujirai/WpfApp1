using System.Text;

namespace WpfApp1.ViewModels
{
    using System.Windows.Input;

    using Prism.Commands;
    using Prism.Ioc;
    using Prism.Mvvm;
    using WpfApp1.Models;

    public class ScopeTestViewModel : BindableBase
    {
        private string text;

        private readonly IContainerExtension container;

        public ScopeTestViewModel(IContainerExtension container)
        {
            this.RegisterTypeCommand = new DelegateCommand(this.RegisterType);
            this.container = container;
        }

        public string Text
        {
            get => this.text;
            set => this.SetProperty(ref this.text, value);
        }

        public ICommand RegisterTypeCommand { get; }

        private void RegisterType()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var writer = this.container.Resolve<ISample>();
            stringBuilder.AppendLine(writer.GetContents("----------Register1-------------"));
            stringBuilder.AppendLine($"{writer.InstanceId}");

            var writer2 = this.container.Resolve<ISample>();
            stringBuilder.AppendLine(writer2.GetContents("----------Register2-------------"));
            stringBuilder.AppendLine($"{writer2.InstanceId}");

            var writer3 = this.container.Resolve<ISample>("Sample2");
            stringBuilder.AppendLine(writer3.GetContents("----------Register3-------------"));
            stringBuilder.AppendLine($"{writer3.GetContents("")} {writer3.InstanceId}");

            var writer4 = this.container.Resolve<ISample>("Sample2");
            stringBuilder.AppendLine(writer4.GetContents("----------Register4-------------"));
            stringBuilder.AppendLine($"{writer4.GetContents("")} {writer4.InstanceId}");

            var writer5 = this.container.Resolve<ISample3>();
            stringBuilder.AppendLine(writer5.GetContents("----------RegisterInstance1-------------"));
            stringBuilder.AppendLine($"{writer5.GetContents("")} {writer5.InstanceId}");

            var writer6 = this.container.Resolve<ISample3>();
            stringBuilder.AppendLine(writer6.GetContents("----------RegisterInstance2-------------"));
            stringBuilder.AppendLine($"{writer6.GetContents("")} {writer6.InstanceId}");

            var writer7 = this.container.Resolve<ISample4>();
            stringBuilder.AppendLine(writer7.GetContents("----------RegisterSingleton1-------------"));
            stringBuilder.AppendLine($"{writer7.GetContents("")} {writer7.InstanceId}");

            var writer8 = this.container.Resolve<ISample4>();
            stringBuilder.AppendLine(writer8.GetContents("----------RegisterSingleton2-------------"));
            stringBuilder.AppendLine($"{writer8.GetContents("")} {writer8.InstanceId}");

            this.Text = stringBuilder.ToString();
        }
    }
}

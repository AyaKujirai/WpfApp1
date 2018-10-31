using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModels
{
    using System.Windows.Input;

    using WpfApp1.Models;
    
    using DryIoc;

    using Prism.Commands;
    using Prism.DryIoc.Ioc;
    using Prism.Ioc;
    using Prism.Mvvm;

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

        public ICommand RegisterTypeCommand { get; set; }

        public void RegisterType()
        {
            StringBuilder stringBuilder = new StringBuilder();

            var writer = this.container.Resolve<ISample>();
            stringBuilder.AppendLine(writer.GetContents("----------Register1-------------"));
            stringBuilder.AppendLine($"{writer.InstanceID()}");

            var writer2 = this.container.Resolve<ISample>();
            stringBuilder.AppendLine(writer2.GetContents("----------Register2-------------"));
            stringBuilder.AppendLine($"{writer2.InstanceID()}");

            var writer3 = this.container.Resolve<ISample>("Sample2");
            stringBuilder.AppendLine(writer3.GetContents("----------Register3-------------"));
            stringBuilder.AppendLine($"{writer3.GetContents("")} {writer3.InstanceID()}");

            var writer4 = this.container.Resolve<ISample>("Sample2");
            stringBuilder.AppendLine(writer4.GetContents("----------Register4-------------"));
            stringBuilder.AppendLine($"{writer4.GetContents("")} {writer4.InstanceID()}");

            var writer5 = this.container.Resolve<ISample3>();
            stringBuilder.AppendLine(writer5.GetContents("----------RegisterInstance1-------------"));
            stringBuilder.AppendLine($"{writer5.GetContents("")} {writer5.InstanceID()}");

            var writer6 = this.container.Resolve<ISample3>();
            stringBuilder.AppendLine(writer6.GetContents("----------RegisterInstance2-------------"));
            stringBuilder.AppendLine($"{writer6.GetContents("")} {writer6.InstanceID()}");

            var writer7 = this.container.Resolve<ISample4>();
            stringBuilder.AppendLine(writer7.GetContents("----------RegisterSingleton1-------------"));
            stringBuilder.AppendLine($"{writer7.GetContents("")} {writer7.InstanceID()}");

            var writer8 = this.container.Resolve<ISample4>();
            stringBuilder.AppendLine(writer8.GetContents("----------RegisterSingleton2-------------"));
            stringBuilder.AppendLine($"{writer8.GetContents("")} {writer8.InstanceID()}");

            using (var container2 = new Container())
            {
                container2.Register(typeof(ISample), typeof(Sample));
                //container2.UseInstance(typeof(ISample), new Sample());
                using (var scope = container2.OpenScope())
                {
                    var writer9 = scope.Resolve(typeof(ISample)) as ISample;
                    stringBuilder.AppendLine(writer9?.GetContents("----------OpenScope1-------------"));
                    stringBuilder.AppendLine($"{writer9?.GetContents("")} {writer9?.InstanceID()}");

                    var writer10 = scope.Resolve(typeof(ISample)) as ISample;
                    stringBuilder.AppendLine(writer10?.GetContents("----------OpenScope2-------------"));
                    stringBuilder.AppendLine($"{writer10?.GetContents("")} {writer10?.InstanceID()}");

                    using (var scope2 = container2.OpenScope())
                    {
                        var writer11 = scope2.Resolve(typeof(ISample)) as ISample;
                        stringBuilder.AppendLine(writer11?.GetContents("----------OpenScope3-------------"));
                        stringBuilder.AppendLine($"{writer11?.GetContents("")} {writer11?.InstanceID()}");
                    }

                    using (var scope3 = container2.OpenScope())
                    {
                        var writer12 = scope3.Resolve(typeof(ISample)) as ISample;
                        stringBuilder.AppendLine(writer12?.GetContents("----------OpenScope4-------------"));
                        stringBuilder.AppendLine($"{writer12?.GetContents("")} {writer12?.InstanceID()}");
                    }
                }
            }

            this.Text = stringBuilder.ToString();
        }
    }
}

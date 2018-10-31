using System.Windows;

namespace WpfApp1
{
    using Prism.Ioc;

    using WpfApp1.Models;
    using WpfApp1.ViewModels;
    using WpfApp1.Views;

    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell() => this.Container.Resolve<ScopeTestView>();

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register(typeof(ICalc), typeof(Calc));
            containerRegistry.RegisterInstance(typeof(MainWindowViewModel), new MainWindowViewModel("@App.xaml_RegisterTypes"));
            containerRegistry.RegisterInstance(typeof(ViewA), new ViewA());
            containerRegistry.RegisterSingleton(typeof(ViewB), typeof(ViewB));

            containerRegistry.Register(typeof(ISample), typeof(Sample));
            containerRegistry.Register(typeof(ISample), typeof(Sample2), "Sample2");
            containerRegistry.RegisterInstance(typeof(ISample3), new Sample3());
            containerRegistry.RegisterSingleton(typeof(ISample4), typeof(Sample4));
        }
    }
}

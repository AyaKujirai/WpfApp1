using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1
{
    using System.Reflection;

    using CommonServiceLocator;

    using Prism.Ioc;
    using Prism.Mvvm;
    using Prism.Regions;

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

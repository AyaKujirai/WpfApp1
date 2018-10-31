using System.Windows;

namespace WpfApp1.Views
{
    using Prism.Ioc;
    using Prism.Regions;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow
    {
        private readonly IContainerExtension container;

        private readonly IRegionManager regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            this.InitializeComponent();
            this.container = container;
            this.regionManager = regionManager;

            this.Loaded += this.MainWindowLoaded;
        }

        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            var region = this.regionManager.Regions["ContentRegion"];
            region.Add(this.container.Resolve<ViewA>());
            region.Add(this.container.Resolve<ViewB>());
        }
    }
}

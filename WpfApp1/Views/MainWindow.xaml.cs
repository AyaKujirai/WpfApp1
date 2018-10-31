using System.Windows;

namespace WpfApp1.Views
{
    using Prism.Ioc;
    using Prism.Regions;

    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        private IContainerExtension container;

        private IRegionManager regionManager;

        public MainWindow(IContainerExtension container, IRegionManager regionManager)
        {
            this.InitializeComponent();
            this.container = container;
            this.regionManager = regionManager;

            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var region = this.regionManager.Regions["ContentRegion"];
            region.Add(this.container.Resolve<ViewA>());
            region.Add(this.container.Resolve<ViewB>());
        }
    }
}

namespace Gajda.NovemberTests.Client
{
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs args)
        {
            Current.DispatcherUnhandledException += this.AppDispatcherUnhandledException;
            base.OnStartup(args);
        }

        protected override void OnExit(ExitEventArgs args)
        {
            Current.DispatcherUnhandledException -= this.AppDispatcherUnhandledException;
            base.OnExit(args);
        }

        private void AppDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs args)
        {
            System.Console.WriteLine(args.Exception.Message);
            args.Handled = true;
        }
    }
}

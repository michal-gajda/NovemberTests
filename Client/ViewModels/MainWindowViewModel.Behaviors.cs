namespace Gajda.NovemberTests.Client.ViewModels
{
    using System.Windows;
    using System.Windows.Input;

    using Gajda.NovemberTests.Client.Extensions;

    public partial class MainWindowViewModel
    {
        public ICommand ExitCommand
        {
            get
            {
                return new RelayCommand(
                    parameter =>
                        {
                            Application.Current.Shutdown();
                        });
            }
        }
    }
}

using Prism.Commands;
using Prism.Mvvm;
using System.Windows.Input;

namespace PrismApplication.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private string _title;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public ICommand CloseApplicationCommand { get; private set; }

        public ShellViewModel()
        {
            Title = "First prism application!";
            CloseApplicationCommand = new DelegateCommand(CloseApplication);
        }

        private void CloseApplication()
        {
            App.Current.Shutdown();
        }
    }
}

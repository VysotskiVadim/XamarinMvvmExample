using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using App4.Core.Services;
using GalaSoft.MvvmLight.Command;

namespace App4.Core.ViewModels
{
    public class ViewModel : INotifyPropertyChanged
    {
        private readonly ISecondService _secondService;

        private bool _canStart;
        private int _number;

        public int Number
        {
            get { return _number; }
            private set
            {
                if (value != _number)
                {
                    _number = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand StartCommand { get; }

        public ViewModel(ISecondService secondService)
        {
            _secondService = secondService;

            _canStart = true;
            StartCommand = new RelayCommand(async () => await Start(), () => _canStart);
        }

        public async Task Start()
        {
            _canStart = false;
            while (true)
            {
                await _secondService.WaitASecond();
                Number++;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

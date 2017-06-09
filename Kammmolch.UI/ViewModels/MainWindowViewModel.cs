using Kammmolch.Core;
using Kammmolch.Core.Models;
using System.Collections.Generic;
using System.Windows.Input;

namespace Kammmolch.UI.ViewModels
{
    internal class MainWindowViewModel : ViewModelBase
    {
        private ICommand _loadDataCommand;
        private ICommand _saveDataCommand;
        private readonly IUnitOfWork _unitOfWork;

        public MainWindowViewModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ICommand LoadDataCommand => 
            _loadDataCommand ?? (_loadDataCommand = new RelayCommand(
                () => Customers = _unitOfWork.Customers.GetAll()));

        public ICommand SaveDataCommand =>
            _saveDataCommand ?? (_saveDataCommand = new RelayCommand(_unitOfWork.Complete));


        private IEnumerable<Customer> _customers;
        public IEnumerable<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged();
            }
        }

    }
}

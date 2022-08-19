using Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Core.ViewModels
{
    public class GuestInfoViewModel : MvxViewModel<Person, Person>
    {
        private readonly IMvxNavigationService _navigationService;

        private Person _guest;
        public Person Guest
        {
            get { return _guest; }
            set
            {
                _guest = value;
                RaisePropertyChanged(() => Guest);
            }
        }

        public GuestInfoViewModel(IMvxNavigationService navigationService)
        {
            _navigationService = navigationService;
            DeleteGuestCommand = new MvxCommand(async () => await DeleteGuest());
            ReturnToMainCommand = new MvxCommand(async () => await ReturnToMain());
        }
        public IMvxCommand DeleteGuestCommand { get; set; }
        public IMvxCommand ReturnToMainCommand { get; set; }

        public override void Prepare(Person parameter)
        {
            Guest = parameter;
            FirstName = parameter.FirstName;
            LastName = parameter.LastName;
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
            }
        }

        public async Task DeleteGuest()
        {
            await _navigationService.Close(this, Guest);
        }

        public async Task ReturnToMain()
        {
            await _navigationService.Close(this, null);
        }
    }
}

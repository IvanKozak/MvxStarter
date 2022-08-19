using Core.Models;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Core.ViewModels
{
	public class GuestBookViewModel : MvxViewModel
	{
		private readonly IMvxNavigationService _navigationService;

		public GuestBookViewModel(IMvxNavigationService navigationService)
		{
			_navigationService = navigationService;
			AddGuestCommand = new MvxCommand(AddGuest);
			ViewPersonInfoCommand = new MvxCommand(async () => await ViewPersonInfo());
		}

		public IMvxCommand AddGuestCommand { get; set; }
		public IMvxCommand ViewPersonInfoCommand { get; set; }
		private ObservableCollection<Person> _people = new ObservableCollection<Person>();


		public ObservableCollection<Person> People
		{
			get { return _people; }
			set
			{
				SetProperty(ref _people, value);
			}
		}

		private string _firstName;

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				SetProperty(ref _firstName, value);
				RaisePropertyChanged(() => FullName);
				RaisePropertyChanged(() => CanAddGuest);
			}
		}

		private string _lastName;

		public string LastName
		{
			get { return _lastName; }
			set
			{
				SetProperty(ref _lastName, value);
				RaisePropertyChanged(() => FullName);
				RaisePropertyChanged(() => CanAddGuest);
			}
		}

		public string FullName => $"{FirstName} {LastName}";

		private Person _selectedPerson;
		public Person SelectedPerson
		{
			get { return _selectedPerson; }
			set
			{
				_selectedPerson = value;
				RaisePropertyChanged(() => SelectedPerson);
				RaisePropertyChanged(() => CanViewInfo);
			}
		}
		public bool CanAddGuest => FirstName?.Length > 0 && LastName?.Length > 0;
		public bool CanViewInfo => _selectedPerson != null;

		public void AddGuest()
		{
			if (CanAddGuest == false)
			{
				return;
			}

			var p = new Person
			{
				FirstName = FirstName,
				LastName = LastName,
			};

			FirstName = string.Empty;
			LastName = string.Empty;

			People.Add(p);
		}

		private void DeleteGuest(Person guest)
		{
			People.Remove(guest);
		}
		private async Task ViewPersonInfo()
		{
			var result = await _navigationService.Navigate<GuestInfoViewModel, Person, Person>(SelectedPerson);
			if (result != null)
			{
				DeleteGuest(result);
			}
		}
	}
}

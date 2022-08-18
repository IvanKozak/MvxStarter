using Core.Models;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace Core.ViewModels
{
	public class GuestBookViewModel : MvxViewModel
	{

		public IMvxCommand AddGuestCommand { get; set; }

		public GuestBookViewModel()
		{
			AddGuestCommand = new MvxCommand(AddGuest);
		}

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

		public bool CanAddGuest => FirstName?.Length > 0 && LastName?.Length > 0;

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
	}
}

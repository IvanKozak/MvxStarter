using Core.Models;
using MvvmCross.ViewModels;
using System.Collections.ObjectModel;

namespace Core.ViewModels
{
	public class GuestBookViewModel : MvxViewModel
	{
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
			}
		}

		public string FullName => $"{FirstName} {LastName}";
	}
}

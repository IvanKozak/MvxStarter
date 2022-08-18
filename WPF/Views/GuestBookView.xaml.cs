using Core.ViewModels;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for GuestBookView.xaml
    /// </summary>
    [MvxContentPresentation]
    [MvxViewFor(typeof(GuestBookViewModel))]
    public partial class GuestBookView : MvxWpfView
    {
        public GuestBookView()
        {
            InitializeComponent();
        }
    }
}

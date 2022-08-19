using Core.ViewModels;
using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.ViewModels;

namespace WPF.Views
{
    /// <summary>
    /// Interaction logic for GuestInfoView.xaml
    /// </summary>

    [MvxContentPresentation]
    [MvxViewFor(typeof(GuestInfoViewModel))]
    public partial class GuestInfoView : MvxWpfView
    {
        public GuestInfoView()
        {
            InitializeComponent();
        }
    }
}

using WoodenMoose.ViewModels.PartialViews;

namespace WoodenMoose.Views.PartialViews
{
    public sealed partial class SummaryView
    {
        public SummaryView()
        {
            InitializeComponent();
            DataContextChanged += (s, e) => Bindings.Update();
        }

        public SummaryViewViewModel ViewModel => DataContext as SummaryViewViewModel;
    }
}

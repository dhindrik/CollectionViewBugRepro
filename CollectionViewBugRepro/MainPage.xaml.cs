using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CollectionViewBugRepro
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var viewModel = new MainViewModel();
            viewModel.Navigation = Navigation;

            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            Cars.SelectionChanged += Cars_SelectionChanged;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            Cars.SelectionChanged -= Cars_SelectionChanged;
        }

        private void Cars_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Cars.SelectedItem == null)
            {
                Cars.SelectedItem = null;
            }
        }
    }
}

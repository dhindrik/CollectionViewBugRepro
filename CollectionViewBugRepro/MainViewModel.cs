using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace CollectionViewBugRepro
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public INavigation Navigation { get; set; }

        public ObservableCollection<string> Items { get; set; }

        public MainViewModel()
        {
            Items = new ObservableCollection<string>()
            {
                "Audi",
                "BMW",
                "Mercedes",
                "Volvo",
                "Toyota"
            };

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Items)));
        }

  

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ItemSelected => new Command<string>((car) =>
        {
            Navigation.PushAsync(new CarView());   
        });
    }
}

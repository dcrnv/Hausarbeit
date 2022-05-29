using DSH.Core;

namespace DSH.MVVM.ViewModel
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand MitarbeiterEinsehenCommand { get; set; }
        public RelayCommand MiVerwaltenCommand { get; set; }
        public RelayCommand MaterialEinsehenCommand { get; set; }
        public RelayCommand MaterialVerwaltenCommand { get; set; }
        public RelayCommand ArbeitsplanErstellenCommand { get; set; }
        public RelayCommand ArbeitsplanEinsehenCommand { get; set; }
        public RelayCommand ArbeitsplanDruckenCommand { get; set; }

        public HomeViewModel HomeVM { get; set; }
        public MitarbeiterEinsehenViewModel MitarbeiterEinsehenVM { get; set; }
        public MiVerwaltenViewModel MiVerwaltenVM { get; set; }
        public MaterialEinsehenViewModel MaterialEinsehenVM { get; set; }
        public MaterialVerwaltenViewModel MaterialVerwaltenVM { get; set; }
        public ArbeitsplanErstellenViewModel ArbeitsplanErstellenVM { get; set; }
        public ArbeitsplanEinsehenViewModel ArbeitsplanEinsehenVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            HomeVM = new HomeViewModel();

            MitarbeiterEinsehenVM = new MitarbeiterEinsehenViewModel();

            MiVerwaltenVM = new MiVerwaltenViewModel(); HomeVM = new HomeViewModel();

            MaterialEinsehenVM = new MaterialEinsehenViewModel();

            MaterialVerwaltenVM = new MaterialVerwaltenViewModel();

            ArbeitsplanErstellenVM = new ArbeitsplanErstellenViewModel();

            ArbeitsplanEinsehenVM = new ArbeitsplanEinsehenViewModel();


            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            }
            );

            MitarbeiterEinsehenCommand = new RelayCommand(o =>
            {
                CurrentView = MitarbeiterEinsehenVM;
            }
            );

            MiVerwaltenCommand = new RelayCommand(o =>
            {
                CurrentView = MiVerwaltenVM;
            }
            );

            MaterialEinsehenCommand = new RelayCommand(o =>
            {
                CurrentView = MaterialEinsehenVM;
            }
            );

            MaterialVerwaltenCommand = new RelayCommand(o =>
                       {
                           CurrentView = MaterialVerwaltenVM;
                       }
            );

            ArbeitsplanErstellenCommand = new RelayCommand(o =>
            {
                CurrentView = ArbeitsplanErstellenVM;
            }
            );

            ArbeitsplanEinsehenCommand = new RelayCommand(o =>
            {
                CurrentView = ArbeitsplanEinsehenVM;
            }
            );
        }
    }
}

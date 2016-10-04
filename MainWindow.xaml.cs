using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Arcan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class Arcan_VM:INotifyPropertyChanged
    {
        #region Data
        private int _Personal;
        private int _GuardianAngel;
        private int _GiftAfter40;
        private int _MainFromPast;
        private int _Father1stPoint;
        private int _Mother2ndPoint;
        private int _Father2ndPoint;
        private int _Mother1stPoint;
        private int _ComfortPoint;
        private int _PastLife1stPoint;
        private int _Money1stPoint;
        private int _MoneyEnter;
        private int _Love2ndPoint;
        private int _Money2ndPoint;
        private int _PastLife2ndPoint;
        private int _Sky;
        private int _Land;
        private int _FirstMission;
        private int _Man;
        private int _Woman;
        private int _SecondMission;
        private int _CommonMission;
        private int _Adjna;
        private int _Vishudha;
        private int _Anahata;
        private int _HelthAdjna;
        private int _HelthVishudha;
        private int _HelthAnahata;
        private string _Name;
        private DateTime _Birthday;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Data
        public Arcan_VM()
        {
            Personal = 1;GuardianAngel = 2;GiftAfter40 = 3;MainFromPast = 4;Father1stPoint = 5;Mother2ndPoint = 6;Father2ndPoint = 7;Mother1stPoint = 8;ComfortPoint = 9;PastLife1stPoint = 10;Money1stPoint = 11;MoneyEnter = 12;Love2ndPoint = 13;Money2ndPoint = 14;PastLife2ndPoint = 15;
            _Adjna = 1; _Vishudha = 1; _Anahata = 1;
            Sky = 16;Land = 17;FirstMission = 18; Man = 19;Woman = 20;SecondMission = 21;CommonMission = 22;
            Name = "Name";Birthday = DateTime.Now;
            //DateChanged = new RelayCommand(arg => DateChanged_Executed());
        }
        public int Personal
        {
            get { return _Personal; }
            set
            {
                _Personal = value;
                OnPropertyChanged("Personal");
            }
        }
        public int GuardianAngel { get { return _GuardianAngel; } set { _GuardianAngel = value; OnPropertyChanged("GuardianAngel"); } }
        public int GiftAfter40 { get { return _GiftAfter40; } set { _GiftAfter40 = value; OnPropertyChanged("GiftAfter40"); } }
        public int MainFromPast { get { return _MainFromPast; } set { _MainFromPast = value; OnPropertyChanged("MainFromPast"); } }
        public int Father1stPoint { get { return _Father1stPoint; } set { _Father1stPoint = value; OnPropertyChanged("Father1stPoint"); } }
        public int Mother2ndPoint { get { return _Mother2ndPoint; } set { _Mother2ndPoint = value; OnPropertyChanged("Mother2ndPoint"); } }
        public int Father2ndPoint { get { return _Father2ndPoint; } set { _Father2ndPoint = value; OnPropertyChanged("Father2ndPoint"); } }
        public int Mother1stPoint { get { return _Mother1stPoint; } set { _Mother1stPoint = value; OnPropertyChanged("Mother1stPoint"); } }
        public int ComfortPoint { get { return _ComfortPoint; } set { _ComfortPoint = value; OnPropertyChanged("ComfortPoint"); } }
        public int PastLife1stPoint { get { return _PastLife1stPoint; } set { _PastLife1stPoint = value; OnPropertyChanged("PastLife1stPoint"); } }
        public int Money1stPoint { get { return _Money1stPoint; } set { _Money1stPoint = value; OnPropertyChanged("Money1stPoint"); } }
        public int MoneyEnter { get { return _MoneyEnter; } set { _MoneyEnter = value; OnPropertyChanged("MoneyEnter"); } }
        public int Love2ndPoint { get { return _Love2ndPoint; } set { _Love2ndPoint = value; OnPropertyChanged("Love2ndPoint"); } }
        public int Money2ndPoint { get { return _Money2ndPoint; } set { _Money2ndPoint = value; OnPropertyChanged("Money2ndPoint"); } }
        public int PastLife2ndPoint { get { return _PastLife2ndPoint; } set { _PastLife2ndPoint = value; OnPropertyChanged("PastLife2ndPoint"); } }
        public int Sky { get { return _Sky; } set { _Sky = value; OnPropertyChanged("Sky"); } }
        public int Land { get { return _Land; } set { _Land = value; OnPropertyChanged("Land"); } }
        public int FirstMission { get { return _FirstMission; } set { _FirstMission = value; OnPropertyChanged("FirstMission"); } }
        public int Man { get { return _Man; } set { _Man = value; OnPropertyChanged("Man"); } }
        public int Woman { get { return _Woman; } set { _Woman = value; OnPropertyChanged("Woman"); } }
        public int SecondMission { get { return _SecondMission; } set { _SecondMission = value; OnPropertyChanged("SecondMission"); } }
        public int CommonMission { get { return _CommonMission; } set { _CommonMission = value; OnPropertyChanged("CommonMission"); } }
        public int Adjna { get { return _Adjna; } set { _Adjna = value; OnPropertyChanged("Adjna"); } }
        public int Vishudha { get { return _Vishudha; } set { _Vishudha = value; OnPropertyChanged("Vishudha"); } }
        public int Anahata { get { return _Anahata; } set { _Anahata = value; OnPropertyChanged("Anahata"); } }
        public int HelthAdjna { get { return _HelthAdjna; } set { _HelthAdjna = value; OnPropertyChanged("HelthAdjna"); } }
        public int HelthVishudha { get { return _HelthVishudha; } set { _HelthVishudha = value; OnPropertyChanged("HelthVishudha"); } }
        public int HelthAnahata { get { return _HelthAnahata; } set { _HelthAnahata = value; OnPropertyChanged("HelthAnahata"); } }
        public string Name { get { return _Name; } set { _Name = value; OnPropertyChanged("Name"); } }
        public DateTime Birthday
        {
            get { return _Birthday; }
            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value;
                    OnPropertyChanged("Birthday");
                    DateChanged_Executed();
                }
            }
        }

        //public ICommand DateChanged { get; set; }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void DateChanged_Executed()
        {
            if (Birthday == null) return;
            Personal = GetArcNum(Birthday.Day);
            GuardianAngel = Birthday.Month;
            GiftAfter40 = GetArcNum(Birthday.Year); // !!!!!!!!!!
            MainFromPast = GetArcNum(Personal + GuardianAngel + GiftAfter40);
            ComfortPoint = GetArcNum(Personal + GuardianAngel + GiftAfter40 + MainFromPast);
            Father1stPoint = GetArcNum(Personal + GuardianAngel);
            Mother2ndPoint = GetArcNum(GuardianAngel + GiftAfter40);
            Father2ndPoint = GetArcNum(MainFromPast + GiftAfter40);
            Mother1stPoint = GetArcNum(Personal + MainFromPast);
            PastLife1stPoint = GetArcNum(ComfortPoint + MainFromPast);
            PastLife2ndPoint = GetArcNum(PastLife1stPoint + MainFromPast);
            MoneyEnter = GetArcNum(ComfortPoint + GiftAfter40);
            Money1stPoint = GetArcNum(PastLife1stPoint + MoneyEnter);
            Love2ndPoint = GetArcNum(PastLife1stPoint + Money1stPoint);
            Money2ndPoint = GetArcNum(Money1stPoint + MoneyEnter);
            Sky = GetArcNum(GuardianAngel + MainFromPast);
            Land = GetArcNum(Personal + GiftAfter40);
            FirstMission = GetArcNum(Sky + Land);
            Woman = GetArcNum(Mother1stPoint + Mother2ndPoint);
            Man = GetArcNum(Father1stPoint + Father2ndPoint);
            SecondMission = GetArcNum(Man + Woman);
            CommonMission = GetArcNum(FirstMission + SecondMission);
            Vishudha = GetArcNum(GuardianAngel + ComfortPoint);
            Adjna = GetArcNum(GuardianAngel + Vishudha);
            Anahata = GetArcNum(Vishudha + ComfortPoint);
            HelthVishudha = GetArcNum(Personal + ComfortPoint);
            HelthAdjna = GetArcNum(Personal + HelthVishudha);
            HelthAnahata = GetArcNum(HelthVishudha + ComfortPoint);
        }
        private int GetArcNum(int num)
        {
            if (num < 0) num *= -1;// на всякий случай
            if (num <= 22) return num;
            List<int> lis = new List<int>();
            do
            {
                int tail = num % 10;
                num /= 10;
                lis.Add(tail);
            } while (num != 0);
            int sum = 0;
            foreach(int s in lis)
            {
                sum += s;
            }
            if (sum > 22)
                sum = GetArcNum(sum);
            return sum;
        }
    }
    /*public class RelayCommand : ICommand
    {
        public RelayCommand(Action<object> action)
        {
            ExecuteDelegate = action;
        }

        public Predicate<object> CanExecuteDelegate { get; set; }
        public Action<object> ExecuteDelegate { get; set; }

        public bool CanExecute(object parameter)
        {
            if (CanExecuteDelegate != null)
                return CanExecuteDelegate(parameter);
            else
                return true;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        public void Execute(object parameter)
        {
            if (ExecuteDelegate != null)
                ExecuteDelegate(parameter);
        }
    }*/
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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

    public static class Utils
    {
        public static int GetArcNum(int num)
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
            foreach (int s in lis)
            {
                sum += s;
            }
            if (sum > 22)
                sum = GetArcNum(sum);
            return sum;
        }
    }
    public class ObservableClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class ChakraItem : ObservableClass
    {
        private string _Name;
        private int _Land;
        private int _Sky;
        public ChakraItem() { }
        public ChakraItem(string name, int land, int sky)
        {
            _Name = name; _Land = land; _Sky = sky;
        }
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                OnPropertyChanged("Name");
            }
        }
        public int Land
        {
            get { return _Land; }
            set
            {
                _Land = value;
                OnPropertyChanged("Land");
                OnPropertyChanged("Total");
            }
        }
        public int Sky
        {
            get { return _Sky; }
            set
            {
                _Sky = value;
                OnPropertyChanged("Sky");
                OnPropertyChanged("Total");
            }
        }
        public int Total
        {
            get { return Utils.GetArcNum(_Sky + _Land); }
        }
        public string Plus
        {
            get { return "+"; }
        }
        public string Equal
        {
            get { return "="; }
        }
    }

    public class AgeItem
    {
        public float _Age;
        private int _Arcan;
        public AgeItem() { }
        public AgeItem(float age, int arcan)
        {
            _Age = age; _Arcan = arcan;
        }
        public float Age
        {
            get { return _Age; }
            set { _Age = value; }
        }
        public string AgeString
        {
            get
            {
                int fullyears = (int)_Age;
                int months = (int)((_Age % 1) * 1000);
                StringBuilder sb = new StringBuilder();
                sb.Append(fullyears);
                int i = fullyears % 10;
                switch (i)
                {
                    case 0: case 5: case 6: case 7: case 8: case 9:
                        sb.Append(" лет");
                        break;
                    case 1:
                        sb.Append(" год");
                        break;
                    case 2: case 3: case 4:
                        sb.Append(" года");
                        break;
                    default:
                        sb.Append(" лет");
                        break;
                }
                switch (months)
                {
                    case 125: sb.Append(" 1.5 месяца"); break;
                    case 250: sb.Append(" 3 месяца"); break;
                    case 375: sb.Append(" 4.5 месяца"); break;
                    case 500: sb.Append(" 6 месяцев"); break;
                    case 625: sb.Append(" 7.5 месяцев"); break;
                    case 750: sb.Append(" 9 месяцев"); break;
                    case 875: sb.Append(" 10.5 месяцев"); break;
                }
                return sb.ToString();
            }
        }
        public int Arcan
        {
            get { return _Arcan; }
            set { _Arcan = value; }
        }
        public string ArcanString
        {
            get { return _Arcan > 0 ? _Arcan.ToString() : string.Empty; }
        }
        #region Public Methods
        public static AgeItem GetMiddle(AgeItem bot, AgeItem top)
        {
            Debug.Assert(top.Age > bot.Age);
            float rest = top.Age - bot.Age;
            AgeItem ai = new AgeItem();
            ai.Age = bot.Age + rest / 2;
            ai.Arcan = Utils.GetArcNum(bot.Arcan + top.Arcan);
            return ai;
        }
        public static List<AgeItem> GetEightAges(AgeItem bot, AgeItem top)
        {
            List<AgeItem> res = new List<AgeItem>();
            for(int i = 0; i < 8; i++) { res.Add(new AgeItem()); }
            res[3] = GetMiddle(bot, top);
            res[1] = GetMiddle(bot, res[3]);
            res[0] = GetMiddle(bot, res[1]);
            res[2] = GetMiddle(res[1], res[3]);
            res[5] = GetMiddle(res[3], top);
            res[4] = GetMiddle(res[3], res[5]);
            res[6] = GetMiddle(res[5], top);
            res[7] = new AgeItem(top.Age, top.Arcan);
            return res;
        }
        public AgeItem Clone(AgeItem item)
        {
            return new AgeItem(item.Age, item.Arcan);
        }
        #endregion Public Methods
    }

    public class Arcan_VM : ObservableClass
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
        private int _HealthTotal;
        private string _Name;
        private DateTime _Birthday;
        private ObservableCollection<ChakraItem> _Chakras = new ObservableCollection<ChakraItem>();
        private List<AgeItem> _Years20 = new List<AgeItem>();
        private List<AgeItem> _Years40 = new List<AgeItem>();
        private List<AgeItem> _Years60 = new List<AgeItem>();
        private List<AgeItem> _Years80 = new List<AgeItem>();
        #endregion Data
        #region Constructor
        public Arcan_VM()
        {
            Personal = 1; GuardianAngel = 2; GiftAfter40 = 3; MainFromPast = 4; Father1stPoint = 5; Mother2ndPoint = 6; Father2ndPoint = 7; Mother1stPoint = 8;
            ComfortPoint = 9; PastLife1stPoint = 10; Money1stPoint = 11; MoneyEnter = 12; Love2ndPoint = 13; Money2ndPoint = 14; PastLife2ndPoint = 15;
            _Adjna = 1; _Vishudha = 1; _Anahata = 1;
            Sky = 16;Land = 17;FirstMission = 18; Man = 19;Woman = 20;SecondMission = 21;CommonMission = 22;
            Name = "Name";

            _Chakras.Add(new ChakraItem() { Name = "Сахасрара" });
            _Chakras.Add(new ChakraItem() { Name = "Аджна" });
            _Chakras.Add(new ChakraItem() { Name = "Вишудха" });
            _Chakras.Add(new ChakraItem() { Name = "Анахата" });
            _Chakras.Add(new ChakraItem() { Name = "Манипура" });
            _Chakras.Add(new ChakraItem() { Name = "Свадхистана" });
            _Chakras.Add(new ChakraItem() { Name = "Муладхара" });
            //DateChanged = new RelayCommand(arg => DateChanged_Executed());

            


            Birthday = DateTime.Now; // Старт вычисления
        }
        #endregion Constructor
        #region Properties
        public ObservableCollection<ChakraItem> ChakrasCV
        {
            get { return _Chakras; }
            set
            {
                _Chakras = value;
                OnPropertyChanged("ChakrasCV");
            }
        }
        public List<AgeItem> Years20CV
        {
            get { return _Years20; }
            set
            {
                _Years20 = value;
                OnPropertyChanged("Years20CV");
            }
        }
        public List<AgeItem> Years40CV
        {
            get { return _Years40; }
            set
            {
                _Years40 = value;
                OnPropertyChanged("Years40CV");
            }
        }
        public List<AgeItem> Years60CV
        {
            get { return _Years60; }
            set
            {
                _Years60 = value;
                OnPropertyChanged("Years60CV");
            }
        }
        public List<AgeItem> Years80CV
        {
            get { return _Years80; }
            set
            {
                _Years80 = value;
                OnPropertyChanged("Years80CV");
            }
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
        public int HealthTotal { get { return _HealthTotal; } set { _HealthTotal = value; OnPropertyChanged("HealthTotal"); } }
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
        #endregion Properties
        #region Methods
        private void DateChanged_Executed()
        {
            if (Birthday == null) return;
            Personal = Utils.GetArcNum(Birthday.Day);
            GuardianAngel = Birthday.Month;
            GiftAfter40 = Utils.GetArcNum(Birthday.Year); // !!!!!!!!!!
            MainFromPast = Utils.GetArcNum(Personal + GuardianAngel + GiftAfter40);
            ComfortPoint = Utils.GetArcNum(Personal + GuardianAngel + GiftAfter40 + MainFromPast);
            Father1stPoint = Utils.GetArcNum(Personal + GuardianAngel);
            Mother2ndPoint = Utils.GetArcNum(GuardianAngel + GiftAfter40);
            Father2ndPoint = Utils.GetArcNum(MainFromPast + GiftAfter40);
            Mother1stPoint = Utils.GetArcNum(Personal + MainFromPast);
            PastLife1stPoint = Utils.GetArcNum(ComfortPoint + MainFromPast);
            PastLife2ndPoint = Utils.GetArcNum(PastLife1stPoint + MainFromPast);
            MoneyEnter = Utils.GetArcNum(ComfortPoint + GiftAfter40);
            Money1stPoint = Utils.GetArcNum(PastLife1stPoint + MoneyEnter);
            Love2ndPoint = Utils.GetArcNum(PastLife1stPoint + Money1stPoint);
            Money2ndPoint = Utils.GetArcNum(Money1stPoint + MoneyEnter);
            Sky = Utils.GetArcNum(GuardianAngel + MainFromPast);
            Land = Utils.GetArcNum(Personal + GiftAfter40);
            FirstMission = Utils.GetArcNum(Sky + Land);
            Woman = Utils.GetArcNum(Mother1stPoint + Mother2ndPoint);
            Man = Utils.GetArcNum(Father1stPoint + Father2ndPoint);
            SecondMission = Utils.GetArcNum(Man + Woman);
            CommonMission = Utils.GetArcNum(FirstMission + SecondMission);
            Vishudha = Utils.GetArcNum(GuardianAngel + ComfortPoint);
            Adjna = Utils.GetArcNum(GuardianAngel + Vishudha);
            Anahata = Utils.GetArcNum(Vishudha + ComfortPoint);
            HelthVishudha = Utils.GetArcNum(Personal + ComfortPoint);
            HelthAdjna = Utils.GetArcNum(Personal + HelthVishudha);
            HelthAnahata = Utils.GetArcNum(HelthVishudha + ComfortPoint);
            _Chakras[0].Land = Personal;
            _Chakras[0].Sky = GuardianAngel;
            _Chakras[1].Land = HelthAdjna;
            _Chakras[1].Sky = Adjna;
            _Chakras[2].Land = HelthVishudha;
            _Chakras[2].Sky = Vishudha;
            _Chakras[3].Land = HelthAnahata;
            _Chakras[3].Sky = Anahata;
            _Chakras[4].Land = ComfortPoint;
            _Chakras[4].Sky = ComfortPoint;
            _Chakras[5].Land = MoneyEnter;
            _Chakras[5].Sky = PastLife1stPoint;
            _Chakras[6].Land = GiftAfter40;
            _Chakras[6].Sky = MainFromPast;
            OnPropertyChanged("ChakraCV");
            HealthTotal = Utils.GetArcNum(_Chakras.Sum(a => a.Total));

            List<AgeItem> tmp = AgeItem.GetEightAges(new AgeItem(0f, _Personal), new AgeItem(10f, _Father1stPoint));
            _Years20.Clear();
            _Years20.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(10f, _Father1stPoint), new AgeItem(20f, _GuardianAngel));
            _Years20.AddRange(tmp);
            OnPropertyChanged("Years20CV");
            _Years40.Clear();
            tmp = AgeItem.GetEightAges(new AgeItem(20f, _GuardianAngel), new AgeItem(30f, _Mother2ndPoint));
            _Years40.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(30f, _Mother2ndPoint), new AgeItem(40f, _GiftAfter40));
            _Years40.AddRange(tmp);
            OnPropertyChanged("Years40CV");
            _Years60.Clear();
            tmp = AgeItem.GetEightAges(new AgeItem(40f, _GiftAfter40), new AgeItem(50f, _Father2ndPoint));
            _Years60.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(50f, _Father2ndPoint), new AgeItem(60f, _MainFromPast));
            _Years60.AddRange(tmp);
            OnPropertyChanged("Years60CV");
            _Years80.Clear();
            tmp = AgeItem.GetEightAges(new AgeItem(60f, _MainFromPast), new AgeItem(70f, _Mother1stPoint));
            _Years80.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(70f, _Mother1stPoint), new AgeItem(80f, _Personal));
            _Years80.AddRange(tmp);
            OnPropertyChanged("Years80CV");
        }
        #endregion Methods
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

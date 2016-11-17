using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for MatrixUC.xaml
    /// </summary>
    public partial class MatrixUC : UserControl
    {
        public MatrixUC()
        {
            InitializeComponent();
        }
    }

    public class MatrixVM : ObservableClass
    {
        #region Data
        private string _sMatrixName;
        private Brush _BackgroundColor;
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
        private DateTime _Birthday;
        private ObservableCollection<ChakraItem> _Chakras = new ObservableCollection<ChakraItem>();
        #endregion Data
        #region Constructor
        public MatrixVM(Brush background)
        {
            BackgroundColor = background;
        }
        public MatrixVM(DateTime date, string matrixname, Brush background)
        {
            //_sMatrixName = matrixname;
            BackgroundColor = background;
            Personal = 1; GuardianAngel = 2; GiftAfter40 = 3; MainFromPast = 4; Father1stPoint = 5; Mother2ndPoint = 6; Father2ndPoint = 7; Mother1stPoint = 8;
            ComfortPoint = 9; PastLife1stPoint = 10; Money1stPoint = 11; MoneyEnter = 12; Love2ndPoint = 13; Money2ndPoint = 14; PastLife2ndPoint = 15;
            Adjna = 1; Vishudha = 1; Anahata = 1;
            Sky = 16; Land = 17;
            FirstMission = 18;
            Man = 19; Woman = 20;
            SecondMission = 21;
            CommonMission = 22;

            _Chakras.Add(new ChakraItem() { Name = "Сахасрара" });
            _Chakras.Add(new ChakraItem() { Name = "Аджна" });
            _Chakras.Add(new ChakraItem() { Name = "Вишудха" });
            _Chakras.Add(new ChakraItem() { Name = "Анахата" });
            _Chakras.Add(new ChakraItem() { Name = "Манипура" });
            _Chakras.Add(new ChakraItem() { Name = "Свадхистана" });
            _Chakras.Add(new ChakraItem() { Name = "Муладхара" });
            //DateChanged = new RelayCommand(arg => DateChanged_Executed());

            Birthday = date;
            Init(); // Старт вычисления
        }
        #endregion Constructor
        #region Properties
        public string MatrixName
        {
            get { return _sMatrixName; }
            set
            {
                _sMatrixName = value;
                OnPropertyChanged("MatrixName");
            }
        }
        public Brush BackgroundColor
        {
            get { return _BackgroundColor; }
            set
            {
                _BackgroundColor = value;
                OnPropertyChanged("BackgroundColor");
            }
        }
        public ObservableCollection<ChakraItem> ChakrasCV
        {
            get { return _Chakras; }
            set
            {
                _Chakras = value;
                OnPropertyChanged("ChakrasCV");
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
        public int GuardianAngel    { get { return _GuardianAngel;      } set { _GuardianAngel = value;     OnPropertyChanged("GuardianAngel");     } }
        public int GiftAfter40      { get { return _GiftAfter40;        } set { _GiftAfter40 = value;       OnPropertyChanged("GiftAfter40");       } }
        public int MainFromPast     { get { return _MainFromPast;       } set { _MainFromPast = value;      OnPropertyChanged("MainFromPast");      } }
        public int Father1stPoint   { get { return _Father1stPoint;     } set { _Father1stPoint = value;    OnPropertyChanged("Father1stPoint");    } }
        public int Mother2ndPoint   { get { return _Mother2ndPoint;     } set { _Mother2ndPoint = value;    OnPropertyChanged("Mother2ndPoint");    } }
        public int Father2ndPoint   { get { return _Father2ndPoint;     } set { _Father2ndPoint = value;    OnPropertyChanged("Father2ndPoint");    } }
        public int Mother1stPoint   { get { return _Mother1stPoint;     } set { _Mother1stPoint = value;    OnPropertyChanged("Mother1stPoint");    } }
        public int ComfortPoint     { get { return _ComfortPoint;       } set { _ComfortPoint = value;      OnPropertyChanged("ComfortPoint");      } }
        public int PastLife1stPoint { get { return _PastLife1stPoint;   } set { _PastLife1stPoint = value;  OnPropertyChanged("PastLife1stPoint");  } }
        public int Money1stPoint    { get { return _Money1stPoint;      } set { _Money1stPoint = value;     OnPropertyChanged("Money1stPoint");     } }
        public int MoneyEnter       { get { return _MoneyEnter;         } set { _MoneyEnter = value;        OnPropertyChanged("MoneyEnter");        } }
        public int Love2ndPoint     { get { return _Love2ndPoint;       } set { _Love2ndPoint = value;      OnPropertyChanged("Love2ndPoint");      } }
        public int Money2ndPoint    { get { return _Money2ndPoint;      } set { _Money2ndPoint = value;     OnPropertyChanged("Money2ndPoint");     } }
        public int PastLife2ndPoint { get { return _PastLife2ndPoint;   } set { _PastLife2ndPoint = value;  OnPropertyChanged("PastLife2ndPoint");  } }
        public int Sky              { get { return _Sky;                } set { _Sky = value;               OnPropertyChanged("Sky");               } }
        public int Land             { get { return _Land;               } set { _Land = value;              OnPropertyChanged("Land");              } }
        public int FirstMission     { get { return _FirstMission;       } set { _FirstMission = value;      OnPropertyChanged("FirstMission");      } }
        public int Man              { get { return _Man;                } set { _Man = value;               OnPropertyChanged("Man");               } }
        public int Woman            { get { return _Woman;              } set { _Woman = value;             OnPropertyChanged("Woman");             } }
        public int SecondMission    { get { return _SecondMission;      } set { _SecondMission = value;     OnPropertyChanged("SecondMission");     } }
        public int CommonMission    { get { return _CommonMission;      } set { _CommonMission = value;     OnPropertyChanged("CommonMission");     } }
        public int Adjna            { get { return _Adjna;              } set { _Adjna = value;             OnPropertyChanged("Adjna");             } }
        public int Vishudha         { get { return _Vishudha;           } set { _Vishudha = value;          OnPropertyChanged("Vishudha");          } }
        public int Anahata          { get { return _Anahata;            } set { _Anahata = value;           OnPropertyChanged("Anahata");           } }
        public int HelthAdjna       { get { return _HelthAdjna;         } set { _HelthAdjna = value;        OnPropertyChanged("HelthAdjna");        } }
        public int HelthVishudha    { get { return _HelthVishudha;      } set { _HelthVishudha = value;     OnPropertyChanged("HelthVishudha");     } }
        public int HelthAnahata     { get { return _HelthAnahata;       } set { _HelthAnahata = value;      OnPropertyChanged("HelthAnahata");      } }
        public int HealthTotal      { get { return _HealthTotal;        } set { _HealthTotal = value;       OnPropertyChanged("HealthTotal");       } }
        public DateTime Birthday
        {
            get { return _Birthday; }
            set
            {
                if (_Birthday != value)
                {
                    _Birthday = value;
                    OnPropertyChanged("Birthday");
                    Init();
                }
            }
        }
        
        #endregion Properties
        #region Methods
        public void Init()
        {
            if (Birthday == null) return;
            //MatrixName = _Birthday.ToShortDateString();
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
            CalcMissions();
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
        }
        public void CalcMissions()
        {
            Sky = Utils.GetArcNum(GuardianAngel + MainFromPast);
            Land = Utils.GetArcNum(Personal + GiftAfter40);
            FirstMission = Utils.GetArcNum(Sky + Land);
            Woman = Utils.GetArcNum(Mother1stPoint + Mother2ndPoint);
            Man = Utils.GetArcNum(Father1stPoint + Father2ndPoint);
            SecondMission = Utils.GetArcNum(Man + Woman);
            CommonMission = Utils.GetArcNum(FirstMission + SecondMission);
        }
        #endregion Methods
    }
    public class YearsGridVM : ObservableClass
    {
        #region Data
        private MatrixVM _MainMatrix;
        private List<AgeItem> _Years27 = new List<AgeItem>();
        private ListCollectionView _Years27CV;
        private List<AgeItem> _Years55 = new List<AgeItem>();
        private ListCollectionView _Years55CV;
        private List<AgeItem> _Years80 = new List<AgeItem>();
        private ListCollectionView _Years80CV;
        #endregion Data
        #region Constructor
        public YearsGridVM(MatrixVM mmvm)
        {
            _MainMatrix = mmvm;
            _Years27CV = CollectionViewSource.GetDefaultView(_Years27) as ListCollectionView;
            _Years55CV = CollectionViewSource.GetDefaultView(_Years55) as ListCollectionView;
            _Years80CV = CollectionViewSource.GetDefaultView(_Years80) as ListCollectionView;
        }
        #endregion Constructor
        #region Properties
        public ICollectionView Years27CV
        {
            get { return _Years27CV; }
            set
            {
                _Years27CV = value as ListCollectionView;
                OnPropertyChanged("Years27CV");
            }
        }
        public ICollectionView Years55CV
        {
            get { return _Years55CV; }
            set
            {
                _Years55CV = value as ListCollectionView;
                OnPropertyChanged("Years55CV");
            }
        }
        public ICollectionView Years80CV
        {
            get { return _Years80CV; }
            set
            {
                _Years80CV = value as ListCollectionView;
                OnPropertyChanged("Years80CV");
            }
        }
        #endregion Properties
        #region Methods
        public void Init()
        {
            List<AgeItem> tmp = AgeItem.GetEightAges(new AgeItem(0f, _MainMatrix.Personal), new AgeItem(10f, _MainMatrix.Father1stPoint));
            _Years27.Clear();
            _Years27.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(10f, _MainMatrix.Father1stPoint), new AgeItem(20f, _MainMatrix.GuardianAngel));
            _Years27.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(20f, _MainMatrix.GuardianAngel), new AgeItem(30f, _MainMatrix.Mother2ndPoint));
            for (int i = 0; i < 6; i++)
                _Years27.Add(tmp[i]);
            Years27CV.Refresh();
            _Years55.Clear();
            _Years55.Add(tmp[6]);
            _Years55.Add(tmp[7]);
            tmp = AgeItem.GetEightAges(new AgeItem(30f, _MainMatrix.Mother2ndPoint), new AgeItem(40f, _MainMatrix.GiftAfter40));
            _Years55.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(40f, _MainMatrix.GiftAfter40), new AgeItem(50f, _MainMatrix.Father2ndPoint));
            _Years55.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(50f, _MainMatrix.Father2ndPoint), new AgeItem(60f, _MainMatrix.MainFromPast));
            for (int i = 0; i < 4; i++)
                _Years55.Add(tmp[i]);
            Years55CV.Refresh();
            _Years80.Clear();
            for (int i = 4; i < 8; i++)
                _Years80.Add(tmp[i]);
            tmp = AgeItem.GetEightAges(new AgeItem(60f, _MainMatrix.MainFromPast), new AgeItem(70f, _MainMatrix.Mother1stPoint));
            _Years80.AddRange(tmp);
            tmp = AgeItem.GetEightAges(new AgeItem(70f, _MainMatrix.Mother1stPoint), new AgeItem(80f, _MainMatrix.Personal));
            _Years80.AddRange(tmp);
            Years80CV.Refresh();
        }
        #endregion Init
    }
}

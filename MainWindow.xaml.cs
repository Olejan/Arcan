﻿using System;
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

        private void CancelSorting(object sender, DataGridSortingEventArgs e)
        {
            e.Handled = true;
        }

        private void tabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as TabControl).SelectedIndex == 3)
                dt_SecondDT.Visibility = Visibility.Visible;
            else
                dt_SecondDT.Visibility = Visibility.Collapsed;
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
                if (fullyears == 11 || fullyears == 13)
                    sb.Append(" лет");
                else if (months != 500)
                {
                    switch (i)
                    {
                        case 0:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                            sb.Append(" лет");
                            break;
                        case 1:
                            sb.Append(" год");
                            break;
                        case 2:
                        case 3:
                        case 4:
                            sb.Append(" года");
                            break;
                        default:
                            sb.Append(" лет");
                            break;
                    }
                }
                switch (months)
                {
                    case 125: sb.Append(" 1,5 месяца"); break;
                    case 250: sb.Append(" 3 месяца"); break;
                    case 375: sb.Append(" 4,5 месяца"); break;
                    case 500:
                        //sb.Append(" 6 месяцев");
                        sb.Append(",5");
                        if (fullyears == 0)
                            sb.Append(" года");
                        else if (fullyears >= 10 && fullyears <= 20)
                            sb.Append(" лет");
                        else
                        {
                            switch (i)
                            {
                                case 1:
                                case 2:
                                case 3:
                                case 4:
                                    sb.Append(" года");
                                    break;
                                case 0:
                                case 5:
                                case 6:
                                case 7:
                                case 8:
                                case 9:
                                    sb.Append(" лет");
                                    break;
                            }
                        }
                        break;
                    case 625: sb.Append(" 7,5 месяцев"); break;
                    case 750: sb.Append(" 9 месяцев"); break;
                    case 875: sb.Append(" 10,5 месяцев"); break;
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
        private DateTime _Birthday;
        private DateTime _SecondBD;
        private MatrixVM _MainMatrix_VM;
        private MatrixVM _SecondMatrix_VM;
        private MatrixVM _CommonMatrix_VM;
        private YearsGridVM _YearsGrid_VM;
        private string _FirstMatrixName;
        private string _SecondMatrixName;
        private string _CommonMatrixName;
        //private DelegateCommand _CmdTabItemChanged;
        #endregion Data
        #region Constructor
        public Arcan_VM()
        {
            _Birthday = DateTime.Now;
            _SecondBD = DateTime.Now;
            _MainMatrix_VM = new MatrixVM(_Birthday, _Birthday.ToShortDateString(), new SolidColorBrush(Color.FromRgb(255, 255, 187)));
            _SecondMatrix_VM = new MatrixVM(_SecondBD, _SecondBD.ToShortDateString(), new SolidColorBrush(Color.FromRgb(187, 238, 255)));
            _CommonMatrix_VM = new MatrixVM(new SolidColorBrush(Color.FromRgb(189, 255, 187)));
            _YearsGrid_VM = new YearsGridVM(_MainMatrix_VM);
            DateChanged_Executed(); // Старт вычисления
        }
        #endregion Constructor
        #region Properties
        public string FirstMatrixName
        {
            get { return _FirstMatrixName; }
            set
            {
                _FirstMatrixName = value;
                OnPropertyChanged("FirstMatrixName");
            }
        }
        public string SecondMatrixName
        {
            get { return _SecondMatrixName; }
            set
            {
                _SecondMatrixName = value;
                OnPropertyChanged("SecondMatrixName");
            }
        }
        public string CommonMatrixName
        {
            get { return _CommonMatrixName; }
            set
            {
                _CommonMatrixName = value;
                OnPropertyChanged("CommonMatrixName");
            }
        }
        /*public ICommand CmdTabItemChanged
        {
            get { return _CmdTabItemChanged ?? (_CmdTabItemChanged = new DelegateCommand(CmdTabItemChanged_Executed)); }
        }*/
        public MatrixVM MainMatrix_VM
        {
            get { return _MainMatrix_VM; }
            set
            {
                _MainMatrix_VM = value;
                OnPropertyChanged("MainMatrix_VM");
            }
        }
        public MatrixVM SecondMatrix_VM
        {
            get { return _SecondMatrix_VM; }
            set
            {
                _SecondMatrix_VM = value;
                OnPropertyChanged("SecondMatrix_VM");
            }
        }
        public MatrixVM CommonMatrix_VM
        {
            get { return _CommonMatrix_VM; }
            set
            {
                _CommonMatrix_VM = value;
                OnPropertyChanged("CommonMatrix_VM");
            }
        }
        public YearsGridVM YearsGrid_VM
        {
            get { return _YearsGrid_VM; }
            set
            {
                _YearsGrid_VM = value;
                OnPropertyChanged("YearsGrid_VM");
            }
        }
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
        public DateTime SecondBD
        {
            get { return _SecondBD; }
            set
            {
                if (_SecondBD != value)
                {
                    _SecondBD = value;
                    OnPropertyChanged("SecondBD");
                    CommonMatrixCalculate();
                }
            }
        }

        //public ICommand DateChanged { get; set; }
        #endregion Properties
        #region Methods
        private void DateChanged_Executed()
        {
            if (Birthday == null) return;
            _MainMatrix_VM.Birthday = Birthday;
            FirstMatrixName = _Birthday.ToShortDateString();
            _MainMatrix_VM.Init();
            _YearsGrid_VM.Init();
            OnPropertyChanged("MainMatrix_VM");
            OnPropertyChanged("YearsGrid_VM");
            CommonMatrixCalculate();
        }
        private void CommonMatrixCalculate()
        {
            if (_SecondMatrix_VM == null) return;
            _SecondMatrix_VM.Birthday = SecondBD;
            SecondMatrixName = _SecondBD.ToShortDateString();
            _SecondMatrix_VM.Init();
            //_CommonMatrix_VM.MatrixName = SecondMatrix_VM.MatrixName + " + " + MainMatrix_VM.MatrixName;
            CommonMatrixName = SecondMatrixName + " + " + FirstMatrixName;
            _CommonMatrix_VM.Personal = Utils.GetArcNum(_MainMatrix_VM.Personal + _SecondMatrix_VM.Personal);
            _CommonMatrix_VM.GuardianAngel = Utils.GetArcNum(_MainMatrix_VM.GuardianAngel + _SecondMatrix_VM.GuardianAngel);
            _CommonMatrix_VM.GiftAfter40 = Utils.GetArcNum(_MainMatrix_VM.GiftAfter40 + _SecondMatrix_VM.GiftAfter40);
            _CommonMatrix_VM.MainFromPast = Utils.GetArcNum(_MainMatrix_VM.MainFromPast + _SecondMatrix_VM.MainFromPast);
            _CommonMatrix_VM.Father1stPoint = Utils.GetArcNum(_MainMatrix_VM.Father1stPoint + _SecondMatrix_VM.Father1stPoint);
            _CommonMatrix_VM.Father2ndPoint = Utils.GetArcNum(_MainMatrix_VM.Father2ndPoint + _SecondMatrix_VM.Father2ndPoint);
            _CommonMatrix_VM.Mother1stPoint = Utils.GetArcNum(_MainMatrix_VM.Mother1stPoint + _SecondMatrix_VM.Mother1stPoint);
            _CommonMatrix_VM.Mother2ndPoint = Utils.GetArcNum(_MainMatrix_VM.Mother2ndPoint + _SecondMatrix_VM.Mother2ndPoint);
            _CommonMatrix_VM.ComfortPoint = Utils.GetArcNum(_MainMatrix_VM.ComfortPoint + _SecondMatrix_VM.ComfortPoint);
            _CommonMatrix_VM.CalcMissions();
            OnPropertyChanged("CommonMatrix_VM");
            
        }
        /*private void CmdTabItemChanged_Executed(object param)
        {
            
        }*/
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

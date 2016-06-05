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
        private int _A;
        private int _B;
        private int _C;
        private int _D;
        private int _E;
        private int _F;
        private int _G;
        private int _H;
        private int _I;
        private int _J;
        private int _K;
        private int _L;
        private int _M;
        private int _N;
        private int _O;
        private int _Sky;
        private int _Land;
        private int _SkyLandCommon;
        private int _Man;
        private int _Woman;
        private int _ManWomanCommon;
        private int _Common;
        private string _Name;
        private DateTime _Birthday;

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Data
        public Arcan_VM()
        {
            A = 1;B = 2;C = 3;D = 4;E = 5;F = 6;G = 7;H = 8;I = 9;J = 10;K = 11;L = 12;M = 13;N = 14;O = 15;
            Sky = 16;Land = 17;SkyLandCommon = 18; Man = 19;Woman = 20;ManWomanCommon = 21;Common = 22;
            Name = "Name";Birthday = DateTime.Now;
            //DateChanged = new RelayCommand(arg => DateChanged_Executed());
        }
        public int A
        {
            get { return _A; }
            set
            {
                _A = value;
                OnPropertyChanged("A");
            }
        }
        public int B { get { return _B; } set { _B = value; OnPropertyChanged("B"); } }
        public int C { get { return _C; } set { _C = value; OnPropertyChanged("C"); } }
        public int D { get { return _D; } set { _D = value; OnPropertyChanged("D"); } }
        public int E { get { return _E; } set { _E = value; OnPropertyChanged("E"); } }
        public int F { get { return _F; } set { _F = value; OnPropertyChanged("F"); } }
        public int G { get { return _G; } set { _G = value; OnPropertyChanged("G"); } }
        public int H { get { return _H; } set { _H = value; OnPropertyChanged("H"); } }
        public int I { get { return _I; } set { _I = value; OnPropertyChanged("I"); } }
        public int J { get { return _J; } set { _J = value; OnPropertyChanged("J"); } }
        public int K { get { return _K; } set { _K = value; OnPropertyChanged("K"); } }
        public int L { get { return _L; } set { _L = value; OnPropertyChanged("L"); } }
        public int M { get { return _M; } set { _M = value; OnPropertyChanged("M"); } }
        public int N { get { return _N; } set { _N = value; OnPropertyChanged("N"); } }
        public int O { get { return _O; } set { _O = value; OnPropertyChanged("O"); } }
        public int Sky { get { return _Sky; } set { _Sky = value; OnPropertyChanged("Sky"); } }
        public int Land { get { return _Land; } set { _Land = value; OnPropertyChanged("Land"); } }
        public int SkyLandCommon { get { return _SkyLandCommon; } set { _SkyLandCommon = value; OnPropertyChanged("SkyLandCommon"); } }
        public int Man { get { return _Man; } set { _Man = value; OnPropertyChanged("Man"); } }
        public int Woman { get { return _Woman; } set { _Woman = value; OnPropertyChanged("Woman"); } }
        public int ManWomanCommon { get { return _ManWomanCommon; } set { _ManWomanCommon = value; OnPropertyChanged("ManWomanCommon"); } }
        public int Common { get { return _Common; } set { _Common = value; OnPropertyChanged("Common"); } }
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
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void DateChanged_Executed()
        {
            if (Birthday == null) return;
            A = GetArcNum(Birthday.Day);
            B = Birthday.Month;
            C = GetArcNum(Birthday.Year); // !!!!!!!!!!
            D = GetArcNum(A + B + C);
        }
        private int GetArcNum(int num)
        {
            if (num > 99) return 0;
            else if (num <= 22) return num;
            int s1 = num / 10;
            int s2 = num % 10;
            return s1 + s2;
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

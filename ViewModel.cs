using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Windows;


namespace Krestiki_noliki_3._0
{
    public delegate string ChangeHandler(out bool flag);

    public class ViewModel : ViewModelBase
    {       
        private MachineIntelligenceModel machine;
        private DBManagerModel _dbManager;
        public static bool BoardLocked { get; set; }

        //событие, возникающее при изменении значения кнопки-клетки поля
        public event ChangeHandler OnChange; 
        private ICommand _move0;
        private ICommand _move1;
        private ICommand _move2;
        private ICommand _move3;
        private ICommand _move4;
        private ICommand _move5;
        private ICommand _move6;
        private ICommand _move7;
        private ICommand _move8;        

        public ViewModel()
        {
            BoardLocked = false;
            machine = new MachineIntelligenceModel();
            _dbManager = new DBManagerModel();
            OnChange += machine.Analysis;
        }        
       
        //метод вызова события
        public void CallOnChange()
        {
            if (OnChange != null)
            {
                string cellName = OnChange(out bool OcanWin);
                MachineMove(cellName);
                if(OcanWin)
                {
                    machine.CongratulationsO();
                    OcanWin = false;
                }
            }
        }

        //свойство, к которому привязана кнопка-клетка поля. 
        //инкапсулирует работу с БД, а также вызов алгоритма для обработки информации и ответного хода машины через событие
        public string B0
        {
            get { return _dbManager.GetValue(0); }
            set
            {
                _dbManager.InsertValue(0,value);
                RaisePropertyChanged(() => B0);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();                   
                }
                BoardLocked = false;
            }
        }

        //команда, привязанная к кнопке-клетке поля: изменяет свойство
        public ICommand Move_0
        {
            get
            {
                return _move0 ?? (_move0 = new RelayCommand(() =>
                  {
                      if (BoardLocked != true)
                      {
                          B0 = "x";
                      }
                  }));
            }
            
        }


        public string B1
        {
            get { return _dbManager.GetValue(1); }
            set
            {
                _dbManager.InsertValue(1, value);
                RaisePropertyChanged(() => B1);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_1
        {
            get
            {
                return _move1 ?? (_move1 = new RelayCommand(() =>
                  {
                      if (BoardLocked != true)
                      {
                          B1 = "x";
                      }
                  }));
            }
        }

        public string B2
        {
            get { return _dbManager.GetValue(2); }
            set
            {
                _dbManager.InsertValue(2, value);
                RaisePropertyChanged(() => B2);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_2
        {
            get
            {
                return _move2 ?? (_move2 = new RelayCommand(() =>
                {
                    if (BoardLocked != true)
                    {
                        B2 = "x";
                    }
                }));
            }
        }

        public string B3
        {
            get { return _dbManager.GetValue(3); }
            set
            {
                _dbManager.InsertValue(3, value);
                RaisePropertyChanged(() => B3);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_3
        {
            get
            {
                return _move3 ?? (_move3 = new RelayCommand(() =>
                {
                    if (BoardLocked != true)
                    {
                        B3 = "x";
                    }
                }));
            }
        }

        public string B4
        {
            get { return _dbManager.GetValue(4); }
            set
            {
                _dbManager.InsertValue(4, value);
                RaisePropertyChanged(() => B4);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_4
        {
            get
            {
                return _move4 ?? (_move4 = new RelayCommand(() =>
                {
                    if (BoardLocked != true)
                    {
                        B4 = "x";
                    }
                }));
            }
        }

        public string B5
        {
            get { return _dbManager.GetValue(5); }
            set
            {
                _dbManager.InsertValue(5, value);
                RaisePropertyChanged(() => B5);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_5
        {
            get
            {
                return _move5 ?? (_move5 = new RelayCommand(() =>
                {
                    if (BoardLocked != true)
                    {
                        B5 = "x";
                    }
                }));
            }
        }

        public string B6
        {
            get { return _dbManager.GetValue(6); }
            set
            {
                _dbManager.InsertValue(6, value);
                RaisePropertyChanged(() => B6);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_6
        {
            get
            {
                return _move6 ?? (_move6 = new RelayCommand(() =>
                {
                    if (BoardLocked != true)
                    {
                        B6 = "x";
                    }
                }));
            }
        }

        public string B7
        {
            get { return _dbManager.GetValue(7); }
            set
            {
                _dbManager.InsertValue(7, value);
                RaisePropertyChanged(() => B7);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_7
        {
            get
            {
                return _move7 ?? (_move7 = new RelayCommand(() =>
                {
                    if (BoardLocked != true)
                    {
                        B7 = "x";
                    }
                }));
            }
        }

        public string B8
        {
            get { return _dbManager.GetValue(8); }
            set
            {
                _dbManager.InsertValue(8, value);
                RaisePropertyChanged(() => B8);
                if (BoardLocked != true)
                {
                    BoardLocked = true;
                    CallOnChange();
                }
                BoardLocked = false;
            }
        }

        public ICommand Move_8
        {
            get
            {
                return _move8 ?? (_move8 = new RelayCommand(() =>
                {
                    if (BoardLocked != true)
                    {
                        B8 = "x";
                    }
                }));
            }
        }

        public void MachineMove(string number)
        {
            switch (number)
            {
                case "0":
                    {
                        B0 = "o";
                        break;
                    }
                case "1":
                    {
                        B1 = "o";
                        break;
                    }
                case "2":
                    {
                        B2 = "o";
                        break;
                    }
                case "3":
                    {
                        B3 = "o";
                        break;
                    }
                case "4":
                    {
                        B4 = "o";
                        break;
                    }
                case "5":
                    {
                        B5 = "o";
                        break;
                    }
                case "6":
                    {
                        B6 = "o";
                        break;
                    }
                case "7":
                    {
                        B7 = "o";
                        break;
                    }
                case "8":
                    {
                        B8 = "o";
                        break;
                    }
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Krestiki_noliki_3._0
{   
    //реализация паттерна singleton для класса-обертки, имитирующего БД
    public sealed class DBModel
    {
        private static readonly DBModel _instance = new DBModel();
        private List<CellModel> _gameBoard = new List<CellModel>();

        private DBModel()
        {
            for(int i=1; i<10;i++)
            {
                _gameBoard.Add(new CellModel());
            }
        }

        public static DBModel Instance
        {
            get { return _instance; }
        }

        public CellModel this[int index]
        {
            get { return _gameBoard[index]; }
            set { _gameBoard[index] = value;
                
            }
        }

        public List<CellModel> Gameboard
        {
            get { return _gameBoard; }
        }
    }
}

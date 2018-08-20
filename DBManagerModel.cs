using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krestiki_noliki_3._0
{
    
    class DBManagerModel
    {
        private DBModel _db;       

       
        public DBManagerModel()
        {
            _db = DBModel.Instance;           
        }

        public void InsertValue (int index, string value)
        {
            _db[index].CellValue = value;
            
        }

        public string GetValue(int index)
        {
            return _db[index].CellValue;
        }

        public List<CellModel> GetAllValues()
        {
            List<CellModel> allValues = _db.Gameboard;
            return allValues;
        }
    }
}

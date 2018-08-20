using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using GalaSoft.MvvmLight;

namespace Krestiki_noliki_3._0
{
    public class CellModel 
    {
        private string _cellvalue = "";

        public CellModel()
        {
            CellValue = "";
                                   
        }
        public string CellValue
        {
            get { return _cellvalue; }
            set
            {
                _cellvalue = value;
            }
        }

        
        
    }
}

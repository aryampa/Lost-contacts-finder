using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostContactFinder._01_Automated
{
    class ColumnMetaData
    {
        public string ColName = "";
        public int ColIndex = -1;
        public int ColTotalElems = 0;
        public int TotalDigitalElems = 0;
        public int TotalNonDigitalElems = 0;
        public int ColTotalMixedElems = 0;
        public Boolean Assigned = false;

        public ColumnMetaData(string Col_Name) { ColName = Col_Name; }
    }
}

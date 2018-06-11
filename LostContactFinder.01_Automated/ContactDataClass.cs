using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostContactFinder._01_Automated
{
    public class ContactDataClass
    {
        public List<string> namesList = new List<string> { };
        public List<string> numbersList = new List<string> { };
        public List<string> emailsList = new List<string> { };

        public void updateNames(string ContName)
        {
            namesList.Add(ContName);
        }

        public void updateNumbers(string ContNumber)
        {
            numbersList.Add(ContNumber);
        }

        public void upadteEmail(string ContEmail)
        {
            emailsList.Add(ContEmail);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using LumenWorks.Framework.IO.Csv;
using System.Threading;
using CsvHelper;
namespace LostContactFinder._01_Automated
{
    delegate void setLogTextDelegate();

    public partial class MainForm : Form
    {
        StringBuilder sbuilderErrorFile;
        FolderBrowserDialog folderBrowseDlgIN;

        Thread GUIlogThread;
        Boolean UpdateGUI;
        Boolean ClearGUI;
        Boolean StopWhileLoop = false;
        StringBuilder sbOutputLog;
        string loggingString = "";

        OpenFileDialog openFileDlgIN;
        LumenWorks.Framework.IO.Csv.CsvReader csvReaderObj;

        CsvHelper.CsvReader csvReaderOBJHelper;
        DatabaseInterfaceClass DataBaseObj;
        string errorMessage = "";

        public MainForm()
        {
            InitializeComponent();
        }

        //Delegates Declare HERE

        delegate void updateLableDelagate(Label lbl, string text);
        delegate void updateTextBoxDelegate(TextBox txtbx, string text, Boolean append);
        delegate void enableControlDelegate(Control control, Boolean flag);

        // Delegate Functions HERE

        private void updateLableFunction(Label lbl, string txt)
        {
            lbl.Text = txt;

        }

        private void enableControlFunction(Control ctrl, Boolean flag)
        {
            ctrl.Enabled = flag;
        }

        private void updateTextBoxFunction(TextBox txtbx, string txt, Boolean append)
        {
            if (append)
            {
                txtbx.AppendText(txt);
                txtbx.Update();
            }
            else
            {
                txtbx.Text = txt;
                txtbx.Update();
            }
        }

        // ThreadSafe Functions HERE

        public void threadSafeLableUpdate(Label lbl, string txt)
        {
            if (lbl.InvokeRequired)
            {
                updateLableDelagate d = new updateLableDelagate(updateLableFunction);
                this.Invoke(d, new object[] { lbl, txt });
            }
            else
            {
                lbl.Text = txt;
                lbl.Update();
            }
        }

        public void threadSafeEnableControl(Control ctrl, Boolean flag)
        {
            if (ctrl.InvokeRequired)
            {
                enableControlDelegate d = new enableControlDelegate(enableControlFunction);
                this.Invoke(d, new object[] { ctrl, flag });
            }
            else
            {
                ctrl.Enabled = flag;
            }
        }
        public void threadSafeTextBoxUpdate(TextBox txtbx, string txt, Boolean append)
        {
            if (txtbx.InvokeRequired)
            {
                updateTextBoxDelegate d = new updateTextBoxDelegate(updateTextBoxFunction);
                this.Invoke(d, new object[] { txtbx, txt, append });
            }
            else
            {

                if (append)
                {
                    txtbx.AppendText(txt);
                    txtbx.Update();
                }
                else
                {
                    txtbx.Text = txt;
                    txtbx.Update();
                }
            }
        }

        private string RemoveUnwantedCharacters(string dirtyString)
        {

            string string2Return = "";
            dirtyString = dirtyString.Trim();

            if (dirtyString.Length > 0)
            {
                if (dirtyString[0] == '+')
                {
                    string2Return = "+";
                    dirtyString = dirtyString.TrimStart(new char[] { '+' });
                }

                foreach (char letter in dirtyString)
                {
                    if (char.IsDigit(letter)) string2Return = string2Return + letter.ToString();
                }

            }
            else string2Return = dirtyString;

            return string2Return;
        }
        
        
        private string formatPhoneNumbers(string number)
        {

            List<string> phonePrefixList = new List<string> {"70", "71", "72", "73", "74", "75", "76", "77", "78", "79", "80", "41", "39","31" };

            string returnString = "";

            if (number.StartsWith("+"))
            {

                if (number.Length == 13)
                {

                    returnString = number;
                }

            }

            else if (number.StartsWith("0"))
            {
                if (number.Length == 10)
                {

                    //string subString = number.Substring(1, 2);
                    //if(phonePrefixList .Contains (subString)){
                    //    returnString = "+256" + number.Substring (1);
                    //}

                    returnString = "+256" + number.Substring(1);

                }
            }

            else if (number.StartsWith("7") | number.StartsWith("3") | number.StartsWith("4") | number.StartsWith("8"))
            {

                if (number.Length == 9)
                {

                    if (phonePrefixList.Contains(number.Substring(0, 2)))
                    {

                        returnString = "+256" + number;
                    }
                }


            }


            else if (number.StartsWith("256"))
            {

                if (number.Length == 12)
                {

                    if (phonePrefixList.Contains(number.Substring(3, 4)))
                    {

                        returnString = "+" + number;

                    }
                }
            }

            return returnString;

        }


        private List<ContactDataClass> AutomatchDataFields(DataTable inputTable)
        {

            List<ContactDataClass> ListofFinalContacts = new List<ContactDataClass> { };

            Dictionary<string, int> FieldsDictionary = new Dictionary<string, int> { };
            FieldsDictionary.Add("FirstName", -1);
            FieldsDictionary.Add("MiddleName", -1);
            FieldsDictionary.Add("LastName", -1);
            FieldsDictionary.Add("Phone1", -1);
            FieldsDictionary.Add("Phone2", -1);
            FieldsDictionary.Add("Phone3", -1);
            FieldsDictionary.Add("Phone4", -1);
            FieldsDictionary.Add("Phone5", -1);
            FieldsDictionary.Add("Phone6", -1);
            FieldsDictionary.Add("Email1", -1);
            FieldsDictionary.Add("Email2", -1);
            FieldsDictionary.Add("Email3", -1);


            autoMatchNames(inputTable, FieldsDictionary);
            autoMatchNumbers(inputTable, FieldsDictionary);
            autoMatchEmail(inputTable, FieldsDictionary);

            ListofFinalContacts = AssembleFinalTable(inputTable, FieldsDictionary);
            return ListofFinalContacts;
        }


        private List<ContactDataClass> AssembleFinalTable(DataTable SourceTable, Dictionary<string, int> DictionaryWithData)
        {
            DataTable FinalTable = new DataTable();

            List<string> originalColNames = new List<string> { };

            // find colums with valued and and names to new table

            foreach (KeyValuePair<string, int> Key_Value in DictionaryWithData)
            {

                    if (Key_Value.Value != -1)
                    {
                        if (Key_Value .Key == "FirstName") { FinalTable.Columns.Add("First Name"); originalColNames.Add(SourceTable.Columns[Key_Value.Value ].ColumnName); }
                        if (Key_Value.Key == "MiddleName") { FinalTable.Columns.Add("Middle Name"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }
                        if (Key_Value.Key == "LastName") { FinalTable.Columns.Add("Last Name"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }

                        if (Key_Value.Key == "Phone1") { FinalTable.Columns.Add("Phone1"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }
                        if (Key_Value.Key == "Phone2") { FinalTable.Columns.Add("Phone2"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }
                        if (Key_Value.Key == "Phone3") { FinalTable.Columns.Add("Phone3"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }
                        if (Key_Value.Key == "Phone4") { FinalTable.Columns.Add("Phone4"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }
                        if (Key_Value.Key == "Phone5") { FinalTable.Columns.Add("Phone5"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }
                        if (Key_Value.Key == "Phone6") { FinalTable.Columns.Add("Phone6"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }

                        if (Key_Value.Key == "Email1") { FinalTable.Columns.Add("Email1"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }
                        if (Key_Value.Key == "Email2") { FinalTable.Columns.Add("Email2"); originalColNames.Add(SourceTable.Columns[Key_Value.Value].ColumnName); }



                    }

            }

            // populate rows of the new table 

            for (int r0w = 0; r0w < SourceTable.Rows.Count; r0w++)
            {

                DataRow newDataR0w = FinalTable.NewRow();

                for (int c0lumnValue = 0; c0lumnValue < FinalTable.Columns.Count; c0lumnValue++)
                {
                    if (originalColNames[c0lumnValue].ToString().ToLower().Contains("phone") | originalColNames[c0lumnValue].ToString().ToLower().Contains("number") | originalColNames[c0lumnValue].ToString().ToLower().Contains("mobile"))
                    {
                        string cellNumberValue = SourceTable .Rows[r0w][originalColNames[c0lumnValue]].ToString();
                        string formatedPhoneNumber = formatPhoneNumbers(RemoveUnwantedCharacters(cellNumberValue));

                        if (formatedPhoneNumber == "") newDataR0w[c0lumnValue] = "";
                        else newDataR0w[c0lumnValue] = formatedPhoneNumber;
                    }

                    else
                    {

                        newDataR0w[c0lumnValue] = SourceTable.Rows[r0w][originalColNames[c0lumnValue]];
                    }
                }

                FinalTable.Rows.Add(newDataR0w);
            }

            //dbGridView.DataSource = FinalTable;

            List<ContactDataClass> ListofFinalContactsLocal = new List<ContactDataClass> { };
            ListofFinalContactsLocal.Clear();

            for (int list2 = 0; list2 < FinalTable.Rows.Count; list2++)
            {

                ContactDataClass ContactObject = new ContactDataClass();
                DataRow currentRow = FinalTable.Rows[list2];

                if (FinalTable.Columns.Contains("First Name"))
                {

                    if (currentRow["First Name"].ToString() != "") ContactObject.updateNames(currentRow["First Name"].ToString());
                }

                if (FinalTable.Columns.Contains("Middle Name"))
                {

                    if (currentRow["Middle Name"].ToString() != "") ContactObject.updateNames(currentRow["Middle Name"].ToString());
                }

                if (FinalTable.Columns.Contains("Last Name"))
                {
                    if (currentRow["Last Name"].ToString() != "") ContactObject.updateNames(currentRow["Last Name"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone1"))
                {
                    if (currentRow["Phone1"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone1"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone2"))
                {
                    if (currentRow["Phone2"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone2"].ToString());
                }

                if (originalColNames.Contains("Phone3"))
                {
                    if (currentRow["Phone3"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone3"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone4"))
                {
                    if (currentRow["Phone4"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone4"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone5"))
                {
                    if (currentRow["Phone5"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone5"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone6"))
                {
                    if (currentRow["Phone6"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone6"].ToString());
                }

                if (FinalTable.Columns.Contains("Email1"))
                {
                    if (currentRow["Email1"].ToString() != "") ContactObject.updateNumbers(currentRow["Email1"].ToString());
                }

                if (FinalTable.Columns.Contains("Email2"))
                {
                    if (currentRow["Email2"].ToString() != "") ContactObject.updateNumbers(currentRow["Email2"].ToString());
                }

                ListofFinalContactsLocal.Add(ContactObject);


            }

           // MessageBox.Show("Contacts List of " + ListofFinalContactsLocal.Count.ToString() + " successfully Generated!");

            return  ListofFinalContactsLocal;

        }

        private void autoMatchEmail(DataTable TableWithEmails, Dictionary <string , int > Dictionary2Map)
        {

            if (TableWithEmails.Rows.Count == 0) MessageBox.Show("No Data Found in Data Table");
            else
            {

                List<ColumnMetaData> validColumnsWithEmailList = new List<ColumnMetaData> { };

                foreach (DataColumn inPutTableColum in TableWithEmails.Columns)
                {



                    if ((inPutTableColum.ColumnName.ToLower().Contains("email") | inPutTableColum.ColumnName.ToLower().Contains("e-mail")))
                    {

                        ColumnMetaData colMetaData = new ColumnMetaData(inPutTableColum.ColumnName);

                        int colIndex = inPutTableColum.Ordinal;
                        colMetaData.ColIndex = inPutTableColum.Ordinal;

                        int TotalElems = 0;

                        foreach (DataRow tableRow in TableWithEmails.Rows )
                        {

                            if (tableRow[inPutTableColum.ColumnName].ToString() != "")
                            {
                                TotalElems++;
                                colMetaData.ColTotalElems++;

                            }
                        }

                        if (colMetaData.ColTotalElems != 0) validColumnsWithEmailList.Add(colMetaData);
                    }



                }


                if (Dictionary2Map["Email1"]==-1)
                {

                    int Email1TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithEmailList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Email1TotalItems) { selectedColIndex = ColumnindexCounter; Email1TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { Dictionary2Map["Email1"] = validColumnsWithEmailList[selectedColIndex].ColIndex; validColumnsWithEmailList[selectedColIndex].Assigned = true; }
                }

                if (Dictionary2Map["Email2"]==-1)
                {

                    int Email2TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithEmailList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Email2TotalItems) { selectedColIndex = ColumnindexCounter; Email2TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { Dictionary2Map["Email2"] = validColumnsWithEmailList[selectedColIndex].ColIndex; validColumnsWithEmailList[selectedColIndex].Assigned = true; }
                }



            }
        }

        private void autoMatchNumbers(DataTable TableWithNumbers, Dictionary <string ,int> Dictionary2Map)
        {

            if (TableWithNumbers.Rows.Count == 0) MessageBox.Show("No Data Found in Data Table");
            else
            {

                List<ColumnMetaData> validColumnsWithNumbersList = new List<ColumnMetaData> { };
                List<char> phoneCharacters = new List<char> { '*', '#', '+', ' ', '(', ')', '?', '-' };

                ////>>>>>>>>>>>>>>>>>>>>>>>>> START FILTERING_OUT VALID CONTACTS ////////////////////////////

                foreach (DataColumn inPutTableColum in TableWithNumbers.Columns)
                {
                    //tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN is NOW being Processed\n");




                    if (inPutTableColum.ColumnName.ToLower().Contains("phone") | inPutTableColum.ColumnName.ToLower().Contains("mobile") | inPutTableColum.ColumnName.ToLower().Contains("number"))
                    {
                        //tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN Contains PHONE or MOBILE...hence is tobe analysed...\n");


                        ColumnMetaData colMetaData = new ColumnMetaData(inPutTableColum.ColumnName);

                        int colIndex = inPutTableColum.Ordinal;
                        colMetaData.ColIndex = inPutTableColum.Ordinal;

                        int TotalElems = 0;

                        int rowCounterNew = 0;

                        foreach (DataRow tableRow in TableWithNumbers.Rows)
                        {

                            rowCounterNew++;
                           // if (inPutTableColum.ColumnName == "Mobile Phone") tbxDebuging.AppendText(tableRow["First Name"].ToString() + " has Number ===> " + tableRow["Mobile Phone"] + "===>" + rowCounterNew.ToString() + "\n");
                            Boolean isAllDigit = true;
                            Boolean isAllChars = true;
                            Boolean isMixed = false;


                            if (tableRow[inPutTableColum.ColumnName].ToString() != "")
                            {
                                TotalElems++;
                                colMetaData.ColTotalElems++;

                                foreach (char letter in tableRow[inPutTableColum.ColumnName].ToString())
                                {
                                    if (char.IsDigit(letter) | phoneCharacters.Contains(letter)) isAllChars = false;
                                    else if (!char.IsDigit(letter) | !phoneCharacters.Contains(letter)) isAllDigit = false;
                                }

                                if (!isAllDigit & !isAllChars) isMixed = true;

                                if (isAllChars) colMetaData.TotalNonDigitalElems++;
                                if (isAllDigit) colMetaData.TotalDigitalElems++;
                                if (isMixed)
                                {
                                    colMetaData.ColTotalMixedElems++;
                                    //if (inPutTableColum.ColumnName == "Mobile Phone") tbxDebuging.AppendText(tableRow["First Name"].ToString() + " has MIXED Number ===> " + tableRow["Mobile Phone"] + "===>" + rowCounterNew.ToString() + "\n");
                                }


                            }
                        }

                        // tbxDebuging.AppendText(inPutTableColum.ColumnName + "COLUMN has " + colMetaData.ColTotalElems + " elements \n");

                        //Console.WriteLine(inPutTableColum.ColumnName);

                        string columnName = inPutTableColum.ColumnName;

                        float NonDigitalElemsPercantage = (colMetaData.TotalNonDigitalElems / (float)colMetaData.ColTotalElems) * 100;
                        float DigitalElemPercentage = ((colMetaData.TotalDigitalElems / (float)colMetaData.ColTotalElems) * 100);

                        validColumnsWithNumbersList.Add(colMetaData);

                        //if (((colMetaData.TotalNonDigitalElems / (float)colMetaData.ColTotalElems) * 100) > 2.0 | ((colMetaData.TotalDigitalElems / (float)colMetaData.ColTotalElems) * 100) < 90.0) { }
                        //else
                        //{
                        //    if (colMetaData.ColTotalElems != 0)
                        //    {

                        //        validColumnsWithNumbersList.Add(colMetaData);
                        //        //tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has been added to list of valid cols \n");
                        //    }
                        //    else
                        //    {
                        //        // tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has NOT been added to list of valid cols \n");
                        //    }
                        //}
                    }

                    //tbxDebuging.AppendText("------------------------------------------------------------------------\n");

                    //tbxDebuging.AppendText("\n");



                }


                //////////////>>>>>>>>>>>>>>>>>>>>>>> DONE FILTERING >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>/////////////////////////////////////

                if (Dictionary2Map["Phone1"]==-1)
                {

                    int Phone1TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithNumbersList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Phone1TotalItems) { selectedColIndex = ColumnindexCounter; Phone1TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { 
                        Dictionary2Map ["Phone1"] = validColumnsWithNumbersList[selectedColIndex].ColIndex; 
                        validColumnsWithNumbersList[selectedColIndex].Assigned = true;
                    }
                }

                if (Dictionary2Map["Phone2"] == -1)
                {

                    int Phone2TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithNumbersList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Phone2TotalItems) { selectedColIndex = ColumnindexCounter; Phone2TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { Dictionary2Map["Phone2"] = validColumnsWithNumbersList[selectedColIndex].ColIndex; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (Dictionary2Map["Phone3"] == -1)
                {

                    int Phone3TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithNumbersList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Phone3TotalItems) { selectedColIndex = ColumnindexCounter; Phone3TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { Dictionary2Map["Phone3"] = validColumnsWithNumbersList[selectedColIndex].ColIndex; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (Dictionary2Map["Phone4"]==-1)
                {

                    int Phone4TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithNumbersList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Phone4TotalItems) { selectedColIndex = ColumnindexCounter; Phone4TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { Dictionary2Map["Phone4"] = validColumnsWithNumbersList[selectedColIndex].ColIndex; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (Dictionary2Map["Phone5"]==-1)
                {

                    int Phone5TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithNumbersList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Phone5TotalItems) { selectedColIndex = ColumnindexCounter; Phone5TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { Dictionary2Map["Phone5"] = validColumnsWithNumbersList[selectedColIndex].ColIndex; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (Dictionary2Map["Phone6"]==-1)
                {

                    int Phone6TotalItems = -1;
                    int selectedColIndex = -1;
                    int ColumnindexCounter = -1;
                    foreach (ColumnMetaData columnItem in validColumnsWithNumbersList)
                    {

                        ColumnindexCounter++;
                        if (!columnItem.Assigned)
                        {

                            if (columnItem.ColTotalElems > Phone6TotalItems) { selectedColIndex = ColumnindexCounter; Phone6TotalItems = columnItem.ColTotalElems; }

                        }
                    }

                    if (selectedColIndex > -1) { Dictionary2Map["Phone6"] = validColumnsWithNumbersList[selectedColIndex].ColIndex; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }



            }


        }

        private void autoMatchNames(DataTable TableWithData, Dictionary <string ,int > Dictionary2Map)
        {
            if (TableWithData.Rows.Count == 0)
            {

                MessageBox.Show("No Data Found in Data Table");
            }

            else
            {



                List<ColumnMetaData> ValidColums = new List<ColumnMetaData> { };

                ///<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<////

                foreach (DataColumn inPutTableColum in TableWithData.Columns)
                {

                   // tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN is NOW being Processed\n");



                    if (inPutTableColum.ColumnName.ToLower().Contains("name"))
                    {
                      //  tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN Contains name...hence is tobe analysed...\n");

                        ColumnMetaData colMetaData = new ColumnMetaData(inPutTableColum.ColumnName); //create column object to hold col info

                        int colIndex = inPutTableColum.Ordinal;
                        colMetaData.ColIndex = inPutTableColum.Ordinal;

                        int TotalElems = 0;

                        foreach (DataRow tableRow in TableWithData.Rows)
                        {//loop to check type of string in each row of subject Col
                            Boolean isAllDigit = true;
                            Boolean isAllChars = true;
                            Boolean isMixed = false;


                            if (tableRow[inPutTableColum.ColumnName].ToString() != "")
                            {// if empty ignore
                                TotalElems++;
                                colMetaData.ColTotalElems++;

                                foreach (char letter in tableRow[inPutTableColum.ColumnName].ToString())
                                {
                                    if (char.IsDigit(letter)) isAllChars = false;                     //check for chars and digits in rows of subject column
                                    else if (!char.IsDigit(letter)) isAllDigit = false;
                                }

                                if (!isAllDigit & !isAllChars) isMixed = true;

                                if (isAllChars) colMetaData.TotalNonDigitalElems++;
                                if (isAllDigit) colMetaData.TotalDigitalElems++;
                                if (isMixed) colMetaData.ColTotalMixedElems++;


                            }
                        }

                        //tbxDebuging.AppendText(inPutTableColum.ColumnName + "COLUMN has " + colMetaData.ColTotalElems + " elements \n");

                        if (colMetaData.ColTotalElems != 0)
                        {

                            ValidColums.Add(colMetaData);
                            //  tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has been added to list of valid cols \n");

                        }
                        else
                        {
                           // tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has NOT been added to list of valid cols \n");
                        }

                    }

                    //tbxDebuging.AppendText("------------------------------------------------------------------------\n");

                    //tbxDebuging.AppendText("\n");



                }



                ////<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//



                if (ValidColums.Count > 0)
                {
                    foreach (ColumnMetaData selectedColum in ValidColums)
                    {

                        if (selectedColum.ColName.ToLower().Contains("first") & selectedColum.ColName.ToLower().Contains("name") & !selectedColum.Assigned)
                        {
                            // CbxFName.SelectedIndex = selectedColum.ColIndex+1;
                           // CbxFName.SelectedItem = selectedColum.ColName;
                            Dictionary2Map["FirstName"] = selectedColum.ColIndex;
                            selectedColum.Assigned = true;
                        }

                        else if (selectedColum.ColName.ToLower().Contains("last") & selectedColum.ColName.ToLower().Contains("name") & !selectedColum.Assigned)
                        {
                            //cbxLName.SelectedIndex = selectedColum.ColIndex+1;
                            //cbxLName.SelectedItem = selectedColum.ColName;
                            Dictionary2Map["LastName"] = selectedColum.ColIndex;
                            selectedColum.Assigned = true;
                        }

                        else if (selectedColum.ColName.ToLower().Contains("middle") & selectedColum.ColName.ToLower().Contains("name") & !selectedColum.Assigned)
                        {
                            // CbxMidName.SelectedIndex = selectedColum.ColIndex+1;
                            Dictionary2Map["MiddleName"] = selectedColum.ColIndex;
                            selectedColum.Assigned = true;
                        }
                    }

                    //MessageBox.Show("CbxFName Index: " + CbxFName.SelectedIndex.ToString());
                    //MessageBox.Show("CbxLName Index: " + cbxLName.SelectedIndex.ToString());
                    //MessageBox.Show("CbxMidName Index: " + CbxMidName.SelectedIndex.ToString());

                    if ( Dictionary2Map["FirstName"] == -1)
                    {

                        int FNameTotalItems = -1;
                        int selectedColIndex = -1;
                        int ColumnindexCounter = -1;
                        foreach (ColumnMetaData columnItem in ValidColums)
                        {

                            ColumnindexCounter++;
                            if (!columnItem.Assigned)
                            {

                                if (columnItem.ColTotalElems > FNameTotalItems) { 
                                    selectedColIndex = ColumnindexCounter; 
                                    FNameTotalItems = columnItem.ColTotalElems; 
                                }

                            }
                        }

                        if (selectedColIndex > -1) { 
                            //CbxFName.SelectedItem = ValidColums[selectedColIndex].ColName;
                            Dictionary2Map["FirstName"] = ValidColums[selectedColIndex].ColIndex;
                            ValidColums[selectedColIndex].Assigned = true; }
                    }

                    if (Dictionary2Map["LastName"] == -1)
                    {

                        int LNameTotalItems = -1;
                        int selectedColIndex = -1;
                        int ColumnindexCounter = -1;

                        foreach (ColumnMetaData columnItem in ValidColums)
                        {
                            ColumnindexCounter++;

                            if (!columnItem.Assigned)
                            {

                                if (columnItem.ColTotalElems > LNameTotalItems) { selectedColIndex = ColumnindexCounter; LNameTotalItems = columnItem.ColTotalElems; }

                            }
                        }

                        if (selectedColIndex > 0) { 
                           // cbxLName.SelectedItem = ValidColums[selectedColIndex].ColName;
                            Dictionary2Map["LastName"] = ValidColums[selectedColIndex].ColIndex;
                            ValidColums[selectedColIndex].Assigned = true; 
                        }
                    }


                    if (Dictionary2Map["MiddleName"] == -1)
                    {

                        int MidNameTotalItems = -1;
                        int selectedColIndex = -1;
                        int ColumnindexCounter = -1;
                        foreach (ColumnMetaData columnItem in ValidColums)
                        {
                            ColumnindexCounter++;

                            if (!columnItem.Assigned)
                            {

                                if (columnItem.ColTotalElems > MidNameTotalItems) { selectedColIndex = ColumnindexCounter; MidNameTotalItems = columnItem.ColTotalElems; }

                            }
                        }

                        if (selectedColIndex > 0) { 
                           // CbxMidName.SelectedItem = ValidColums[selectedColIndex].ColName;
                            Dictionary2Map["MiddleName"] = ValidColums[selectedColIndex].ColIndex;
                            ValidColums[selectedColIndex].Assigned = true; }
                    }
                }

            }



        }

        private string removeUnwantedCharaters(string DirtyString)
        {
            string string2return = "";

            DirtyString = DirtyString.Trim();
            foreach (char letter in DirtyString)
            {
                if (char.IsLetter(letter) | char.IsDigit(letter) | letter == ' ')
                {
                    string2return = string2return + letter.ToString();
                }
            }

            return string2return;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            sbuilderErrorFile = new StringBuilder();
            DataBaseObj = new DatabaseInterfaceClass("Contacts");
            RbtnSingleUpdateMode.Checked = true;
            RbtnMultiVcardUpdateMode.Checked = false;
            BtnOkUpdate.Enabled = false;
            lblFileInUpdateMode.ForeColor = Color.Red;
            lblFileInUpdateMode.Text = "NO File Or Folder Selected!";
            // tbxLog.Enabled = false;

            ////UpdateGUI = false ;
            ////ClearGUI = false;
            ////StopWhileLoop = false;
            ////sbOutputLog = new StringBuilder();
            ////loggingString = "";

            //GUIlogThread  = new Thread (new ThreadStart (updateLOgDisplay));

            //changeGUILogUpdateSettings(true, false, false, "Starting program...");

            ////GUIlogThread.Start();

            openFileDlgIN = new OpenFileDialog();
            folderBrowseDlgIN = new FolderBrowserDialog();

            openFileDlgIN.Filter = "Vcard Files(*.VCF)|*.vcf|Comma Seperated Files(*.CSV)|*.csv";
            openFileDlgIN.ReadOnlyChecked = true;
            openFileDlgIN.Multiselect = false;
            openFileDlgIN.Title = "Open File With Contacts";

        }



        private void SearchMenuItem_Click(object sender, EventArgs e)
        {
            SearchDataBaseForm searchForm = new SearchDataBaseForm();
            searchForm.ShowDialog();
        }

        private void BtnLoadFileUpdateMode_Click(object sender, EventArgs e)
        {
            openFileDlgIN.FileName = "";
            BtnOkUpdate.Enabled = false;
            try
            {
                folderBrowseDlgIN.SelectedPath = "";
                folderBrowseDlgIN.ShowDialog();

                lblFileInUpdateMode.Text = "";
                BtnOkUpdate.Enabled = false;
                if (folderBrowseDlgIN.SelectedPath != "")
                {
                    lblFileInUpdateMode.ForeColor = Color.Green;
                    lblFileInUpdateMode.Text = folderBrowseDlgIN.SelectedPath.ToString();
                    BtnOkUpdate.Enabled = true;

                }

                else
                {

                    lblFileInUpdateMode.ForeColor = Color.Red;
                    lblFileInUpdateMode.Text = "No File Selected!";
                    BtnOkUpdate.Enabled = false;
                    throw new Exception("No Folder Selected");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void BtnOkUpdate_Click(object sender, EventArgs e)
        {
            StreamReader sReader;
            try
            {
                string FileExtension = Path.GetExtension(openFileDlgIN.FileName).ToUpper();
                System.Threading.Thread thrd = new Thread(new ThreadStart(ProcessCSVFiles_Caller));
                thrd.Start();

           }

            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString(), "Error Occured");
               // if (fileIN != null) fileIN.Close();
            }
        }


        

        private void updateLOgDisplay()
        {


            while (!StopWhileLoop)
            {
                if (UpdateGUI & !ClearGUI)
                {

                    safeThreadExecutionMethod();

                    UpdateGUI = false;
                    loggingString = "";
                }
                else if (UpdateGUI & ClearGUI)
                {

                    sbOutputLog.Clear();
                    //tbxLog.Text = sbOutputLog.ToString();
                    safeThreadExecutionMethod();
                    UpdateGUI = false;
                    ClearGUI = false;
                }


            }
        }

        private void setLogTextMethod()
        {
            tbxLog.Text = sbOutputLog.ToString();
        }

        private void safeThreadExecutionMethod()
        {

            if (this.tbxLog.InvokeRequired)
            {
                setLogTextDelegate setTextdelegate = new setLogTextDelegate(setLogTextMethod);
                this.Invoke(setTextdelegate);
            }
            else
            {
                tbxLog.Text = sbOutputLog.ToString();
            }


        }

        private List<string> customStringSpliter(List<char> inputListofChars, string inputStringLocal)
        {

            if (inputListofChars.Count > 0 & inputStringLocal.Length > 0)
            {

                List<string> currentListLocal = new List<string> { };
                //List<string> tempListLocal = new List<string> { };
                List<string> finalListLocal = new List<string> { };

                char[] inputCharsArray = inputListofChars.ToArray();

                inputStringLocal = inputStringLocal.TrimStart(inputCharsArray);
                inputStringLocal = inputStringLocal.TrimEnd(inputCharsArray);

                currentListLocal.Clear();
                currentListLocal.Add(inputStringLocal);

                for (int i_char = 0; i_char < inputListofChars.Count; i_char++)
                {
                    List<string> tempListLocal = new List<string> { };
                    char currentInputChar = inputListofChars[i_char];



                    for (int i_string = 0; i_string < currentListLocal.Count; i_string++)
                    {


                        string currentInputStringFromList = currentListLocal[i_string];

                        string tempString2 = "";

                        //List<string> tempListLocal = new List<string> { };
                        for (int i_charInCurrentStringFromList = 0; i_charInCurrentStringFromList < currentInputStringFromList.Length; i_charInCurrentStringFromList++)
                        {

                            char charinCurrentString = currentInputStringFromList[i_charInCurrentStringFromList];
                            if (currentInputStringFromList[i_charInCurrentStringFromList] == currentInputChar)
                            {
                                if (tempString2 == "") { }
                                else
                                {
                                    tempListLocal.Add(tempString2);
                                    tempString2 = "";
                                }
                            }

                            else if (i_charInCurrentStringFromList == currentInputStringFromList.Length - 1)
                            {

                                tempString2 = tempString2 + currentInputStringFromList[i_charInCurrentStringFromList];
                                if (tempString2 == "") { }
                                else
                                {
                                    tempListLocal.Add(tempString2);
                                    tempString2 = "";
                                }
                            }

                            else tempString2 = tempString2 + currentInputStringFromList[i_charInCurrentStringFromList];

                        }
                    }

                    currentListLocal = tempListLocal;


                }

                finalListLocal = currentListLocal;

                return finalListLocal;
            }
            else return new List<string> { inputStringLocal };

        }

        private void btnClearDB_Click(object sender, EventArgs e)
        {

            int rowCounter = 0;
            int totalRows = DataBaseObj.objDataSet.Tables[0].Rows.Count;
            string totalRowStr = totalRows.ToString();


            try
            {
                foreach (DataRow dtRowCurr in DataBaseObj.objDataSet.Tables["contacts"].Rows)
                {
                    dtRowCurr.Delete();
                    rowCounter++;
                }

                // DataBaseObj.objCommandBuilder.GetDeleteCommand();
                DataBaseObj.objDataAdapter.Update(DataBaseObj.objDataSet, "contacts");

                MessageBox.Show("Success! " + rowCounter + " Records Deleted!" + " Current Table Rows: " + DataBaseObj.objDataSet.Tables["contacts"].Rows.Count.ToString());

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), "Database Deletion Error");
            }
        }

        private void ProcessCSVFiles_Executer( string fileName) {

            DataTable RawDataTable = new DataTable();
            DataTable ProcessedDataTable = new DataTable();// Define DataTable

            //fileIN = new FileStream(openFileDlgIN.FileName, FileMode.Open); // open loaded fi
            //sReader = new StreamReader(fileIN);                                // stream reader to read file
            //csvReaderObj = new CsvReader(sReader, true);  // CSV reader object with Sreader

            CsvHelper.Configuration.CsvConfiguration config = new CsvHelper.Configuration.CsvConfiguration();

            config.HasHeaderRecord = true;


           // csvReaderOBJHelper = new CsvHelper.CsvReader(File.OpenText(openFileDlgIN.FileName), config);

            csvReaderOBJHelper = new CsvHelper.CsvReader(File.OpenText(fileName), config);

            //int ColumnCount = csvReaderObj.FieldCount;
            // Total Fields

            Boolean rd = csvReaderOBJHelper.Read();



            int ColumnCount = csvReaderOBJHelper.FieldHeaders.Length;

            //string[] FileHeaders = csvReaderObj.GetFieldHeaders(); //load field headers into an array

            string[] FileHeaders = csvReaderOBJHelper.FieldHeaders;



            if (FileHeaders.Length == 0) throw new Exception("No Headers Foind in CSV File");// cause error if no filds
            else
            {
                for (int i = 0; i < FileHeaders.Length; i++)
                {

                    RawDataTable.Columns.Add(FileHeaders[i]);
                }



                List<string> colNamesList = new List<string> { };
                foreach (DataColumn ColObj in RawDataTable.Columns)
                {
                    if (!colNamesList.Contains(ColObj.ColumnName)) colNamesList.Add(ColObj.ColumnName);
                    else throw new Exception("Csv File Contains Duplicate Column Names!");
                }




                if (csvReaderOBJHelper.CurrentRecord != null) {


                                    while (csvReaderOBJHelper.Read())
                {
                    string[] currentRow = csvReaderOBJHelper.CurrentRecord;

                    int totalCells = currentRow.Length;

                    DataRow dtRow = RawDataTable.NewRow();



                    for (int i2 = 0; i2 < FileHeaders.Length; i2++)
                    {
                        if (currentRow[i2] == null | currentRow[i2] == "") dtRow[i2] = "";
                        else
                        {
                            dtRow[i2] = currentRow[i2];
                        }
                    }

                    RawDataTable.Rows.Add(dtRow);
                }

                //fileIN.Close();

                ////// AUTOMATION BEGIN S HERE

                List<ContactDataClass> ListOfFinalContacts = AutomatchDataFields(RawDataTable);



               

               // MessageBox.Show("Have exixted Editor window");
               // MessageBox.Show(ListOfFinalContacts.Count.ToString());




                int totalRows = DataBaseObj.objDataSet.Tables[0].Rows.Count;


                if (ListOfFinalContacts.Count > 0)
                {

                    for (int RowsCounter = 0; RowsCounter < ListOfFinalContacts.Count; RowsCounter++)
                    {

                        threadSafeLableUpdate(lblLog, "Processing contact: " + (RowsCounter+1).ToString() + " of " + ListOfFinalContacts.Count.ToString());


                        ContactDataClass contactItem = ListOfFinalContacts[RowsCounter];

                        foreach (string phoneNumber in contactItem.numbersList)
                        {// for each phone number of cirrent contact

                            DataRow dtr = DataBaseObj.objDataSet.Tables["Contacts"].Rows.Find(phoneNumber);

                            if (dtr != null)// if number in database
                            {

                                string currentNameList = dtr["Name Collections"].ToString();// get names

                                List<string> contactItemNameCollections = new List<string> { };
                                contactItemNameCollections.Clear();
                                foreach (string contactName in contactItem.namesList)
                                {
                                    List<string> contactItemNameCollections_temp = customStringSpliter(new List<char> { ' ', '.' }, contactName);

                                    foreach (string string_temp in contactItemNameCollections_temp)
                                    {

                                        if (!contactItemNameCollections.Contains(string_temp)) contactItemNameCollections.Add(removeUnwantedCharaters(string_temp));
                                    }

                                }


                                foreach (string splitName in contactItemNameCollections)
                                {
                                    if (splitName == "")
                                    {
                                        //currentNameList = ""; 
                                    }

                                    else
                                    {

                                        currentNameList = currentNameList + splitName + "^";
                                    }
                                }

                                dtr["Name Collections"] = currentNameList;

                                DataBaseObj.objCommandBuilder.GetUpdateCommand();
                                DataBaseObj.objDataAdapter.Update(DataBaseObj.objDataSet, "Contacts");
                                //MessageBox.Show("Update Not Null Successfull");
                            }

                            else
                            {

                                string currentNameList = "";

                                DataRow newDtRow = DataBaseObj.objDataSet.Tables[0].NewRow();
                                newDtRow["Phone Number"] = phoneNumber;
                                // newDtRow["Name Collection"] = "";

                                List<string> contactItemNameCollections = new List<string> { };
                                contactItemNameCollections.Clear();
                                foreach (string contactName in contactItem.namesList)
                                {
                                    List<string> contactItemNameCollections_temp = customStringSpliter(new List<char> { ' ', '.' }, contactName);

                                    foreach (string string_temp in contactItemNameCollections_temp)
                                    {

                                        if (!contactItemNameCollections.Contains(string_temp)) contactItemNameCollections.Add(removeUnwantedCharaters(string_temp));
                                    }

                                }


                                foreach (string splitName in contactItemNameCollections)
                                {
                                    if (splitName == "")
                                    {
                                        //currentNameList = ""; 
                                    }

                                    else
                                    {

                                        currentNameList = currentNameList + splitName + "^";
                                    }
                                }

                                newDtRow["Name Collections"] = currentNameList;

                                string emails = "";
                                foreach (string contactEmail in contactItem.emailsList)
                                {

                                    emails = emails + contactEmail + "^";

                                }

                                newDtRow["Emails"] = emails;

                                newDtRow["Related Numbers"] = "";
                                newDtRow["Full Name"] = false;
                                newDtRow["True Name"] = "";

                                DataBaseObj.objDataSet.Tables["Contacts"].Rows.Add(newDtRow);

                                DataBaseObj.objCommandBuilder.GetUpdateCommand();
                                DataBaseObj.objDataAdapter.Update(DataBaseObj.objDataSet, "Contacts");

                            }


                        }


                    }

                  //  MessageBox.Show("Database Update Sucessfull!");


                }
                }
             
            }

        }

        private void ProcessCSVFiles_Caller() {

            string[] filenamesCollection = Directory.GetFiles(folderBrowseDlgIN.SelectedPath , "*.csv", SearchOption.AllDirectories);

            MessageBox.Show (filenamesCollection .Length .ToString () +" Files Found ", "Notice");
            
            foreach ( string fileInputName in filenamesCollection ){

                //threadSafeLableUpdate(lblLog, "Now Processing " + fileInputName);

                threadSafeTextBoxUpdate(tbxLog, "Now Processing " + fileInputName, true);

                ProcessCSVFiles_Executer(fileInputName);
            }

            MessageBox.Show("All files have Been Processed");
        }

       



    }
}

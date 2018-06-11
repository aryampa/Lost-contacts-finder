using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LostContactFinder._01_Automated
{
    public partial class DisplayPreview : Form
    {
        DataTable inputTable;
        public DataTable outputTable;
        public List<ContactDataClass> ListofFinalContacts = new List<ContactDataClass> { };

        public DisplayPreview()
        {
            InitializeComponent();
        }

        public DisplayPreview(DataTable InputTable)
        {

            this.InitializeComponent();
            inputTable = InputTable;

        }

        private void DisplayPreview_Load(object sender, EventArgs e)
        {
            if (inputTable != null)
            {

                dbGridView.DataSource = inputTable;

                CbxFName.Items.Add("Not Set");

                CbxMidName.Items.Add("Not Set");
                cbxLName.Items.Add("Not Set");
                cbxPhone1.Items.Add("Not Set");
                cbxPhone2.Items.Add("Not Set");
                cbxPhone3.Items.Add("Not Set");
                cbxPhone4.Items.Add("Not Set");
                cbxPhone5.Items.Add("Not Set");
                cbxPhone6.Items.Add("Not Set");
                cbxEmail1.Items.Add("Not Set");
                cbxEmail2.Items.Add("Not Set");

                CbxFName.SelectedIndex = 0;
                CbxMidName.SelectedIndex = 0;
                cbxLName.SelectedIndex = 0;
                cbxPhone1.SelectedIndex = 0;
                cbxPhone2.SelectedIndex = 0;
                cbxPhone3.SelectedIndex = 0;
                cbxPhone4.SelectedIndex = 0;
                cbxPhone5.SelectedIndex = 0;
                cbxPhone6.SelectedIndex = 0;
                cbxEmail1.SelectedIndex = 0;
                cbxEmail2.SelectedIndex = 0;

                for (int c = 0; c < inputTable.Columns.Count; c++)
                {

                    CbxFName.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxLName.Items.Add(inputTable.Columns[c].ColumnName);
                    CbxMidName.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxPhone1.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxPhone2.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxPhone3.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxPhone4.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxPhone5.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxPhone6.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxEmail1.Items.Add(inputTable.Columns[c].ColumnName);
                    cbxEmail2.Items.Add(inputTable.Columns[c].ColumnName);
                }
            }
            else
            {
                MessageBox.Show("Data Table Note Set ! ");
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CbxFName_SelectedIndexChanged(object sender, EventArgs e)
        {


            ComboBox CurrentCombox = sender as ComboBox;
            // MessageBox.Show(CurrentCombox.Name);



            foreach (Control ctrl in this.Controls)
            {

                // MessageBox.Show(ctrl.Name + "------------------------------------"+ctrl.GetType().Name);

                if (ctrl.GetType().Name.ToString() == "ComboBox" & ctrl.Name.ToString() != CurrentCombox.Name.ToString())
                {
                    ComboBox testCombo = ctrl as ComboBox;

                    if (testCombo.SelectedItem != null)
                    {

                        if (testCombo.SelectedItem.ToString() == CurrentCombox.SelectedItem.ToString())
                        {
                            testCombo.SelectedIndex = 0;
                        }
                    }

                }
            }

        }

        private void btnClearMatch_Click(object sender, EventArgs e)
        {

            CbxFName.SelectedIndex = 0;
            CbxMidName.SelectedIndex = 0;
            cbxLName.SelectedIndex = 0;
            cbxPhone1.SelectedIndex = 0;
            cbxPhone2.SelectedIndex = 0;
            cbxPhone3.SelectedIndex = 0;
            cbxPhone4.SelectedIndex = 0;
            cbxEmail1.SelectedIndex = 0;
            cbxEmail2.SelectedIndex = 0;

            dbGridView.DataSource = inputTable;

        }

        private void btnAutoMatch_Click(object sender, EventArgs e)
        {
            autoMatchNames(inputTable);
            autoMatchNumbers(inputTable);
            autoMatchEmail(inputTable);

        }

        private void autoMatchEmail(DataTable TableWithEmails)
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

                        foreach (DataRow tableRow in inputTable.Rows)
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


                if (cbxEmail1.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxEmail1.SelectedItem = validColumnsWithEmailList[selectedColIndex].ColName; validColumnsWithEmailList[selectedColIndex].Assigned = true; }
                }

                if (cbxEmail2.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxEmail2.SelectedItem = validColumnsWithEmailList[selectedColIndex].ColName; validColumnsWithEmailList[selectedColIndex].Assigned = true; }
                }



            }
        }

        private void autoMatchNumbers(DataTable TableWithNumbers)
        {

            if (TableWithNumbers.Rows.Count == 0) MessageBox.Show("No Data Found in Data Table");
            else
            {

                List<ColumnMetaData> validColumnsWithNumbersList = new List<ColumnMetaData> { };
                List<char> phoneCharacters = new List<char> { '*', '#', '+', ' ', '(', ')', '?', '-' };

                ////>>>>>>>>>>>>>>>>>>>>>>>>> START FILTERING_OUT VALID CONTACTS ////////////////////////////

                foreach (DataColumn inPutTableColum in TableWithNumbers.Columns)
                {
                    tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN is NOW being Processed\n");




                    if (inPutTableColum.ColumnName.ToLower().Contains("phone") | inPutTableColum.ColumnName.ToLower().Contains("mobile") | inPutTableColum.ColumnName.ToLower().Contains("number"))
                    {
                        //tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN Contains PHONE or MOBILE...hence is tobe analysed...\n");


                        ColumnMetaData colMetaData = new ColumnMetaData(inPutTableColum.ColumnName);

                        int colIndex = inPutTableColum.Ordinal;
                        colMetaData.ColIndex = inPutTableColum.Ordinal;

                        int TotalElems = 0;

                        int rowCounterNew = 0;

                        foreach (DataRow tableRow in inputTable.Rows)
                        {

                            rowCounterNew++;
                            if (inPutTableColum.ColumnName == "Mobile Phone") tbxDebuging.AppendText(tableRow["First Name"].ToString() + " has Number ===> " + tableRow["Mobile Phone"] + "===>" + rowCounterNew.ToString() + "\n");
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
                                    if (inPutTableColum.ColumnName == "Mobile Phone") tbxDebuging.AppendText(tableRow["First Name"].ToString() + " has MIXED Number ===> " + tableRow["Mobile Phone"] + "===>" + rowCounterNew.ToString() + "\n");
                                }


                            }
                        }

                        // tbxDebuging.AppendText(inPutTableColum.ColumnName + "COLUMN has " + colMetaData.ColTotalElems + " elements \n");

                        //Console.WriteLine(inPutTableColum.ColumnName);

                        string columnName = inPutTableColum.ColumnName;

                        float NonDigitalElemsPercantage = (colMetaData.TotalNonDigitalElems / (float)colMetaData.ColTotalElems) * 100;
                        float DigitalElemPercentage = ((colMetaData.TotalDigitalElems / (float)colMetaData.ColTotalElems) * 100);

                        if (((colMetaData.TotalNonDigitalElems / (float)colMetaData.ColTotalElems) * 100) > 2.0 | ((colMetaData.TotalDigitalElems / (float)colMetaData.ColTotalElems) * 100) < 90.0) { }
                        else
                        {
                            if (colMetaData.ColTotalElems != 0)
                            {

                                validColumnsWithNumbersList.Add(colMetaData);
                                //tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has been added to list of valid cols \n");
                            }
                            else
                            {
                                // tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has NOT been added to list of valid cols \n");
                            }
                        }
                    }

                    tbxDebuging.AppendText("------------------------------------------------------------------------\n");

                    tbxDebuging.AppendText("\n");



                }


                //////////////>>>>>>>>>>>>>>>>>>>>>>> DONE FILTERING >>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>/////////////////////////////////////

                if (cbxPhone1.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxPhone1.SelectedItem = validColumnsWithNumbersList[selectedColIndex].ColName; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (cbxPhone2.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxPhone2.SelectedItem = validColumnsWithNumbersList[selectedColIndex].ColName; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (cbxPhone3.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxPhone3.SelectedItem = validColumnsWithNumbersList[selectedColIndex].ColName; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (cbxPhone4.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxPhone4.SelectedItem = validColumnsWithNumbersList[selectedColIndex].ColName; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (cbxPhone5.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxPhone5.SelectedItem = validColumnsWithNumbersList[selectedColIndex].ColName; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }

                if (cbxPhone6.SelectedItem.ToString() == "Not Set")
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

                    if (selectedColIndex > -1) { cbxPhone6.SelectedItem = validColumnsWithNumbersList[selectedColIndex].ColName; validColumnsWithNumbersList[selectedColIndex].Assigned = true; }
                }



            }


        }


        private void autoMatchNames(DataTable TableWithData)
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

                    tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN is NOW being Processed\n");



                    if (inPutTableColum.ColumnName.ToLower().Contains("name"))
                    {
                        tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN Contains name...hence is tobe analysed...\n");

                        ColumnMetaData colMetaData = new ColumnMetaData(inPutTableColum.ColumnName); //create column object to hold col info

                        int colIndex = inPutTableColum.Ordinal;
                        colMetaData.ColIndex = inPutTableColum.Ordinal;

                        int TotalElems = 0;

                        foreach (DataRow tableRow in inputTable.Rows)
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

                        tbxDebuging.AppendText(inPutTableColum.ColumnName + "COLUMN has " + colMetaData.ColTotalElems + " elements \n");

                        if (colMetaData.ColTotalElems != 0)
                        {

                            ValidColums.Add(colMetaData);
                            tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has been added to list of valid cols \n");

                        }
                        else tbxDebuging.AppendText(inPutTableColum.ColumnName + " COLUMN has NOT been added to list of valid cols \n");


                    }

                    tbxDebuging.AppendText("------------------------------------------------------------------------\n");

                    tbxDebuging.AppendText("\n");



                }



                ////<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<//



                if (ValidColums.Count > 0)
                {
                    foreach (ColumnMetaData selectedColum in ValidColums)
                    {

                        if (selectedColum.ColName.ToLower().Contains("first") & selectedColum.ColName.ToLower().Contains("name") & !selectedColum.Assigned)
                        {
                            // CbxFName.SelectedIndex = selectedColum.ColIndex+1;
                            CbxFName.SelectedItem = selectedColum.ColName;
                            selectedColum.Assigned = true;
                        }

                        else if (selectedColum.ColName.ToLower().Contains("last") & selectedColum.ColName.ToLower().Contains("name") & !selectedColum.Assigned)
                        {
                            //cbxLName.SelectedIndex = selectedColum.ColIndex+1;
                            cbxLName.SelectedItem = selectedColum.ColName;
                            selectedColum.Assigned = true;
                        }

                        else if (selectedColum.ColName.ToLower().Contains("middle") & selectedColum.ColName.ToLower().Contains("name") & !selectedColum.Assigned)
                        {
                            // CbxMidName.SelectedIndex = selectedColum.ColIndex+1;
                            CbxMidName.SelectedItem = selectedColum.ColName;
                            selectedColum.Assigned = true;
                        }
                    }

                    //MessageBox.Show("CbxFName Index: " + CbxFName.SelectedIndex.ToString());
                    //MessageBox.Show("CbxLName Index: " + cbxLName.SelectedIndex.ToString());
                    //MessageBox.Show("CbxMidName Index: " + CbxMidName.SelectedIndex.ToString());

                    if (CbxFName.SelectedItem.ToString() == "Not Set")
                    {

                        int FNameTotalItems = -1;
                        int selectedColIndex = -1;
                        int ColumnindexCounter = -1;
                        foreach (ColumnMetaData columnItem in ValidColums)
                        {

                            ColumnindexCounter++;
                            if (!columnItem.Assigned)
                            {

                                if (columnItem.ColTotalElems > FNameTotalItems) { selectedColIndex = ColumnindexCounter; FNameTotalItems = columnItem.ColTotalElems; }

                            }
                        }

                        if (selectedColIndex > -1) { CbxFName.SelectedItem = ValidColums[selectedColIndex].ColName; ValidColums[selectedColIndex].Assigned = true; }
                    }

                    if (cbxLName.SelectedItem.ToString() == "Not Set")
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

                        if (selectedColIndex > 0) { cbxLName.SelectedItem = ValidColums[selectedColIndex].ColName; ValidColums[selectedColIndex].Assigned = true; }
                    }


                    if (CbxMidName.SelectedItem.ToString() == "Not Set")
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

                        if (selectedColIndex > 0) { CbxMidName.SelectedItem = ValidColums[selectedColIndex].ColName; ValidColums[selectedColIndex].Assigned = true; }
                    }
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

        private void btnPreviewFinalTable_Click(object sender, EventArgs e)
        {
            DataTable FinalTable = new DataTable();

            List<string> originalColNames = new List<string> { };

            foreach (Control ctrl in this.Controls)
            {


                if (ctrl.GetType().Name.ToString() == "ComboBox")
                {
                    ComboBox testCombo = ctrl as ComboBox;


                    if (testCombo.SelectedItem != null & testCombo.SelectedItem.ToString().ToLower() != "not set")
                    {
                        if (testCombo.Name.ToString() == "CbxFName") { FinalTable.Columns.Add("First Name"); originalColNames.Add(CbxFName.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "CbxMidName") { FinalTable.Columns.Add("Middle Name"); originalColNames.Add(CbxMidName.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "cbxLName") { FinalTable.Columns.Add("Last Name"); originalColNames.Add(cbxLName.SelectedItem.ToString()); }

                        if (testCombo.Name.ToString() == "cbxPhone1") { FinalTable.Columns.Add("Phone 1"); originalColNames.Add(cbxPhone1.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "cbxPhone2") { FinalTable.Columns.Add("Phone 2"); originalColNames.Add(cbxPhone2.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "cbxPhone3") { FinalTable.Columns.Add("Phone 3"); originalColNames.Add(cbxPhone3.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "cbxPhone4") { FinalTable.Columns.Add("Phone 4"); originalColNames.Add(cbxPhone4.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "cbxPhone5") { FinalTable.Columns.Add("Phone 5"); originalColNames.Add(cbxPhone5.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "cbxPhone6") { FinalTable.Columns.Add("Phone 6"); originalColNames.Add(cbxPhone6.SelectedItem.ToString()); }

                        if (testCombo.Name.ToString() == "cbxEmail1") { FinalTable.Columns.Add("Email 1"); originalColNames.Add(cbxEmail1.SelectedItem.ToString()); }
                        if (testCombo.Name.ToString() == "cbxEmail2") { FinalTable.Columns.Add("Email 2"); originalColNames.Add(cbxEmail2.SelectedItem.ToString()); }



                    }

                }


            }

            for (int r0w = 0; r0w < inputTable.Rows.Count; r0w++)
            {

                DataRow newDataR0w = FinalTable.NewRow();

                for (int c0lumnValue = 0; c0lumnValue < FinalTable.Columns.Count; c0lumnValue++)
                {
                    if (originalColNames[c0lumnValue].ToString().ToLower().Contains("phone") | originalColNames[c0lumnValue].ToString().ToLower().Contains("number") | originalColNames[c0lumnValue].ToString().ToLower().Contains("mobile"))
                    {
                        string cellNumberValue = inputTable.Rows[r0w][originalColNames[c0lumnValue]].ToString();
                        string formatedPhoneNumber = formatPhoneNumbers(RemoveUnwantedCharacters(cellNumberValue));

                        if (formatedPhoneNumber == "") newDataR0w[c0lumnValue] = "";
                        else newDataR0w[c0lumnValue] = formatedPhoneNumber;
                    }

                    else
                    {

                        newDataR0w[c0lumnValue] = inputTable.Rows[r0w][originalColNames[c0lumnValue]];
                    }
                }

                FinalTable.Rows.Add(newDataR0w);
            }

            dbGridView.DataSource = FinalTable;


            ListofFinalContacts.Clear();
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

                if (FinalTable.Columns.Contains("Phone 1"))
                {
                    if (currentRow["Phone 1"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone 1"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone 2"))
                {
                    if (currentRow["Phone 2"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone 2"].ToString());
                }

                if (originalColNames.Contains("Phone 3"))
                {
                    if (currentRow["Phone 3"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone 3"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone 4"))
                {
                    if (currentRow["Phone 4"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone 4"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone 5"))
                {
                    if (currentRow["Phone 5"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone 5"].ToString());
                }

                if (FinalTable.Columns.Contains("Phone 6"))
                {
                    if (currentRow["Phone 6"].ToString() != "") ContactObject.updateNumbers(currentRow["Phone 6"].ToString());
                }

                if (FinalTable.Columns.Contains("Email 1"))
                {
                    if (currentRow["Email 1"].ToString() != "") ContactObject.updateNumbers(currentRow["Email 1"].ToString());
                }

                if (FinalTable.Columns.Contains("Email 2"))
                {
                    if (currentRow["Email 2"].ToString() != "") ContactObject.updateNumbers(currentRow["Email 2"].ToString());
                }

                ListofFinalContacts.Add(ContactObject);


            }

            MessageBox.Show("Contacts List of " + ListofFinalContacts.Count.ToString() + " successfully Generated!");

            //SharedStaticResources.sharedProcessedContactsList = ListofFinalContacts;

        }

        private string formatPhoneNumbers(string number)
        {

            List<string> phonePrefixList = new List<string> { "71", "72", "74", "75", "76", "77", "78", "79", "80", "41" };

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

        private void btnAccept_Click(object sender, EventArgs e)
        {

        }


    }
}

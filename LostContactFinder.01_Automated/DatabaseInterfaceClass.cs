using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace LostContactFinder._01_Automated
{
    public class DatabaseInterfaceClass
    {
        private string Table_name = "";
        public DataSet objDataSet;
        public OleDbConnection objConection;
        public OleDbCommand objCommand;
        public OleDbCommandBuilder objCommandBuilder;
        public OleDbDataAdapter objDataAdapter;


        public DatabaseInterfaceClass()
        {
        }

        public DatabaseInterfaceClass(string tablename)
        {


            string SqlCommandStrg = "Select * FROM " + "[" + tablename + "]";
            Table_name = tablename;

            try
            {
                string appDir = Path.GetDirectoryName(Application.ExecutablePath);
                //objConection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=aryampa;Data Source=D:\\PROGRAMMING STUFF\\VISUAL STUDIO PROJECTS\\databases\\editable db\\BugatechDB2.accdb");

                objConection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=aryampa;Data Source=" + appDir + "\\RawContacts.mdb");
                objCommand = new OleDbCommand();
                objCommand.Connection = objConection;
                objCommand.CommandType = CommandType.Text;

                objDataAdapter = new OleDbDataAdapter();
                objDataAdapter.SelectCommand = objCommand;
                objCommandBuilder = new OleDbCommandBuilder(objDataAdapter);

                objDataAdapter.SelectCommand.CommandText = SqlCommandStrg;

                objDataAdapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;


                objCommandBuilder.QuotePrefix = "[";
                objCommandBuilder.QuoteSuffix = "]";

                objDataSet = new DataSet();

                objDataAdapter.Fill(objDataSet, tablename);
            }

            catch (Exception ex)
            {
                Console.Write(ex.Message.ToString());
            }




        }

        public DataTable GetDatabaseInfo()
        {

            DataTable tableScheme = new DataTable();
            try
            {
                OleDbConnection dbConnection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Jet OLEDB:Database Password=aryampa;Data Source=D:\\PROGRAMMING STUFF\\VISUAL STUDIO PROJECTS\\databases\\editable db\\BugatechDB2.accdb");

                dbConnection.Open();

                tableScheme = dbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });

                dbConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Getting Requested Database Schema: " + ex.Message, "Schema retrieval Error");
            }

            return tableScheme;


        }

        public List<Dictionary<string, string>> get_rows(Dictionary<string, string> row_with_search_data)
        {
            Dictionary<string, string> temp_row_with_search_data = row_with_search_data;
            List<Dictionary<string, string>> list_of_saerchResultRows = new List<Dictionary<string, string>> { };


            if (temp_row_with_search_data.ContainsKey("Action")) { temp_row_with_search_data.Remove("Action"); }
            if (temp_row_with_search_data.ContainsKey("RowID")) { temp_row_with_search_data.Remove("RowID"); }
            if (temp_row_with_search_data.ContainsKey("Status")) { temp_row_with_search_data.Remove("Status"); }

            foreach (DataRow dtSearchRow in objDataSet.Tables[Table_name].Rows)
            {


                foreach (KeyValuePair<string, string> dic_key_values in temp_row_with_search_data)
                {

                    if (dtSearchRow[dic_key_values.Key.ToString()].ToString().Contains(dic_key_values.Value.ToString()))
                    {
                        Dictionary<string, string> positive_result_row = new Dictionary<string, string> { };

                        foreach (DataColumn dtcol in objDataSet.Tables[Table_name].Columns)
                        {
                            positive_result_row.Add(dtcol.ColumnName.ToString(), dtSearchRow[dtcol.ColumnName.ToString()].ToString());

                        }

                        list_of_saerchResultRows.Add(positive_result_row);
                    }
                }
            }

            return list_of_saerchResultRows;
        }

        public Boolean deleteItem(string ID_of_row_to_delete)
        {

            Boolean deleteSuccess = false;

            return deleteSuccess;
        }

        public Boolean editRow(string row_id, string column_name)
        {

            Boolean rowEditSuccess = false;
            return rowEditSuccess;
        }

    }
}
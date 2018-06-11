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
    public partial class Test_StringSpliterForm : Form
    {
        public Test_StringSpliterForm()
        {
            InitializeComponent();
        }

        StringBuilder sbOutputChars = new StringBuilder();
        StringBuilder sbOutputFinal = new StringBuilder();
        List<char> listofChars = new List<char> { };
        List<string> listofString = new List<string> { };

        private void Test_StringSpliterForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            tbxInput.Text = "";
        }

        private void btnCharClear_Click(object sender, EventArgs e)
        {
            listofChars.Clear();
            sbOutputChars.Clear();
            tbxOutputChars.Text = sbOutputChars.ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            char char2add;

            if (tbxCharInsput.Text == "") char2add = ' ';
            else char2add = tbxCharInsput.Text[0];
            listofChars.Add(char2add);
            sbOutputChars.AppendLine(tbxCharInsput.Text);
            tbxOutputChars.Text = sbOutputChars.ToString();
        }

        private void btnSplit_Click(object sender, EventArgs e)
        {
            listofString = customStringSpliter(listofChars, tbxInput.Text);

            foreach (string listString in listofString)
            {

                sbOutputFinal.AppendLine(listString);
            }

            tbxFinalOutput.Text = sbOutputFinal.ToString();



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

                            // char charinCurrentString = currentInputStringFromList[i_charInCurrentStringFromList];
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

    }
}

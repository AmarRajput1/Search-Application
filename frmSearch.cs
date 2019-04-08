using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SearchTest
{
    public partial class frmSearch : Form
    {
        ExcelComms excel = new ExcelComms(); //instantiate the excelComms class
        string filePath = Application.StartupPath + "\\Data.xlsx"; //get the file path for the excel file
        private static bool searchInProgress = false; //do stuff while search is in progress...

        public static bool cancelBGW = false; //cancel the backgroundworker if needs be
        string conString = "Server=.;Database=SearchResults;User ID=sa;Password=sasdi;"; //temp connection string. In a real application would use user specifications
        string queryString = "";

        //SQL database parameters...
        string tableName = "ResultsTable";

        public frmSearch()
        {
            InitializeComponent();
            FormatGridview(); //format the data gridview to have the same amound of columns etc as the excel data and sql table
        }

        private void FormatGridview()
        {
            dgRes.ColumnCount = ExcelComms.columnCount; //use the excel file as a basis for everything. Could be changed to be more robust

            for (int i = 0; i < dgRes.ColumnCount; i++) //grab the headers for all the columns
                dgRes.Columns[i].HeaderText = ExcelComms.columnHeaders[i];
        }

        private void PopulateExcelData() //grab data from the excel file
        {
            Object[,] results = ExcelComms.GetData(filePath); //pass the results from excel instance into a local object array
            string[] rowToAdd = new string[ExcelComms.columnCount]; //create a string array to evaluate each row against search criteria as it is added to the table

            for (int i = 0; i < ExcelComms.rowCount - 1; i++)
            {
                for (int j = 0; j < ExcelComms.columnCount; j++)                
                    rowToAdd[j] = results[i, j].ToString(); //add some results to the row                

                if (searchInProgress)
                {
                    if (txtLowSal.Text != "" || txtHighSal.Text != "")
                        if (txtLowSal.Text == "" || txtHighSal.Text == "") //throw up a message if user has entered only partial information for salary
                        {
                            MessageBox.Show("Please type both lower and upper search limits to include a salary range in the search criteria.");
                            return;
                        }

                    if (EvaluateData(rowToAdd)) //only if we are searching, pass the row through evaluation against criteria before adding to the display
                        dgRes.Rows.Add(rowToAdd);
                }
                else
                    dgRes.Rows.Add(rowToAdd);
            }
        }

        private bool EvaluateData(string[] rowToEvaluate)
        {
            //create some bools and pass each one based on the specified criteria
            bool namePass = false; 
            bool genderPass = false;
            bool empNumPass = false;
            bool salaryPass = false;

            if ((txtName.Text == "") || (rowToEvaluate[0] == txtName.Text))
                namePass = true; //if the textbox is empty or matches the data, pass

            if ((cmbGender.Text == "") || (rowToEvaluate[2] == cmbGender.Text.ToLower()))
                genderPass = true; //if the text is empty or matches the data, pass

            if (txtEmpNum.Text == "")
                empNumPass = true; //pass if empty (unspecified)
            else
                switch (rdoExactEmpNum.Checked) //pass on finding partial or exact string based on selections
                {
                    case (true):
                        if (rowToEvaluate[1] == txtEmpNum.Text)
                            empNumPass = true;
                        break;
                    case (false):
                        if (rowToEvaluate[1].Contains(txtEmpNum.Text))
                            empNumPass = true;
                        break;
                }

            if (txtLowSal.Text == "" && txtHighSal.Text == "")
                salaryPass = true; //pass if unspecified
            else
                if ((int.Parse(rowToEvaluate[3]) >= int.Parse(txtLowSal.Text)) && (int.Parse(rowToEvaluate[3]) <= int.Parse(txtHighSal.Text)))
                salaryPass = true; //pass if the limits fall around the data as expected



            if (namePass && genderPass && empNumPass && salaryPass)
                return true; //only return true if all fields are in pass state. Otherwise this row does not get displayed in the search results
            else
                return false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //excel side of things
            dgRes.Rows.Clear();
            searchInProgress = true;
            PopulateExcelData();

            if (cbSQL.Checked)
            {
                //sql side of things - first build the query string
                queryString = "SELECT * FROM [" + tableName + "]";
                 
                if (txtName.Text != "" || txtEmpNum.Text != "" || cmbGender.Text != "" || txtHighSal.Text != "" || txtLowSal.Text != "")
                {
                    queryString = queryString + " WHERE "; //if any of the fields have been included, we must develop this query string further
                    if (!string.IsNullOrEmpty(txtName.Text))
                        queryString = queryString + " [NAME] = '" + txtName.Text + "' AND "; //add name elements to the query string
                    if (!string.IsNullOrEmpty(cmbGender.Text))
                        queryString = queryString + " [GENDER] = '" + cmbGender.Text + "' AND "; //add gender elements...
                    if (!string.IsNullOrEmpty(txtEmpNum.Text))
                        if (rdoExactEmpNum.Checked)
                            queryString = queryString + " [EMPLOYEE NUMBER] = '" + txtEmpNum.Text + "' AND "; //add employee number...
                        else
                            queryString = queryString + " [EMPLOYEE NUMBER] LIKE '%" + txtEmpNum.Text + "%' AND ";
                    if (!string.IsNullOrEmpty(txtLowSal.Text) && !string.IsNullOrEmpty(txtHighSal.Text))
                        queryString = queryString + " [SALARY] BETWEEN '" + txtLowSal.Text + "' AND '" + txtHighSal.Text + "' AND "; //add salary elements...

                    //take the last AND off the query string and close it
                    char[] trimLastAnd = { ' ', 'A', 'N', 'D', ' ' };
                    queryString = (queryString.TrimEnd(trimLastAnd));
                    //queryString = queryString + ")";
                }

                btnSearch.Enabled = false;
                BGW1.RunWorkerAsync(); //run search operations in a backgroundworker so as not to disrupt other stuff or risk non-responsiveness on larger tables
            }
        }

        private void BGW1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (searchInProgress) //place the table that results from SearchResults method into e.results for later
            {                
                e.Result = SearchResults();
                if (e.Result == null) //if the blank table is found, exit handling
                    return;
            }
        }

        private DataTable SearchResults()
        {
            DataTable blankTable = new DataTable(); //create a blank table to return if anything goes wrong
            try
            {
                using (DataTable dtbl = new DataTable())
                {
                    string[] rowToAdd = new string[ExcelComms.columnCount]; //Specify the number of elements in the row to add as a string array (similar to excel method above)

                    for (int i = 0; i < ExcelComms.columnCount; i++) //give the virtual datatable the same amount of columns as the excel table, gridview and sql results table
                    {
                        if (cancelBGW) //return a blank table if the operation has been cancelled or form closed                    
                            return blankTable;
                        else
                            dtbl.Columns.Add();
                    }
                    #region retrieve data from sql server
                    //Execute the Search query, read data from sql and count new gridview entries.
                    using (SqlConnection connection = new SqlConnection(conString)) //using (SqlConnection connection = new SqlConnection(tempCon))
                    {
                        // Read all data from the database using the previously contructed queryString
                        connection.Open();
                        SqlCommand command = new SqlCommand(queryString, connection);

                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read()) //while the reader is reading...
                        {
                            rowToAdd = new string[ExcelComms.columnCount];
                            for (int i = 0; i < ExcelComms.columnCount; i++)
                                if (!reader.IsDBNull(i)) //grab the value if it exists
                                    rowToAdd[i] = reader.GetValue(i).ToString();
                            dtbl.Rows.Add(rowToAdd); //add the row to our temporary datatable
                        }
                        reader.Close(); //tidy up, close reader and connections to the database
                        connection.Close();
                    }
                    #endregion //get the actual data from sql using the query string that was previously defined
                    return dtbl; //return the results as a virtual datatable in the same format as the results display gridview
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Exception caught while extracting results from SQL database: " + ex + " -- Query String used: " + queryString);
                return blankTable;
            }

        }

        private void BGW1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result is DataTable) //make sure e.results is a suitable table before converting to dtbl, then populate the gridview from the results
            {
                DataTable dtbl = e.Result as DataTable; //pass the results from the BGW to a datatable
                foreach (DataRow dr in dtbl.Rows) //populate all fields in the Data Row as an itemarray
                {
                    dgRes.Rows.Add(dr.ItemArray);
                    Application.DoEvents();
                }

                queryString = "";
                dtbl.Rows.Clear();
                searchInProgress = false;
                btnSearch.Enabled = true;
            }
        }

        //handle misc events from the form

        private void rdoPartEmpNum_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoPartEmpNum.Checked)
                rdoExactEmpNum.Checked = false;
        }

        private void rdoExactEmpNum_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoExactEmpNum.Checked)
                rdoPartEmpNum.Checked = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            cmbGender.Text = "";
            txtEmpNum.Text = "";
            txtLowSal.Text = "";
            txtHighSal.Text = "";
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            this.Close(); //close the application.
        }
    }
}

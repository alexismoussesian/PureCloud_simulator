using PureCloudPlatform.Client.V2.Api;
using PureCloudPlatform.Client.V2.Client;
using System;
using System.Windows.Forms;
using CsvHelper;
using System.IO;
using System.Collections.Generic;

namespace PureCloud_simulator
{
    public class DataTable
    {
        ArchitectApi architect;
        ListBox _lstLog;

        public DataTable(ListBox lstLog)
        {
            _lstLog = lstLog;
            architect = new ArchitectApi();

        }
        private void AddLog(string message)
        {
            _lstLog.Items.Add($"{DateTime.Now} {message}");
            _lstLog.SelectedIndex = _lstLog.Items.Count - 1;
            _lstLog.SelectedIndex = -1;
        }


        public void GetDataTable()
        {
            AddLog("GetDataTable");
            try
            {
                var pageNumber = 1;
                var pageCount = 1;

                var datatableEntityListing = architect.GetFlowsDatatables("", pageNumber, 100, "id", "ascending");

                pageCount = datatableEntityListing.PageCount.Value;
                AddLog("pageCount: " + pageCount);

                foreach (var dt in datatableEntityListing.Entities)
                {

                    AddLog("Get Name: " + dt.Name + " - Id: " + dt.Id);

                }

            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDataTable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void GetDataTableSchema(string name)
        {
            AddLog("GetDataTableName");
            try
            {
                var pageNumber = 1;
                var pageCount = 1;

                var datatableEntityListing = architect.GetFlowsDatatables("schema", pageNumber, 100, "id", "ascending");

                pageCount = datatableEntityListing.PageCount.Value;
                AddLog("pageCount: " + pageCount);

                foreach (var dt in datatableEntityListing.Entities)
                {
                    if (dt.Name.Equals(name))
                    {
                        AddLog("Get Name: " + dt.Name + " - Id: " + dt.Id);
                        //var test = dt.Schema;

                        AddLog("Schema: " + dt.Schema.ToString());
                    }
                }

            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDataTableSchema: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public string GetDataTableId(string name)
        {
            string id = "";

            try
            {
                var pageNumber = 1;

                var datatableEntityListing = architect.GetFlowsDatatables("schema", pageNumber, 100, "id", "ascending");

                foreach (var dt in datatableEntityListing.Entities)
                {
                    if (dt.Name.Equals(name))
                    {
                        AddLog("GetDataTableId: " + dt.Id);
                        id = dt.Id;
                    }
                }

            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDataTableSchema: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return id;
        }


        public void CreateDataTable(string DataTableName)
        {
            try
            {
                List<string> required = new List<string>();
                required.Add("key");
                Dictionary<string, object> properties = new Dictionary<string, object>();
                bool addprop = false;

                Dictionary<string, string> item = new Dictionary<string, string>();
                item.Add("title", "DNIS");
                item.Add("type", "string");
                properties.Add("key", item);

                item.Clear();
                item.Add("title", "Description");
                item.Add("type", "string");
                properties.Add("Description", item);


                PureCloudPlatform.Client.V2.Model.JsonSchemaDocument schema = new PureCloudPlatform.Client.V2.Model.JsonSchemaDocument(null,
                    null, DataTableName, DataTableName, "object", required, properties, addprop);

                var json_debug = schema.ToJson();

                PureCloudPlatform.Client.V2.Model.DataTable body = new PureCloudPlatform.Client.V2.Model.DataTable(DataTableName, DataTableName, schema);

                var datatableEntityListing = architect.PostFlowsDatatables(body);

            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateDataTable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void CreateDataTable(string DataTableName, List<string> head)
        {
            try
            {
                List<string> required = new List<string>();
                required.Add("key");
                bool columnKey = true;

                Dictionary<string, object> properties = new Dictionary<string, object>();
                bool addprop = false;


                foreach (var column in head)
                {
                    Dictionary<string, string> item = new Dictionary<string, string>();
                    item.Add("title", column);
                    item.Add("type", "string");
                    if (columnKey)
                    {
                        properties.Add("key", item);
                        columnKey = false;
                    }
                    else
                    {
                        properties.Add(column, item);
                    }
                }


                PureCloudPlatform.Client.V2.Model.JsonSchemaDocument schema = new PureCloudPlatform.Client.V2.Model.JsonSchemaDocument(null,
                    null, DataTableName, DataTableName, "object", required, properties, addprop);

                var json_debug = schema.ToJson();

                PureCloudPlatform.Client.V2.Model.DataTable body = new PureCloudPlatform.Client.V2.Model.DataTable(DataTableName, DataTableName, schema);

                var datatableEntityListing = architect.PostFlowsDatatables(body);

            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateDataTable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public string checkType(string filename, string field)
        {
            StreamReader file = new StreamReader(filename);
            string line = file.ReadLine();
            bool found = false;
            var colonnes = line.Split(';');
            int indiceHead = 0;
            int indiceField = 0;
            int numItem = 0;

            foreach (var test in colonnes)
            {
                if (test.Equals(field))
                {
                    indiceHead = numItem;
                }
                numItem++;
            }

            line = file.ReadLine();
            colonnes = line.Split(';');
            numItem = 0;
            foreach (var test in colonnes)
            {
                switch (test)
                {
                    case "true":
                    case "True":
                    case "TRUE":
                    case "false":
                    case "False":
                    case "FALSE":
                        indiceField = numItem;
                        found = true;
                        break;
                    default:
                        break;
                }
                numItem++;
            }

            if (found && (indiceHead == indiceField))
                return "boolean";
            else
                return "string";
        }


        public void CreateAndFillDataTable(string filename)
        {
            try
            {
                List<string> required = new List<string>();
                required.Add("key");
                bool columnKey = true;
                bool addprop = false;

                StreamReader file = new StreamReader(filename);
                string line = file.ReadLine();

                var shortFileName = Path.GetFileNameWithoutExtension(filename);

                List<string> fields = new List<string>();
                Dictionary<string, object> properties = new Dictionary<string, object>();

                var colonnes = line.Split(';');

                foreach (var colonne in colonnes)
                {
                    fields.Add(colonne);
                }

                file.Close();

                foreach (var column in fields)
                {
                    Dictionary<string, string> item = new Dictionary<string, string>();

                    item.Add("title", column);
                    var typeField = checkType(filename, column);
                    item.Add("type", typeField);
                    if (columnKey)
                    {
                        properties.Add("key", item);
                        columnKey = false;
                    }
                    else
                    {
                        properties.Add(column, item);
                    }
                }


                var dataTableId = GetDataTableId(shortFileName);

                if (dataTableId.Equals(""))
                {
                    PureCloudPlatform.Client.V2.Model.JsonSchemaDocument schema = new PureCloudPlatform.Client.V2.Model.JsonSchemaDocument(null,
                        null, shortFileName, shortFileName, "object", required, properties, addprop);

                    var json_debug = schema.ToJson();

                    PureCloudPlatform.Client.V2.Model.DataTable body = new PureCloudPlatform.Client.V2.Model.DataTable(shortFileName, shortFileName, schema);

                    var datatableEntityListing = architect.PostFlowsDatatables(body);

                    dataTableId = this.GetDataTableId(shortFileName);
                }

                AddRows(filename, dataTableId);

            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateDataTable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        public void CreateAndFillDataTable(string DataTableName, string filename)
        {
            try
            {
                List<string> fields = new List<string>();
                string line;
                var result = this.GetDataTableId(DataTableName);


                StreamReader file = new StreamReader(filename);

                line = file.ReadLine();

                Console.WriteLine(line);
                var colonnes = line.Split(';');
                foreach (var colonne in colonnes)
                {
                    fields.Add(colonne);
                }

                file.Close();

                List<string> required = new List<string>();
                required.Add("key");
                Dictionary<string, object> properties = new Dictionary<string, object>();
                bool addprop = false;

                Dictionary<string, string> item = new Dictionary<string, string>();

                bool first_item = true;

                foreach (var field in fields)
                {
                    item.Clear();
                    item.Add("title", field);
                    item.Add("type", "string");

                    if (first_item)
                    {
                        properties.Add("key", item);
                        first_item = false;
                    }
                    else
                        properties.Add(field, item);

                }


                PureCloudPlatform.Client.V2.Model.JsonSchemaDocument schema = new PureCloudPlatform.Client.V2.Model.JsonSchemaDocument(null,
                    null, DataTableName, DataTableName, "object", required, properties, addprop);

                var json_debug = schema.ToJson();

                PureCloudPlatform.Client.V2.Model.DataTable body = new PureCloudPlatform.Client.V2.Model.DataTable(DataTableName, DataTableName, schema);

                var datatableEntityListing = architect.PostFlowsDatatables(body);


            }
            catch (Exception ex)
            {
                AddLog($"Error in CreateDataTable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void AddRows(string filename, string dtId)
        {
            AddLog("AddRows started");
            
            try
            {
                using (var reader = new StreamReader(filename))
                using (var csv = new CsvReader(reader))
                {
                    csv.Configuration.Delimiter = ";";
                    csv.Configuration.HasHeaderRecord = true;

                    var dtRowsProto = csv.GetRecords<dynamic>();

                    foreach (ICollection<KeyValuePair<string, object>> dtRow in dtRowsProto)
                    {
                        bool first_item = true;

                        Dictionary<string, object> dtRow2 = new Dictionary<string, object>();

                        foreach (var field in dtRow)
                        {
                            if (first_item)
                            {
                                dtRow2.Add("KEY", field.Value);
                                first_item = false;
                            }
                            else
                            {
                                if (field.Value.Equals("true") || field.Value.Equals("True") || field.Value.Equals("TRUE"))
                                {
                                    dtRow2.Add(field.Key, true);
                                }
                                else if (field.Value.Equals("false") || field.Value.Equals("False") || field.Value.Equals("FALSE"))
                                {
                                    dtRow2.Add(field.Key, false);
                                }
                                else
                                {
                                    dtRow2.Add(field.Key, field.Value);
                                }
                            }
                        }

                        try
                        {
                            var addRowInDataTable = architect.PostFlowsDatatableRows(dtId, dtRow2);
                            AddLog("AddRow " + dtRow2.Keys.ToString());
                        }
                        catch (ApiException ex)
                        {
                            if (ex.ErrorCode.Equals(409))
                            {
                                AddLog($"Existing key " + ex.ErrorContent + " " + ex.Message);
                            }
                        }

                    }
                }

                AddLog("AddRows finished");

            }
            catch (Exception ex)
            {
                AddLog($"Error in AddRows: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        

        public void AddRow(string dtId, DataTableRow dtRow)
        {
            try
            {
                var addRowInDataTable = architect.PostFlowsDatatableRows(dtId, dtRow);

                AddLog("AddRow " + dtRow.KEY);

            }
            catch (ApiException ex)
            {
                switch (ex.ErrorCode)
                { 
                    case 409:
                        AddLog($"Duplicate key in AddRow: {ex.Message}");
                        MessageBox.Show("Duplicate key in AddRow: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    default:
                        AddLog($"Error in AddRow: {ex.Message}");
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                }

            }
            catch (Exception ex)
            {
                AddLog($"Error in AddRow: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        public void GetRow(string dtId)
        {
            AddLog("GetRow");
            try
            {
                var pageNumber = 1;
                var pageSize = 100;
                bool showbrief = false;

                var dtRows = architect.GetFlowsDatatableRows(dtId,pageNumber, pageSize, showbrief);

                AddLog("Get Row: " + dtRows.ToString());

            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDataTable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void DeleteDataTable(string filename)
        {
            AddLog("DeleteDataTable");
            try
            {
                var shortFileName = Path.GetFileNameWithoutExtension(filename);

                var dtId = GetDataTableId(shortFileName);

                architect.DeleteFlowsDatatable(dtId, true);

                AddLog($"DeleteDataTable {shortFileName} successfully");
            }
            catch (Exception ex)
            {
                AddLog($"Error in GetDataTable: {ex.Message}");
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    }
}

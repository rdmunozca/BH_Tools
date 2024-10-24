using GetObjDB.Data;
using GetObjDB.Properties;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Web;

namespace GetObjDB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string srvDataBase = "2021-cobog-01";
        Enviroment objEnviroment = new Enviroment();
        DataTable data = new DataTable();

        private void button1_Click(object sender, EventArgs e)
        {
            List<string> objectsDB = LoadFileInfo(); //------------------->Obtiene lista de SP del archivo .txt

            string[] _files = Directory.GetFiles(tbxSource.Text, "*.*", searchOption: SearchOption.AllDirectories); //----> Obtiene todos los archivos del path Source
            string[] _scripts = Directory.GetFiles(tbxTarget.Text, "*.*", searchOption: SearchOption.AllDirectories); //----> Obtiene todos los archivos del path Source
            if (_scripts.Length > 0)
            {
                foreach (string s in _scripts)
                {
                    File.Delete(s);
                }
                btnExecuteScript.Enabled = true;
            }
            foreach (string file in _files)
            {
                FileInfo fileInfo = new FileInfo(file);
                foreach (string obj in objectsDB)
                {
                    if (fileInfo.Name == obj)
                    {
                        File.Copy(file, tbxTarget.Text + "\\" + obj);
                    }
                }
            }
        }

        public List<string> LoadFileInfo()
        {
            List<string> fileList = new List<string>();
            try
            {
                using (StreamReader info = new StreamReader(tbxListSource.Text))
                {
                    string line;
                    //info.ReadToEnd();                    
                    while ((line = info.ReadLine()) != null)
                    {
                        fileList.Add(line);
                    }
                    //line = info.ReadLine();
                    //close the file
                    info.Close();
                }

            }
            catch (Exception e)
            {
                // Let the user know what went wrong.
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return fileList;
        }

        public void ExcecuteScriptDB()
        {
            #region Este bloque obtiene los scripts de una ruta

            string[] scriptList = Directory.GetFiles(tbxTarget.Text);
            List<string> _sqllIST = new List<string>();
            foreach (string file in scriptList)
            {
                FileInfo fileInfo = new FileInfo(file);
                _sqllIST.Add(fileInfo.Name);
            }

            #endregion

            #region Este bloque ejecuta los scripts

            StreamWriter result = new StreamWriter(@"D:\Versiones\BD_Objects\Result.txt");
            foreach (string _sqlScript in _sqllIST)
            {
                ProcessStartInfo cmd;
                string _command1 = "-S 2021-COBOG-01 -d BeyondHealth_Changes -i " + tbxTarget.Text + "\\" + _sqlScript;
                string _command = "-S " + srvDataBase + " -d " + cbxSchemaDb.SelectedItem +
                                  " -i " + tbxTarget.Text + "\\" + _sqlScript;
                cmd = new ProcessStartInfo("sqlcmd", _command);
                cmd.UseShellExecute = false;
                cmd.CreateNoWindow = true;
                cmd.RedirectStandardOutput = true;
                Process _excecute = new Process();
                _excecute.StartInfo = cmd;
                _excecute.Start();
                string output = _excecute.StandardOutput.ReadToEnd();
                if (output == "")
                    result.WriteLine(_sqlScript + ": Ejecutado correctamente");
                else
                    result.WriteLine(_sqlScript + ": Error en la ejecución: " + output);
            }
            result.Close();
            MessageBox.Show("Proceso de ejecución de scripts terminado");
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExcecuteScriptDB();
        }

        private void cbxSchemaDb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxSchemaDb_SelectedIndexChanged != null)
            {
                SetPathInfo(cbxSchemaDb.SelectedIndex);
            }
        }

        public void LoadEnviromentInfo(int id)
        {
            data = objEnviroment.FindEnviromenById(id);
            if (data.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron datos para el ambiente seleccionado");
                ClearControls(true);
            }
            else
            {
                foreach (DataRow row in data.Rows)
                {
                    objEnviroment.Id = Convert.ToInt32(row[0]);
                    objEnviroment.Name = row[1].ToString();
                    objEnviroment.BranchName = row[2].ToString();
                    objEnviroment.ApplicationBD = row[3].ToString();
                    objEnviroment.SecurityBD = row[4].ToString();
                    objEnviroment.TransportBD = row[5].ToString();
                    objEnviroment.Type = row[6].ToString();
                }
            }

        }

        public void SetPathInfo(int id)
        {
            string folderDbName = "\\Sonda.BeyondHealth.DB";
            if (id > 0)
            {
                LoadEnviromentInfo(id);
                var myConf = Program.Configuration.GetSection("Configuration");
                if (myConf != null)
                {
                    if (objEnviroment.BranchName != "")
                        tbxSource.Text = myConf.GetSection("BranchPath").Value + objEnviroment.BranchName + folderDbName;
                    else
                        tbxSource.Clear();
                    if (objEnviroment.BranchName != "")
                        tbxTarget.Text = myConf.GetSection("PublishPath").Value + objEnviroment.BranchName + "\\DB Objects";
                    else
                        tbxSource.Clear();
                }
            }
            else 
            {
                ClearControls(true);
            }

        }
        void ClearControls(bool value)
        {
            if(value == true) {
                tbxSource.Clear();
                tbxTarget.Clear();
                button1.Enabled = false;
                btnExecuteScript.Enabled = false;
                objEnviroment.Id = 0;
                objEnviroment.Name = "";
                objEnviroment.BranchName = "";
                objEnviroment.ApplicationBD = "";
                objEnviroment.SecurityBD = "";
                objEnviroment.TransportBD = "";
                objEnviroment.Type = "";
                cbxSchemaDb.SelectedItem = null;
            }            
        }
    }
}

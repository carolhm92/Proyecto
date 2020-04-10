using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace SistemaCarga
{
    public partial class frmPrincipal : Form
    {
        clsPersona objPersona = new clsPersona();
        List<List<string>> matriz = new List<List<string>>();
        string[] lineas;
        string[] campos;
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            odrCargar.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            DialogResult result = odrCargar.ShowDialog();
            if (result==DialogResult.OK)
            {
                txtRuta.Text = odrCargar.FileName;
                bgwCarga.RunWorkerAsync("TXT");
            }
        }

        private void bgwCarga_DoWork(object sender, DoWorkEventArgs e)
        {
            if (e.Argument.ToString()=="TXT")
            {
                if (string.IsNullOrEmpty(txtRuta.Text))
                {
                    MessageBox.Show("El Archivo no ha sido cargado o su ruta no esta definida", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRuta.Focus();
                    return;
                }
                CargarArchivo(txtRuta.Text);
            }
            else if (e.Argument.ToString() == "EXCEL")
            {

            }
        }
        void CargarArchivo(string RutaTXT) 
        {
            try
            {
                int pCantidadTotal = 0;
                int pFila = 0;

                //for (int x = 0; x <= pCantidadTotal; x++)
                //{
                //    Invoke(new del_ActualizarProceso(ActualizarProceso), "Fila-" + x, pCantidadTotal, pFila);

                //}

                //Leemos Todas las lineas del fichero
                lineas = File.ReadAllLines(RutaTXT);
                pCantidadTotal = lineas.Count();

                foreach (string linea in lineas)
                {
                    pFila += 1;
                    //Declaramos uan lista para los campos de linea concreta que estamos recorriendo
                    List<string> lineamatriz = new List<string>();

                    //Partimos la linea con el caracter "," indicado
                    campos = linea.Split(",".ToCharArray());
                    
                    //Agregamos todos los campos obtenidos a partir de la linea a la fila de la matriz
                    lineamatriz.AddRange(campos.ToList());
                    
                    //Agregarmos a la matriz la linea leida
                    matriz.Add(lineamatriz);

                    objPersona.AgregarPersona(campos[0].Trim(),Convert.ToInt32(campos[2].Trim()),campos[5].Trim(), campos[6].Trim(), campos[7].Trim(), campos[1].Trim());
                    Invoke(new del_ActualizarProceso(ActualizarProceso), "Fila-" + pFila, pCantidadTotal, pFila);
                }
                MessageBox.Show("El Archivo ha sido cargado exitosamente", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Existe un problema con el archivo o la ruta", "Validación de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void bgwCarga_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Cursor = Cursors.Default;
            pbAvance.Visible = false;
            lblAvance.Visible = false;
            lblAvance.Text = string.Empty;
        }
        #region Delegados

        private delegate void del_ActualizarProceso(string pNota, int pAvanceTotal, int pAvanceReal);
        private void ActualizarProceso(string pNota,int pAvanceTotal,int pAvanceReal) 
        {
            pbAvance.Visible = true;
            lblAvance.Visible= true;

            pbAvance.Maximum = pAvanceTotal;
            pbAvance.Value = pAvanceReal;
            lblAvance.Text = Convert.ToInt32((((decimal)pAvanceReal / (decimal)pAvanceTotal) * 100)).ToString() + "%" + pNota;

            Cursor = Cursors.WaitCursor;
        }

        #endregion
    }
}

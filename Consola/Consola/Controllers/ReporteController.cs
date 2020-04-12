using Consola.Models;
using Microsoft.Reporting.WebForms;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Consola.Controllers
{
    public class ReporteController : Controller
    {
        // GET: Reporte
        public ActionResult Index()
        {
            return View();
        }

        // GET: Reporte/Reporte
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reporte(ViewReporteBusqueda viewReporte)
        {
            // Buscar Info
            ApiCall api = new ApiCall(Session);
            var response = await api.PostAsync("/api/Reporte", viewReporte);
            List<Reporte_Ventas> informacion = new List<Reporte_Ventas>();
            if (response.IsSuccessStatusCode)
            {
                var datastring = await response.Content.ReadAsStringAsync();
                informacion = JsonConvert.DeserializeObject<List<Reporte_Ventas>>(datastring);
            }
            // Cargar origen de Datos
            DataTable dt = new DataTable();
            dt = ConvertToDataTable(informacion);

            // Diseño del reporte
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.Width = Unit.Percentage(100);
            reportViewer.Height = Unit.Percentage(100);
            reportViewer.ZoomMode = ZoomMode.Percent;
            reportViewer.ZoomPercent = 165;

            reportViewer.LocalReport.ReportPath = Request.MapPath(Request.ApplicationPath) + @"Report\ReportVentas.rdlc";
            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("Data", dt));
            
            ViewBag.ReportViewer = reportViewer;
            return View();
        }

        private DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable("View_Ventas");
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }
    }
}
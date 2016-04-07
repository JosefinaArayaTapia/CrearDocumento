using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using ETL.Cobranza.bcp;
using ETL.Cobranza.dto;


namespace ETL.Cobranza.web
{
    /// <summary>
    /// Summary description for GenerarArchivo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class GenerarArchivo : System.Web.Services.WebService
    {

        [WebMethod]
        public GenerarArchivodto GenerarDocumento(String ArchivoXML, String ArchivoXSLT, String TipoArchivo, String RutaSalida, String NombreSalida)
        {

            GenerarArchivobcp GenerarArchivo = new GenerarArchivobcp();
            GenerarArchivodto Error = new GenerarArchivodto();
            Error= GenerarArchivo.GenerarArchivo_bcp(ArchivoXML, ArchivoXSLT, TipoArchivo, RutaSalida, NombreSalida);
            return Error;
             
        }      
    }
}

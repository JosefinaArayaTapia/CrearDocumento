using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ETL.Cobranza.dao;
using ETL.Cobranza.dto;



namespace ETL.Cobranza.bcp
{
    public class GenerarArchivobcp
    {

        public GenerarArchivodto GenerarArchivo_bcp(String ArchivoXML, String ArchivoXSLT,String TipoArchivo,String RutaSalida, String NombreSalida)
        {
            GenerarArchivodto Error = new GenerarArchivodto();
            GenerarArchivodao Archivo = new GenerarArchivodao();


            if (string.IsNullOrEmpty(ArchivoXML) || string.IsNullOrEmpty(ArchivoXSLT) || string.IsNullOrEmpty(TipoArchivo) || string.IsNullOrEmpty(RutaSalida) || string.IsNullOrEmpty(NombreSalida)) {

                Error.CodigoError = 99;
                Error.MensajeError = "Parametros Vacios";
                return Error;
            }
                

            if (Directory.Exists(RutaSalida))
            {
                if (File.Exists(ArchivoXML))
                {

                    if (File.Exists(ArchivoXSLT))
                    {

                        switch (TipoArchivo)
                        {
                            case "PDF":

                                Error = Archivo.GenerarArchivoPDF(ArchivoXML, ArchivoXSLT, RutaSalida, NombreSalida);
                                return Error;

                            case "EXCEL":
                                Error = Archivo.GenerarArchivoExcel(ArchivoXML, ArchivoXSLT, RutaSalida, NombreSalida);
                                return Error;
                            default:
                                Error.CodigoError = 3;
                                Error.MensajeError = "Tipo de Archivo a Generar no Permitido";
                                return Error;

                        }



                    }
                    else
                    {
                        Error.CodigoError = 2;
                        Error.MensajeError = "No Existe la Ruta o Archivo XSLT ";
                        return Error;

                    }

                }
                else
                {

                    Error.CodigoError = 1;
                    Error.MensajeError = "No Existe la Ruta o Archivo XML ";
                    return Error;

                }
            }
            else {

                Error.CodigoError = 6;
                Error.MensajeError = "No Existe la Ruta de Destino ";
                return Error;
            }
        }       
    }
}

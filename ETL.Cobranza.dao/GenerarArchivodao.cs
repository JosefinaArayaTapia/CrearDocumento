using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ETL.Cobranza.dto;
using Fonet;
using System.Xml;
using System.Xml.Xsl;
using System.IO;
using System.Xml.XPath;


namespace ETL.Cobranza.dao
{
    public  class GenerarArchivodao
    {
        public GenerarArchivodto GenerarArchivoPDF(String ArchivoXML, String ArchivoXSLT, String RutaSalida, String NombreSalida) {


            GenerarArchivodto Error = new GenerarArchivodto();
            string ArchivoTemporalFO = RutaSalida + NombreSalida + ".FO";
            string ArchivoPDF = RutaSalida + NombreSalida + ".PDF";
        
           try
            {
                XslCompiledTransform XSLT = new XslCompiledTransform();
                XSLT.Load(ArchivoXSLT);
                XSLT.Transform(ArchivoXML, ArchivoTemporalFO);

                FonetDriver driver = FonetDriver.Make();
                driver.Render(ArchivoTemporalFO, ArchivoPDF);

                if (File.Exists(ArchivoTemporalFO))
                {
                    File.Delete(ArchivoTemporalFO);
                }

                Error.CodigoError = 0;
                Error.MensajeError = "Archivo Generado Exitosamente";
                return Error;
                
            }
            catch (Exception e)
            {
                Error.CodigoError = 4;
                Error.MensajeError = e.Message;
                return Error;

            }
        
        }
        public GenerarArchivodto GenerarArchivoExcel(String ArchivoXML, String ArchivoXSLT, String RutaSalida, String NombreSalida)
        {
            GenerarArchivodto Error = new GenerarArchivodto();
            string ArchivoXMLSalida = RutaSalida+"/"+NombreSalida+".XML";

            try
            {
                StreamReader xml;
                XmlDocument objXmlDocument = new XmlDocument();
                XPathDocument objXPathDocument;
                XslCompiledTransform objXslTransform = new XslCompiledTransform();
                //string strXMLFilePath = string.Empty;
                string strXSLTPath = string.Empty;


                //strXMLFilePath = @"C:\Users\admin\Downloads\Archivos Excel\SALDONETOCOTIZAR1003_20160331.XML";

                //Load XML document
                xml = new StreamReader(ArchivoXML);
                objXPathDocument = new XPathDocument(xml);

                //Load Xslt
                //strXSLTPath = @"C:\Users\admin\Downloads\Archivos Excel\SALDONETOCOTIZAR1003_20160331.xslt";
                objXmlDocument.Load(ArchivoXSLT);

                //RUta y Nombre de Salida como XML
                // string strExcelFileOutstdBill = string.Format(@"C:\Users\admin\Downloads\Archivos Excel\Saldo Neto por Cotizar 1003.xml");


                //Do actual transform of Xml
                objXslTransform.Load(objXmlDocument);
                XmlWriterSettings xws = objXslTransform.OutputSettings.Clone();
                xws.Encoding = Encoding.UTF8;
                using (XmlWriter ws = XmlWriter.Create(ArchivoXMLSalida, xws))
                {
                    objXslTransform.Transform(objXPathDocument, null, ws);
                }

                xml.Close();
                xml.Dispose();
                Error.CodigoError = 0;
                Error.MensajeError = "Archivo Generado Exitosamente";
                return Error;
            }catch(Exception e){

                Error.CodigoError = 4;
                Error.MensajeError = e.Message;
                return Error;
            }

        }


    }
}

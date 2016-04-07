using System;


namespace ETL.Cobranza.dto
{
    public class GenerarArchivodto
    {
        #region "Manejadores de Propiedades"

        private int _CodigoError;
        private string _MensajeError;

        #endregion


        #region "Implementacion Propiedades"


        public int CodigoError {

            get {
                return this._CodigoError;
            }
            set {
                _CodigoError = value;
            }

        }

        public string MensajeError {
            get {
                return this._MensajeError;
            }
            set{
                _MensajeError = value;
            }        
        }
        
        #endregion
    }
}

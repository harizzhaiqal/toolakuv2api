using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Toolaku.Library
{
    public class Adapter : IDisposable
    {

        public void ConfigSettings()
        {
            this.Init();
            this._KeepHist = false;
        }
        #region "Properties"
        private bool _IsInit = false;
        private bool _IsCommitHere = false;
        private bool _KeepHist = false;

        private bool _disposed = false;
        private SqlConnection _SQLConn;

        private SqlTransaction _SQLTran;
        public SqlConnection SQLConn
        {
            get { return _SQLConn; }
            set { _SQLConn = value; }
        }

        public SqlTransaction SQLTran
        {
            get { return _SQLTran; }
            set { _SQLTran = value; }
        }

        #endregion

        #region "SQL Connection"
        /// <summary>
        /// Constructor
        /// </summary>
        /// <remarks></remarks>    ''' 
        public Adapter()
        {
            //Initial customized settings
            if (_KeepHist == false)
            {
                // put this if statement just to remove the warning message during compile.
            }

            this.ConfigSettings();
        }

        public Adapter(SqlConnection SQLConn, SqlTransaction SQLTran)
        {
            this._SQLConn = SQLConn;
            this._SQLTran = SQLTran;

            this._IsInit = true;
        }

        private void Init()
        {
            if (!this._IsInit)
            {
                this._SQLConn = new SqlConnection(Common.GetConnString(Const.constWebConfig_ConnectionString));
                this._SQLConn.Open();
                this._SQLTran = this._SQLConn.BeginTransaction();

                this._IsCommitHere = true;
                this._IsInit = true;
            }

        }

        #endregion

        #region "Disposal"
        // Implement IDisposable.
        // Do not make this method Overridable.
        // A derived class should not be able to override this method.
        public void Dispose()
        {
            Dispose(true);
            // Take yourself off of the finalization queue
            // to prevent finalization code for this object
            // from executing a second time.
            GC.SuppressFinalize(this);
        }

        // Dispose(disposing As Boolean) executes in two distinct scenarios.
        // If disposing is true, the method has been called directly 
        // or indirectly by a user's code. Managed and unmanaged resources 
        // can be disposed.
        // If disposing equals false, the method has been called by the runtime
        // from inside the finalizer and you should not reference other    
        // objects. Only unmanaged resources can be disposed.
        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (this._IsCommitHere & (this._SQLTran.Connection != null))
                {
                    this._SQLTran.Commit();
                }
            }
            catch (Exception ex)
            {
                this._SQLTran.Rollback();
                throw ex;
                //clsErrorLog.ErrorLog(this._PageID, ex);
            }
            // Check to see if Dispose has already been called.
            if (!(this._disposed) & this._IsCommitHere)
            {
                if ((this._SQLConn != null))
                {
                    this._SQLConn.Dispose();
                    this._SQLConn = null;
                }

                if ((this._SQLTran != null))
                {
                    this._SQLTran.Dispose();
                    this._SQLTran = null;
                }
            }

            this._disposed = true;
        }

        // This Finalize method will run only if the 
        // Dispose method does not get called.
        // By default, methods are NotOverridable. 
        // This prevents a derived class from overriding this method.

        //protected override void Finalize()
        //{
        //    // Do not re-create Dispose clean-up code here.
        //    // Calling Dispose(false) is optimal in terms of
        //    // readability and maintainability.
        //    Dispose(false);
        //}
        #endregion

    }
}

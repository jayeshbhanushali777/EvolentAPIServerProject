using Evolent.DataModel.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Evolent.DataModel.UnitOfWork
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables
        private readonly WebApiDbEntities _context = null;
        private GenericRepository<Contact> _contactRepo;
        #endregion

        #region Public constructor to initialise properties
        public UnitOfWork()
        {
            _context = new WebApiDbEntities();
        }
        #endregion

        #region Public Repository properties

        /// <summary>
        /// Get Property for contact repository.
        /// </summary>
        public GenericRepository<Contact> ContactRepository
        {
            get
            {
                if (this._contactRepo == null)
                    this._contactRepo = new GenericRepository<Contact>(_context);
                return _contactRepo;
            }
        }
        #endregion

        #region Public member methods...
        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {

                var error = new List<string>();
                foreach (var entityError in e.EntityValidationErrors)
                {
                    error.Add(string.Format("{0}: Entity of type \"{1}\" in state \"{2}\" has the following validation errors:", DateTime.Now, entityError.Entry.Entity.GetType().Name, entityError.Entry.State));
                    foreach (var validationError in entityError.ValidationErrors)
                    {
                        error.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", validationError.PropertyName, validationError.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", error);

                throw e;
            }

        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("Disposing UnitOfWork");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}

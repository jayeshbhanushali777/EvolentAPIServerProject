using Evolent.DataModel.GenericRepository;

namespace Evolent.DataModel.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Properties
        GenericRepository<Contact> ContactRepository { get; }

        #endregion

        /// <summary>
        /// Save method.
        /// </summary>
        void Save();
    }
}

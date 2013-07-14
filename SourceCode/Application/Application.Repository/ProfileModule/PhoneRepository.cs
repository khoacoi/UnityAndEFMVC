using Application.Domain.ContactModule.PhoneAggregate;
using Application.DAL;
using Application.DAL.Contract;

namespace Application.Repository.ProfileModule
{
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public PhoneRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}

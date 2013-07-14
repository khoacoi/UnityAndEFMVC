using Application.Domain.ContactModule.ProfileAddressAggregate;
using Application.DAL;
using Application.DAL.Contract;

namespace Application.Repository.ProfileModule
{
    public class ProfileAddressRepository : Repository<ProfileAddress>, IProfileAddressRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public ProfileAddressRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}

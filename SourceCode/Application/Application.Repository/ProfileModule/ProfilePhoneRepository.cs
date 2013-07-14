using Application.Domain.ContactModule.ProfilePhoneAggregate;
using Application.DAL;
using Application.DAL.Contract;

namespace Application.Repository.ProfileModule
{
    public class ProfilePhoneRepository : Repository<ProfilePhone>, IProfilePhoneRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public ProfilePhoneRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion
    }
}

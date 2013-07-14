using Application.Domain.ContactModule.ProfileAggregate;
using Application.DAL;
using Application.DAL.Contract;

namespace Application.Repository.ProfileModule
{
    public class ProfileRepository : Repository<Profile>, IProfileRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public ProfileRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}

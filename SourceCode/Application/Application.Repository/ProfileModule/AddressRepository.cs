using Application.Domain.ContactModule.AddressAggregate;
using Application.DAL.Contract;
using Application.DAL;

namespace Application.Repository.ProfileModule
{
    public class AddressRepository : Repository<Address>, IAddressRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public AddressRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}

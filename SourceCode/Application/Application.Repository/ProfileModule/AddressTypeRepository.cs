using Application.Domain.ContactModule.AddressAggregate;
using Application.DAL;
using Application.DAL.Contract;

namespace Application.Repository.ProfileModule
{
    public class AddressTypeRepository : Repository<AddressType>, IAddressTypeRepository
    {
        #region Constructor

        /// <summary>
        /// Create a new instance
        /// </summary>
        /// <param name="unitOfWork">Associated unit of work</param>
        public AddressTypeRepository(IQueryableUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        #endregion
    }
}

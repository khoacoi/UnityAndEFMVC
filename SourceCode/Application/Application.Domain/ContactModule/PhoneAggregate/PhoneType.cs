using Application.Common;
using Application.Domain.ContactModule.ProfilePhoneAggregate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.ContactModule.PhoneAggregate
{
    public class PhoneType : Entity
    {
        #region Constructor

        public PhoneType()
        {
            this.ProfilePhones = new HashSet<ProfilePhone>();
        }

        #endregion Constructor

        #region Property

        [Key]
        public int PhoneTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProfilePhone> ProfilePhones { get; set; }

        #endregion Property

    }
}

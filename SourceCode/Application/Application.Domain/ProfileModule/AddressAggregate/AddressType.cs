﻿using Application.Common;
using Application.Domain.ProfileModule.ProfileAddressAggregate;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Domain.ProfileModule.AddressAggregate
{
    public class AddressType : Entity
    {
        
        #region Constructor

        public AddressType()
        {
            this.ProfileAddresses = new HashSet<ProfileAddress>();
        }

        #endregion Constructor

        #region Property

        [Key]
        public int AddressTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ProfileAddress> ProfileAddresses { get; set; }

        #endregion Property

    }
}

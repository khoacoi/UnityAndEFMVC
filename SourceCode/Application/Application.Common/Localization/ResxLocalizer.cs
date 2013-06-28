using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;

namespace Application.Common.Localization
{
    /// <summary>
    /// An implementation of <see cref="ILocalizer"/> which loads Resx satellite resource assemblies.
    /// </summary>
    public class ResxLocalizer : ILocalizer
    {
        /// <summary>
        /// Gets the string by resource key and type.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <param name="resourceType">Type of the resource.</param>
        /// <param name="paras">The parameters in formatted resource string.</param>
        /// <returns></returns>
        public string GetString(string resourceKey, Type resourceType, params object[] paras)
        {
            var rm = new ResourceManager(resourceType);
            string resourceString = rm.GetString(resourceKey);
            return paras == null || paras.Count() == 0 ? resourceString : string.Format(resourceString, paras);
        }
    }
}

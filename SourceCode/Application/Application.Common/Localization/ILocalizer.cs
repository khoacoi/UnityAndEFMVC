using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Common.Localization
{
    /// <summary>
    /// Declares interface of localizer which supports getting locale string as current culture of request.
    /// </summary>
    public interface ILocalizer
    {
        /// <summary>
        /// Gets the string by resource key and type.
        /// </summary>
        /// <param name="resourceKey">The resource key.</param>
        /// <param name="resourceType">Type of the resource.</param>
        /// <param name="paras">The parameters in formatted resource string.</param>
        /// <returns></returns>
        string GetString(string resourceKey, Type resourceType, params object[] paras);
    }
}

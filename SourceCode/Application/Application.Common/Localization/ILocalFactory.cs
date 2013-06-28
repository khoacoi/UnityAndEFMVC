using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Localization
{
    /// <summary>
    /// Base contract for Locale abstract factory
    /// </summary>
    public interface ILocalFactory
    {
        /// <summary>
        /// Create a new ILocalizer
        /// </summary>
        /// <returns>The ILocalizer created</returns>
        ILocalizer Create();
    }
}

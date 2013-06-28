using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Localization
{
    /// <summary>
    /// Localizer Factory
    /// </summary>
    public static class LocalizerFactory
    {
        #region Members
        static ILocalFactory _currentLocalFactory = null;
        #endregion

        #region Public Methods
        /// <summary>
        /// Set the  log factory to use
        /// </summary>
        /// <param name="logFactory">Log factory to use</param>
        public static void SetCurrent(ILocalFactory localFactory)
        {
            _currentLocalFactory = localFactory;
        }

        /// <summary>
        /// Createt a new Log
        /// </summary>
        /// <returns>Created ILog</returns>
        public static ILocalizer CreateLocalizer()
        {
            return (_currentLocalFactory != null) ? _currentLocalFactory.Create() : null;
        }
        #endregion
    }
}

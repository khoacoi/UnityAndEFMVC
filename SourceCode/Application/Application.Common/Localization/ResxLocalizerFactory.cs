using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Localization
{
    public class ResxLocalizerFactory : ILocalFactory
    {
        public ILocalizer Create()
        {
            return new ResxLocalizer();
        }
    }
}

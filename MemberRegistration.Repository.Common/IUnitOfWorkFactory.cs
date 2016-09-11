using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Repository.Common
{
    public interface IUnitOfWorkFactory
    {
        /// <summary>
        /// Creates the unit of work.
        /// </summary>
        /// <returns></returns>
        IUnitOfWork CreateUnitOfWork();
    }
}

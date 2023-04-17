using CoursesTikects.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursesTikects.BL.Managers.Inertfaces
{
    public interface IDeveloperManager : IManager<Developer>
    {
        public Task<IEnumerable<Developer>> GetRange(IEnumerable<int> Ids);

    }
}

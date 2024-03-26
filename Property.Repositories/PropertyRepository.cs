using Property.Data;
using Property.IRepositories;
using Property.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.Repositories
{
    public class PropertyRepository : Repository<Propertys>, IPropertyRepository
    {
        public PropertyRepository(PropertyDbContext dbContext) : base(dbContext)
        {
        }
    }
}

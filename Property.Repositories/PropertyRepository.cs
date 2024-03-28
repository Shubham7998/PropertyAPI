using Microsoft.EntityFrameworkCore;
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
        private readonly PropertyDbContext _dbContext;
        public PropertyRepository(PropertyDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Propertys>> GetPropertysAsync()
        {
           return await _dbContext.properties.Include(x=>x.PropertyType).Include(x=>x.PropertyStatusType).ToListAsync();
        }

        public async Task<IEnumerable<Propertys>> GetSearchAsync(string find)
        {
            
            string keyword = find.ToLower();



            var filteredList = _dbContext.properties

                    .Where(p =>

                    p.PropertyAddress.ToLower().Contains(keyword) ||

                   p.PropertyDescription.ToLower().Contains(keyword) ||

                   p.PropertyTitle.ToLower().Contains(keyword) ||

                    p.PropertyBedrooms.Equals(keyword) || 
                    p.PropertyPrice.Equals(keyword))

                    .ToList();

            //var filteredList = _dbContext.Bikes.ToList();


            return filteredList;
        }
    }
}

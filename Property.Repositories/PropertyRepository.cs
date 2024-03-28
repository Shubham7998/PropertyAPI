using Microsoft.EntityFrameworkCore;
using Property.Data;
using Property.IRepositories;
using Property.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        
        public async Task<IEnumerable<Propertys>> GetPropertyAdvanceFilterAsync(Propertys propertysObj)
        {
            await _dbContext.properties.Include(x => x.PropertyType).Include(x => x.PropertyStatusType).ToListAsync();

            var query = _dbContext.properties.AsQueryable();
            if (!string.IsNullOrWhiteSpace(propertysObj.PropertyTitle))
            {
                query = query.Where(property => property.PropertyTitle == propertysObj.PropertyTitle);
            }
            
            if (!string.IsNullOrWhiteSpace(propertysObj.PropertyDescription))
            {
                query = query.Where(property => property.PropertyDescription == propertysObj.PropertyDescription);
            } 
            
            
            if (!string.IsNullOrWhiteSpace(propertysObj.PropertyAddress))
            {
                query = query.Where(property => property.PropertyAddress == propertysObj.PropertyAddress);
            }

            if (propertysObj.PropertyPrice > 0)
            {
                query = query.Where(property => property.PropertyPrice == propertysObj.PropertyPrice);
            }

            if (propertysObj.PropertySize > 0)
            {
                query = query.Where(property => property.PropertySize == propertysObj.PropertySize);
            }

            if (propertysObj.PropertyBedrooms > 0)
            {
                query = query.Where(property => property.PropertyBedrooms == propertysObj.PropertyBedrooms);
            }


            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Propertys>> GetSearchAsync(string find)
        {
            
            string keyword = find.ToLower();

            await _dbContext.properties.Include(x => x.PropertyType).Include(x => x.PropertyStatusType).ToListAsync();

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

﻿using Property.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property.IRepositories
{
    public interface IPropertyRepository : IRepository<Propertys>
    {
        Task<IEnumerable<Propertys>> GetSearchAsync(string find);
        Task<IEnumerable<Propertys>> GetPropertysAsync();
        Task<IEnumerable<Propertys>> GetPropertyAdvanceFilterAsync(Propertys propertysObj);

    }
}

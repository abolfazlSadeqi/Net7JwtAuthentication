﻿using Contract.Repository;
using DAL.Contexts;
using DAL.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

class PersonRepository : GenericRepository<Person>, IPersonRepository
{
    public PersonRepository(TestCurdContext context) : base(context) { }
}

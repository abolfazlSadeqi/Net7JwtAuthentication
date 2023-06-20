﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract.Repository;

public interface IUnitOfWork : IDisposable
{
    
    IPersonRepository Person
    {
        get;
    }
    int Save();
}

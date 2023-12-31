﻿using Contract.Repository;
using DAL.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository;

public class UnitOfWork : IUnitOfWork
{
    private TestCurdContext context;
    public UnitOfWork(TestCurdContext context)
    {
        this.context = context;
        Person = new PersonRepository(this.context);
    }
    
    public IPersonRepository Person
    {
        get;
        private set;
    }
    public void Dispose()
    {
        context.Dispose();
    }
    public int Save()
    {
        return context.SaveChanges();
    }
}

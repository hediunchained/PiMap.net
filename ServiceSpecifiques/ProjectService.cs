using Data.Infrastructure;
using Domain.Entity;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSpecifiques
{
    public class ProjectService:Service<Projet>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);
        public ProjectService():base(ut)
          
        {

        }
    
    }
}

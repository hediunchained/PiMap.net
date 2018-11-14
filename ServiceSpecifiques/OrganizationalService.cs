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
    public class OrganizationalService : Service<Organizational_chart>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);

        public OrganizationalService():base(utwk)
          
        {
        }
    }
}

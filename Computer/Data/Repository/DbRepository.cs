using Data.Context;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class DbRepository
    {
        public void Create(Computer model)
        {
            using(var context = new ComputerContext())
            {
                context.Set<Computer>().Add(model);
                context.SaveChanges();
            }
        }
    }
}

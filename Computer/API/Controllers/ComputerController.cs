using Data.Model;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class ComputerController : BaseController<Computer, ComputerRepository>
    {
        public ComputerController() : base(new ComputerRepository())
        {

        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.comm;
using Workflow.Entity.Imp.DataBase;

namespace Workflow.Core.Controllers
{
    public class BaseController : Controller
    {
        public BaseController() {
            ServiceLocator.readContext = new ReadDbContext();
            ServiceLocator.writeContext = new WriteDbContext();
            ServiceLocator.writeContext.Database.EnsureCreated();
        }
    }
}

using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminRepositories.FAQ
{
    public interface IFAQRepository : IRepository<Database.FAQQuestions>
    {
    }
}
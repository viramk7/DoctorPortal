using DoctorPortal.Web.AdminServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminServices.FAQ
{
    public interface IFAQService : IEntityService<Database.FAQQuestions>
    {
    }
}
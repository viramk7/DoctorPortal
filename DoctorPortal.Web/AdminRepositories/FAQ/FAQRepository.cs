using DoctorPortal.Web.Database.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminRepositories.FAQ
{
    public class FAQRepository : EfRepository<Database.FAQQuestions>, IFAQRepository
    {
        public FAQRepository(IDbContext context) : base(context)
        {

        }
    }
}
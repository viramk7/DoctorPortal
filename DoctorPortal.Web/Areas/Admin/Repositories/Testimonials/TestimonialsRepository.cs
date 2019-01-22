using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoctorPortal.Web.Database;
using DoctorPortal.Web.Database.Repositories;

namespace DoctorPortal.Web.Areas.Admin.Repositories.Testimonials
{
    public class TestimonialsRepository : EfRepository<Testimonial>, ITestimonialsRepository
    {
        public TestimonialsRepository(IDbContext context) : base(context)
        {
            
        }
    }
}
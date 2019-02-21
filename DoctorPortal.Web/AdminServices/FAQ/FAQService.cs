using DoctorPortal.Web.AdminRepositories.FAQ;
using DoctorPortal.Web.AdminServices.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoctorPortal.Web.AdminServices.FAQ
{
    public class FAQService : EntityService<Database.FAQQuestions>, IFAQService
    {
        private readonly IFAQRepository _repository;

        public FAQService(IFAQRepository repository) : base(repository)
        {
            _repository = repository;
        }
    }
}
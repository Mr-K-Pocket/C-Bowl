using EntityModel.Models;
using Service.GenericRepo;
using Service.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class EnrollmentService
    {
        private GenericRepository<Enrollment> genericRepo;
        private GenericUnitOfWork unitOfWork;

        public EnrollmentService()
        {
            unitOfWork = new GenericUnitOfWork();
            genericRepo = unitOfWork.GetGenericRepositoryInstance<Enrollment>();
        }

        public async Task<List<Enrollment>> GetAllEnrollments()
        {
            var result = await genericRepo.GetAllEntities();

            return result.ToList();
        }
    }
}

using EntityModel.Models;
using Service.GenericRepo;
using Service.UnitOfWork;
using Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service.Service
{
    public class CourseService
    {
        private GenericRepository<Course> genericRepo;
        private GenericUnitOfWork unitOfWork;

        public CourseService()
        {
            unitOfWork = new GenericUnitOfWork();
            genericRepo = unitOfWork.GetGenericRepositoryInstance<Course>();
        }

        public async Task<List<CourseViewModel>> GetAllCourses()
        {
            var courseList = await genericRepo.GetAllEntities();
            var result = (from c in courseList
                          select new CourseViewModel()
                          {
                              CourseID = c.CourseID,
                              Title = c.Title,
                              Credits = c.Credits
                          })
                         .ToList();

            return result;
        }

        public async Task<CourseViewModel> GetCourseById(int courseID)
        {
            var course = await genericRepo.GetByEntityID(courseID);
            var result = course != null ?
                         new CourseViewModel()
                         {
                             CourseID = course.CourseID,
                             Title = course.Title,
                             Credits = course.Credits
                         } : null;

            if (result == null)
            {
                throw new NullReferenceException("Can not find the course by id.");
            }

            return result;
        }

        public Course CreateCourse(CourseViewModel courseVM)
        {
            if (courseVM == null)
            {
                throw new ArgumentNullException("Course view model is null.");
            }

            var result = genericRepo.AddEntity(Adapt(courseVM));
            unitOfWork.SaveChanges();

            return result;
        }

        public Course UpdateCourse(CourseViewModel courseVM)
        {
            if (courseVM == null)
            {
                throw new ArgumentNullException("Course view model is null.");
            }

            var result = genericRepo.UpdateEntity(Adapt(courseVM));
            unitOfWork.SaveChanges();

            return result;
        }

        public Course DeleteCourse(CourseViewModel courseVM)
        {
            if (courseVM == null)
            {
                throw new ArgumentNullException("Course view model is null.");
            }

            var result = genericRepo.DeleteEntity(Adapt(courseVM));
            unitOfWork.SaveChanges();

            return result;
        }

        public Course Adapt(CourseViewModel courseVM)
        {
            Course course = new Course()
            {
                Title = courseVM.Title,
                Credits = courseVM.Credits
            };

            return course;
        }
    }
}

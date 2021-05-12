using EntityModel.DAL;
using Service.GenericRepo;
using System;

namespace Service.UnitOfWork
{
    public class GenericUnitOfWork
    {
        private SchoolContext schoolContext = new SchoolContext();

        public GenericRepository<TEntity> GetGenericRepositoryInstance<TEntity>() where TEntity : class
        {
            return new GenericRepository<TEntity>(schoolContext);
        }

        public void SaveChanges()
        {
            schoolContext.SaveChanges();
        }
    }
}

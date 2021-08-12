


using System.Collections.Generic;
using System.Linq;

namespace Domain.Core.Repository
{
    public interface IRepository<TEntity> 
        where TEntity : class
    {
        /// <summary>
        /// Add item into repository
        /// </summary>
        /// <param name="item">Item to add to repository</param>
        void Add(TEntity item);


        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="item">Item to delete</param>
        void Remove(TEntity item);

        /// <summary>
        /// Delete item 
        /// </summary>
        /// <param name="id">Id of item to delete</param>
        void Remove(int id);



        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="item"></param>
        void Update(TEntity item);       

        /// <summary>
        /// Update Entity
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        TEntity GetByName(string name);


        /// <summary>
        /// Get all elements of type {T} in repository
        /// </summary>
        /// <returns>List of selected elements</returns>
        IEnumerable<TEntity> GetAll();


         TEntity GetById(int id);

         IQueryable<TEntity> Query();

        IQueryable<TEntity> CreateSet();

    }
      
}

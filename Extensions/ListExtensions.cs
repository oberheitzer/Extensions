using System;
using System.Collections.Generic;
using System.Linq;

namespace Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// Joining two lists by a common property.
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TEntityOne"></typeparam>
        /// <typeparam name="TEntityTwo"></typeparam>
        /// <param name="entities"></param>
        /// <param name="items"></param>
        /// <param name="selector"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static List<TResult> AsJoinedList<TResult, TEntityOne, TEntityTwo>(
            this List<TEntityOne> entities, 
            List<TEntityTwo> items, 
            Func<TEntityOne, TEntityTwo, TResult> selector,
            string firstPropertyName,
            string secondPropertyName)
        {
            return entities.Join(
                items,
                entity => GetPropertyValue(entity, entities, firstPropertyName),
                item => GetPropertyValue(item, items, secondPropertyName),
                selector).ToList();
        }

        private static object GetPropertyValue<TEntity>(TEntity entity, List<TEntity> entities, string propertyName)
        {
            return entities.GetType().GetProperties().Single(p => p.Name == propertyName).GetValue(entity);
        }
    }
}

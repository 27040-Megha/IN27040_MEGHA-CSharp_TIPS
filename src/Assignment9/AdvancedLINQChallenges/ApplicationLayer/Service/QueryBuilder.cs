using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdvancedLINQChallenges.Domain;
using AdvancedLINQChallenges.Domain.DTO;

namespace AdvancedLINQChallenges.ApplicationLayer.Service
{
    /// <summary>
    /// QueryBuilder class
    /// </summary>
    /// <typeparam name="TResult">Generic Type</typeparam>
    public class QueryBuilder<TResult>
    {
        private IEnumerable<TResult> _queryResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{TResult}"/> class.
        /// </summary>
        /// <param name="newList">List of generic type objects</param>
        public QueryBuilder(IEnumerable<TResult> newList)
        {
            this._queryResult = newList;
        }

        /// <summary>
        /// Filter method
        /// </summary>
        /// <param name="condition">Condition to filter</param>
        /// <returns>Result</returns>
        public QueryBuilder<TResult> Filter(Func<TResult, bool> condition)
        {
            this._queryResult = this._queryResult.Where(condition);
            return this;
        }

        /// <summary>
        /// Sort method
        /// </summary>
        /// <typeparam name="TKey">Generic key type</typeparam>
        /// <param name="condition">Condition to sort</param>
        /// <returns>Result</returns>
        public QueryBuilder<TResult> SortBy<TKey>(Func<TResult, TKey> condition)
        {
            this._queryResult = this._queryResult.OrderBy(condition);
            return this;
        }

        /// <summary>
        /// Joins two collections with matching key and transforms the stream to a new DTO type
        /// </summary>
        /// <typeparam name="TInner">The type of elements in the inner collection.</typeparam>
        /// <typeparam name="TKey">The type of the key used to match elements.</typeparam>
        /// <typeparam name="TNewResult">The type of the resultant joined Collection DTO</typeparam>
        /// <param name="listToMap">The inner collection to join with.</param>
        /// <param name="outerKeySelector">A function to extract the join key from each element in the current collection.</param>
        /// <param name="innerKeySelector">A function to extract the join key from each element in the inner collection.</param>
        /// <param name="resultSelector">A function to create a combined object from two matching elements.</param>
        /// <returns>A new QueryBuilder instance containing the joined results.</returns>
        public QueryBuilder<TNewResult> Joins<TInner, TKey, TNewResult>(
            IEnumerable<TInner> listToMap,
            Func<TResult, TKey> outerKeySelector,
            Func<TInner, TKey> innerKeySelector,
            Func<TResult, TInner, TNewResult> resultSelector)
        {
            var joinedCollection = this._queryResult.Join(listToMap, outerKeySelector, innerKeySelector, resultSelector);
            return new QueryBuilder<TNewResult>(joinedCollection); 
        }

        /// <summary>
        /// Returns the query result
        /// </summary>
        /// <returns>Query Result</returns>
        public IEnumerable<TResult> Execute()
        {
            return this._queryResult.ToList();
        }
    }
}

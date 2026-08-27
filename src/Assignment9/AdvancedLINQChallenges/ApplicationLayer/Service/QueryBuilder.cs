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
        public QueryBuilder()
        {
            this._queryResult = new List<TResult>();
        }

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

        //public QueryBuilder<TResult> Join<TResult, Tkey1, Tkey2>(IEnumerable<Tkey1> listToMap, Func<TResult, T> outerKeySelector, Func<TResult, Tkey1> innerKeySelector, Func<TResult, Tkey2, bool> condition)
        //{
        //    this._queryResult = this._queryResult.Join(listToMap, outerKeySelector, innerKeySelector, condition);
        //    var resultObject = new QueryBuilder<TResult>();
        //    resultObject._queryResult = this._queryResult;
        //    return resultObject;
        //}

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

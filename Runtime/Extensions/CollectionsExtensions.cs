using System;
using System.Collections.Generic;
using System.Linq;
using CommonSolutions.Runtime.Providers;
using UnityEngine;

namespace CommonSolutions.Runtime.Extensions
{
    public static class CollectionsExtensions
    {
        public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, 
                                                      Func<TSource, bool> predicate, string notFoundError)
        {
            var result = Enumerable.FirstOrDefault(source, predicate);
            if(result == null && !string.IsNullOrEmpty(notFoundError))
            {
                Debug.LogError(notFoundError);
            }

            return result;
        }
        
        public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> source, 
                                                      Func<TSource, bool> predicate, string notFoundError)
        {
            var result = Enumerable.LastOrDefault(source, predicate);
            if(result == null && !string.IsNullOrEmpty(notFoundError))
            {
                Debug.LogError(notFoundError);
            }

            return result;
        }

        public static T GetRandomElement<T>(this ICollection<T> source)
        {
            var count = source.Count;
            if(count == 0)
            {
                Debug.LogError($"Can't get random element from empty source!");
                return default;
            } 
            
            var index = UnityEngine.Random.Range(0, count);
            return source.ElementAt(index);
        }
        
        public static T GetRandomElement<T>(this ICollection<T> source, 
                                            IRandomProvider randomProvider)
        {
            var count = source.Count;
            if(count == 0)
            {
                Debug.LogError($"Can't get random element from empty source!");
                return default;
            } 
            
            var index = randomProvider.Random.Next(0, count);
            return source.ElementAt(index);
        }
    }
}
using System;
using System.Collections.ObjectModel;
using CuttingEdge.Conditions;

namespace MyMvcSample.Common.Collections
{
    public class GenericKeyedCollection<TKey, TValue> : KeyedCollection<TKey, TValue>
    {
        private readonly Func<TValue, TKey> _keyGenerator;

        public GenericKeyedCollection(Func<TValue, TKey> keyGenerator)
        {
            Condition.Requires(keyGenerator).IsNotNull();

            _keyGenerator = keyGenerator;
        }

        /// <summary>
        /// When implemented in a derived class, extracts the key from the specified element.
        /// </summary>
        /// <returns>
        /// The key for the specified element.
        /// </returns>
        /// <param name="item">The element from which to extract the key.</param>
        protected override TKey GetKeyForItem(TValue item)
        {
            return _keyGenerator(item);
        }
    }
}
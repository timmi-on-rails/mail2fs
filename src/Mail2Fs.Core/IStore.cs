using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MailSync
{
    public interface IReadOnlyStore<T>
    {
        TextReader Get(T id);
        IEnumerable<T> List();
    }

    public interface IStore<T> : IReadOnlyStore<T>
    {
        /// <summary>
        /// Delete and if already gone, no problem.
        /// </summary>
        /// <param name="id"></param>
        void Delete(T id);
        T Store(TextReader reader);
    }

    public static class Util
    {
        public static void Sync<A, B>(IStore<A> source, IStore<B> destination, IdMap<A, B> idMap)
        {
            Integrate(source, destination, idMap);
            Integrate(destination, source, idMap.Invert());
        }
        public static void Integrate<A, B>(IReadOnlyStore<A> source, IStore<B> destination, IdMap<A, B> idMap)
        {
            var listA = source.List();

            foreach (var id in listA)
            {
                if (!idMap.ContainsKey(id))
                {
                    TextReader reader = source.Get(id);
                    B newId = destination.Store(reader);
                    idMap.Add(id, newId);
                }
            }

            var syncA = idMap.Keys;

            foreach (var syncId in syncA)
            {
                if (!listA.Contains(syncId))
                {
                    B idB = idMap[syncId];
                    destination.Delete(idB);
                    idMap.Remove(syncId);
                }
            }
        }
    }
}

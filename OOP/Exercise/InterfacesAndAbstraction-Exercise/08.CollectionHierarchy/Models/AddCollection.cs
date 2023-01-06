namespace _08.CollectionHierarchy.Models
{
    using System.Collections.Generic;

    using Models.Interfaces;
    internal class AddCollection<T> : IAddCollection<T>
    {

        private readonly ICollection<T> data;
        public AddCollection()
        {
            data = new List<T>();
        }

        public int Add(T item)
        {
            this.data.Add(item);

            return this.data.Count - 1;
        }
    }
}

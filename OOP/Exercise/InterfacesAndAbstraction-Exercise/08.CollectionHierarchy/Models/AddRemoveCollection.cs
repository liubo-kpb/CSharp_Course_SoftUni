namespace _08.CollectionHierarchy.Models
{
    using Models.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    internal class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        protected readonly IList<T> data;
        public AddRemoveCollection()
        {
            data = new List<T>();
        }
        public int Add(T item)
        {
            data.Insert(0, item);

            return 0;
        }

        public virtual T Remove()
        {
            T element = this.data.LastOrDefault();

            if (element != null)
            {
                this.data.Remove(element);
            }

            return element;
        }
    }
}

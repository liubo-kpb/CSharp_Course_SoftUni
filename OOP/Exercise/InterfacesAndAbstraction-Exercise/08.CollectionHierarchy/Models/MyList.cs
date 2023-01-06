namespace _08.CollectionHierarchy.Models
{
    using Models.Interfaces;
    using System.Linq;

    internal class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        

        public MyList() : base()
        {
        }
        public int Used {
            get => this.data.Count;
        }

        public override T Remove()
        {
            T element = this.data.FirstOrDefault();

            if (element != null)
            {
                this.data.Remove(element);
            }

            return element;
        }
    }
}

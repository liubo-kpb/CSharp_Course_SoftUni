namespace _08.CollectionHierarchy.Models.Interfaces
{
    internal interface IAddRemoveCollection<T> : IAddCollection<T>
    {
        public T Remove();
    }
}

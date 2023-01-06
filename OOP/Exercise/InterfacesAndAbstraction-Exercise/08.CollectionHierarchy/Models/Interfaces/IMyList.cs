namespace _08.CollectionHierarchy.Models.Interfaces
{
    internal interface IMyList<T> : IAddRemoveCollection<T>
    {
        public int Used { get; }
    }
}

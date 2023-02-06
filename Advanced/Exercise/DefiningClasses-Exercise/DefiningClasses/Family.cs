namespace DefiningClasses
{
    public class Family
    {
        private List<Person> people;

        public Family()
        {
            people= new List<Person>();
        }

        public List<Person> People { get { return people; } }
        public void AddMember(Person person) => people.Add(person);
        public Person GetOldersMember() => people.MaxBy(p => p.Age);
    }
}

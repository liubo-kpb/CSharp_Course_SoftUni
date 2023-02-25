namespace _05.ComparingObjects
{
    internal class Person : IComparable<Person>
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            int result = Name.CompareTo(other.Name);
            if (result == 0)
            {
                result = Age.CompareTo(other.Age);
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            Person other = obj as Person;
            if (other == null)
            {
                return false;
            }
            return Name == other.Name && Age == other.Age;
        }
        public override int GetHashCode()
        {
            int hashCode = Age + Name.Length;
            char[] nameChars = Name.ToLower().ToCharArray();
            for (int i = 0; i < nameChars.Length; i++)
            {
                hashCode += nameChars[i];
            }

            return hashCode;
        }
    }
}

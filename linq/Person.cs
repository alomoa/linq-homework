public class Person
{
    public Person(string firstName, string lastName, int age, bool isMale)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
        Male = isMale;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public bool Male { get; set; }

    public override string ToString()
    {
        return string.Format("{0} {1} {2} {3}", FirstName, LastName, Age, Male);
    }
}

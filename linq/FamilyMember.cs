public class FamilyMember
{
    public FamilyMember(string firstName, int age, bool isMale)
    {
        FirstName = firstName;
        Age = age;
        Male = isMale;
    }

    public string FirstName { get; set; }
    public int Age { get; set; }
    public bool Male { get; set; }
}
public class Family
{
    public Family()
    {
        Members = new List<FamilyMember>();
    }

    public Family(string lastName, List<FamilyMember> members)
    {
        LastName = lastName;
        Members = members;
    }

    public string LastName { get; set; }
    List<FamilyMember> Members { get; set; }
}

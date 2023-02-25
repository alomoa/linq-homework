public class NameWithTitle
{
    public NameWithTitle(string firstName, string lastName, bool isMale)
    {
        FirstName = firstName;
        LastName = lastName;
        IsMale = isMale;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsMale { get; set; }

    public string NameAndTitle()
    {
        var title = "Ms.";
        if (IsMale)
        {
            title = "Mr.";
        }
        return $"{title} {FirstName} {LastName}";
    }
}

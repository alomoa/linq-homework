using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var people = new List<Person>()
        {
            new Person("Bill", "Smith", 41, true),
            new Person("Sarah", "Jones", 22, false),
            new Person("Stacy","Baker", 21, false),
            new Person("Vivianne","Dexter", 19, false),
            new Person("Bob","Smith", 49 , true),
            new Person("Brett","Baker", 51 , true),
            new Person("Mark","Parker", 19, true),
            new Person("Alice","Thompson", 18, false),
            new Person("Evelyn","Thompson", 58 , false),
            new Person("Mort","Martin", 58, true),
            new Person("Eugene","deLauter", 84 , true),
            new Person("Gail","Dawson", 19 , false),
            new Person("Allain","deLauter", 51 , true),
            new Person("Natalie","deLauter", 19 , false),
            new Person("Peter","deLauter", 22 , true),
        };


        //0. write linq display every name ordered alphabetically
        var orderedPeople = people.OrderBy(person => person.FirstName).ToList();
        orderedPeople.ForEach(person => Console.WriteLine(String.Format("{0} {1}", person.FirstName, person.LastName)));

        //1. write linq statement for the people with last name that starts with the letter D
        var dPeople = people.Where(person => person.LastName.ToUpper().StartsWith("D"));
        Console.WriteLine("Number of people who's last name starts with the letter D " + dPeople.Count());


        //2. write linq statement for all the people who are have the surname Thompson and Baker. Write all the first names to the console
        var tOrBPeople = people.Where(person => person.LastName.Equals("Thompson") || person.LastName.Equals("Baker")).ToList();
        tOrBPeople.ForEach(person => Console.WriteLine(person.FirstName));



        //3. write linq to convert the list of people to a dictionary keyed by first name
        var dictPeople = people.ToDictionary(person => person.FirstName);
        foreach(var person in dictPeople)
        {
            Console.WriteLine("{0} {1} {2}", person.Key, person.Value.LastName, person.Value.Age);
        }

        // 4. Write linq statement for first Person Older Than 40 In Descending Alphabetical Order By First Name
        var oldPeople = people.Where(person => person.Age > 40).OrderByDescending(person => person.FirstName).ToList();
        var person2 = oldPeople[0];
        Console.WriteLine("First Person Older Than 40 in Descending Order by First Name " + person2.ToString());

        //5. Write a linq statement that finds all the people who are part of a family. (aka there is at least one other person with the same surname.)
        var familial = people.Where(
            person => people.Where(person2 => person.LastName.Equals(person2.LastName)).Count() > 1
            );

        //6. Write a linq statement that finds which of the following numbers are multiples of 4 or 6
        List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

        var multiplesOf4Or6 = mixedNumbers.Where(number => number % 4 == 0 || number % 6 == 0).ToList();



        // 7. How much money have we made?
        List<double> purchases = new List<double>()
            {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };
        var sum = purchases.Sum(purchase => purchase);
        Console.WriteLine(sum);

        // 8. Write a linq statement to copy the List<Person>() as a List<SimplePerson>(). You will need to join the first and last names of the person for the name field
        var simplePerson = people.Select(person =>
        {
            var simple = new SimplePerson();
            simple.Name = String.Format("{0} {1}", person.FirstName, person.LastName);
            simple.Age = person.Age;
            return simple;
        }
        ).ToList();

        // 9. Write a linq statement to copy the List<Person>() as a List<PersonWithName>(). Then print to the console the NameAndTitle of each person
        var peopleWithName = people.Select(person =>
        {
            var personWithName = new PersonWithName();
            personWithName.Name = new NameWithTitle(person.FirstName, person.LastName, person.Male);
            personWithName.Age = person.Age;
            return personWithName;
        }
        ).ToList();

        peopleWithName.ForEach(person => Console.WriteLine("{0}", person.Name.NameAndTitle()));


        // 10. Write a linq statement get all the families as a List<Family> class below. You will need to find all the members and group them by family (see question 5). Then create a family class for each family with the relevant details
        var fam = people
            .Where(person => people.Where(person2 => person.LastName.Equals(person2.LastName)).Count() > 1)
            .GroupBy(person => person.LastName)
            .Select(group => new Family(group.Key, group.Select(member => new FamilyMember(member.FirstName, member.Age, member.Male)).ToList()))
            .ToList();
            
    }
}


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

public class SimplePerson
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public class PersonWithName
{
    public NameWithTitle Name { get; set; }
    public int Age { get; set; }
}

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
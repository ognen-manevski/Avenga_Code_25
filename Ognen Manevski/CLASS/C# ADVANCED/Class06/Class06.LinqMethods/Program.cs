// ===================== Where =====================

using LinqMethods.Data;
using LinqMethods.Entities;
using LinqMethods.Helpers;

//standard method syntax
IEnumerable<Student> findBobsLambda = SEDC.Students
    .Where(s => s.FirstName.Equals("Bob", StringComparison.OrdinalIgnoreCase)); //equals for string comparison -> easy ignore case

//sql like query
IEnumerable<Student> findBobsSql = from s in SEDC.Students
                                   where s.FirstName.Equals("Bob", StringComparison.OrdinalIgnoreCase)
                                   select s;

// ===================== Select =====================

List<string> firstNames = SEDC.Students
    .Select(s => s.FirstName)
    .ToList();

firstNames.PrintSimple();

//students with academy type programmigng

IEnumerable<Student> programmingStudentsSql = from student in SEDC.Students
                                              where student.IsPartTime
                                              && (from subject in student.Subjects
                                                  where subject.Academy == Academy.Programming
                                                  select subject)
                                              .Count() != 0
                                              select student;

List<Student> programmingStudents = SEDC.Students
    .Where(s => s.IsPartTime
    && s.Subjects.Any(sub => sub.Academy == Academy.Programming))
    .ToList();


// ===================== First/Signle/Last (OrDefault) =====================

//Student petko = SEDC.Students.First(s => s.FirstName == "Petko"); //exception if not found!
Student petko = SEDC.Students.FirstOrDefault(s => s.FirstName == "Petko"); //null if not found!

//Student bob = SEDC.Students.Single(s => s.FirstName == "Bob"); //exception if 0 or more than 1 found!
                                                                 //-> we have 2 bobs in our list, so this will throw an exception

//Student bob = SEDC.Students.SingleOrDefault(s => s.FirstName == "Bob"); //null if 0 found, exception if more than 1 found!



// ===================== Any / All =====================

bool allAdults = SEDC.Students.All(s => s.Age >= 18); //true if all students are adults (18 or older)
bool anyAdults = SEDC.Students.Any(s => s.Age >= 18); //true if at least 1 student is an adult


// ===================== Distinct =====================

List<string> distinctFirstNames = SEDC.Students
    .Select(s => s.FirstName)
    .Distinct() // removes duplicates, but it is case sensitive, so "Bob" and "bob" would be considered different
    .ToList();

//===================== Select Many =====================

List<Subject> subjectOfPartTimeStudents = SEDC.Students
    .Where(s => s.IsPartTime)
    .SelectMany(s => s.Subjects) // flattens the list of lists of subjects into a single list of subjects
    .DistinctBy(sub => sub.Title) // removes duplicates based on the subject name //distinct compares entire objects
                                  //so if 2 same objects have different id it will consider them different
    .ToList();


//===================== OrderBy / ThenBy =====================

List<Student> orderedSt = SEDC.Students
    .OrderBy(s => s.FirstName) //by Name
    .ThenByDescending(s => s.Age) // if Names are the same, order by age descending
    .ThenBy(s => s.Id)
    .ToList();

orderedSt.PrintEntities();


//===================== GroupBy =====================

List<IGrouping<Academy, Subject>> subjectsByAcademy = SEDC.Subjects
    .GroupBy(sub => sub.Academy)
    //.GroupBy(sub => sub.Academy, s => s.Title) // if we want to group by academy but only select the title of the subject, we can use this overload of GroupBy
    .ToList();


foreach (IGrouping<Academy, Subject> academy in subjectsByAcademy)
{
    Console.WriteLine($"=========== {academy.Key} ===========");
    foreach (Subject subject in academy)
    {
        Console.WriteLine(subject.GetInfo());
    }
}
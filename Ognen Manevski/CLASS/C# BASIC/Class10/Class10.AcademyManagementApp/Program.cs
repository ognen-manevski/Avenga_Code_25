//=================================
#region Requirements
//=================================

/*
Exercise 📒
Create an Academy Management app
The app will have users that can log in and perform some actions. The user can choose one of the 3 roles and log in:

Admin
Trainer
Student ( has a current Subject, and Grades )

After logging in there should be different options for different roles:

Admins can add/remove Teachers, Students, and other Admins ( can't remove itself )

Trainer can choose between seeing all students and all subjects

When choosing Students, all student names should appear
When chosen a name, it should print all the subjects
When choosing Subjects, all Subject names appear with how many students attend it next to it

Students are shown the name of the subject that they are listening to and a list of their grades

Try and handle all scenarios with exception handling. Handle expected exceptions with special messages.
*/

#endregion
//=================================


//=================================
#region For Copilot
//=================================

/* ## 🧠 Before You Start – Think About the Design

Before writing any code, think about:

- What classes do we need?
- What properties does each role have?
- What is shared between Admin, Trainer and Student?
- Should we use inheritance?
- Where should we store collections (List<Student>, List<Trainer>, etc.)?
- How should login work?

Avoid writing everything inside `Main`.

Split logic into:
- Models (classes)
- Services (logic methods)
- UI (console interaction)

---

    You are encouraged to use GitHub Copilot while working on this exercise, but make sure you understand every line of code that is generated.

🤖 Copilot – Step by Step Guidance
Step 1 – Base User Design

    Create a base class User with common properties like Id, FirstName, LastName and Role.

Think:

    Should Role be an enum?
    Should we override something later?

Step 2 – Role Enum

    Create an enum Role with values: Admin, Trainer, Student.

Step 3 – Inheritance

    Create three classes that inherit from User: Admin, Trainer, and Student.

Add specific properties:

    Student → CurrentSubject, List Grades
    Trainer → List Subjects
    Admin → no special properties (for now)

Step 4 – Data Storage

    Create collections to store all users, students, trainers and admins.

Decide:

    Should everything be stored in one List?
    Or separate lists per type?

Step 5 – Login Logic

    Create a method that allows the user to choose a role and log in by entering a name or id.

After login:

    Redirect to a role-specific menu

Step 6 – Admin Menu

    Create a method that displays Admin options: add/remove users.

Implement:

    Add Teacher
    Add Student
    Add Admin
    Remove user (but prevent removing the currently logged-in Admin)

Split each action into separate methods.
Step 7 – Trainer Menu

    Create a method that displays Trainer options: Students or Subjects.

If Students:

    Print all student names
    Let trainer select one
    Print that student’s subjects

If Subjects:

    Print all subjects
    Show how many students attend each

Step 8 – Student Menu

    Create a method that prints the student's current subject and list of grades.

Handle:

    Case where no grades exist
    Case where subject is null

🛡 Exception Handling Guidance

Use try/catch for:

    Invalid menu choice
    Selecting non-existing user
    Parsing wrong input
    Null reference scenarios

Instead of crashing:

    Print friendly messages
    Return to the menu

Think:

    Where should validation happen?
    Should parsing be done inside helper methods?

✅ Validation & Reflection

After finishing, ask yourself:

    Is Main short and clean?
    Is logic separated from UI?
    Can each role menu work independently?
    If we added a new role tomorrow, how much code would change?
    Are exceptions handled at the correct level?
    Are we catching specific exceptions before general ones?

 */
#endregion
//=================================




public class Student
{
    private static int lastId = 0;

    public int Id { get; private set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public Student(string name, string surname)
    {
        Id = ++lastId;
        Name = name;
        Surname = surname;
    }
}
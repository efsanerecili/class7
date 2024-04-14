public class Classroom
{
    private static Dictionary<string, List<Student>> classrooms = new Dictionary<string, List<Student>>();

    public static void CreateClassroom()
    {
        Console.Write("Sinif adi daxil edin: ");
        string className = Console.ReadLine();
        while (!className.IsValidClassName())
        {
            Console.WriteLine("Sinif adi dogru deyil! Ad: İki boyuk herf və üç rəqəm olmalıdır.");
            Console.Write("Zəhmət olmasa yenidən daxil edin: ");
            className = Console.ReadLine();
        }
        classrooms.Add(className, new List<Student>());
        Console.WriteLine($"'{className}' adlı sinif yaradıldı.");
    }

    public static void CreateStudent()
    {
        Console.Write("Ad daxil edin: ");
        string name = Console.ReadLine();
        while (!name.IsValidName())
        {
            Console.WriteLine("Ad dogru deyil! Adin boyuk herfle baslamali ve en azi uzunlugu 3 olmalidir.");
            Console.Write("Zəhmət olmasa yenidən daxil edin: ");
            name = Console.ReadLine();
        }

        Console.Write("Soyad daxil edin: ");
        string surname = Console.ReadLine();
        while (!surname.IsValidName())
        {
            Console.WriteLine("Soyad dogru deyil! Soyadin boyuk herfle baslamali ve en azi uzunlugu 3 olmalidir.");
            Console.Write("Zəhmət olmasa yenidən daxil edin: ");
            surname = Console.ReadLine();
        }

        Console.Write("Sinif adi daxil edin: ");
        string className = Console.ReadLine();
        if (classrooms.ContainsKey(className))
        {
            classrooms[className].Add(new Student(name, surname));
            Console.WriteLine($"'{name} {surname}' adlı telebe '{className}' sinifine elave edildi.");
        }
        else
        {
            throw new ClassroomNotFoundException($"'{className}' adli sinif tapilmadi.");
        }
    }

    public static void DisplayAllStudents()
    {
        foreach (var classroom in classrooms)
        {
            foreach (var student in classroom.Value)
            {
                Console.WriteLine($"Ad: {student.Name}, Soyad: {student.Surname}, Sinif: {classroom.Key}");
            }
        }
    }

    public static void DisplayStudentsInClassroom()
    {
        Console.Write("Sinif adi daxil edin: ");
        string className = Console.ReadLine();
        if (classrooms.ContainsKey(className))
        {
            foreach (var student in classrooms[className])
            {
                Console.WriteLine($"Ad: {student.Name}, Soyad: {student.Surname}, Sinif: {className}");
            }
        }
        else
        {
            throw new ClassroomNotFoundException($"'{className}' adli sinif tapilmadi.");
        }
    }

    public static void DeleteStudent(int id)
    {
        foreach (var classroom in classrooms)
        {
            var studentToRemove = classroom.Value.Find(student => student.Id == id);
            if (studentToRemove != null)
            {
                classroom.Value.Remove(studentToRemove);
                Console.WriteLine($"Telebe {id} nömrəsi ilə siyahıdan silindi.");
                return;
            }
        }
        throw new StudentNotFoundException($"Telebe {id} nömrəsi ilə tapılmadı.");
    }
}

public class ClassroomNotFoundException : Exception
{
    public ClassroomNotFoundException(string message) : base(message) { }
}

public class StudentNotFoundException : Exception
{
    public StudentNotFoundException(string message) : base(message) { }
}
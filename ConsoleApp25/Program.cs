

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nMenyu:");
            Console.WriteLine("1. Sinif yarat");
            Console.WriteLine("2. Telebe yarat");
            Console.WriteLine("3. Butun telebeleri ekrana cixart");
            Console.WriteLine("4. Secilmis sinifdaki telebeleri ekrana cixart");
            Console.WriteLine("5. Telebe sil");
            Console.WriteLine("6. Cixis");
            Console.Write("Sechiminizi daxil edin: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Zehmet olmasa yalniz reqem daxil edin!");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1:
                        Classroom.CreateClassroom();
                        break;
                    case 2:
                        Classroom.CreateStudent();
                        break;
                    case 3:
                        Classroom.DisplayAllStudents();
                        break;
                    case 4:
                        Classroom.DisplayStudentsInClassroom();
                        break;
                    case 5:
                        Console.Write("Silinecek telebenin ID-sini daxil edin: ");
                        int idToDelete;
                        if (int.TryParse(Console.ReadLine(), out idToDelete))
                        {
                            Classroom.DeleteStudent(idToDelete);
                        }
                        else
                        {
                            Console.WriteLine("Zehmet olmasa yalniz reqem daxil edin!");
                        }
                        break;
                    case 6:
                        Console.WriteLine("Programdan cixis edildi.");
                        return;
                    default:
                        Console.WriteLine("Duzgun secim edilmeyib!");
                        break;
                }
            }
            catch (ClassroomNotFoundException ex)
            {
                Console.WriteLine($"Xeta bas verdi: {ex.Message}");
            }
            catch (StudentNotFoundException ex)
            {
                Console.WriteLine($"Xeta bas verdi: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Xeta bas verdi: {ex.Message}");
            }
        }
    }
}
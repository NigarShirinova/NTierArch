using Application.Services.Constant;
using Azure;
using Core.Constants;
using Core.Entities;

public static class Program
{
    public static void Main()
    {
        bool continuty = true;
        while (continuty)
        {
            ShowMenu();
            Messages.InputMessage("Choise");
            string choiceInput = Console.ReadLine();
            int choice;
            bool isSucceeded = int.TryParse(choiceInput, out choice);

            StudentService studentService = new StudentService();
            GroupService groupService = new GroupService();
            if (isSucceeded)
            {
                switch ((Operations)choice)
                {
                    case Operations.AllStudents:
                        studentService.GetAllStudents();
                        break;
                    case Operations.AddStudent:
                        studentService.AddStudent();
                        break;
                    case Operations.RemoveStudent:
                        studentService.DeleteStudent();
                        break;
                    case Operations.UpdateStudent:
                        studentService.UpdateStudent();
                        break;
                    case Operations.AllGroups:
                        groupService.GetAllGroups();
                        break;
                    case Operations.AddGroup:
                        groupService.AddGroup();
                        break;
                    case Operations.UpdateGroup:
                        groupService.UpdateGroup();
                        break;
                    case Operations.RemoveGroup:
                        groupService.DeleteGroup();
                        break;
                    case Operations.Exit:
                        continuty = false;
                        return;
                    default:
                        Messages.InvalidInputMessage("choice");
                        break;
                }
            }
            else
            {
                Messages.InvalidInputMessage("choice");
            }
        }
    }

    public static void ShowMenu()
    {
        Console.WriteLine("------MENU------");
        Console.WriteLine("1.All students");
        Console.WriteLine("2.Add student");
        Console.WriteLine("3.Delete student");
        Console.WriteLine("4.Update student");
        Console.WriteLine("5.All groups");
        Console.WriteLine("6.Add group");
        Console.WriteLine("7.Delete group");
        Console.WriteLine("8.Update group");
        Console.WriteLine("0.Exit");
    }
}

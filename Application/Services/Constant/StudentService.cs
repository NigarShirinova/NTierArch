using Core.Constants;
using Core.Entities;
using Data.Repistories.Base;
using Data.UnitOfWork.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Constant
{
    public class StudentService
    {
        private readonly UnitOfWork _unitOfWork;

        public StudentService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void GetAllStudents()
        {
            List<Student> list = _unitOfWork.Students.GetAll();
            foreach (Student student in list)
            {
                Console.WriteLine($"Name: {student.Name} Surname: {student.Surname}");
            }
            _unitOfWork.Commit();
            
        }

        public void GetStudentById()
        {
        InputIdSection:
            Messages.InputMessage("id");
            string inputId = Console.ReadLine();
            if (!int.TryParse(inputId, out int id))
            {
                Messages.InvalidInputMessage("id");
                goto InputIdSection;
            }
            Student student = _unitOfWork.Students.Get(id);
            if (student == null)
            {
                Messages.NotFoundMessage();
            }
            else
            {
                Console.WriteLine($"Name: {student.Name} Surname: {student.Surname}");
            }
        }

        public void AddStudent()
        {
        NameInput:
            Messages.InputMessage("name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name");
                goto NameInput;
            }

        SurNameInput:
            Messages.InputMessage("surname");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("Surname");
                goto SurNameInput;
            }

            Student student = new Student
            {
                Name = name,
                Surname = surname
            };
            _unitOfWork.Students.Add(student);
            Messages.SuccessMessage();
            _unitOfWork.Commit();
        }

        public void UpdateStudent()
        {
        InputIdSection:
            Messages.InputMessage("id");
            string inputId = Console.ReadLine();
            if (!int.TryParse(inputId, out int id))
            {
                Messages.InvalidInputMessage("id");
                goto InputIdSection;
            }

            Student student = _unitOfWork.Students.Get(id);
            if (student == null)
            {
                Messages.NotFoundMessage();
                return;
            }

        NameInput:
            Messages.InputMessage("new name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name");
                goto NameInput;
            }

        SurNameInput:
            Messages.InputMessage("new surname");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname))
            {
                Messages.InvalidInputMessage("Surname");
                goto SurNameInput;
            }

            student.Name = name;
            student.Surname = surname;
            _unitOfWork.Students.Update(student);
            Messages.SuccessMessage();
            _unitOfWork.Commit();
        }

        public void DeleteStudent()
        {
        InputIdSection:
            Messages.InputMessage("id");
            string inputId = Console.ReadLine();
            if (!int.TryParse(inputId, out int id))
            {
                Messages.InvalidInputMessage("id");
                goto InputIdSection;
            }

            Student student = _unitOfWork.Students.Get(id);
            if (student == null)
            {
                Messages.NotFoundMessage();
            }
            else
            {
                _unitOfWork.Students.Delete(student);
                Messages.SuccessMessage();
            }
            _unitOfWork.Commit();
        }
    }
}

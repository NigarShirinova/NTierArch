using Core.Constants;
using Core.Entities;
using Data.UnitOfWork.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Constant
{
    public class GroupService
    {
        private readonly UnitOfWork _unitOfWork;

        public GroupService()
        {
            _unitOfWork = new UnitOfWork();
        }

        public void GetAllGroups()
        {
            List<Group> list = _unitOfWork.Groups.GetAll();
            foreach (Group group in list)
            {
                Console.WriteLine($"Name: {group.Name} Limit: {group.Limit}");
            }
            _unitOfWork.Commit();
        }

        public void GetGroupById()
        {
        InputIdSection:
            Messages.InputMessage("id");
            string inputId = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(inputId, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("id");
                goto InputIdSection;
            }
            Group group = _unitOfWork.Groups.Get(id);
            if (group == null)
            {
                Messages.NotFoundMessage();
            }
            else
            {
                Console.WriteLine($"Name: {group.Name} Limit: {group.Limit}");
            }
        }

        public void AddGroup()
        {
        NameInput:
            Messages.InputMessage("name");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Messages.InvalidInputMessage("Name");
                goto NameInput;
            }

        LimitInput:
            Messages.InputMessage("limit");
            string inputLimit = Console.ReadLine();
            int limit;
            bool isSucceeded = int.TryParse(inputLimit, out limit);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("limit");
                goto LimitInput;
            }
            Group group = new Group
            {
                Name = name,
                Limit = limit
            };
            _unitOfWork.Groups.Add(group);
            Messages.SuccessMessage();
            _unitOfWork.Commit();
        }

        public void UpdateGroup()
        {
        InputIdSection:
            Messages.InputMessage("id");
            string inputId = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(inputId, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("id");
                goto InputIdSection;
            }

            Group group = _unitOfWork.Groups.Get(id);
            if (group == null)
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

        LimitInput:
            Messages.InputMessage("new limit");
            string inputLimit = Console.ReadLine();
            int limit;
            bool isSucceededLimit = int.TryParse(inputLimit, out limit);
            if (!isSucceededLimit)
            {
                Messages.InvalidInputMessage("limit");
                goto LimitInput;
            }

            group.Name = name;
            group.Limit = limit;
            _unitOfWork.Groups.Update(group);
            Messages.SuccessMessage();
            _unitOfWork.Commit();
        }

        public void DeleteGroup()
        {
        InputIdSection:
            Messages.InputMessage("id");
            string inputId = Console.ReadLine();
            int id;
            bool isSucceeded = int.TryParse(inputId, out id);
            if (!isSucceeded)
            {
                Messages.InvalidInputMessage("id");
                goto InputIdSection;
            }

            Group group = _unitOfWork.Groups.Get(id);
            if (group == null)
            {
                Messages.NotFoundMessage();
                return;
            }

            _unitOfWork.Groups.Delete(group);
            Messages.SuccessMessage();
            _unitOfWork.Commit();
        }
    }
}

﻿using System.Xml.Linq;

namespace Shared.DTO.Users
{
    public class UserCreateDTO
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; }
        public DateTime? CreatedDate { get; private set; }

        public bool ValidateCreation()
        {
            if (Name == null) return false;
            if (Email == null) return false;
            if (Password == null) return false;

            return true;
        }

        public void SetCreatedDate(DateTime createdDate) => CreatedDate = createdDate;
    }
}

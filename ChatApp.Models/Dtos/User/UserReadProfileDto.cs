using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Models.Dtos.User
{
    public class UserReadProfileDto
    {
        public int UserId { get; set; }

        public string? UserName { get; set; }

    }
}

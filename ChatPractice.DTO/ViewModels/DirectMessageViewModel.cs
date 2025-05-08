using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPractice.DTO.ViewModels;
public class DirectMessageViewModel
{
        public string? Message { get; set; }
        public string? UserName { get; set; }
        public DateTime CreatedAt { get; set; }
}

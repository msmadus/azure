using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDAXIGAIntegration.Models
{
    public class ModifyUserResponse
    {
        public string? Message { get; set; }
        public List<string> ProcessedUsers { get; set; } = new List<string>();
    }
}

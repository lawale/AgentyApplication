using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AgentyApplication.Models.Payloads
{
    public class ResumePayload
    {
        [Required(ErrorMessage = "Name of Resume is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [DataType(DataType.PhoneNumber), RegularExpression(@"^\+[0-9]?()[0-9](\S)(\d[0-9]{9})$", ErrorMessage = "The phone number must be in international format")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string Location { get; set; }

        [MinLength(1, ErrorMessage = "At least one skill is required")]
        public string[] Skills { get; set; }

        [Required(ErrorMessage = "Years of Experience is required")]
        public string Experience { get; set; }
    }
}

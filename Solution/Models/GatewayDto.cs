using Domain.Core.CoreData;
using Domain.Core.Interface;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Solution.Models
{
    public class GatewayDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "This fieled is required")]
        public string Name { get; set; }

        [Display(Name = "IPv4 Address")]
        [Required(ErrorMessage = "This fieled is required")]
        [RegularExpression(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", ErrorMessage = "The IPv4 address is invalid")]
        public string IPv4Address { get; set; }

        [Display(Name = "Serial Number")]
        [Required(ErrorMessage = "This fieled is required")]
        [MaxLength(10, ErrorMessage = "The maximum field length is 10")]
        public string SerialNumber { get; set; }

        public virtual IEnumerable<IDevice> Devices { get; set; }

    }
}

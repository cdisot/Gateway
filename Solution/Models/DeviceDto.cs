using Domain.Core.CoreData;
using Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Solution.Models
{
    public class DeviceDto
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Name")]            
        [Required(ErrorMessage = "This fieled is required.Name can not be empty.")]
        [DataType(DataType.Text)]
        public string Name { get; set; }


        [Display(Name = "UID")]      
        [Required(ErrorMessage = "This fieled is required")]
        public int UID { get; set; }


        [Display(Name = "Date Create")]
        [Required(ErrorMessage = "This fieled is required")]
        [DataType(DataType.DateTime)]
        public DateTime DateCreate { get; set; }


        [Display(Name = "Status")]
        public IStatus Status { get; set; }


        [Display(Name = "Vendor")]
        [Required(ErrorMessage = "This fieled is required")]
        public string Vendor { get; set; }

        [Display(Name = "Gateway")]
        public IGateway Gateway { get; set; }

        [Display(Name = "Status")]
        public int StatusId { get; set; }

        [Display(Name = "Gateway")]
        public int GatewayId { get; set; }
    }

}

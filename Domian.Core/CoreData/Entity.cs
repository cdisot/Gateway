using Domain.Core.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.Core.CoreData
{
    public class Entity:IEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

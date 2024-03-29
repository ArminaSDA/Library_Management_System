﻿using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
        public DateTime? DateUpdated { get; set; } = null;
        public bool IsDeleted { get; set; } = false;

    }
}

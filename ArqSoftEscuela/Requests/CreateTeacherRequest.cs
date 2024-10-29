﻿using System.ComponentModel.DataAnnotations;

namespace ArqSoftEscuela.Requests
{
    public class CreateTeacherRequest
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
    }
}

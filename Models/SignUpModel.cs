﻿using System.ComponentModel.DataAnnotations;

namespace BigCorp.Models
{
    public class SignUpModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        //public string lastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string ConfirmPassword { get; set; } = string.Empty;

    }
}

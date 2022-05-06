﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.ViewModels
{
    public class RegisterAccountViewModel
    {
        [Required]
        [Display(Name = "نام کاربری")]
        [StringLength(11, ErrorMessage = "شماره همراه معتبر نمیباشد")]
        [Phone(ErrorMessage = "شماره همراه معتبر نمیباشد")]
        public string Username { get; set; }
    }
}

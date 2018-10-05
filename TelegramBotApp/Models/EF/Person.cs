﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelegramBotApp.Models.EF
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Secondname { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
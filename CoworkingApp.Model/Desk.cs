﻿using CoworkingApp.Model.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoworkingApp.Model
{
    public class Desk
    {
        public Guid DeskId { get; set; } = Guid.NewGuid();
        public string Number { get; set; }
        public string Description { get; set; }
        public DeskStatus DeskStatus { get; set; } = DeskStatus.Active;
    }
}

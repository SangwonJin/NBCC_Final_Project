using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GreenSwitchWebFrontEnd.Models
{
    public class ReviewVM
    {
        public SupervisorViewModel supervisor { get; set; }
        public Review Review { get; set; }
    }
}
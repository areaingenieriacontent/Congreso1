using Congreso_1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Congreso_1.ViewModels
{
    public class CreateWebinar
    {
        public string WebinarTheme;
        [DataType(DataType.DateTime)]
        public DateTime WebinarInitialDate;
        [DataType(DataType.DateTime)]
        public DateTime WebinarEndDate;
        public bool available;
        public string userId;
        public int congressId;
        public ICollection<Congress> congressList;
    }
}
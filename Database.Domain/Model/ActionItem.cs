using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Domain.Model
{
    public class ActionItem
    {
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Route { get; set; }
        public string Title { get; set; }
    }
}

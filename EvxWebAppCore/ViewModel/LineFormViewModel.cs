using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EvxWebAppCore.Models;

namespace EvxWebAppCore.ViewModel
{
    public class LineFormViewModel
    {
        public LineFormViewModel(LineModel line, List<UserDetailModel> adminUsers)
        {
            this.Line = line;
            this.AdminUsers = adminUsers;
        }
        public  LineModel Line { get; set; }
        public List<UserDetailModel> AdminUsers { get; set; }
    }
}

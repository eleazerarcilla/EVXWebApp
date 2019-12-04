using EvxWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.ViewModel
{
    public class DriverFormViewModel
    {
        public DriverFormViewModel(UserDetailModel driver, List<LineModel> lines)
        {
            this.Lines = lines;
            this.Driver = driver;
        }
        public UserDetailModel Driver { get; set; }
        public List<LineModel> Lines { get; set; }
    }
}

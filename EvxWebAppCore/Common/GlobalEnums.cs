using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common
{
    public class GlobalEnums
    {
        public enum UserTypes{
            Administrator
        }
        public enum Direction
        {
            CW,
            CCW
        }
        public enum RecordType
        {
            Line,
            Route,
            Station
        }
    }
}

using EvxWebAppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvxWebAppCore.Common.Interfaces
{
    public interface ILine
    {
        Task<List<LineModel>> GetLines(int adminID);
    }
}

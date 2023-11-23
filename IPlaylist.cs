using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2
{
    public interface IPlaylist
    {
        string name { get; set; }
        List<int> list { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Services
{
    public interface IApiParser
    {
        dynamic[] ParseApi(dynamic json);
    }
}

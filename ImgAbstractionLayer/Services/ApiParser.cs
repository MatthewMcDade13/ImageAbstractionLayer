using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgAbstractionLayer.Services
{
    public class ApiParser : IApiParser
    {
        public dynamic[] ParseApi(dynamic json)
        {
            List<dynamic> searchList = new List<dynamic>();


            for (int i = 0; i < 10; i++)
            {
                searchList.Add(
                    new
                    {
                        Name = json.value[i].name,
                        Url = json.value[i].contentUrl,                        
                        Thumbnail = json.value[i].thumbnailUrl,
                        HostPage = json.value[i].hostPageUrl
                    });
            }

            return searchList.ToArray();
        }
    }
}

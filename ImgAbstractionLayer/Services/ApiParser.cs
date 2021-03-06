﻿using System.Collections.Generic;

namespace ImgAbstractionLayer.Services
{
    public class ApiParser : IApiParser
    {
        public dynamic[] ParseApi(dynamic json)
        {
            List<dynamic> searchList = new List<dynamic>();

            //Only give us the first 10 search results
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

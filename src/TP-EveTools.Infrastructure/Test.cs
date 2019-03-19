using System;
using RestSharp;
using TP_EveTools.Core.Domain;

namespace TP_EveTools.Infrastructure
{
    public static class Test
    {
        public static ComplexCharacter kek()
        {
            var client = new RestClient("https://esi.evetech.net");
            var request = new RestRequest("latest/characters/{id}", Method.GET);
            request.AddUrlSegment("id", "2113633471");
            var response = client.Execute<ComplexCharacter>(request);
            var name = response.Data.alliance_id;
            Console.WriteLine(name);
            return response.Data;
        }
    }
}
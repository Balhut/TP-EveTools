using System;
using Newtonsoft.Json;
using System.Collections.Generic;
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
        public static void kek2()
        {
            var client = new RestClient("https://esi.evetech.net");
            var request = new RestRequest("legacy/universe/ids/", Method.POST);
            request.AddHeader("Accept", "application/json");
            var CharSet = new HashSet<string>{
                "Velia Yaken",
                "Day Ones",
                "Morpion aka Darkflyy",
                "Kuczmaczkwaczabdullahhhh"
            };
            request.Parameters.Clear();
            var strJSONContent = Newtonsoft.Json.JsonConvert.SerializeObject(CharSet);
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine(strJSONContent);
            request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);
            var response = client.Execute(request);
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();
            Console.WriteLine(response.Content);
            var ListOfChars = new HashSet<BasicCharacter>();
            dynamic characters = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            foreach (var c in characters.characters)
            {
                Console.WriteLine(c.id + " " + c.name);
                ListOfChars.Add(new BasicCharacter(Convert.ToInt32(c.id), Convert.ToString(c.name)));
            }
            foreach (var c in ListOfChars)
            {
                Console.WriteLine(c.id + " " + c.name);
            }
            Console.WriteLine();
            Console.WriteLine("=============================");
            Console.WriteLine();
            //return response.Data;
        }
    }
}
using System;
using System.Collections.Generic;
using RestSharp;
using System.Linq;
using TP_EveTools.Core.Domain;
using TP_EveTools.Infrastructure.Extensions;
using shortid;
using TP_EveTools.Infrastructure.DTO;
using System.Threading.Tasks;

namespace TP_EveTools.Infrastructure.Fetchers
{
    public static class EsiFetcher
    {
        public static ComplexCharacter ReturnComplexCharacterInfo(int id)
        {
            var client = new RestClient("https://esi.evetech.net");
            var request = new RestRequest("latest/characters/{id}", Method.GET);
            request.AddUrlSegment("id", id);
            var response = client.Execute<ComplexCharacter>(request);
            return response.Data;
        }

        public static HashSet<Alliance> GetAllAlliances()
        {
            var ToReturn = new HashSet<Alliance>();
            var client = new RestClient("https://esi.evetech.net");
            var request = new RestRequest("latest/alliances/", Method.GET);
            var request2 = new RestRequest("latest/alliances/{id}", Method.GET);

            var response = client.Execute<List<int>>(request);

            foreach (var id in response.Data)
            {
                request2.AddUrlSegment("id", id);
                var resp = client.Execute<AllianceDTO>(request2);
                var ally = new Alliance();
                ally.alliance_id = id;
                ally.creator_corporation_id = resp.Data.creator_corporation_id;
                ally.creator_id = resp.Data.creator_id;
                ally.date_founded = resp.Data.date_founded;
                ally.name = resp.Data.name;
                ally.ticker = resp.Data.ticker;
                ToReturn.Add(ally);
            }

            return ToReturn;
        }

        public static HashSet<BasicCharacter> ReturnBasicCharacters(HashSet<string> CharSet)
        {
            var client = new RestClient("https://esi.evetech.net");
            var request = new RestRequest("latest/universe/ids/", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            var strJSONContent = Newtonsoft.Json.JsonConvert.SerializeObject(CharSet);
            request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);
            var response = client.Execute(request);
            var ListOfChars = new HashSet<BasicCharacter>();
            dynamic characters = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            foreach (var c in characters.characters)
            {
                ListOfChars.Add(new BasicCharacter(Convert.ToInt32(c.id), Convert.ToString(c.name)));
            }
            return ListOfChars;
        }

        public static async Task<LocalScan> ReturnFormattedLocalScan(HashSet<BasicCharacter> Characters, string id)
        {
            var client = new RestClient("https://esi.evetech.net");
            var request = new RestRequest("latest/characters/affiliation/", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            var Ids = new HashSet<int>();
            foreach (var character in Characters)
            {
                Ids.Add(character.id);
            }
            var strJSONContent = Newtonsoft.Json.JsonConvert.SerializeObject(Ids);
            request.AddParameter("application/json", strJSONContent, ParameterType.RequestBody);
            var response = client.Execute(request);
            dynamic affiliations = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);

            var ListOfAllianceIds = new HashSet<int>();
            var ListOfCorporationIds = new HashSet<int>();
            foreach (var a in affiliations)
            {
                if (a.alliance_id != null)
                    ListOfAllianceIds.Add(Convert.ToInt32(a.alliance_id));
                ListOfCorporationIds.Add(Convert.ToInt32(a.corporation_id));
            }
            var request2 = new RestRequest("latest/corporations/{id}", Method.GET);
            var request3 = new RestRequest("latest/alliances/{id}", Method.GET);

            var allianceCount = new HashSet<AllianceCount>();
            var corporationCount = new HashSet<CorporationCount>();

            var dict = new Dictionary<int, string>();

            foreach (var c in ListOfCorporationIds)
            {
                try
                {
                    Console.WriteLine("New corp..." + " " + c);
                    request2.Parameters.Clear();
                    request2.AddUrlSegment("id", c);
                    var response2 = await client.GetAsync<Corporation>(request2);
                    Console.WriteLine(response2.name + ": " + c);
                    dict.Add(c, response2.name);
                    var cc = new CorporationCount();
                    cc.CorpName = response2.name;
                    cc.CorpId = c;
                    cc.CorpCount = 0;
                    corporationCount.Add(cc);
                }
                catch
                {
                    continue;
                }

            }
            foreach (var a in ListOfAllianceIds)
            {
                try
                {
                    request3.Parameters.Clear();
                    request3.AddUrlSegment("id", a);
                    var response3 = await client.GetAsync<AllianceDTO>(request3);
                    dict.Add(a, response3.name);
                    var ac = new AllianceCount();
                    ac.AllyName = response3.name;
                    ac.AllyId = a;
                    ac.AllyCount = 0;
                    allianceCount.Add(ac);
                }
                catch
                {
                    continue;
                }

            }

            foreach (var a in affiliations)
            {
                try
                {
                    if (a.alliance_id != null)
                    {
                        var ac = allianceCount.FirstOrDefault(x => x.AllyName == dict[Convert.ToInt32(a.alliance_id)]);
                        ac.AllyCount++;
                    }
                    var cc = corporationCount.FirstOrDefault(x => x.CorpName == dict[Convert.ToInt32(a.corporation_id)]);
                    cc.CorpCount++;
                }
                catch
                {
                    continue;
                }
            }

            var corpSorted = new HashSet<CorporationCount>();
            foreach (var c in corporationCount.OrderByDescending(x => x.CorpCount))
            {
                corpSorted.Add(c);
            }
            var allySorted = new HashSet<AllianceCount>();
            foreach (var a in allianceCount.OrderByDescending(x => x.AllyCount))
            {
                allySorted.Add(a);
            }
            var ToReturn = new LocalScan(id, Characters, corpSorted, allySorted);

            return ToReturn;
        }
    }
}
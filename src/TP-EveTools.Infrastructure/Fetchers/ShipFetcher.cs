using System.Collections.Generic;
using TP_EveTools.Core.Domain;

namespace TP_EveTools.Infrastructure.Fetchers
{
    public static class ShipFetcher
    {
        private static Dictionary<string, string> TypeOfShip = new Dictionary<string, string>{
            {"Molok", "Faction Titan"},
            {"Vanquisher", "Faction Titan"},
            {"Komodo", "Faction Titan"},
            {"Ragnarok", "Titan"},
            {"Leviathan", "Titan"},
            {"Avatar", "Titan"},
            {"Erebus", "Titan"},
            {"Vendetta", "Faction Supercarrier"},
            {"Revenant", "Faction Supercarrier"},
            {"Nyx", "Supercarrier"},
            {"Aeon", "Supercarrier"},
            {"Hel", "Supercarrier"},
            {"Wyvern", "Supercarrier"},
            {"Vehement", "Faction Dreadnought"},
            {"Chemosh", "Faction Dreadnought"},
            {"Caiman", "Faction Dreadnought"},
            {"Moros", "Dreadnought"},
            {"Revelation", "Dreadnought"},
            {"Phoenix", "Dreadnought"},
            {"Naglfar", "Dreadnought"},
            {"Dagon", "Faction Force Auxiliary"},
            {"Loggerhead", "Faction Force Auxiliary"},
            {"Ninazu", "Force Auxiliary"},
            {"Apostle", "Force Auxiliary"},
            {"Minokawa", "Force Auxiliary"},
            {"Lif", "Force Auxiliary"},
            {"Archon", "Carrier"},
            {"Chimera", "Carrier"},
            {"Nidhoggur", "Carrier"},
            {"Thanatos", "Carrier"},
            {"Rorqual", "Capital Industrial Ship"},
            {"Widow", "Black Ops"},
            {"Sin", "Black Ops"},
            {"Panther", "Black Ops"},
            {"Redeemer", "Black Ops"},
            {"Marshal", "Black Ops"},
            {"Paladin", "Marauder"},
            {"Vargur", "Marauder"},
            {"Golem", "Marauder"},
            {"Kronos", "Marauder"},
            {"Abaddon", "Battleship"},
            {"Apocalypse", "Battleship"},
            {"Apocalypse Imperial Issue", "AT Battleship"},
            {"Apocalypse Navy Issue", "Faction Battleship"},
            {"Armageddon", "Battleship"},
            {"Armageddon Imperial Issue", "AT Battleship"},
            {"Armageddon Navy Issue", "Faction Battleship"},
            {"Barghest", "Faction Battleship"},
            {"Bhaalgorn", "Faction Battleship"},
            {"Dominix", "Battleship"},
            {"Dominix Navy Issue", "Battleship"},
            {"Hyperion", "Battleship"},
            {"Machariel", "Faction Battleship"},
            {"Leshak", "Precursor Battleship"},
            {"Maelstrom", "Battleship"},
            {"Megathron", "Battleship"},
            {"Megathron Federate Issue", "AT Battleship"},
            {"Megathron Navy Issue", "Faction Battleship"},
            {"Nestor", "Faction Battleship"},
            {"Nightmare", "Faction Battleship"},
            {"Rattlesnake", "Faction Battleship"},
            {"Raven", "Battleship"},
            {"Raven Navy Issue", "Faction Battleship"},
            {"Raven State Issue", "AT Battleship"},
            {"Rokh", "Battleship"},
            {"Scorpion", "Battleship"},
            {"Scorpion Navy Issue", "Faction Battleship"},
            {"Tempest", "Battleship"},
            {"Tempest Fleet Issue", "Faction Battleship"},
            {"Tempest Tribal Issue", "AT Battleship"},
            {"Typhoon", "Battleship"},
            {"Typhoon Fleet Issue", "Faction Battleship"},
            {"Vindicator", "Faction Battleship"},
            {"Naga", "Attack Battlecruiser"},
            {"Oracle", "Attack Battlecruiser"},
            {"Tornado", "Attack Battlecruiser"},
            {"Talos", "Attack Battlecruiser"},
            {"Brutix", "Combat Battlecruiser"},
            {"Brutix Navy Issue", "Faction Combat Battlecruiser"},
            {"Cyclone", "Combat Battlecruiser"},
            {"Drake", "Combat Battlecruiser"},
            {"Drake Navy Issue", "Faction Combat Battlecruiser"},
            {"Ferox", "Combat Battlecruiser"},
            {"Gnosis", "Combat Battlecruiser"},
            {"Harbinger", "Combat Battlecruiser"},
            {"Harbinger Navy Issue", "Faction Combat Battlecruiser"},
            {"Hurricane", "Combat Battlecruiser"},
            {"Hurrican Fleet Issue", "Faction Combat Battlecruiser"},
            {"Myrmidon", "Combat Battlecruiser"},
            {"Prophecy", "Combat Battlecruiser"},
            {"Drakevac", "Precursor Battlecruiser"},
            {"Absolution", "Command Ship"},
            {"Astarte", "Command Ship"},
            {"Claymore", "Command Ship"},
            {"Damnation", "Command Ship"},
            {"Eos", "Command Ship"},
            {"Nighthawk", "Command Ship"},
            {"Sleipnir", "Command Ship"},
            {"Vulture", "Command Ship"},
            {"Curse", "Combat Recon Ship"},
            {"Huginn", "Combat Recon Ship"},
            {"Lachesis", "Combat Recon Ship"},
            {"Rook", "Combat Recon Ship"},
            {"Arbitrator", "Cruiser"},
            {"Ashimmu", "Faction Cruiser"},
            {"Augoror", "Cruiser"},
            {"Augoror Navy Issue", "Faction Cruiser"},
            {"Bellicose", "Cruiser"},
            {"Blackbird", "Cruiser"},
            {"Caracal", "Cruiser"},
            {"Caracal Navy Issue", "Faction Cruiser"},
            {"Celestis", "Cruiser"},
            {"Cynabal", "Cruiser"},
            {"Exequror", "Cruiser"},
            {"Exequror Navy Issue", "Cruiser"},
            {"Gila", "Faction Cruiser"},
            {"Guardian-Vexor", "Unique Cruiser"},
            {"Maller", "Cruiser"},
            {"Moa", "Cruiser"},
            {"Omen", "Cruiser"},
            {"Omen Navy Issue", "Faction Cruiser"},
            {"Opux Luxury Yacht", "Unique Cruiser"},
            {"Orthrus", "Faction Cruiser"},
            {"Osprey", "Cruiser"},
            {"Osprey Navy Issue", "Faction Cruiser"},
            {"Phantasm", "Faction Cruiser"},
            {"Rodiva", "Precursor Cruiser"},
            {"Rupture", "Cruiser"},
            {"Scythe", "Cruiser"},
            {"Scythe Fleet Issue", "Faction Cruiser"},
            {"Stabber", "Cruiser"},
            {"Stabber Fleet Issue", "Faction Cruiser"},
            {"Stratios", "Faction Cruiser"},
            {"Stratios Emergency Responder", "Unique Cruiser"},
            {"Thorax", "Cruiser"},
            {"Vedmak", "Precursor Cruiser"},
            {"Vexor", "Cruiser"},
            {"Vexor Navy Issue", "Faction Cruiser"},
            {"Victorieux Luxury Yacht", "Cruiser"},
            {"Vigilant", "Faction Cruiser"},
            {"Monitor", "Flag Cruiser"},
            {"Enforcer", "Force Recon Ship"},
            {"Arazu", "Force Recon Ship"},
            {"Falcon", "Force Recon Ship"},
            {"Pilgrim", "Force Recon Ship"},
            {"Rapier", "Force Recon Ship"},
            {"Chameleon", "AT Force Recon Ship"},
            {"Moracha", "AT Force Recon Ship"},
            {"Tiamat", "AT Force Recon Ship"},
            {"Victor", "AT Force Recon Ship"},
            {"Cerberus", "Heavy Assault Cruiser"},
            {"Deimos", "Heavy Assault Cruiser"},
            {"Eagle", "Heavy Assault Cruiser"},
            {"Ishtar", "Heavy Assault Cruiser"},
            {"Muninn", "Heavy Assault Cruiser"},
            {"Sacrilege", "Heavy Assault Cruiser"},
            {"Vagabond", "Heavy Assault Cruiser"},
            {"Zealot", "Heavy Assault Cruiser"},
            {"Adrestia", "AT Heavy Assault Cruiser"},
            {"Mimir", "AT Heavy Assault Cruiser"},
            {"Vangel", "AT Heavy Assault Cruiser"},
            {"Broadsword", "Heavy Interdiction Cruiser"},
            {"Devoter", "Heavy Interdiction Cruiser"},
            {"Onyx", "Heavy Interdiction Cruiser"},
            {"Phobos", "Heavy Interdiction Cruiser"},
            {"Fiend", "AT Heavy Interdiction Cruiser"},
            {"Basilisk", "Logistics"},
            {"Guardian", "Logistics"},
            {"Oneiros", "Logistics"},
            {"Scimitar", "Logistics"},
            {"Etana", "AT Logistics"},
            {"Rabisu", "AT Logistics"},
            {"Zarmazd", "Precursor Logistics"},
            {"Legion", "Strategic Cruiser"},
            {"Loki", "Strategic Cruiser"},
            {"Proteus", "Strategic Cruiser"},
            {"Tengu", "Strategic Cruiser"},
            {"Kikimora", "Precursor Destroyer"},
            {"Bifrost", "Command Destroyer"},
            {"Magus", "Command Destroyer"},
            {"Pontifex", "Command Destroyer"},
            {"Stork", "Command Destroyer"},
            {"Algos", "Destroyer"},
            {"Catalyst", "Destroyer"},
            {"Coercer", "Destroyer"},
            {"Corax", "Destroyer"},
            {"Cormorant", "Destroyer"},
            {"Dragoon", "Destroyer"},
            {"Sunesis", "Destroyer"},
            {"Talwar", "Destroyer"},
            {"Thrasher", "Destroyer"},
            {"Eris", "Interdictor"},
            {"Flycatcher", "Interdictor"},
            {"Heretic", "Interdictor"},
            {"Sabre", "Interdictor"},
            {"Confessor", "Tactical Destroyer"},
            {"Hecate", "Tactical Destroyer"},
            {"Jackdaw", "Tactical Destroyer"},
            {"Svipul", "Tactical Destroyer"},
            {"Hydra", "AT Covert Ops"},
            {"Caedes", "AT Covert Ops"},
            {"Chremoas", "AT Covert Ops"},
            {"Anathema", "Covert Ops"},
            {"Buzzard", "Covert Ops"},
            {"Cheetah", "Covert Ops"},
            {"Helios", "Covert Ops"},
            {"Pacifier", "Covert Ops"},
            {"Hyena", "Electronic Attack Ship"},
            {"Keres", "Electronic Attack Ship"},
            {"Kitsune", "Electronic Attack Ship"},
            {"Sentinel", "Electronic Attack Ship"},
            {"Endurance", "Expedition Frigate"},
            {"Prospect", "Expedition Frigate"},
            {"Ares", "Interceptor"},
            {"Claw", "Interceptor"},
            {"Crow", "Interceptor"},
            {"Crusader", "Interceptor"},
            {"Malediction", "Interceptor"},
            {"Raptor", "Interceptor"},
            {"Stiletto", "Interceptor"},
            {"Taranis", "Interceptor"},
            {"Imp", "AT Interceptor"},
            {"Whiptail", "Interceptor"},
            {"Deacon", "Logistics Frigate"},
            {"Kirin", "Logistics Frigate"},
            {"Scalpel", "Logistics Frigate"},
            {"Thalia", "Logistics Frigate"},
            {"Enyo", "Assault Frigate"},
            {"Harpy", "Assault Frigate"},
            {"Hawk", "Assault Frigate"},
            {"Ishkur", "Assault Frigate"},
            {"Jaguar", "Assault Frigate"},
            {"Retribution", "Assault Frigate"},
            {"Vengeance", "Assault Frigate"},
            {"Wolf", "Assault Frigate"},
            {"Cambion", "AT Assault Frigate"},
            {"Freki", "AT Assault Frigate"},
            {"Malice", "AT Assault Frigate"},
            {"Utu", "AT Assault Frigate"},
            {"Virtuoso", "AT Stealth Bomber"},
            {"Hound", "Stealth Bomber"},
            {"Manticore", "Stealth Bomber"},
            {"Nemesis", "Stealth Bomber"},
            {"Purifier", "Stealth Bomber"},
            {"Astero", "Faction Frigate"},
            {"Atron", "Frigate"},
            {"Bantam", "Frigate"},
            {"Breacher", "Frigate"},
            {"Burst", "Frigate"},
            {"Caldari Navy Hookbill", "Faction Frigate"},
            {"Condor", "Frigate"},
            {"Crucifier", "Frigate"},
            {"Crucifier Navy Issue", "Faction Frigate"},
            {"Cruor", "Faction Frigate"},
            {"Daredevil", "Faction Frigate"},
            {"Dramiel", "Faction Frigate"},
            {"Echelon", "Faction Frigate"},
            {"Executioner", "Frigate"},
            {"Federation Navy Comet", "Frigate"},
            {"Garmur", "Faction Frigate"},
            {"Gold Magnate", "Unique Frigate"},
            {"Griffin", "Frigate"},
            {"Griffin Navy Issue", "Faction Frigate"},
            {"Heron", "Frigate"},
            {"Imicus", "Frigate"},
            {"Imperial Navy Slicer", "Faction Frigate"},
            {"Incursus", "Frigate"},
            {"Inquisitor", "Frigate"},
            {"Kestrel", "Frigate"},
            {"Magnate", "Frigate"},
            {"Maulus", "Frigate"},
            {"Maulus Navy Issue", "Faction Frigate"},
            {"Merlin", "Frigate"},
            {"Navitas", "Frigate"},
            {"Probe", "Frigate"},
            {"Punisher", "Frigate"},
            {"Republic Fleet Firetail", "Faction Frigate"},
            {"Rifter", "Frigate"},
            {"Silver Magnate", "Unique Frigate"},
            {"Slasher", "Frigate"},
            {"Succubus", "Faction Frigate"},
            {"Tormentor", "Frigate"},
            {"Tristan", "Frigate"},
            {"Venture", "Frigate"},
            {"Vigil", "Frigate"},
            {"Vigil Fleet Issue", "Faction Frigate"},
            {"Worm", "Faction Frigate"},
            {"Zephyr", "Prototype Exploration Ship"},
            {"Amarr Shuttle", "Shuttle"},
            {"Apotheosis", "Faction Shuttle"},
            {"Caldari Shuttle", "Shuttle"},
            {"Council Diplomatic Shuttle", "Faction Shuttle"},
            {"Gallente Shuttle", "Shuttle"},
            {"Goru's Shuttle", "Faction Shuttle"},
            {"Guristas Shuttle", "Faction Shuttle"},
            {"InterBus Shuttle", "Faction Shuttle"},
            {"Leopard", "Faction Shuttle"},
            {"Minmatar Shuttle", "Shuttle"},
            {"Echo", "Unique Corvette"},
            {"Hematos", "Unique Corvette"},
            {"Immolator", "Unique Corvette"},
            {"Taipan", "Unique Corvette"},
            {"Violator", "Unique Corvette"},
            {"Ibis", "Corvette"},
            {"Impairor", "Corvette"},
            {"Reaper", "Corvette"},
            {"Velator", "Corvette"},
            {"Anshar", "Jump Freighter"},
            {"Ark", "Jump Freighter"},
            {"Nomad", "Jump Freighter"},
            {"Rhea", "Jump Freighter"},
            {"Bowhead", "Freighter"},
            {"Charon", "Freighter"},
            {"Fenrir", "Freighter"},
            {"Obelisk", "Freighter"},
            {"Providence", "Freighter"},
            {"Bustard", "Deep Space Transport"},
            {"Impel", "Deep Space Transport"},
            {"Mastodon", "Deep Space Transport"},
            {"Occator", "Deep Space Transport"},
            {"Crane", "Blockade Runner"},
            {"Prorator", "Blockade Runner"},
            {"Prowler", "Blockade Runner"},
            {"Viator", "Blockade Runner"},
            {"Badger", "Industrial"},
            {"Bestower", "Industrial"},
            {"Epithal", "Industrial"},
            {"Hoarder", "Industrial"},
            {"Iteron Mark V", "Industrial"},
            {"Kryos", "Industrial"},
            {"Mammoth", "Industrial"},
            {"Miasmos", "Industrial"},
            {"Miasmos Amastris Edition", "Unique Industrial"},
            {"Miasmos Quafe Ultra Edition", "Unique Industrial"},
            {"Miasmos Quafe Ultramarine Edition", "Unique Industrial"},
            {"Nereus", "Industrial"},
            {"Noctis", "Industrial"},
            {"Primae", "Industrial"},
            {"Sigil", "Industrial"},
            {"Tayra", "Industrial"},
            {"Wreathe", "Industrial"},
            {"Orca", "Industrial Command Ship"},
            {"Porpoise", "Industrial Command Ship"},
            {"Covetor", "Mining Barge"},
            {"Procurer", "Mining Barge"},
            {"Retriever", "Mining Barge"},
            {"Hulk", "Exhumer"},
            {"Mackinaw", "Exhumer"},
            {"Skiff", "Exhumer"},
            {"Astrahus", "Citadel"},
            {"Fortizar", "Citadel"},
            {"Keepstar", "Citadel"},
            {"Raitaru", "Engineering Complex"},
            {"Azbel", "Engineering Complex"},
            {"Sotiyo", "Engineering Complex"},
            {"Athanor", "Refinery"},
            {"Tatara", "Refinery"},
            {"'Draccous' Fortizar", "Faction Citadel"},
            {"'Horizon' Fortizar", "Faction Citadel"},
            {"'Moreau' Fortizar", "Faction Citadel"},
            {"'Marginis' Fortizar", "Faction Citadel"},
            {"'Prometheus' Fortizar", "Faction Citadel"},
            {"Capsule", "Capsule"},
            {"Capsule - Genolution 'Auroral' 197-variant", "Capsule"},
            {"Sisters Combat Scanner Probe", "Combat Scanner Probe"},
            {"Combat Scanner Probe I", "Combat Scanner Probe"},
            {"Sisters Core Scanner Probe", "Core Scanner Probe"},
            {"RSS Core Scanner Probe", "Core Scanner Probe"},
            {"Core Scanner Probe I", "Core Scanner Probe"}
            };

        private static Dictionary<string, string> ClassOfShip = new Dictionary<string, string>{
            {"Faction Titan", "Supercapital"},
            {"Titan", "Supercapital"},
            {"Faction Supercarrier", "Supercapital"},
            {"Supercarrier", "Supercapital"},
            {"Faction Dreadnought", "Capital"},
            {"Dreadnought", "Capital"},
            {"Faction Force Auxiliary", "Capital"},
            {"Force Auxiliary", "Capital"},
            {"Carrier", "Capital"},
            {"Capital Industrial Ship", "Capital"},
            {"Black Ops", "Battleship"},
            {"Marauder", "Battleship"},
            {"Faction Battleship", "Battleship"},
            {"Precursor Battleship", "Battleship"},
            {"Battleship", "Battleship"},
            {"AT Battleship", "Unique"},
            {"Attack Battlecruiser", "Battlecruiser"},
            {"Precursor Battlecruiser", "Battlecruiser"},
            {"Combat Battlecruiser", "Battlecruiser"},
            {"Faction Combat Battlecruiser", "Battlecruiser"},
            {"Command Ship", "Battlecruiser"},
            {"Combat Recon Ship", "Cruiser"},
            {"Cruiser", "Cruiser"},
            {"Precursor Cruiser", "Cruiser"},
            {"Faction Cruiser", "Cruiser"},
            {"Flag Cruiser", "Cruiser"},
            {"Unique Cruiser", "Unique"},
            {"Force Recon Ship", "Cruiser"},
            {"AT Force Recon Ship", "Unique"},
            {"Heavy Assault Cruiser", "Cruiser"},
            {"AT Heavy Assault Cruiser", "Unique"},
            {"Heavy Interdiction Cruiser", "Cruiser"},
            {"AT Heavy Interdiction Cruiser", "Unique"},
            {"Logistics", "Cruiser"},
            {"Precursor Logistics", "Cruiser"},
            {"AT Logistics", "Unique"},
            {"Strategic Cruiser", "Cruiser"},
            {"Precursor Destroyer", "Destroyer"},
            {"Command Destroyer", "Destroyer"},
            {"Interdictor", "Destroyer"},
            {"Destroyer", "Destroyer"},
            {"Tactical Destroyer", "Destroyer"},
            {"Precursor Frigate", "Frigate"},
            {"Assault Frigate", "Frigate"},
            {"AT Assault Frigate", "Unique"},
            {"Stealth Bomber", "Frigate"},
            {"AT Stealth Bomber", "Unique"},
            {"Unique Frigate", "Unique"},
            {"Covert Ops", "Frigate"},
            {"AT Covert Ops", "Unique"},
            {"Electronic Attack Ship", "Frigate"},
            {"Expedition Frigate", "Frigate"},
            {"Interceptor", "Frigate"},
            {"AT Interceptor", "Unique"},
            {"Logistics Frigate", "Frigate"},
            {"Frigate", "Frigate"},
            {"Faction Frigate", "Frigate"},
            {"Prototype Exploration Ship", "Frigate"},
            {"Faction Shuttle", "Shuttle"},
            {"Shuttle", "Shuttle"},
            {"Unique Corvette", "Unique"},
            {"Corvette", "Corvette"},
            {"Jump Freighter", "Capital Hauler"},
            {"Freighter", "Capital Hauler"},
            {"Industrial", "Industrial"},
            {"Unique Industrial", "Unique"},
            {"Blockade Runner", "Industrial"},
            {"Deep Space Transport", "Industrial"},
            {"Exhumer", "Mining"},
            {"Industrial Command Ship", "Mining"},
            {"Mining Barge", "Mining"},
            {"Citadel", "Upwell Structure"},
            {"Engineering Complex", "Upwell Structure"},
            {"Refinery", "Upwell Structure"},
            {"Faction Citadel", "Upwell Structure"},
            {"Capsule", "Capsule"},
            {"Combat Scanner Probe", "Scanner Probe"},
            {"Core Scanner Probe", "Scanner Probe"}
            };

        public static Ship ReturnShip(string name){
            var ship = new Ship();
            ship.Name = name;
            string type;
            if (TypeOfShip.TryGetValue(name, out type))
            {
                ship.Type = type;
            }
            else{
                ship.Type = "Unknown";
            }
            string cls;
            if (ClassOfShip.TryGetValue(ship.Type, out cls)){
                ship.Class = cls;
            }
            else{
                ship.Class = "Unknown";
            }

            return ship;
        }
    
    }
}
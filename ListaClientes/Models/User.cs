using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace ListaClientes
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public Dictionary<string, string> Number { get; set; }

        public Dictionary <string, string> Adress { get; set; }

        public List <string> Social { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }
    }
}

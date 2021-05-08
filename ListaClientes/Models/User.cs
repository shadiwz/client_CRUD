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

        public DateTime BirthDate { get; set; }

        public List<PhoneDescription> PhoneNumber { get; set; }
        
        public List<AddressDescription> Adress { get; set; }

        public List <string> Social { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }
    }
    public class PhoneDescription
    {
        public string NickName { get; set; }
        public string Phone { get; set; }
    }

    public class AddressDescription
    {
        public string Description { get; set; }
        public string Address { get; set; }
    }

    public class FilterUser 
    { 
        public string Name { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
    }

    }

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neo4jDTO
{
    public class FollowerPathDTO
    {
        [JsonProperty(PropertyName = "length")]
        public string len { get; set; }
    }
}

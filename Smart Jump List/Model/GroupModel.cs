using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Jump_List.Model
{
    class GroupModel
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public Dictionary<String, ItemModel> Items { get; set; }
    }
}

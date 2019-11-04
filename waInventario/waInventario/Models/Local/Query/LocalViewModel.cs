using System.Collections.Generic;
using waInventario.Models.Item.Query;

namespace waInventario.Models.Local.Query
{
    public class LocalViewModel
    {
        public long ID { get; set; }
        public string Descricao { get; set; }
        public List<ItemViewModel> Itens { get; set; }
    }
}
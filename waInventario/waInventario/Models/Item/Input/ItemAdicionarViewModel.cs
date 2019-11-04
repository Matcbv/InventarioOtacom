namespace waInventario.Models.Item.Input
{
    public class ItemAdicionarViewModel
    {
        public long FKLocal { get; set; }
        public string Nome { get; set; }
        public string Autor { get; set; }
        public int Edicao { get; set; }
        public string ISBN { get; set; }
        public string PathImagem { get; set; }
    }
}

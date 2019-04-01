namespace Solution.Domain.Entities
{
    public class Produto
    {
        public long ProdutoId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }

        public long ClienteId { get; set; }

        //virtual in old entity framework allowed lazy load.
        //lazy load doesn't exist in EntityCore 2
        public virtual Cliente Cliente { get; set; }

    } //class
} //namespace

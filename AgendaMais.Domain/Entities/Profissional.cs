namespace AgendaMais.Domain.Entities
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; } = "";


        //Relacionamentos
        public virtual IEnumerable<Consulta>? Consultas { get; set; }
    }
}

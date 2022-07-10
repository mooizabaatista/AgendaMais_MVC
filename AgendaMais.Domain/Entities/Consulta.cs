namespace AgendaMais.Domain.Entities
{
    public class Consulta
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Email { get; set; } = "";
        public DateTime Start { get; set; }
        //public DateTime? End { get; set; }
        public bool? Finished { get; set; }
        public bool? Notified { get; set; }

        // Relacionamentos
        public int ProfissionalId { get; set; }
        public virtual Profissional? Profissional { get; set; }
    }
}

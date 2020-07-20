namespace CopaApp.Infra.Data.Entities
{
    public class EquipeEntity : EntityBase
    {
      public string Nome { get; set; }
      public string Sigla { get; set; }
      public int Gols { get; set; }
    }
}

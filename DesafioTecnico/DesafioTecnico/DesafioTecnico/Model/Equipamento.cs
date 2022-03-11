using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioTecnico.Model
{
    [Table("equipamento")]
    public class Equipamento
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string situacao { get; set; }
        public string dataDeCadastro { get; set; }
        public string dataDeAlteracao { get; set; }
        public int numeroDoPatrimonio { get; set; }
    }
}

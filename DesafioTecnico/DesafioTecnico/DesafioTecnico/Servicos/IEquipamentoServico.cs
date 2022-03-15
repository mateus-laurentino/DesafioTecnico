using DesafioTecnico.Model;
using System.Collections.Generic;

namespace DesafioTecnico.Servicos
{
    public interface IEquipamentoServico
    {
        Equipamento Create(Equipamento equipamento);
        Equipamento FindByPatrimonio(int patrimonio);
        List<Equipamento> FindByDescricao(string Descricao);
        List<Equipamento> FindAll();
        Equipamento Update(Equipamento equipamento);
        void Delete(int id);
    }
}

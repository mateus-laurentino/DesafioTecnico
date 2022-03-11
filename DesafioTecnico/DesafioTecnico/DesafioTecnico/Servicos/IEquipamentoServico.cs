using DesafioTecnico.Model;
using System.Collections.Generic;

namespace DesafioTecnico.Servicos
{
    public interface IEquipamentoServico
    {
        Equipamento Create(Equipamento equipamento);
        Equipamento FindById(int id);
        List<Equipamento> FindAll();
        Equipamento Update(Equipamento equipamento);
        void Delete(int id);
    }
}

using DesafioTecnico.Model;
using System;
using System.Collections.Generic;
using System.Threading;

namespace DesafioTecnico.Servicos.Implementacao
{
    public class ImplementacaoEquipamento : IEquipamentoServico
    {
        private volatile int count;

        public List<Equipamento> FindAll()
        {
            List<Equipamento> equipamentos = new List<Equipamento>();
            for(int x = 0; x < 10; x++)
            {
                Equipamento equipamento = MockEquipamento(x);
                equipamentos.Add(equipamento);
            }
            return equipamentos;
        }

        public Equipamento Create(Equipamento equipamento)
        {
            return equipamento;
        }

        public Equipamento Update(Equipamento equipamento)
        {
            return equipamento;
        }

        public Equipamento FindById(int id)
        {
            return new Equipamento
            {
                Id = IncrementAndGet(),
                Descricao = "Notebook",
                Situacao = "Ativo",
                DataDeCadastro = "05/10/2021",
                DataDeAlteracao = "06/10/2021",
                NumeroDoPatrimonio = 010203
            };
        }

        public void Delete(int id)
        {

        }

        private Equipamento MockEquipamento(int x)
        {
            return new Equipamento
            {
                Id = IncrementAndGet(),
                Descricao = "Produto" + x,
                Situacao = "Situação" + x,
                DataDeCadastro = "Data de cadatro" + x,
                DataDeAlteracao = "Data de Alteração" + x,
                NumeroDoPatrimonio = 010203 + x
            };
        }

        private int IncrementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}

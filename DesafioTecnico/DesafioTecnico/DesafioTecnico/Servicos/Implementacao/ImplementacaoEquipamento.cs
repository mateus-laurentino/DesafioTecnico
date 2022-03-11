using DesafioTecnico.Model;
using DesafioTecnico.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioTecnico.Servicos.Implementacao
{
    public class ImplementacaoEquipamento : IEquipamentoServico
    {
        private MySQLContext _context; 

        public ImplementacaoEquipamento(MySQLContext context)
        {
            _context = context;
        }

        public List<Equipamento> FindAll()
        {
            return _context.Equipamentos.ToList();
        }

        public Equipamento FindById(int id)
        {
            return _context.Equipamentos.SingleOrDefault(e => e.id.Equals(id));
        }

        public Equipamento Create(Equipamento equipamento)
        {
            if (!ExistePatrimonio(equipamento.numeroDoPatrimonio))
            {
                try
                {
                    _context.Add(equipamento);
                    _context.SaveChanges();
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
            
            return equipamento;
        }

        public Equipamento Update(Equipamento equipamento)
        {
            if (!ExisteId(equipamento.id)) return new Equipamento();

            var resultado = _context.Equipamentos.SingleOrDefault(p => p.id.Equals(equipamento.id));
            if (resultado != null)
            {
                try
                {
                    _context.Entry(resultado).CurrentValues.SetValues(equipamento);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return equipamento;
        }

        public void Delete(int id)
        {
            var resultado = _context.Equipamentos.SingleOrDefault(p => p.id.Equals(id));
            if(resultado != null)
            {
                try
                {
                    _context.Equipamentos.Remove(resultado);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        private bool ExisteId(int id)
        {
            return _context.Equipamentos.Any(p => p.id.Equals(id));
        }

        private bool ExistePatrimonio(int patrimonio)
        {
            return _context.Equipamentos.Any(p => p.numeroDoPatrimonio.Equals(patrimonio));
        }

    }
}

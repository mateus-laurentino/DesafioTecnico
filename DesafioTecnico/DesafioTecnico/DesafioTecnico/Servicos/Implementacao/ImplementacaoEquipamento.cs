using DesafioTecnico.Model;
using DesafioTecnico.Model.Context;
using DesafioTecnico.Model.Functions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioTecnico.Servicos.Implementacao
{
    public class ImplementacaoEquipamento : IEquipamentoServico
    {
        private MySQLContext _context; 
        verificador verificador = new verificador();

        public ImplementacaoEquipamento(MySQLContext context)
        {
            _context = context;
        }

        public List<Equipamento> FindAll()
        {
            return _context.Equipamentos.ToList();
        }

        public Equipamento FindByPatrimonio(int patrimonio)
        {
            return _context.Equipamentos.SingleOrDefault(e => e.numeroDoPatrimonio.Equals(patrimonio));
        }

        public List<Equipamento> FindByDescricao(string Descricao)
        {
            List<Equipamento> equipamentos = new List<Equipamento>();
            //equipamentos = _context.Equipamentos.ToList();
            for(int x = 0; x < _context.Equipamentos.ToList().Count; x++)
            {
                if(_context.Equipamentos.ToList()[x].descricao == Descricao)
                {
                    equipamentos.Add(_context.Equipamentos.ToList()[x]);
                }
            }
            return equipamentos;

            //return _context.Equipamentos.Append(Descricao).ToList();
        }

        public Equipamento Create(Equipamento equipamento)
        {
            if(verificador.verificando(equipamento.descricao,equipamento.situacao,equipamento.numeroDoPatrimonio) == true)
            {
                if (!ExistePatrimonio(equipamento.numeroDoPatrimonio))
                {
                    try
                    {
                        equipamento.dataDeCadastro = DateTime.Now.ToShortDateString();
                        equipamento.dataDeAlteracao = DateTime.Now.ToShortDateString();
                        _context.Add(equipamento);
                        _context.SaveChanges();
                    }
                    catch (System.Exception)
                    {
                        throw;
                    }
                    return equipamento;
                }
                else return null;

            }
            else
            {
                return null;
            }

        }

        public Equipamento Update(Equipamento equipamento)
        {

            var resultado = _context.Equipamentos.SingleOrDefault(p => p.id.Equals(equipamento.id));
            if (resultado != null)
            {
                try
                {
                    if (resultado.situacao != equipamento.situacao)
                    {
                        resultado.dataDeAlteracao = DateTime.Now.ToShortDateString();
                        resultado.situacao = equipamento.situacao;
                        _context.Entry(resultado);
                        _context.SaveChanges();
                    }
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
            if (resultado != null)
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

        private bool ExistePatrimonio(int patrimonio)
        {
            return _context.Equipamentos.Any(p => p.numeroDoPatrimonio.Equals(patrimonio));
        }

    }
}

using System.Collections.Generic;

namespace DesafioTecnico.Model.Functions
{
    public class verificador
    {
        public bool numeroPatrimonio(int numero)
        {
            string texto = numero.ToString();
            if(texto.Length == 6)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool verificando(string descricao,string situacao,int numeroDoPatrimonio)
        {
            List<int> verificacoes = new List<int>();
            if (string.IsNullOrWhiteSpace(descricao)) verificacoes.Add(1);
            if(string.IsNullOrWhiteSpace(situacao)) verificacoes.Add(2);
            if(numeroPatrimonio(numeroDoPatrimonio)== false) verificacoes.Add(3);

            if (verificacoes.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}

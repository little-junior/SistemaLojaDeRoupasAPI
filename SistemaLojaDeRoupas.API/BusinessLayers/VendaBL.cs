using SistemaLojaDeRoupas.API.CustomExceptions;
using SistemaLojaDeRoupas.API.RequestDTOs;

namespace SistemaLojaDeRoupas.API.BusinessLayers
{
    public class VendaBL
    {
        public void ValidateRequestProdutosQuantidade(VendaRequest vendaRequest)
        {
            if (vendaRequest.ProdutosQuantidade.Count == 0)
            {
                throw new CustomException("The 'produtosQuantidade' field can't be empty", 400);
            }
        }

        public bool ValidateCpfCliente(VendaRequest vendaRequest)
        {
            var cpf = vendaRequest.CpfCliente;

            int[] multiplicador1 = { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;

            if (cpf.Length != 11)
                return false;

            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = resto.ToString();

            tempCpf += digito;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito += resto.ToString();

            return cpf.EndsWith(digito);
        }
    }
}

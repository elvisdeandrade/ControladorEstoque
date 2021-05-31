namespace ControladorDeEstoque.Controllers.Models
{
    public static class CPF
    {
        public static bool Validar(string value)
        {
             //limpa formatação
            string valor = value.Replace(".", "").Replace("-", "");

            if (valor.Length != 11)
                return false;

            bool igual = true;

            //Verifica se os números não são todos iguais, por exemplo; 111.111.111-11
            for (int i = 1; i < 11 && igual; i++)
            {
                if (valor[i] != valor[0])
                    igual = false;
            }
            
            //Checa se não é uma sequencia
            if (igual || valor == "12345678909")
                return false;

            int[] numeros = new int[11];

            for (int i = 0; i < 11; i++)
            {
                numeros[i] = int.Parse(valor[i].ToString());
            }

            int soma = 0;

            for (int i = 0; i < 9; i++)
            {
                soma += (10 - i) * numeros[i];
            }

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[9] != 0)
                    return false;
            }
            else if (numeros[9] != 11 - resultado)
            {
                return false;
            }

            soma = 0;

            for (int i = 0; i < 10; i++)
            {
                soma += (11 - i) * numeros[i];
            }

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
            {
                if (numeros[10] != 0)
                    return false;
            }
            else
            {
                if (numeros[10] != 11 - resultado)
                    return false;
            }

            return true;
        }
    }
}
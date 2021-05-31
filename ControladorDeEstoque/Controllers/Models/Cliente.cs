using System;

namespace ControladorDeEstoque.Controllers.Models
{
    public class Cliente
    {
        private string _cpf;
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf
        {
            get { return _cpf; }
            set
            {
                if (!CPF.Validar(value))
                    throw new Exception("CPF inválido");

                _cpf = value;
            }
        }
    }
}
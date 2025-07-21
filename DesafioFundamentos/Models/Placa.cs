using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Placa
    {
        private static readonly Regex PlacaPadraoBrasil = new Regex(@"^[A-Z]{3}[0-9]{4}$");
        private static readonly Regex PlacaPadraoMercosul = new Regex(@"^[A-Z]{3}[0-9][A-Z][0-9]{2}$");

        public string Valor { get; }

        public Placa(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                throw new ArgumentException("A placa não pode ser nula ou vazia.");
            }

            if (!VerificaFormato(valor))
            {
                throw new ArgumentException($"O valor da placa '{valor}' não corresponde a um formato válido (Brasil ou Mercosul).");
            }
            Valor = valor.ToUpper().Trim().Replace("-", "");
        }
        
        private static bool VerificaFormato(string valor)
        {
            string placaLimpa = valor.ToUpper().Trim().Replace("-", "");
            return PlacaPadraoBrasil.IsMatch(placaLimpa) || PlacaPadraoMercosul.IsMatch(placaLimpa);
        }

        public override string ToString()
        {
            return Valor;
        }

        public override bool Equals(object? obj)
        {
            return obj is Placa placa &&
                   Valor == placa.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Valor);
        }
    }
}
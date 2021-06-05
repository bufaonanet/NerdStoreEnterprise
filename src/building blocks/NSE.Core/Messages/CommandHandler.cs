using FluentValidation.Results;
using NSE.Core.Data;
using System.Threading.Tasks;

namespace NSE.Core.Messages
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AdicionarErro(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(propertyName: "", errorMessage: mensagem));
        }

        protected async Task<ValidationResult> PersistirDados(IUnitOfWork uow)
        {
            if( ! await uow.Commit())
            {
                AdicionarErro("Houve um erro ao tentar persistir os dados");
            }

            return ValidationResult;
        }
    }
}

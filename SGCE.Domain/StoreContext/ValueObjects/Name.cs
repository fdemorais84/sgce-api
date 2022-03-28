using FluentValidator;
using FluentValidator.Validation;

namespace SGCE.Domain.StoreContext.ValueObjects
{
    public class Name : Notifiable
    {
        public Name(string nome)
        {
            Nome = nome; 
            
        }

        public string Nome { get; private set; }        

        public override string ToString()
        {
            return $"{Nome}";
        }
    }
}

namespace PassIn.Exceptions;
public class PassInException : SystemException
{
    public PassInException(string message) : base(message) // dois pontos no ctor, pega a mensagem do construtor e repassa para o SystemExeption
    {
        
    }
}
namespace Errors.SyntaxInvalidError.ErrorDatatypes;

public class SyntaxInvalidLambdaDatatypeError : Error
{
    public SyntaxInvalidLambdaDatatypeError(int _position_start, int _position_end,
        string _error_name = "Синтаксическая ошибка: неверный лямбда-терм.",
        string _discription = "Синтаксическая ошибка при некорректном создании лямбда-терма. Он не верный") : base(_position_start, _position_end,
        _error_name, _discription)
    {
    }
}
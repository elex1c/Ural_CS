//V2.0.5

namespace Errors.SyntaxInvalidError.ErrorDatatypes;

public class SyntaxInvalidFuncError : Error
{
    public SyntaxInvalidFuncError(int _position_start, int _position_end,
        string _error_name = "Синтаксическая ошибка: функция не правильно определина.",
        string _discription = " Функция принимает или возвращает не правельный тип данных.") : base(_position_start,
        _position_end, _error_name, _discription)
    {
        // Inherited Constructor
    }
}
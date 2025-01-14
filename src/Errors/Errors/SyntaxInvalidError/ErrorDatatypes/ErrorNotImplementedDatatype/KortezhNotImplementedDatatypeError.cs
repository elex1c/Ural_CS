namespace Errors.SyntaxInvalidError.ErrorDatatypes.ErrorNotImplementedDatatype;

public class KortezhNotImplementedDatatypeError : Error
{
    public KortezhNotImplementedDatatypeError(int _position_start, int _position_end,
        string _error_name = "Логическая ошибка: неверное оператор над кортеж.",
        string _discription = "Логическая ошибка при попытки изменения кортежа. Кортеж не изменяемый тип данных.") :
        base(_position_start, _position_end, _error_name, _discription)
    {
    }
}
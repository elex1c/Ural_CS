namespace Errors.SyntaxInvalidError.ErrorDatatypes.ErrorOutOfRange;

public class VoschOutOfRangeMaxError : SyntaxInvalidVoschDatatypeError
{
    public VoschOutOfRangeMaxError(int _position_start, int _position_end,
        string _error_name = "Восьмеричное число не в диапазоне: ",
        string _discription = "число не должно превышать 281474976710655.") : base(_position_start, _position_end,
        _error_name, _discription)
    {
    }
}
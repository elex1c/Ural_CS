﻿using System;
using Ural_CS_Rider.Ural_translator_compiler.Errors;
namespace Ural_CS_Rider.Ural_translator_compiler.Errors.SyntaxInvalidError.ErrorDatatypes

{
    public class SyntaxInvalidDrobchDatatypeError : Error
    {
        public SyntaxInvalidDrobchDatatypeError(int _position_start, int _position_end, string _error_name = "Синтаксическая ошибка: неверное дробное число.", string _discription = "Синтаксическая ошибка при попытке создания дробного числа.") : base(_position_start, _position_end, _error_name, _discription)
        {
            // Inherited Constructor
        }

    }
}
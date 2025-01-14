#region

using Errors.SyntaxInvalidError.ErrorDatatypes.ErrorOutOfRange;
using Errors.SyntaxInvalidError.ErrorDatatypes.ErrorOverloadDatatype;

#endregion

namespace Datatypes.Strings;

public class str0 : VOID, Interface_Ural_Datatype
{
    public const ushort MaxLength = 1;
    public const string DefaultValue = "А"; //Русская А

    public str0(string _value = "") : base(_value)
    {
        switch (_value)
        {
            case "" :
                this.value = DefaultValue;
                break;
            default :
                this.value = _value[0];
                break;
        }
    }

    public str0(char _value) : base(_value)
    {
        this.value = Convert.ToString(_value);
    }

    public str0(str0 _value) : base(_value)
    {
        this.value = _value.value;
    }

    public str0(str10 _value) : base(_value)
    {
        this.value = _value.value == "" ? DefaultValue : _value[0];
    }

    public str0(str16 _value) : base(_value)
    {
        this.value = _value.value == "" ? DefaultValue : _value[0];
    }

    public str0(str32 _value) : base(_value)
    {
        this.value = _value.value == "" ? DefaultValue : _value[0];
    }

    public str0(str64 _value) : base(_value)
    {
        this.value = _value.value == "" ? DefaultValue : _value[0];
    }

    //((char)(((ulong)this.value[0] + (ulong)str.value[0]))/(ulong)2).ToString()
    public str0(natch16 _value) : base(_value)
    {
        this.value = ((char)(ulong)_value).ToString();
    }

    public str0(natch32 _value) : base(_value)
    {
        this.value = ((char)(ulong)_value).ToString();
    }

    public str0(natch64 _value) : base(_value)
    {
        this.value = ((char)(ulong)_value).ToString();
    }

    public str0(celch16 _value) : base(_value)
    {
        this.value = ((char)(ulong)Math.Abs(_value.value)).ToString();
    }

    public str0(celch32 _value) : base(_value)
    {
        this.value = ((char)(ulong)Math.Abs(_value.value)).ToString();
    }

    public str0(celch64 _value) : base(_value)
    {
        this.value = ((char)(ulong)Math.Abs(_value.value)).ToString();
    }

    public str0(drobch16 _value) : base(_value)
    {
        this.value = ((char)(ulong)Math.Abs(_value.value)).ToString();
    }

    public str0(drobch32 _value) : base(_value)
    {
        this.value = ((char)(ulong)Math.Abs(_value.value)).ToString();
    }

    public str0(drobch64 _value) : base(_value)
    {
        string value = Convert.ToString(_value.value);
        this.value = value.Length == 1 ? value : value[0];
    }

    public static explicit operator string(str0 str) => (string)str.value;

    public static dynamic operator +(str0 l, str0 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(Convert.ToString(r.value));
    }

    public static dynamic operator +(str0 l, str10 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(Convert.ToString(r.value));
    }

    public static dynamic operator +(str0 l, str16 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(Convert.ToString(r.value));
    }

    public static dynamic operator +(str0 l, str32 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(Convert.ToString(r.value));
    }

    public static dynamic operator +(str0 l, str64 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(Convert.ToString(r.value));
    }

    public static dynamic operator +(str0 l, natch16 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(r);
    }

    public static dynamic operator +(str0 l, natch32 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(r);
    }

    public static dynamic operator +(str0 l, natch64 r)
    {
        str0 l2 = new str0(l);
        return l2.___Add(r);
    }


    public static dynamic operator -(str0 l, str10 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, str16 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, str32 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, str64 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, natch16 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, natch32 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, natch64 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, celch16 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, celch32 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, celch64 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, drobch16 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, drobch32 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(str0 l, drobch64 r)
    {
        str10 l2 = new str10(l);
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(natch16 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(natch32 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(natch64 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(celch16 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(celch32 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(celch64 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(drobch16 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(drobch32 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator -(drobch64 l, str0 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Minus(Convert.ToString(r.value));
    }

    public static dynamic operator *(str0 l, natch16 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Multiply(Convert.ToString(r.value));
    }

    public static dynamic operator *(str0 l, natch32 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Multiply(Convert.ToString(r.value));
    }

    public static dynamic operator *(str0 l, natch64 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Multiply(Convert.ToString(r.value));
    }

    public static dynamic operator *(str0 l, celch16 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Multiply(Convert.ToString(r.value));
    }

    public static dynamic operator *(str0 l, celch32 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Multiply(Convert.ToString(r.value));
    }

    public static dynamic operator *(str0 l, celch64 r)
    {
        str10 l2 = new str10(Convert.ToString(l));
        return l2.___Multiply(Convert.ToString(r.value));
    }

    public static dynamic operator /(str0 l, str0 r)
    {
        str0 l2 = new str0(l);
        return l2.___Divide(r);
    }

    public natch16 ___Len() => new natch16(1);

    public dynamic ___Add(dynamic _value)
    {
        if (!IsNumericFull(_value))
        {
            string str = this.value + _value.ToString();
            switch (str.Length)
            {
                case 1 :
                    return new str0(str);
                case < str10.MaxLength :
                    return new str10(str);
                default :
                {
                    switch ((str.Length >= str10.MaxLength) & (str.Length < str16.MaxLength))
                    {
                        case true :
                            return new str16(str);
                        default :
                        {
                            switch ((str.Length >= str16.MaxLength) & (str.Length < str32.MaxLength))
                            {
                                case true :
                                    return new str32(str);
                                default :
                                {
                                    switch ((str.Length >= str32.MaxLength) & ((ulong)str.Length < str64.MaxLength))
                                    {
                                        case true :
                                            return new str64(str);
                                        default :
                                        {
                                            Str64OutOfRangeError err = new Str64OutOfRangeError(0, 0);
                                            err.Execute();
                                            return null;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        return new SyntaxInvalidOverloadStrNumericError(0, 0);
    }

    public dynamic ___Add(string _value)
    {
        string str = this.value + Convert.ToString(_value);
        switch (str.Length)
        {
            case < str10.MaxLength :
                return new str10(str);
            default :
            {
                switch ((str.Length >= str10.MaxLength) & (str.Length < str16.MaxLength))
                {
                    case true :
                        return new str16(str);
                    default :
                    {
                        switch ((str.Length >= str16.MaxLength) & (str.Length < str32.MaxLength))
                        {
                            case true :
                                return new str32(str);
                            default :
                            {
                                switch ((str.Length >= str32.MaxLength) & ((ulong)str.Length < str64.MaxLength))
                                {
                                    case true :
                                        return new str64(str);
                                    default :
                                    {
                                        Str64OutOfRangeError err = new Str64OutOfRangeError(0, 0);
                                        err.Execute();
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public dynamic ___Add(str0 _value)
    {
        string str = this.value + Convert.ToString(_value);
        switch (str.Length)
        {
            case 1 :
                return new str0(this.value);
            case < str10.MaxLength :
                return new str10(str);
            default :
            {
                switch ((str.Length >= str10.MaxLength) & (str.Length < str16.MaxLength))
                {
                    case true :
                        return new str16(str);
                    default :
                    {
                        switch ((str.Length >= str16.MaxLength) & (str.Length < str32.MaxLength))
                        {
                            case true :
                                return new str32(str);
                            default :
                            {
                                switch ((str.Length >= str32.MaxLength) & ((ulong)str.Length < str64.MaxLength))
                                {
                                    case true :
                                        return new str64(str);
                                    default :
                                    {
                                        Str64OutOfRangeError err = new Str64OutOfRangeError(0, 0);
                                        err.Execute();
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public dynamic ___Add(str10 _value)
    {
        string str = this.value + Convert.ToString(_value);
        switch (str.Length)
        {
            case 1 :
                return new str0(this.value);
            case < str10.MaxLength :
                return new str10(str);
            default :
            {
                switch ((str.Length >= str10.MaxLength) & (str.Length < str16.MaxLength))
                {
                    case true :
                        return new str16(str);
                    default :
                    {
                        switch ((str.Length >= str16.MaxLength) & (str.Length < str32.MaxLength))
                        {
                            case true :
                                return new str32(str);
                            default :
                            {
                                switch ((str.Length >= str32.MaxLength) & ((ulong)str.Length < str64.MaxLength))
                                {
                                    case true :
                                        return new str64(str);
                                    default :
                                    {
                                        Str64OutOfRangeError err = new Str64OutOfRangeError(0, 0);
                                        err.Execute();
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public dynamic ___Add(str16 _value)
    {
        string str = this.value + Convert.ToString(_value);
        switch (str.Length)
        {
            case 1 :
                return new str0(this.value);
            case < str10.MaxLength :
                return new str10(str);
            default :
            {
                switch ((str.Length >= str10.MaxLength) & (str.Length < str16.MaxLength))
                {
                    case true :
                        return new str16(str);
                    default :
                    {
                        switch ((str.Length >= str16.MaxLength) & (str.Length < str32.MaxLength))
                        {
                            case true :
                                return new str32(str);
                            default :
                            {
                                switch ((str.Length >= str32.MaxLength) & ((ulong)str.Length < str64.MaxLength))
                                {
                                    case true :
                                        return new str64(str);
                                    default :
                                    {
                                        Str64OutOfRangeError err = new Str64OutOfRangeError(0, 0);
                                        err.Execute();
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public dynamic ___Add(str32 _value)
    {
        string str = this.value + Convert.ToString(_value);
        switch (str.Length)
        {
            case 1 :
                return new str0(this.value);
            case < str10.MaxLength :
                return new str10(str);
            default :
            {
                switch ((str.Length >= str10.MaxLength) & (str.Length < str16.MaxLength))
                {
                    case true :
                        return new str16(str);
                    default :
                    {
                        switch ((str.Length >= str16.MaxLength) & (str.Length < str32.MaxLength))
                        {
                            case true :
                                return new str32(str);
                            default :
                            {
                                switch ((str.Length >= str32.MaxLength) & ((ulong)str.Length < str64.MaxLength))
                                {
                                    case true :
                                        return new str64(str);
                                    default :
                                    {
                                        Str64OutOfRangeError err = new Str64OutOfRangeError(0, 0);
                                        err.Execute();
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public dynamic ___Add(str64 _value)
    {
        string str = this.value + Convert.ToString(_value);
        switch (str.Length)
        {
            case 1 :
                return new str0(this.value);
            case < str10.MaxLength :
                return new str10(str);
            default :
            {
                switch ((str.Length >= str10.MaxLength) & (str.Length < str16.MaxLength))
                {
                    case true :
                        return new str16(str);
                    default :
                    {
                        switch ((str.Length >= str16.MaxLength) & (str.Length < str32.MaxLength))
                        {
                            case true :
                                return new str32(str);
                            default :
                            {
                                switch ((str.Length >= str32.MaxLength) & ((ulong)str.Length < str64.MaxLength))
                                {
                                    case true :
                                        return new str64(str);
                                    default :
                                    {
                                        Str64OutOfRangeError err = new Str64OutOfRangeError(0, 0);
                                        err.Execute();
                                        return null;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    public str0 ___Add(natch16 _value) => new str0(((char)((ulong)this.value[0] + (ulong)_value)).ToString());

    public str0 ___Add(natch32 _value) => new str0(((char)((ulong)this.value[0] + (ulong)_value)).ToString());

    public str0 ___Add(natch64 _value) => new str0(((char)((ulong)this.value[0] + (ulong)_value)).ToString());


    public unsafe str0 ___Minus(str0 str) => new str0(((char)((ulong)this.value[0] + (ulong)str.value[0])).ToString());

    public unsafe str0 ___Minus(natch16 _value) => new str0(((char)((ulong)this.value[0] - (ulong)_value)).ToString());

    public unsafe str0 ___Minus(natch32 _value) => new str0(((char)((ulong)this.value[0] - (ulong)_value)).ToString());

    public unsafe str0 ___Minus(natch64 _value) => new str0(((char)((ulong)this.value[0] - (ulong)_value)).ToString());

    public unsafe dynamic ___Multiply(str0 str)
    {
        try { return new str0(((char)((ulong)this.value[0] + (ulong)str.value[0]) / (ulong)2).ToString()); }
        catch (OverflowException e)
        {
            Natch64OutOfRangeMaxError err = new Natch64OutOfRangeMaxError(0, 0);
            err.Execute();
            return null;
        }
        catch (Exception e)
        {
            Natch64OutOfRangeMaxError err = new Natch64OutOfRangeMaxError(0, 0);
            err.Execute();
            return null;
        }
    }

    public dynamic ___Divide(str0 str)
    {
        try { return new str0(((ulong)this.value[0] * (ulong)str.value[0] / 2).ToString()); }
        catch (DivideByZeroException e) { return this; }
        catch (OverflowException e)
        {
            Natch64OutOfRangeMaxError err = new Natch64OutOfRangeMaxError(0, 0);
            err.Execute();
            return null;
        }
        catch (Exception e)
        {
            Natch64OutOfRangeMaxError err = new Natch64OutOfRangeMaxError(0, 0);
            err.Execute();
            return null;
        }
    }
}
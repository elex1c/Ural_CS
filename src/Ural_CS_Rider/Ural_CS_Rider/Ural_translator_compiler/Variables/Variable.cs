namespace Ural_CS_Rider.Ural_translator_compiler.Variables;

public class Variable
{
    public Hashtable ___variables = new Hashtable();

    public Variable(string name, Type? type = null, dynamic? value = null)
    {
        type ??= typeof(VOID);
        value ??= new VOID();

        this.___variables[name] = new KeyValuePair<Type?, dynamic?>(type, value);
    }

    public dynamic? this[string index]
    {
        get => this.___variables[index];
        set => this.___variables[index] = new KeyValuePair<Type?, dynamic?>(value?.GetType(), value);
    }


    public static void StringCreate2Variable(string name, dynamic value) //НЕ РАБОТАЕТ
    {
        // Define a dynamic method that creates a new variable with the specified name and value
        DynamicMethod method = new DynamicMethod(
            "StringCreate2Variable",
            typeof(void),
            new [] { typeof(string), typeof(Variable) },
            typeof(Variable).Module,
            true
        );

        // Get the IL generator for the dynamic method
        ILGenerator generator = method.GetILGenerator();

        // Define a local variable with the desired name and value
        LocalBuilder local = generator.DeclareLocal(typeof(Variable), true);
        generator.Emit(OpCodes.Ldloc, local);
        generator.Emit(OpCodes.Ldc_I4, (int)value);
        generator.Emit(OpCodes.Stloc, local);

        // Invoke the dynamic method on the target object
        typeof(Variable).InvokeMember(
            "StringCreate2Variable",
            BindingFlags.InvokeMethod | BindingFlags.Public | BindingFlags.Static,
            null,
            null,
            new object [] { name, value }
        );
    }

    public static str64 NameConvert2String<T>(T variable) => new str64(typeof(T).GetProperties()[0].Name);
    //Variable.Convert2String(new { outside_variable }))
}
#region

using Datatypes.Collections.MathCollections.LambdaAnaliz;
using Datatypes.Collections.MathCollections.LambdaAnaliz.LambdaSyntaxTree;
using LambdaExpression = Datatypes.Collections.MathCollections.LambdaAnaliz.LambdaSyntaxTree.LambdaExpression;
using UralConsole = Colorful.Console;

#endregion

// ReSharper disable ClassNeverInstantiated.Global

namespace Ural_CS_Rider;

internal class MainClass
{
    public static unsafe void Main(string [] args)
    {
        matrica c = new matrica(3)
        {
            [0, 1] = new drobch64(1),
            [0, 2] = new drobch64(-1)
        };


        string lambdaExpression = @"λx.λy.λt.λf.f x (y t)";
        LambdaExpression lala = LambdaParser.ParseTerm(lambdaExpression);
        LambdaTerm lala2 = LambdaParser.ParseLine(lambdaExpression);
        Console.WriteLine(lala.ToBinary());
        Console.WriteLine(nameof(c));

        //Console.WriteLine(matrica.___HyperCrossProduct(c, c));
        //Console.WriteLine(matrica.___HyperCrossProduct(c, c).___Diagonalisacia());
        //Libraries.UralMathFsharpLib.UralPlot.UraFunctionalPlot Plt = new Libraries.UralMathFsharpLib.UralPlot.UraFunctionalPlot("uralplot"); 
        //Plt.Plot("sin(x)", FSharpOption<Style>.None, FSharpOption<Internal.LambdaRange>.None, FSharpOption<Output>.None, FSharpOption<Titles>.None);
    }

    
}
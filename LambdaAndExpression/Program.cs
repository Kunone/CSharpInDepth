using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Reflection;

namespace LambdaAndExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            //ExpressionStartWith();
            ComplicatedExpressionStartWith();
        }

        static int ComplexExpressionAdd5()
        {
            var firstEx = Expression.Constant(2);
            var secondEx = Expression.Constant(3);
            var addEx = Expression.Add(firstEx, secondEx);

            var result = Expression.Lambda<Func<int>>(addEx).Compile();
            return result();
        }

        static int SimpleExpressionAdd5()
        {
            Expression<Func<int>> return5 = () => 5;
            var result = return5.Compile();
            return result();
        }

        static void ExpressionStartWith()
        {
            Expression<Func<string, string, bool>> ex = (x, y) => x.StartsWith(y);
            var compiled = ex.Compile();
            Console.WriteLine(compiled("first", "second"));
            Console.WriteLine(compiled("first", "fir"));
        }

        static void ComplicatedExpressionStartWith()
        {
            var method = typeof(string).GetMethod("StartsWith", new[] { typeof(string) });
            var target = Expression.Parameter(typeof(string), "x");
            var methodArg = Expression.Parameter(typeof(string), "y");
            var methodArgs = new[] { methodArg };

            // CallExpression
            var call = Expression.Call(target, method, methodArgs);

            // Transfor to lambda
            var lambdaParameters = new[] { target, methodArg };
            var lambda = Expression.Lambda<Func<string, string, bool>>(call, lambdaParameters);

            var compiled = lambda.Compile();
            Console.WriteLine(compiled("first", "second"));
            Console.WriteLine(compiled("first", "fir"));
        }
    }
}

using ConsoleApp1.Evaluator;
using ConsoleApp1.Parser_Utilities.Nodes;
using ConsoleApp1.Tokenizer;
using ConsoleApp1.Parser_Utilities;

namespace Project3.Parser
{
    public static class MathExpressionEvaluator
    {
        private static readonly ITokenizer Tokenizer = new ExpressionTokenizer();
        private static readonly IParser Parser = new ExpressionParser();
        private static readonly INodeEvaluator NodeEvaluator = new NodeEvaluator();
        private static readonly IExpressionEvaluator Evaluator = new ExpressionEvaluator(Tokenizer, Parser, NodeEvaluator);

        public static bool TryEvaluate(string input, out double result)
        {
            try
            {
                result = Evaluator.Evaluate(input);
                return true;
            }
            catch
            {
                result = 0;
                return false;
            }
        }
    }
}
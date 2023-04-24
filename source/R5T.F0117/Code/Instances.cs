using System;


namespace R5T.F0117
{
    public static class Instances
    {
        public static IGitOperator GitOperator => F0117.GitOperator.Instance;
        public static IStringOperator StringOperator => F0117.StringOperator.Instance;
    }
}
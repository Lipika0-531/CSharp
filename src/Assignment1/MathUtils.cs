namespace Assignment1
{
    /// <summary>
    /// MathUtils Class
    /// </summary>
    public class MathUtils
    {
        /// <summary>
        /// Add function will perform addition operation
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns>it returns x + y</returns>
        public double Add(double x, double y)
        {
            return (long)x + y;
        }
        /// <summary>
        /// Subtraction method would subtract two values 
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns>subtract</returns>
        public double Subtract(double x, double y)
        {
            return (long)x - y;
        }
        /// <summary>
        /// Multiply method would multiply two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns>it returns multiplication of two values</returns>
        public double Multiply(double x, double y)
        {
            return x * y;
        }
        /// <summary>
        /// Divide method will divide the two values
        /// </summary>
        /// <param name="x">x denotes variable x</param>
        /// <param name="y">y denotes variable y</param>
        /// <returns>it returns division of two values</returns>
        public double Divide(double x, double y)
        {
            if ( y == 0)
            {
                throw new DivideByZeroException();
            }
            return x / y;
        }
    }
}
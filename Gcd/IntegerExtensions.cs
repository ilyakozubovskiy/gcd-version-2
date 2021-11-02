using System;
using System.Diagnostics;
using System.Linq;

namespace Gcd
{
    /// <summary>
    /// Provide methods with integers.
    /// </summary>
    public static class IntegerExtensions
    {
        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GcdByEuclidean(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            return b == 0 ? a : GcdByEuclidean(b, a % b);
        }

        public static int GcdByStein(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            if (a == b || b == 0)
            {
                return a;
            }

            if (a == 0)
            {
                return b;
            }

            if ((a & 1) == 0)
            {
                if ((b & 1) == 1)
                {
                    return GcdByStein(a >> 1, b);
                }
                else
                {
                    return GcdByStein(a >> 1, b >> 1) << 1;
                }
            }

            if ((b & 1) == 0)
            {
                return GcdByStein(a, b >> 1);
            }

            if (a > b)
            {
                return GcdByStein((a - b) >> 1, b);
            }

            return GcdByStein((b - a) >> 1, a);
        }

        public static int GetGcdByEuclidean(int a, int b)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            return GcdByEuclidean(a, b);
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, int c)
        {
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            return GcdByEuclidean(GcdByEuclidean(a, b), c);
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(int a, int b, params int[] other)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && other.Count(c => c == 0) == other.Length)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }
            
            int gcd = GcdByEuclidean(a, b);

            for (int i = 0; i < other.Length; i++)
            {
                gcd = GcdByEuclidean(gcd, other[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Calculates GCD of two integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            return GcdByStein(a, b);
        }

        /// <summary>
        /// Calculates GCD of three integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, int c)
        {
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            return GcdByStein(GcdByStein(a, b), c);
        }

        /// <summary>
        /// Calculates the GCD of integers [-int.MaxValue;int.MaxValue] by the Stein algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(int a, int b, params int[] other)
        {
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && other.Count(c => c == 0) == other.Length)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int gcd = GcdByStein(a, b);

            for (int i = 0; i < other.Length; i++)
            {
                gcd = GcdByStein(gcd, other[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b)
        {
            var timer = new Stopwatch();
            timer.Start();
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }
           
            int res = GcdByEuclidean(a, b);
            timer.Stop();
            elapsedTicks = timer.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, int c)
        {
            var timer = new Stopwatch();
            timer.Start();
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int res = GcdByEuclidean(GcdByEuclidean(a, b), c);
            timer.Stop();
            elapsedTicks = timer.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Euclidean algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByEuclidean(out long elapsedTicks, int a, int b, params int[] other)
        {
            var timer = new Stopwatch();
            timer.Start();
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && other.Count(c => c == 0) == other.Length)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int gcd = GcdByEuclidean(a, b);

            for (int i = 0; i < other.Length; i++)
            {
                gcd = GcdByEuclidean(gcd, other[i]);
            }

            timer.Stop();
            elapsedTicks = timer.ElapsedTicks;
            return gcd;
        }

        /// <summary>
        /// Calculates GCD of two integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or two numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b)
        {
            var timer = new Stopwatch();
            timer.Start();
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int res = GcdByStein(a, b);
            timer.Stop();
            elapsedTicks = timer.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Calculates GCD of three integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="c">Third integer.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, int c)
        {
            var timer = new Stopwatch();
            timer.Start();
            if (a == int.MinValue || b == int.MinValue || c == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && c == 0)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int res = GcdByStein(GcdByStein(a, b), c);
            timer.Stop();
            elapsedTicks = timer.ElapsedTicks;
            return res;
        }

        /// <summary>
        /// Calculates the GCD of integers from [-int.MaxValue;int.MaxValue] by the Stein algorithm with elapsed time.
        /// </summary>
        /// <param name="elapsedTicks">Method execution time in Ticks.</param>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <param name="other">Other integers.</param>
        /// <returns>The GCD value.</returns>
        /// <exception cref="ArgumentException">Thrown when all numbers are 0 at the same time.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when one or more numbers are int.MinValue.</exception>
        public static int GetGcdByStein(out long elapsedTicks, int a, int b, params int[] other)
        {
            var timer = new Stopwatch();
            timer.Start();
            if (a == int.MinValue || b == int.MinValue)
            {
                throw new ArgumentOutOfRangeException($"Number cannot be {int.MinValue}.");
            }

            if (a == 0 && b == 0 && other.Count(c => c == 0) == other.Length)
            {
                throw new ArgumentException("All numbers cannot be 0 at the same time.");
            }

            int gcd = GcdByStein(a, b);

            for (int i = 0; i < other.Length; i++)
            {
                gcd = GcdByStein(gcd, other[i]);
            }

            timer.Stop();
            elapsedTicks = timer.ElapsedTicks;
            return gcd;
        }
    }
}

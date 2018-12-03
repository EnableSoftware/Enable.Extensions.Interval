using System;

namespace Enable.Extensions.Interval
{
    /// <summary>
    /// An ordered pair of values, representing an interval.
    /// </summary>
    /// <param name="lowerBound">
    /// The inclusive lower bound of the interval.
    /// </param>
    /// <param name="upperBound">
    /// The inclusive upper bound of the interval.
    /// </param>
    /// <typeparam name="T">
    /// Type of the upper and lower bounds of the interval.
    /// </typeparam>
    /// <exception cref="ArgumentOutOfRangeException">
    /// <paramref name="lowerBound"/> is greater than
    /// <paramref name="upperBound"/>.
    /// </exception>
    public struct Interval<T> : IEquatable<Interval<T>>
        where T : struct, IComparable
    {
        public Interval(T lowerBound, T upperBound)
            : this()
        {
            var comparison = lowerBound.CompareTo(upperBound);

            if (comparison > 0)
            {
                throw new ArgumentOutOfRangeException(
                    nameof(upperBound),
                    "Invalid bounds specified: upper bound must be greater or equal to lower bound.");
            }

            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public T LowerBound { get; private set; }

        public T UpperBound { get; private set; }

        public static bool operator ==(Interval<T> first, Interval<T> second)
        {
            return first.LowerBound.Equals(second.LowerBound) &&
                first.UpperBound.Equals(second.UpperBound);
        }

        public static bool operator !=(Interval<T> first, Interval<T> second)
        {
            return !(first == second);
        }

        public override bool Equals(object obj)
        {
            if (obj is Interval<T>)
            {
                var other = (Interval<T>)obj;
                return LowerBound.Equals(other.LowerBound) && UpperBound.Equals(other.UpperBound);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return LowerBound.GetHashCode() ^ UpperBound.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{LowerBound}, {UpperBound}]";
        }

        /// <summary>
        /// Check if <paramref name="value"/> lies within the interval.
        /// </summary>
        /// <param name="value">
        /// The value to check against the interval.
        /// </param>
        /// <returns>
        /// <c>true</c> if <paramref name="value"/> lies within the interval;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool Contains(T value)
        {
            var lower = LowerBound.CompareTo(value) <= 0;
            var upper = UpperBound.CompareTo(value) >= 0;

            return lower && upper;
        }

        public bool Equals(Interval<T> other)
        {
            return this == other;
        }
    }
}

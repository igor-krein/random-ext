using System;
using System.Collections.Generic;

namespace RandomExtensions
{
    /// <summary>
    /// A collection of extensions methods for System.Random class.</summary>
    public static class RandomExtensions
    {
        /// <summary>
        /// Returns a random long integer that is within a specified range.
        /// </summary>
        /// <remarks>
        /// <paramref name="minValue"/> and <paramref name="maxValue"/> are
        /// indicating the boundaries of the range. The lower bound could be
        /// greater than the upper, in which case they are simply swapped.
        /// Also, the bounds could be omitted.
        /// </remarks>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="minValue">The inclusive lower bound of the random
        /// number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random
        /// number returned.</param>
        public static long NextLong(this Random random, long minValue = long.MinValue, long maxValue = long.MaxValue)
        {
            if (minValue > maxValue)
            {
                long swap = minValue;
                minValue = maxValue;
                maxValue = swap;
            }

            ulong range;
            if ((minValue < 0) == (maxValue < 0))   // both positive or both negative - result should be positive long
            {
                range = (ulong)(maxValue - minValue);
            }
            else // negative from and positive to - result should be positive ulong
            {
                range = (ulong)maxValue + (ulong)(-minValue);
            }

            double randomDoubleValue = random.NextDouble();
            long value = (long)(Math.Truncate(range * randomDoubleValue) + minValue);
            return value;
        }

        /// <summary>
        /// Returns a random DateTime value that is within a specified range.
        /// </summary>
        /// <remarks>
        /// <paramref name="minValue"/> and <paramref name="maxValue"/> are
        /// indicating the boundaries of the range. The lower bound could be
        /// greater than the upper, in which case they are simply swapped.
        /// Also, the bounds could be omitted.
        /// </remarks>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="minValue">The inclusive lower bound of the random
        /// number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random
        /// number returned.</param>
        public static DateTime NextDateTime(this Random random, DateTime? minValue = null, DateTime? maxValue = null)
        {
            long fromL = (minValue ?? DateTime.MinValue).Ticks;
            long toL = (maxValue ?? DateTime.MaxValue).Ticks;
            return new DateTime(random.NextLong(fromL, toL));
        }

        /// <summary>
        /// Returns a random date part of DateTime value that is within
        /// a specified range.
        /// </summary>
        /// <remarks>
        /// <paramref name="minValue"/> and <paramref name="maxValue"/> are
        /// indicating the boundaries of the range. The time parts of these
        /// parameters are ignored. The lower bound could be greater than
        /// the upper, in which case they are simply swapped. Also, the bounds
        /// could be omitted.
        /// </remarks>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="minValue">The inclusive lower bound of the random
        /// number returned.</param>
        /// <param name="maxValue">The exclusive upper bound of the random
        /// number returned.</param>
        public static DateTime NextDate(this Random random, DateTime? minValue = null, DateTime? maxValue = null)
        {
            DateTime fromD = (minValue ?? DateTime.MinValue).Date;
            DateTime toD = (maxValue ?? DateTime.MaxValue).Date;
            return random.NextDateTime(fromD, toD).Date;
        }

        /// <summary>
        /// "Throws" a virtual dice and returns the value of its uppermost
        /// side.
        /// </summary>
        /// <remarks>
        /// A virtual dice consists of <paramref name="sideCount"/> number of
        /// sides. The sides are numbered from 1 to <paramref name="sideCount"/>.
        /// </remarks>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="sideCount">The number of the dice sides. Could be omitted
        /// (default value is six).</param>
        /// <returns>
        /// Returns random integer from 1 to <paramref name="sideCount"/>
        /// or 0 if provided with not valid (non-positive) value.
        /// </returns>
        public static int ThrowDice(this Random random, int sideCount = 6)
        {
            if (sideCount <= 0) return 0;
            return random.Next(1, sideCount + 1);
        }

        /// <summary>
        /// "Throws" a virtual dice and returns true if the value of its
        /// uppermost side is greater than or equal the target value.
        /// </summary>
        /// <remarks>
        /// A virtual dice consists of <paramref name="sideCount"/> number of
        /// sides. The sides are numbered from 1 to <paramref name="sideCount"/>.
        /// </remarks>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="sideCount">The number of the dice sides.</param>
        /// <param name="minHit">The target minimum.</param>
        /// <returns>
        /// Returns true if the value of the uppermost side of the thrown dice
        /// is greater than or equal the <paramref name="minHit"/>. Otherwise
        /// returns false.
        /// </returns>
        /// <seealso cref="ThrowDice(Random, int)">
        /// ThrowDice method.
        /// </seealso>
        public static bool ThrowDiceToHit(this Random random, int sideCount, int minHit)
        {
            return (random.ThrowDice(sideCount) >= minHit);
        }

        /// <summary>
        /// "Throws" a virtual dart at the shooting target.
        /// </summary>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="circleCount">The number of target circles.
        /// Could be omitted (default value is ten).</param>
        /// <returns>
        /// Returns true if the bull's-eye (the innermost circle) is hitted.
        /// Otherwise returns false.
        /// </returns>
        /// <seealso cref="ThrowDiceToHit(Random, int, int)">
        /// ThrowDiceToHit method.
        /// </seealso>
        public static bool HitBullsEye(this Random random, int circleCount = 10)
        {
            return random.ThrowDiceToHit(circleCount, circleCount);
        }

        /// <summary>
        /// Returns a random element of the list.
        /// </summary>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="list">The list of some items.</param>
        /// <typeparam name="T">The element type of the list.</typeparam>
        /// <returns>
        /// Returns a random element of the <paramref name="list"/>
        /// or default value if the list is null or empty.
        /// </returns>
        public static T NextItem<T>(this Random random, IList<T> list)
        {
            if ((list?.Count ?? 0) == 0) return default(T);
            return list[random.ThrowDice(list.Count) - 1];
        }

        /// <summary>
        /// "Throws" a virtual dice and returns a random element of the list
        /// if the result is greater than or equal the target value.
        /// </summary>
        /// <remarks>
        /// A virtual dice consists of <paramref name="sideCount"/> number of
        /// sides. The sides are numbered from 1 to <paramref name="sideCount"/>.
        /// </remarks>
        /// <param name="random">The variable of Random class type.</param>
        /// <param name="list">The list of some items.</param>
        /// <typeparam name="T">The element type of the list.</typeparam>
        /// <param name="sideCount">The number of the dice sides.</param>
        /// <param name="minHit">The target minimum.</param>
        /// <param name="failureReturn">The optional value that is returned in
        /// case of failing to throw the target minimum.</param>
        /// <returns>
        /// Returns a random element of the <paramref name="list"/>
        /// if the value of the uppermost side of the thrown dice is greater
        /// than or equal the <paramref name="minHit"/>. Otherwise returns
        /// the <paramref name="failureReturn"/> (or default) value.
        /// </returns>
        /// <seealso cref="ThrowDiceToHit(Random, int, int)">
        /// ThrowDiceToHit method.
        /// </seealso>
        /// <seealso cref="NextItem{T}(Random, IList{T})">
        /// NextItem method.
        /// </seealso>
        public static T NextItemOrDefault<T>(this Random random, IList<T> list, int sideCount, int minHit, T failureReturn = default(T))
        {
            if (!random.ThrowDiceToHit(sideCount, minHit)) return failureReturn;
            return random.NextItem<T>(list);
        }
    }
}
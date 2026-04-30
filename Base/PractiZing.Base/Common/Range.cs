using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace PractiZing.Base.Common
{
    public class Range<TFrom, TTo> : RangeDateTypes
    {
        public Range(TFrom from, TTo to)
        {
            From = from;
            To = to;
        }

        public TFrom From { get; }

        public TTo To { get; }
        public override string ToString()
        {
            return $"{From} - {To}";
        }
    }

    public class Range<TEntity> : Range<TEntity, TEntity?>
        where TEntity : struct, IComparable, IComparable<TEntity>, IEquatable<TEntity>
    {
        public Range(TEntity from, TEntity? to) : base(from, to)
        {
            // Skip validation in case of Hospitalization since To date is not required.................
            if (DateTypes == "Hospitalization")
            {
                goto SkipToEnd;
            }
            //in case of Disability or Charge , validate only when to date and from date is known......
            else if (DateTypes == "Disability" || DateTypes == "Charge")
            {
                if (IsBothDateKnown)
                {
                    Contract.Requires<ArgumentException>(from.CompareTo(to) <= 0, $"Parameter {nameof(from)} <= {nameof(to)}.");
                }
            }
            else
            {
                //Contract.Requires<ArgumentException>(from.CompareTo(to) <= 0, $"Parameter {nameof(from)} <= {nameof(to)}.");
            }
            SkipToEnd:
            DateTypes = "";
            IsBothDateKnown = false;
        }

        public bool IsIn(TEntity period)
        {
            return period.CompareTo(From) >= 0 && period.CompareTo(To) <= -1;
        }

        public bool IsOut(TEntity period)
        {
            return !IsIn(period);
        }
    }

    public class RangeDateTypes
    {
        public static string DateTypes = "";
        public static bool IsBothDateKnown = false;
    }
}

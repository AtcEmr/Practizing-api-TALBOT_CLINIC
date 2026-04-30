using PractiZing.ClaimCreator.Base;
using PractiZing.DataAccess.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PractiZing.ClaimCreator.Base
{
    public interface IBuilder
    {

    }

    public interface ISegmentBuilder<TSegment> : IBuilder
    {
        TSegment Build(Claim claim, ClaimOptions claimOptions);
    }

    public class SegmentContainer<value> : Dictionary<Type, value>
    {
        public new void Add(value value)
        {
            base.Add(value.GetType(), value);
        }
    }

    public class SegmentBuilders
    {
        private SegmentContainer<object> _builders = new SegmentContainer<object>();

        public SegmentBuilders()
        {


        }

        public static void Add(List<IBuilder> builders)
        {
            foreach (var item in builders)
            {
                _default._builders.Add(item);
            }
        }

        public static TSegment Build<TBuilder, TSegment>(Claim claim, ClaimOptions claimOptions)
        {
            if (_default._builders.ContainsKey(typeof(TBuilder)))
            {
                var builder = (_default._builders[typeof(TBuilder)] as ISegmentBuilder<TSegment>);

                var segment = builder.Build(claim, claimOptions);
                return segment;
            }
            else
            {
                string messsage = "Builder not found - " + typeof(TBuilder).AssemblyQualifiedName + " - " + typeof(TBuilder).Name;
                Console.WriteLine(messsage);
                throw new Exception(messsage);
            }
        }

        private static SegmentBuilders _default;
        static SegmentBuilders()
        {
            _default = new SegmentBuilders();
        }


    }


}

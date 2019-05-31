using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mTaka.Data.Common
{
    public class AutoMapperCFG
    {
        public static TDestination SetObjectMapping<TSource, TDestination>(TSource source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper mapper = config.CreateMapper();
            var data = mapper.Map<TSource, TDestination>(source);
            return data;
        }

        public static List<TDestination> SetListMapping<TSource, TDestination>(List<TSource> source)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<TSource, TDestination>();
            });
            IMapper mapper = config.CreateMapper();

            List<TDestination> DestinationList = new List<TDestination>();
            foreach (var item in source)
            {
                var data = mapper.Map<TSource, TDestination>(item);
                DestinationList.Add(data);
            }
            return DestinationList;
        }
    }
}

﻿namespace SwiftSkool.MVC5.Infrastructure.Mapping
{
    using AutoMapper;

    public class AutoMapperInitializer
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(typeof(AutoMapperInitializer));
            });
        }
    }
}
﻿namespace MyMvcSample.Common.Domain
{
    public abstract class BaseEntity : IEntity
    {
        public int Id { get; set; }
    }
}
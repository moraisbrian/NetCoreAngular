using System;

namespace NetCoreAngular.Domain.Entidades
{
    public abstract class EntidadeBase
    {
        public EntidadeBase()
        {
            Id = Guid.NewGuid().ToString();
        }
        
        public string Id { get; set; }
    }
}
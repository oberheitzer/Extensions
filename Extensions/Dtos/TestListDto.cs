using Extensions.Entities;
using System;

namespace Extensions.Dtos
{
    public class TestListDto
    {
        public string Name { get; set; }

        public static Func<EntityOne, EntityTwo, TestListDto> Selector = (entityOne, entityTwo) => new TestListDto
        {
            
        };
    }
}

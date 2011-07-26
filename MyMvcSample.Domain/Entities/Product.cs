using System;
using MyMvcSample.Common.Domain;

namespace MyMvcSample.Domain.Entities
{
    public class Product : BaseEntity
    {
        private static int _privateIntVar;
        private int _anotherPrivateIntVar;

        public string Name { get; protected set; }

        public decimal Price { get; set; }

        public Order Order { get; set; }

        public int AnotherPrivateIntVar
        {
            get { return _anotherPrivateIntVar; }
            set { _anotherPrivateIntVar = value; }
        }

        public void NameAsMethod()
        {
            
        }

        private bool PrivateName { get; set; }
    }
}

using System;

namespace IShop.BussinesLayer.Common.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message) { }
        public EntityNotFoundException(string message, Exception exception)
            : base(message, exception) { }
    }
}

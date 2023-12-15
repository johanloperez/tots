namespace Challenge.presentation.layer.api.CustomExceptions
{
    using System;

    public class CustomException : Exception
    {
        public CustomException(string mensaje) : base(mensaje)
        {
        }
        public override string ToString()
        {
            return Message;
        }
    }
}

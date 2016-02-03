using System;
using System.Runtime.Serialization;

namespace SQADemicApp
{
    [Serializable]
    internal class GameLostException : Exception
    {
        public GameLostException() : base("Game Over")
        {
        }

        public GameLostException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected GameLostException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
using System;
using System.Runtime.Serialization;

namespace SQADemicApp
{
    [Serializable]
    public class GameLostException : Exception
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
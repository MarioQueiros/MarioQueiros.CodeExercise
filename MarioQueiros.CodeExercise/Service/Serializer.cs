using System;
using Newtonsoft.Json;

namespace MarioQueiros.CodeExercise.Service
{
    public class Serializer : ISerializer
    {
        public T Deserialize<T>( string data )
        {
            if ( string.IsNullOrEmpty( data ) )
                throw new ArgumentNullException( "Data is null" );

            return JsonConvert.DeserializeObject<T>( data );
        }
    }
}
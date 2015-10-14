namespace MarioQueiros.CodeExercise.Service
{
    public interface ISerializer
    {
        T Deserialize<T>( string data );
    }
}
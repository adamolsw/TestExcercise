using NetExercise.Models;

namespace NetExercise.Repository
{
    public interface IGetModel
    {
        Text GetModel(string inputText);
    }
}
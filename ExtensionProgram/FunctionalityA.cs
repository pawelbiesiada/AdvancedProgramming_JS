using Exercises;

namespace ExtensionProgram
{
    public class FunctionalityA : IPlugin
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }

        public string GetText()
        {
            return $"Hi From {nameof(FunctionalityA)} program.";
        }
    }
}

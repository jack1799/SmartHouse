namespace ConsoleApplication9
{
    public interface IParamModule
    {
        int Max { get; }
        int Min { get; }

        void Minus();
        void Plus();
        void Set(int Argument);
    }
}
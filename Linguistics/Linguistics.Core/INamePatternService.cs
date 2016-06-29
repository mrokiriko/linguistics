namespace Linguistics.Core
{
    public interface INamePatternService
    {
        string GetPattern(string name);
        //bool IsNameMatched(string pattern, string nameCaseValue);
    }
}
namespace Linguistics.Core
{
    public interface INamePatternService
    {
        string GetPattern(string name);

        /// <summary>
        /// Check whether name pattern matches name; name may be cased.
        /// </summary>
        /// <param name="pattern">Name pattern. It should end with asterik.</param>
        /// <param name="nameCaseValue">Name value. Name may be cased.</param>
        /// <returns>true if name is matched by pattern, otherwise false.</returns>
        /// <exception cref="System.ArgumentNullException">Occurs if pattern or nameCaseValue is null</exception>
        /// <exception cref="System.ArgumentException">Occurs if pattern is empty or does not end with asterik.</exception>
        bool IsNameMatched(string pattern, string nameCaseValue);
    }
}
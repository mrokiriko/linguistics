using System.Collections.Generic;

namespace Linguistics.Core
{
	/// <summary>
	///     Represents service to decline russian names.
	/// </summary>
	public interface IDeclensionService
	{
		/// <summary>
		///     Declines first name and returns its cases.
		/// </summary>
		/// <param name="firstName">First Name</param>
		/// <returns>Cases of source first name</returns>
		IDictionary<Case, string> DeclineFirstName(string firstName);
	}
}
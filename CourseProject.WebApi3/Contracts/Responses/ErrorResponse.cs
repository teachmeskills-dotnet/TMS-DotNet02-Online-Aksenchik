using System.Collections.Generic;

namespace CourseProject.WebApi3.Contracts.Responses
{
    /// <summary>
    /// Error response.
    /// </summary>
    public class ErrorResponse<T>
    {
        /// <summary>
        /// Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Errors.
        /// </summary>
        public IEnumerable<T> Errors { get; set; }
    }
}

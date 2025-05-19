using FluentValidation.Results;
using System.Linq;

namespace Ambev.DeveloperEvaluation.Common.Validation
{
    public static class ValidationExtensions
    {
        public static List<ValidationErrorDetail> ToErrorDetails(this IEnumerable<ValidationFailure> failures)
        {
            return failures.Select(e => new ValidationErrorDetail
            {
                Detail = e.ErrorMessage,
                Error = e.ErrorCode
            }).ToList();
        }
    }
}
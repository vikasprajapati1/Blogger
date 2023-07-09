using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class OperationResult
    {
        public OperationStatus Status { get; set; }
        public string Message { get; set; }

        /// <summary>
        /// Holds the data that the function returns
        /// </summary>
        public object? Data { get; set; }
        public static OperationStatus Success { get; set; }

        public OperationResult(OperationStatus status, string message)
        {
            Status = status;
            Message = message;
        }
        public OperationResult(OperationStatus status, string message, object data)
        {
            Status = status;
            Message = message;
            Data = data;
        }

    }

    public enum OperationStatus
    {
        Success,
        Failed,
        NotAuthorized,
        NotAuthenticated,
        SubsriptionFailed,
        ErrorReportingManager,
        InCompleteData,
        ServerError,
        NotLogined,
        Exhausted,
        EnrollNumberUnique,
        EmailUnique
    }
}

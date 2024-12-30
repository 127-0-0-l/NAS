using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NAS.Utils.Helpers
{
    public static class LoggingHelper
    {
        public static void Debug(string message)
        {
            StackFrame stackFrame = new StackFrame(1);
            var type = stackFrame.GetMethod().DeclaringType;
            var logger = LogManager.GetLogger(type);
            logger.Debug(message);
        }

        public static void Info(string message)
        {
            StackFrame stackFrame = new StackFrame(1);
            var type = stackFrame.GetMethod().DeclaringType;
            Info(message, type);
        }

        public static void Info(string message, Type type)
        {
            var logger = LogManager.GetLogger(type);
            logger.Info(message);
        }

        public static void Warn(string message)
        {
            StackFrame stackFrame = new StackFrame(1);
            var type = stackFrame.GetMethod().DeclaringType;
            var logger = LogManager.GetLogger(type);
            logger.Warn(message);
        }

        public static void Error(string message, Exception exception = null)
        {
            StackFrame stackFrame = new StackFrame(1);
            var type = stackFrame.GetMethod().DeclaringType;
            Error(message, exception, type);
        }

        public static void Error(string message, Exception exception, Type type)
        {
            var logger = LogManager.GetLogger(type);

            if (exception != null)
                logger.Error(message, exception);
            else
                logger.Error(message);
        }

        public static void LogMethodEntering(Type type, string methodName, IEnumerable<string> parameterNames, IEnumerable<object> parameterValues)
        {
            Info($"Entering {methodName}({MethodParamsToString(parameterNames, parameterValues)})", type);
        }

        public static void LogMethodLeaving(Type type, string methodName)
        {
            Info($"Leaving {methodName}(...)", type);
        }

        public static void LogMethodException(Type type, Exception exception)
        {
            Error($"Exception in method: {exception.Message}", exception, type);
        }

        private static string MethodParamsToString(IEnumerable<string> parameterNames, IEnumerable<object> parameterValues)
        {
            List<string> result = new List<string>();

            try
            {
                foreach (var keyValue in parameterNames.Zip(parameterValues, (k, v) => new KeyValuePair<string, object>(k, v)))
                {
                    string value = keyValue.Value == null ? "null" : keyValue.Value.ToString();
                    result.Add($"{keyValue.Key}={value}");
                }
            }
            catch (Exception ex)
            {
                Error("Error during dict to string transformation.", ex);
            }

            return string.Join(", ", result);
        }
    }
}

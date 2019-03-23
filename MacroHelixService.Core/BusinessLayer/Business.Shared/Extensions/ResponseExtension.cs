using Business.Shared.Messages;
using Business.Shared.ResponseModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Shared.Extensions
{
    public static class ResponseExtension
    {
        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="response"></param>
        /// <param name="ex"></param>
        public static void SetError(this IResponse response, Exception ex)
        {
            response.DidError = true;
            if (response.Message == null) response.Message = ResponseMessageDisplay.Error;

            var cast = ex as Exception;

            if (cast == null)
            {
                response.ErrorMessage = "There was an internal error, please contact to technical support.";
            }
            else
            {
                response.ErrorMessage = ex.Message;
            }
        }
    }
}

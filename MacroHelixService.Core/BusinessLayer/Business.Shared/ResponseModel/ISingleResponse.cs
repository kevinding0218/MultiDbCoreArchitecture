using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Shared.ResponseModel
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }

    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : new()
    {
        public SingleResponse()
        {
            Model = new TModel();
        }

        public string Message { get; set; }

        public bool DidError { get; set; } = false;

        public string ErrorMessage { get; set; } = string.Empty;

        public TModel Model { get; set; }
    }
}

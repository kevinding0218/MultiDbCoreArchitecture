using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Shared.ResponseModel
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }

    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public string Message { get; set; }

        public bool DidError { get; set; } = false;

        public string ErrorMessage { get; set; } = string.Empty;

        public IEnumerable<TModel> Model { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.Models {
    public class ServiceResult<T> {

        public ServiceResult(T value) {
            Value = value;
            IsSuccess = true;
        }
        public ServiceResult(string error) {
            Error = error;
            IsSuccess = false;
        }
        public T? Value { get; set; }
        public string Error { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NLayer.Core.DTOs
{
    public class NoContentDTO
    {

        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }

        public static NoContentDTO Success(int statusCode)
        {
            return new NoContentDTO { StatusCode = statusCode };

        }

        public static NoContentDTO Fail(int statusCode, List<string> errors)
        {
            return new NoContentDTO { StatusCode = statusCode, Errors = errors };
        }

        public static NoContentDTO Fail(int statusCode, string error)
        {
            return new NoContentDTO { StatusCode = statusCode, Errors = new List<string> { error } };
        }
    }
}

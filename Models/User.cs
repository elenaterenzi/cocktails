using System.ComponentModel.DataAnnotations;

namespace cocktails.Models {
    public class User {
        public System.Guid Id;

        [DataType(DataType.EmailAddress)]
        public string UserName;

    }
}
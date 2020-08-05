using Microsoft.OpenApi.Models;

namespace WebApiProject
{
    public static class Constant
    {
        public const string ValidData = "Item Data Saved Successfully";

        public const string InValidData = "Item Data Not Saved in the Database. Exception thrown:";

        public const string NotFound = "Item not found. Please try with other Input";

        public const string MinLengthWarning = "Please enter 3 or more characters for Name Input";

        public const string BadRequest = "Item is null.";
    }
}
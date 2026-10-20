using System;

namespace Library
{
    /// <summary>
    /// Class definition for User
    /// </summary>
    public class User
    {
        private Guid UserId { get; set; }

        private string UserName { get; set; }

        private Book BookBorrowed { get; set; }

        private string GetUserDetails()
        {
            return $"User Name: {this.UserName}, Book Borrowed: {this.BookBorrowed.BookName}";
        }
    }
}

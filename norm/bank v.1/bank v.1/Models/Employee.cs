﻿
namespace Bank.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int postId { get; set; }

        public Post Post { get; set; }

  
    }
}

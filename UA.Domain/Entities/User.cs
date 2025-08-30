﻿using System;
using System.ComponentModel.DataAnnotations;

namespace UA.Domain.Entities
{
    public  class User
    {        
        public Guid Id { get; set; } = Guid.NewGuid();
        public required string Name { get; set; }
        public required string Email { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}

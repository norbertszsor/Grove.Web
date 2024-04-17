﻿using System.ComponentModel.DataAnnotations;

namespace Grove.Transfer.Commands
{
    public class CreateProductCommand : ICommand<Guid>
    {
        [Required]
        [MaxLength(128)]
        public required string Name { get; set; }

        [MaxLength(512)]
        public string? Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Guid CategoryId { get; set; }

        [Required]
        public Region Region { get; set; }
    }
}
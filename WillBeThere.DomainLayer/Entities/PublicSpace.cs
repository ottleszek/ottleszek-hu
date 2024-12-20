﻿using Shared.DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;

namespace WillBeThere.DomainLayer.Entites
{
    public class PublicSpace : IDbEntity<PublicSpace>
    {
        public PublicSpace() 
        {
            Id=Guid.Empty;
            Name = string.Empty;
        }
        public PublicSpace(Guid id, string nameOfPublicSpace) 
        {
            Id=id;
            Name = nameOfPublicSpace;
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; } = string.Empty;
        public virtual List<Address>? Addresses { get; set; }

    }
}

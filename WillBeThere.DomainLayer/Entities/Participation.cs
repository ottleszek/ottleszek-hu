﻿using Shared.DomainLayer.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WillBeThere.DomainLayer.Entites
{
    public class Participation : IDbEntity<Participation>
    {
        public Participation()
        {
            Id = Guid.Empty;
            ParticipantId =Guid.Empty;
            OrganizationProgramId = Guid.Empty;
            Evaluation = -1;
        }
        public Participation(Guid id, Guid registeredUserID, Guid orgranizationProgramId, int evaluation) 
        {
            Id=id;
            ParticipantId = registeredUserID;
            OrganizationProgramId = orgranizationProgramId;
            Evaluation = evaluation;
        }
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid ParticipantId { get; set; }
        [Required]
        public Guid OrganizationProgramId { get; set; }
        public int Evaluation {  get; set; }
        [ForeignKey(nameof(ParticipantId))]
        public virtual RegisteredUser? Participant { get; set; }
        [ForeignKey(nameof(OrganizationProgramId))]
        public virtual OrganizationProgram? OrganizationProgram { get; set; }
        
    }
}

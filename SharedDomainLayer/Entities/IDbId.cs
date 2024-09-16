namespace SharedDomainLayer.Entities
{
    internal interface IGuid
    {
        public Guid Id { get; set; }
        public Guid EmptyId => Guid.Empty;
        public bool Exsist => Id != Guid.Empty;
    }
}

namespace WillBeThere.DomainLayer.Entities.ResultEntites
{
    internal interface IGuid
    {
        public Guid Id { get; set; }
        public Guid EmptyId => Guid.Empty;
        public bool Exsist => Id != Guid.Empty;
    }
}

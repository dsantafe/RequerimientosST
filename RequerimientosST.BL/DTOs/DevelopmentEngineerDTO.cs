namespace RequerimientosST.BL.DTOs
{
    public partial class DevelopmentEngineerDTO
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }
        public string FullName
        {
            get { return string.Format("{0} {1}", LastName, FirstMidName); }
        }
    }
}

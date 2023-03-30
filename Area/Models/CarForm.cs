namespace Area.Models
{
    public class CarForm
    {
        //public CarForm()
        //{
        //    SelectedCheckboxes = new List<string>()
        //    {
        //        "10%off First service visit",
        //        "10%off Waterwash",
        //        "Free AC Inspection"
        //    };
        //}
        public int Id { get; set; }
        public string CarModel { get; set; }
        public string CarNumber { get; set; }
        public string ContactNumber { get; set; }
        public string TypeOfService { get; set; }
        public string[] SelectedCheckboxes { get; set; }
        public string SelectState { get; set; }
        public string SelectCity { get; set; }
        //public IList<Selection>? Selections { get; set; }


    }
}

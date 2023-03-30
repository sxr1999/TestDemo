namespace MVCwithEF.Models
{
    public class CarForm
    {
        public int Id { get; set; }

        public List<Selection> SelectedCheckboxes { get; set; }
    }
}

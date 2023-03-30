using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace TestDemo.Models
{
    [Serializable]
    public class QueryInfoModel
    {
        [Display(Name = "Work Number")]
        public string WorkNum { get; set; }
    }
}

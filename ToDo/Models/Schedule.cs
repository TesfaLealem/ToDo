using System.ComponentModel.DataAnnotations;

namespace ToDo.Models
{
    public class Schedule
    {

        public int ID { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateOnly DateCreated { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

       
        public DateOnly Date { get; set; }
        public string Status { get; set; }
    }
}

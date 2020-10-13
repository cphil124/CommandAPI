namespace Commander.Models
{
    // DTO - Data Transfer Object : Object intended to present database data to API calling User while obscuring the underlying data model. 
    //                              Has data analagous to database tables' data, but restructured so as not to expose the underlying database
    //                              data model. Can contain a subset of a table's columns, or columns from a combination of tables, or an modification 
    //                              of those columns. 
    public class CommandReadDto
    {
        public int Id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; }

    }
}
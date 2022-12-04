using System.ComponentModel.DataAnnotations;

namespace tp3sqlite.Models
{
public class Person
{ public Int64 id{ get; set;}
    public string? firstName{ get; set;}
    public string? lastname{ get; set;}
    public string? email{ get; set;}
    //[DataType(DataType.Date)]
    //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public string? datebirth { get; set; }
    public string? image{ get; set;}
    public string? country{ get; set;}

}}
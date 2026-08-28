using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WBTask.Models;

[PrimaryKey(nameof(PackageId),nameof(Id))]
public class Process
{

    public long PackageId {get;set;}
    public int Id { get; set; }
    public string? Name { get; set; }
    public long InitiatorUserId { get; set; }
    public string CountryCode {get; set;}
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime StartDate {get;set;}
    public string Status {get; set;}


}
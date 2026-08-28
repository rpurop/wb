using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WBTask.Models;

public class Package
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long Id { get; set; }
    public string PackageContent {get; set;}
    public int LastVersion {get;set;}
    public string? Status {get;set;}
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt {get;set;}

}

[PrimaryKey(nameof(PackageId),nameof(Id))]
public class PackageVersion
{
    
    public long PackageId { get; set; }
    public int Id {get; set;}
    public string PackageContent {get;set;}
    public long ProcessId {get; set;}
    public long StepId {get;set;}
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime CreatedAt {get;set;}
}


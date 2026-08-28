using Microsoft.EntityFrameworkCore;

namespace WBTask.Models;

[PrimaryKey(nameof(PackageId),nameof(ProcessId),nameof(Id))]
public class Step
{
    public long PackageId {get;set;}
    public int ProcessId {get;set;}
    public int Id { get; set; }
    public int ProcessSeq  { get; set; }
    public DateTime StepDate {get;set;}
    public long PackageVersionId {get;set;}
    public long TaskId {get;set;}
    public string? Approval {get;set;}


}
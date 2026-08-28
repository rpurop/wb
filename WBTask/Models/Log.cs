namespace WBTask.Models;

public class Log
{
    public long Id { get; set; }
    public DateTime logDate {get; set;}

    public long ProcessId {get;set;}
    public long StepId {get;set;}
    public long UserId {get;set;}

    public long PackageId {get;set;}
    public long PackageVersionId {get;set;}
    public string? EventDescription {get;set;}


}
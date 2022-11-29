namespace Elearn.Shared.Models;

public class Question
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public string Url { get; set; }
    public DateTime CreationDate { get; set; }

    public long CorrectAnswerId { get; set; }
    
    public User Author { get; set; }

    public Question(long id, string title, string body, string url, DateTime creationDate, long correctAnswerId, User author)
    {
        Id = id;
        Title = title;
        Body = body;
        Url = url;
        CreationDate = creationDate;
        CorrectAnswerId = correctAnswerId;
        Author = author;
    }

    public Question(string title, string body, string url, DateTime creationDate, long correctAnswerId, User author)
    {
        Title = title;
        Body = body;
        Url = url;
        CreationDate = creationDate;
        CorrectAnswerId = correctAnswerId;
        Author = author;
    }

    public Question()
    {
    }
    
    public override string ToString()
    {
        return $"Id: {Id}, Title: {Title}, Body: {Body}, Url: {Url}, CreationDate: {CreationDate}, CorrectAnswerId: {CorrectAnswerId}, Author: {Author}";
    }
}
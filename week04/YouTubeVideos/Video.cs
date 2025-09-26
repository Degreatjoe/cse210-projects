using System;
using System.Text;

public class Video
{
    private string _title;
    private string _author;
    private int _length;

    private List<Comment> _comments = new List<Comment>();

    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public int GetCommentCount()
    {
        int count = _comments.Count;
        return count;
    }

    public string GetDisplayString()
    {
        var sb = new StringBuilder();
        sb.AppendLine("--------------------");
        sb.AppendLine(_title.ToUpper());
        sb.AppendLine($"Author: {_author}\t length: {_length}s");
        sb.AppendLine("");
        sb.AppendLine($"Comments ({GetCommentCount()})");
        foreach (Comment comment in _comments)
        {
            sb.AppendLine(comment.GetDisplayString()); // assuming Comment has GetDisplayString
        }
        sb.AppendLine("--------------------\n");
        return sb.ToString();
    }

}
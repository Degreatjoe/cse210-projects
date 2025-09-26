using System;
using System.ComponentModel.DataAnnotations;

public class Comment
{
    private string _userName;
    private string _text;

    public Comment(string user, string comment)
    {
        _userName = user;
        _text = comment;
    }

    public string GetDisplayString()
    {
        return $"{_userName}:\n\t{_text}\n";
    }
}
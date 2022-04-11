using Godot;
using System;

public class ArtistCredit : Node2D
{
    File fs = new File();
    public override void _Ready()
    {
        base._Ready();
        Visible = false;
        if (fs.FileExists("user://credits.txt")){
            fs.Open("user://credits.txt", File.ModeFlags.Read);
            if (fs.GetAsText() == "1"){
                GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
            }
        } else {
            Visible = true;
        }
    }
    public void ContinueEvent()
    {
        fs.Open("user://credits.txt", File.ModeFlags.Write);
        fs.StoreString("1");
        fs.Close();
        GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
        
    }

    public void TextureLinkClicked()
    {
        OS.ShellOpen("https://tanja012.com/index.php/my-creations/t-craft-realistic-64x64");
    }
}

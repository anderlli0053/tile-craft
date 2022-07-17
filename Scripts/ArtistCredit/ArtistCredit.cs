using Godot;
using TileCraftData;
using TileCraftUtils;
using TileCraftConstants;

namespace TileCraftMain;

public class ArtistCredit : Control
{
    ResizeHandler _resizeHandler = new ResizeHandler();
    FileSystem _fs = new FileSystem();

    GameSettings settings;
    public override void _Ready()
    {
        base._Ready();
        settings = _fs.ReadJSON<GameSettings>("user://settings.json");
        if (settings.SeenAd)
        {
            GetTree().ChangeScene("res://Scenes/MainMenu.tscn");
        }
        else
        {
            Visible = true;
        }

    }
    public void ContinueEvent()
    {
        settings.SeenAd = true;
        _fs.WriteJSON("user://settings.json", settings);
        _fs.Close();
        GetTree().ChangeScene("res://Scenes/MainMenu.tscn");

    }

    public void TextureLinkClicked()
    {
        OS.ShellOpen("https://tanja012.com/index.php/my-creations/t-craft-realistic-64x64");
    }

    public void OnResize()
    {
        _resizeHandler.Contain(this, new Vector2(Constants.WindowWidth, Constants.WindowHeight));
    }
    public override void _Process(float delta)
    {
        base._Process(delta);
        OnResize();
    }
    ~ArtistCredit(){
        GD.Print("I got destructed");
    }
}

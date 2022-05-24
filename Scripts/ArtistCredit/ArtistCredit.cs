using Godot;
using TileCraftData;
using TileCraftUtils;
using TileCraftConstants;
namespace TileCraftMain
{
    public class ArtistCredit : Control
    {
        ResizeHandler _resizeHandler = new ResizeHandler();
        FileSystem _fs = new FileSystem();
        public override void _Ready()
        {
            base._Ready();
            if (_fs.ReadJSON<GameSettings>("user://settings.json").SeenAd){
                GetTree().CurrentScene = GetNode<MainMenu>("/root/MainMenu");
            } else {
                Visible = true;
            }
        }
        public void ContinueEvent()
        {
            
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
    }
}

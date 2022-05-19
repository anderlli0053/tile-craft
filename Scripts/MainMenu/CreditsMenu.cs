using Godot;

namespace TileCraftMain
{
    public class CreditsMenu : ColorRect
    {
        MainMenu mainMenu;
        public override void _Ready()
        {
            base._Ready();
            mainMenu = GetNode<MainMenu>("/root/MainMenu");
        }
        public void ToggleEvent()
        {
            mainMenu.ToggleCredits();
        }
    }
}

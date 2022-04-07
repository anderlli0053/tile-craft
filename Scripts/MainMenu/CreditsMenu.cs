using Godot;

public class CreditsMenu : ColorRect
{
    public void ToggleVisible(){
        MainMenu mainMenu = GetNode<MainMenu>("/root/MainMenu");
        mainMenu.SetCreditsPage(!mainMenu.creditsPageOpen);
    }
}
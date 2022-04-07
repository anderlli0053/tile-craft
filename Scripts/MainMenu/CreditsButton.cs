using Godot;

public class CreditsButton : Button
{
    public void OnClick()
    {
        MainMenu mainMenu = GetNode<MainMenu>("/root/MainMenu");
        
        if (!mainMenu.creditsPageOpen)
        {
            mainMenu.SetCreditsPage(true);
        }
    }
}
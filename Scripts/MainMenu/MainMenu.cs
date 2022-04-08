using Godot;
using Godot.Collections;

public class MainMenu : Node2D {
    public bool creditsPageOpen = false;
    
    public void ToggleCredits()
    {
        creditsPageOpen = !creditsPageOpen;
        GetNode<Button>("PlayButton").Disabled = creditsPageOpen;
        GetNode<Button>("CreditsButton").Disabled = creditsPageOpen;
        GetNode<Button>("QuitButton").Disabled = creditsPageOpen;
        GetNode<ColorRect>("Credits").Visible = creditsPageOpen;
    }
}
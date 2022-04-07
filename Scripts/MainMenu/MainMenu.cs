using Godot;
using Godot.Collections;
using System.Linq;

public class MainMenu : Node2D {
    public bool creditsPageOpen = false;
    
    public void SetCreditsPage(bool state)
    {
        GetNode<Button>("PlayButton").Disabled = state;
        GetNode<Button>("CreditsButton").Disabled = state;
        GetNode<Button>("QuitButton").Disabled = state;

        creditsPageOpen = state;
        GetNode<CreditsMenu>("Credits").Visible = state;
    }
    public override void _Ready()
    {
        base._Ready();
    }
}
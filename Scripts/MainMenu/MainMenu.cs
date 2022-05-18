using Godot;
using Godot.Collections;
using TileCraftUtils;
using GameConstants;

public class MainMenu : Control
{
    ResizeHandler resizeHandler = new ResizeHandler();
    bool creditsPageOpen = false;
    public Button PlayButton;
    public Button CreditsButton;
    public Button QuitButton;
    public ColorRect Credits;
    
    public override void _Ready()
    {
        base._Ready();
        PlayButton = GetNode<Button>("PlayButton");
        CreditsButton = GetNode<Button>("CreditsButton");
        QuitButton = GetNode<Button>("QuitButton");
        Credits = GetNode<ColorRect>("Credits");
    }
    public void ToggleCredits()
    {
        creditsPageOpen = !creditsPageOpen;
        PlayButton.Disabled = creditsPageOpen;
        CreditsButton.Disabled = creditsPageOpen;
        QuitButton.Disabled = creditsPageOpen;
        Credits.Visible = creditsPageOpen;
    }

    public void PlayEvent()
    {
        GetTree().ChangeScene("res://Scenes/GameScene.tscn");
    }

    public void QuitEvent()
    {
        GetTree().Notification(MainLoop.NotificationWmQuitRequest);
    }
    public void OnResize()
    {
        resizeHandler.Contain(this, new Vector2(Constants.WindowWidth, Constants.WindowHeight));
    }
    public override void _Process(float delta)
    {
        base._Process(delta);
        OnResize();
    }
}


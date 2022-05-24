using Godot;
using Godot.Collections;
using TileCraftUtils;
using TileCraftConstants;

namespace TileCraftMain
{
    public class MainMenu : Control
    {
        ResizeHandler _resizeHandler = new ResizeHandler();
        public bool CreditsPageOpen = false;
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
            CreditsPageOpen = !CreditsPageOpen;
            PlayButton.Disabled = CreditsPageOpen;
            CreditsButton.Disabled = CreditsPageOpen;
            QuitButton.Disabled = CreditsPageOpen;
            Credits.Visible = CreditsPageOpen;
        }

        public void PlayEvent()
        {
            GetTree().CurrentScene = GetNode<MainMenu>("/root/GameScene");
        }

        public void QuitEvent()
        {
            GetTree().Notification(MainLoop.NotificationWmQuitRequest);
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

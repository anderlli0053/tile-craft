using Godot;

public class QuitButton : Button
{
    public void OnClick()
    {
        MainMenu mainMenu = GetNode<MainMenu>("/root/MainMenu");
        //quit the app
        GetTree().Notification(MainLoop.NotificationWmQuitRequest);
    }
}
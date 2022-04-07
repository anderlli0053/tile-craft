using Godot;


public class PlayButton : Button
{
    public void OnClick()
    {
        MainMenu mainMenu = GetNode<MainMenu>("/root/MainMenu");
        //switch scene to the game scene where the fun happens

        GetTree().ChangeScene("res://Scenes/GameScene.tscn");

    }
}
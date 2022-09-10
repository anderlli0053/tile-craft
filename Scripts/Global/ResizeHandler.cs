using System;
using Godot;
using TileCraftConstants;

namespace TileCraftUtils;

public class ResizeHandler
{
    static Vector2 viewport = new Vector2();
    public static Vector2 NoBlanks(Vector2 size)
    {
        viewport = OS.WindowSize;
        float viewportAspect = viewport.x / viewport.y;
        float containerAspect = size.x / size.y;
        if (containerAspect < viewportAspect) return new Vector2(viewport.x / size.x, viewport.x / size.x);
        else return new Vector2(viewport.y / size.y, viewport.y / size.y);
    }
    public static Vector2 Contain(Vector2 size)
    {
        viewport = OS.WindowSize;
        float viewportAspect = viewport.x / viewport.y;
        float containerAspect = size.x / size.y;
        if (containerAspect < viewportAspect) return new Vector2(viewport.y / size.y, viewport.y / size.y);
        else return new Vector2(viewport.x / size.x, viewport.x / size.x);
    } 
}

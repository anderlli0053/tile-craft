using System;
using Godot;
using TileCraftConstants;

namespace TileCraftUtils;

public class ResizeHandler
{
    Vector2 viewport = new Vector2();
    public void NoBlanks(Control container, Vector2 size)
    {
        Vector2 newViewport = OS.WindowSize;
        if (viewport.x == newViewport.x && viewport.y == newViewport.y) return;
        viewport = newViewport;
        float viewportAspect = viewport.x / viewport.y;
        float containerAspect = size.x / size.y;
        if (containerAspect < viewportAspect)
        {
            container.RectScale = new Vector2(viewport.x / size.x, viewport.x / size.x);
        }
        else
        {
            container.RectScale = new Vector2(viewport.y / size.y, viewport.y / size.y);
        }
    }
    public void Contain(Control container, Vector2 size)
    {
        Vector2 newViewport = OS.WindowSize;
        if (viewport.x == newViewport.x && viewport.y == newViewport.y) return;

        viewport = OS.WindowSize;
        float viewportAspect = viewport.x / viewport.y;
        float containerAspect = size.x / size.y;
        if (containerAspect < viewportAspect)
        {
            container.RectScale = new Vector2(viewport.y / size.y, viewport.y / size.y);
        }
        else
        {
            container.RectScale = new Vector2(viewport.x / size.x, viewport.x / size.x);
        }
    }
    public void NoBlanks(Node2D container, Vector2 size)
    {
        Vector2 newViewport = OS.WindowSize;
        if (viewport.x == newViewport.x && viewport.y == newViewport.y) return;
        viewport = newViewport;
        float viewportAspect = viewport.x / viewport.y;
        float containerAspect = size.x / size.y;
        if (containerAspect < viewportAspect)
        {
            container.Scale = new Vector2(viewport.x / size.x, viewport.x / size.x);
        }
        else
        {
            container.Scale = new Vector2(viewport.y / size.y, viewport.y / size.y);
        }
    }
    public void Contain(Node2D container, Vector2 size)
    {
        Vector2 newViewport = OS.WindowSize;
        if (viewport.x == newViewport.x && viewport.y == newViewport.y) return;

        viewport = OS.WindowSize;
        float viewportAspect = viewport.x / viewport.y;
        float containerAspect = size.x / size.y;
        if (containerAspect < viewportAspect)
        {
            container.Scale = new Vector2(viewport.y / size.y, viewport.y / size.y);
        }
        else
        {
            container.Scale = new Vector2(viewport.x / size.x, viewport.x / size.x);
        }
    }
}

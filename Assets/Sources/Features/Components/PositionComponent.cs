using Entitas;

public class PositionComponent : IComponent
{
    public PositionComponent()
    {

    }

    public PositionComponent(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int x;
    public int y;
}


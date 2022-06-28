public enum BombType
{
    None,
    Color,
    Column,
    Row,
    Adjacent
}

public class Bomb : GamePiece
{
    public BombType bombType;
}

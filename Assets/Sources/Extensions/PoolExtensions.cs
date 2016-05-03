using Entitas;
using UnityEngine;

public static class PoolExtensions
{
    static readonly string[] _pieces =
    {
        Res.CandyBlue,
        Res.CandyGreen,
        Res.CandyOrange,
        Res.CandyRed
    };

    public static Entity CreateRandomPiece(this Pool pool, int x, int y)
    {
        int pieceId = Random.Range(0, _pieces.Length);
        string pieceName = _pieces[pieceId];

        return pool.CreateEntity()
           .IsGameBoardElement(true)
           .AddPosition(x, y)
           .IsMovable(true)
           .IsInteractive(true)
           .AddResource(pieceName, pieceId);
    }
}

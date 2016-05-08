using Entitas;

public static class GameBoardLogic
{
    public static int GetNextEmptyRow(this Entity[,,] grid, int column, int row)
    {
        var rowBelow = row - 1;
        while (rowBelow >= 0 && grid[column, rowBelow, 0] == null)
        {
            rowBelow -= 1;
        }

        return rowBelow + 1;
    }

    public static int GetNextEmptyDepth(this Entity[,,] grid, int column, int row, int depth)
    {
        var depthBelow = depth - 1;
        while (depthBelow >= 0 && grid[column, row, depthBelow] == null)
        {
            depthBelow -= 1;
        }

        return depthBelow + 1;
    }
}

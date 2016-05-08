using Entitas;

public static class GameBoardLogic
{
    public static int GetNextEmptyRow(this Entity[,] grid, int column, int row)
    {
        var rowBelow = row - 1;
        while (rowBelow >= 0 && grid[column, rowBelow] == null)
        {
            rowBelow -= 1;
        }

        return rowBelow + 1;
    }

    public static bool HasHorizontalMatch(this Entity[,] grid, int column, int row)
    {
        var columnLeft = column - 1;
        var columnRight = column + 1;
        //if (columnLeft >= 0 && columnRight < )
        //{

        //}

        return false;
    }
}

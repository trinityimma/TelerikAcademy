using System;
using System.Linq;

partial class Engine
{
    private GameObject GetCollidedObject(MovingObject obj)
    {
        return GetCollidedObject(obj, obj.Direction);
    }

    private GameObject GetCollidedObject(GameObject obj)
    {
        return GetCollidedObject(obj, Coordinates.Zero);
    }

    private GameObject GetCollidedObject(GameObject obj, Coordinates direction)
    {
        foreach (GameObject cur in this.allObjects.Where(x => x != obj))
            if (WillCollideWith(obj, direction, cur))
                return cur;

        return null;
    }

    private bool WillCollideWith(GameObject obj, Coordinates direction, GameObject cur)
    {
        Coordinates first = new Coordinates(
            Math.Max(obj.Position.Row + direction.Row,
                     cur.Position.Row),

            Math.Max(obj.Position.Col + direction.Col,
                     cur.Position.Col)
        );

        Coordinates last = new Coordinates(
            Math.Min(obj.Position.Row + obj.Rows + direction.Row,
                     cur.Position.Row + cur.Rows),

            Math.Min(obj.Position.Col + obj.Cols + direction.Col,
                     cur.Position.Col + cur.Cols)
        );

        for (int row = first.Row; row < last.Row; row++)
            for (int col = first.Col; col < last.Col; col++)
                if (obj[row - obj.Position.Row - direction.Row, col - obj.Position.Col - direction.Col] != '\0' &&
                    cur[row - cur.Position.Row, col - cur.Position.Col] != '\0')
                        return true;

        return false;
    }

    // TODO: Remove blocks
    private bool IsRowFull(int row)
    {
        for (int col = this.fieldStartCol; col <= this.fieldEndCol; col++)
            if (GetCollidedObject(new Block(new Coordinates(row, col))) == null)
                return false;

        return true;
    }

    private void ClearRow(int row)
    {
        for (int col = this.fieldStartCol; col <= this.fieldEndCol; col++)
        {
            GameObject obj = GetCollidedObject(new Block(new Coordinates(row, col)));

            if(obj != null && obj != this.controlledObject)
                obj.DestroyRow(row - obj.Position.Row);
        }

        this.controlledObject.DestroyRow(row - this.controlledObject.Position.Row);
    }

    private void CheckForClearedRows(object sender, EventArgs e)
    {
        int lines = 0;
        int startRow = this.controlledObject.Position.Row;

        // Start destroying from the bottom
        for (int row = startRow + this.controlledObject.Rows - 1; row >= startRow; row--)
        {
            if (IsRowFull(row))
            {
                lines++;

                ClearRow(row);
            }
        }

        if (lines != 0)
            this.OnClearedRows(this, lines);
    }
}

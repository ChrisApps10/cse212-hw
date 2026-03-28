using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<ValueTuple<int, int>, bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<ValueTuple<int, int>, bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        // Index 0: Left | Decreases X
        if (_mazeMap[(_currX, _currY)][0])
            _currX -= 1;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveRight()
    {
        // Index 1: Right | Increases X
        if (_mazeMap[(_currX, _currY)][1])
            _currX += 1;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveUp()
    {
        // Index 2: Up | Decreases Y
        if (_mazeMap[(_currX, _currY)][2])
            _currY -= 1;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveDown()
    {
        // Index 3: Down | Increases Y
        if (_mazeMap[(_currX, _currY)][3])
            _currY += 1;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}

public static class GameOfLife
{
    public static int GetNewState(int currentState, List<Node> neighbors)
    {
        int liveNeighborCount = 0;

        // if (currentState + liveNeighborCount > 0)
        // {
        //     Console.WriteLine($"DEBUG: currentState = {currentState}");
        //     Console.WriteLine($"DEBUG: liveNeighborCount = {liveNeighborCount}");
        // }

        foreach (Node neighbor in neighbors)
        {
            if (neighbor.State == 1)
            {
                liveNeighborCount++;
            }
        }

        switch (currentState)
        {
            case 0:
                if (liveNeighborCount == 3)
                {
                    return 1;
                } else {
                    return 0;
                }
            case 1:
                if (liveNeighborCount == 2 || liveNeighborCount == 3)
                {
                    return 1;
                } else {
                    return 0;
                }
            default:
                return currentState;
        }
    }
}
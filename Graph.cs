public class Graph
{
    private List<Node> _nodes;
    public List<Node> Nodes {
        get {return this._nodes;}
    }

    // Conway's Game of Life might be played on an infinite plane, but we have less lofty goals
    public int width;
    public int height;

    public Graph(int width, int height)
    {
        this.width = width;
        this.height = height;
        this._nodes = new List<Node>();

        for (int y = 0; y < this.height; y++)
        for (int x = 0; x < this.width;  x++)
        {
            Node node = new Node(x, y);
            this.AddNode(node);
        }
    }

    private void AddNode(Node node)
    {
        this._nodes.Add(node);
    }

    public List<Node> GetNodeNeighbors(Node node)
    {
        List<Node> neighbors = new List<Node>();
        List<int> indices = new List<int>
        {
            GetNodeIndex(node.X + 1, node.Y),
            GetNodeIndex(node.X - 1, node.Y),
            GetNodeIndex(node.X, node.Y + 1),
            GetNodeIndex(node.X, node.Y - 1),
            GetNodeIndex(node.X + 1, node.Y + 1),
            GetNodeIndex(node.X + 1, node.Y - 1),
            GetNodeIndex(node.X - 1, node.Y + 1),
            GetNodeIndex(node.X - 1, node.Y - 1)
        };


        foreach (int index in indices)
        {
            if (index >= 0)
            {
                Node neighbor = this.Nodes[index];
                neighbors.Add(neighbor);
            }
        }
        
        return neighbors;
        // return this.Nodes.FindAll(neighbor => neighbor.IsNeighborOf(node));
    }

    public bool SetNodeState(int x, int y, int newState)
    {
        int nodeIndex = this.GetNodeIndex(x, y);
        if (nodeIndex < 0)
        {
            return false;
        }
        this.Nodes[nodeIndex].State = newState;
        return true;
    }

    public int GetNodeIndex(int x, int y)
    {
        return this.Nodes.FindIndex(node => (node.X == x && node.Y == y));
    }

    public void Print()
    {
        AsciiGrid asciiGrid = new AsciiGrid(this.width, this.height);
        for (int y = 0; y < this.height; y++)
        for (int x = 0; x < this.width;  x++)
        {
            Node node = this.Nodes[GetNodeIndex(x, y)];
            if (node != null)
            asciiGrid.SetCellValue(x, y, node.State);
        }
        Console.Write(asciiGrid);
    }
}
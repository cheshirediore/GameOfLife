public class Node
{
    // Integer state used to allow more than 2 degrees of freedom. Conway's Game of Life only needs a bool
    public int State {get; set;}

    // Node coordinates
    public int X {get; init;}
    public int Y {get; init;}

    #region Constructors
    public Node(int x, int y)
    {
        // Set the node's coordinates
        this.X = x;
        this.Y = y;

        // Initialize to default state
        this.State = 0;
    }
    #endregion

    public bool IsNeighborOf(Node other)
    {
        // The manhatten distance between neighbors must be one or two for neighbors.
        // Equivalently, the absolute distance of the X coodinates or Y coordinates (inclusive) must be one.
        // Console.WriteLine($"DEBUG: This position  = ({this.X}, {this.Y})");
        // Console.WriteLine($"DEBUG: Other position = ({other.X}, {other.Y})");
        
        return (
            (MathF.Abs(this.X - other.X) == 1) ||
            (MathF.Abs(this.Y - other.Y) == 1)
        );
    }
}
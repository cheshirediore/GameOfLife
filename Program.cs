// See https://aka.ms/new-console-template for more information

using System.Diagnostics.Metrics;

Graph graph = new Graph(20, 10);
graph.SetNodeState(2, 1, 1);
graph.SetNodeState(3, 2, 1);
graph.SetNodeState(1, 3, 1);
graph.SetNodeState(2, 3, 1);
graph.SetNodeState(3, 3, 1);


// Output the initial graph
Console.WriteLine("Initial State:\n==========\n");
graph.Print();
Console.WriteLine("\n==========\n");
int counter = 0;
while (graph.Nodes.FindIndex(node => (node.State == 1)) >= 0 && counter < 32)
{   
    // Get the updated states
    Dictionary<int, int> newNodeStates = new Dictionary<int, int>();
    for (int i = 0; i < graph.Nodes.Count; i++)
    {
        Node node = graph.Nodes[i];
        int newState = GameOfLife.GetNewState(node.State, graph.GetNodeNeighbors(node));
        newNodeStates[i] = newState;
    }

    // Set the new states
    for (int i = 0; i < graph.Nodes.Count; i++)
    {
        graph.Nodes[i].State = newNodeStates[i];
    }

    // Output the new graph
    if (counter % 1 == 0)
    {
        Console.WriteLine($"Iteration #{counter}:\n==========\n");
        graph.Print();
        Console.WriteLine("\n==========\n");
    }
    counter++;
}



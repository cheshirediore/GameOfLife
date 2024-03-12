public class AsciiGrid
{
    public int width {get; init;}
    public int height {get; init;}
    Dictionary<int, char> displayValueMap;

    public int[,] cellValues {get; set;}

    public AsciiGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
        this.displayValueMap = new Dictionary<int, char>();
        this.cellValues = new int[width,height];

        // Default Value Map
        this.UpdateMappedValue(0, ' ');
        this.UpdateMappedValue(1, '*');
    }

    public void UpdateMappedValue(int key, char value)
    {
        this.displayValueMap[key] = value;
    }

    public void SetCellValue(int x, int y, int value)
    {
        this.cellValues[x, y] = value;
    }

    public char? GetMappedValue(int key)
    {
        if (this.displayValueMap.ContainsKey(key))
        {
            return this.displayValueMap[key];
        }
        else
        {
            return null;
        }
    }

    public override string ToString()
    {
        string representation = "";

        for (int y = 0; y < this.height; y++)
        {
            for (int x = 0; x < this.width;  x++)
            {
                int value =  this.cellValues[x, y];
                representation += $"{this.displayValueMap[value]}";
            }
                representation += "\n";
        }

        return representation;
    }

}
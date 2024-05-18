internal class Program
{
    private static void Main(string[] args)
    {
        // Bản đồ mìn đầu vào
        string[,] map = {
            {"*", ".", ".", "."},
            {".", ".", ".", "."},
            {".", "*", ".", "."},
            {".", ".", ".", "."}
        };
        
        int MAP_HEIGHT = map.GetLength(0);
        int MAP_WIDTH = map.GetLength(1);

        // Tạo báo cáo bản đồ mìn
        string[,] mapReport = new string[MAP_HEIGHT, MAP_WIDTH];
        
        for (int yOrdinate = 0; yOrdinate < MAP_HEIGHT; yOrdinate++)
        {
            for (int xOrdinate = 0; xOrdinate < MAP_WIDTH; xOrdinate++)
            {
                string currentCell = map[yOrdinate, xOrdinate];
                if (currentCell.Equals("*"))
                {
                    mapReport[yOrdinate, xOrdinate] = "*";
                }
                else
                {
                    int[,] NEIGHBOURS_ORDINATE = {
                        {yOrdinate - 1, xOrdinate - 1}, {yOrdinate - 1, xOrdinate}, {yOrdinate - 1, xOrdinate + 1},
                        {yOrdinate, xOrdinate - 1}, {yOrdinate, xOrdinate + 1},
                        {yOrdinate + 1, xOrdinate - 1}, {yOrdinate + 1, xOrdinate}, {yOrdinate + 1, xOrdinate + 1}
                    };

                    int minesAround = 0;
                    for (int i = 0; i < NEIGHBOURS_ORDINATE.GetLength(0); i++)
                    {
                        int xOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 1];
                        int yOrdinateOfNeighbour = NEIGHBOURS_ORDINATE[i, 0];

                        bool isOutOfMapNeighbour = xOrdinateOfNeighbour < 0 || xOrdinateOfNeighbour == MAP_WIDTH || yOrdinateOfNeighbour < 0 || yOrdinateOfNeighbour == MAP_HEIGHT;
                        if (isOutOfMapNeighbour) continue;

                        bool isMineOwnerNeighbour = map[yOrdinateOfNeighbour, xOrdinateOfNeighbour].Equals("*");
                        if (isMineOwnerNeighbour) minesAround++;
                    }

                    mapReport[yOrdinate, xOrdinate] = minesAround.ToString();
                }
            }
        }

        // In báo cáo bản đồ mìn
        for (int yOrdinate = 0; yOrdinate < MAP_HEIGHT; yOrdinate++)
        {
            for (int xOrdinate = 0; xOrdinate < MAP_WIDTH; xOrdinate++)
            {
                string currentCellReport = mapReport[yOrdinate, xOrdinate];
                Console.Write(currentCellReport);
            }
            Console.WriteLine(); // Xuống dòng sau mỗi hàng
        }
    }
}
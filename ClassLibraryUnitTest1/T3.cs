namespace MathLib
{
    public class T3
    {
        private CellValue[,] _board = new CellValue[3, 3];
        public enum CellValue { None, X, O, } // integers masquerading as enums
        public void MakeMove(int row, int col){}

        public CellValue GetWinner()
        {
            return CellValue.None;
        }
        public CellValue GetPlayer()
        {
            return CellValue.None;
        }
    }
}

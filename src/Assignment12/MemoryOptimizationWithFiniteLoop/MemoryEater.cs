namespace MemoryOptimization
{
    /// <summary>
    /// MemoryEater class that contains method to allocate memory
    /// </summary>
    public class MemoryEater
    {
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Method that allocates memory in an infinite loop, also ensures that OutOfMemoryException doesn't occurs
        /// </summary>
        /// <param name="maxValue">Max Number of Loop Iterations</param>
        public void Allocate(int maxValue)
        {
            while (true)
            {
                if (this._memAlloc.Count > maxValue)
                {
                    return;
                }

                this._memAlloc.Add(new int[1000]);
                Thread.Sleep(10);
            }
        }
    }
}

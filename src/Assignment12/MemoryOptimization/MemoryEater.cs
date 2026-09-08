namespace MemoryOptimization
{
    /// <summary>
    /// MemoryEater class that contains method to allocate memory in an infinite loop
    /// </summary>
    public class MemoryEater
    {
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Method that allocates memory in an infinite loop, also ensures that OutOfMemoryException doesn't occurs
        /// </summary>
        public void Allocate()
        {
            while (true)
            {
                this._memAlloc.Add(new int[1000]);
                if (this._memAlloc.Count > 100)
                {
                    this._memAlloc.RemoveAt(0);
                }

                Thread.Sleep(10);
            }
        }
    }
}

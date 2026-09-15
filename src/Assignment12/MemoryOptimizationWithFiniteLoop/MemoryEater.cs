namespace MemoryOptimization
{
    /// <summary>
    /// MemoryEater class that contains method to allocate memory
    /// </summary>
    public class MemoryEater
    {
        private List<int[]> _memAlloc = new List<int[]>();

        /// <summary>
        /// Method that allocates memory for Array Instances and adds the instance to the list for a threshold(maxValue) passed as an input by the user.
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

        /// <summary>
        /// This method clears the _memAlloc list, so the array instances allocated in managed heap will now become eligible for cleanup by GC
        /// </summary>
        public void CleanUp()
        {
            this._memAlloc.Clear();
        }
    }
}

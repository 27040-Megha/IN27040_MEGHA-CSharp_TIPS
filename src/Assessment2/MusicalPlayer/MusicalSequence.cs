namespace MusicalPlayer
{
    /// <summary>
    /// Musical Sequence
    /// </summary>
    public class MusicalSequence
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MusicalSequence"/> class.
        /// </summary>
        /// <param name="musicalNote">Musical note</param>
        /// <param name="frequency">Frequence of the note</param>
        /// <param name="duration">Duration</param>
        public MusicalSequence(string musicalNote, decimal frequency, int duration)
        {
            this.MusicalNote = musicalNote;
            this.Frequency = frequency;
            this.Duration = duration;
        }

        /// <summary>
        /// Gets or sets the value of musical note
        /// </summary>
        /// <value>
        /// Musical Note
        /// </value>
        public string MusicalNote { get; set; }

        /// <summary>
        /// Gets or sets the value of Frequency
        /// </summary>
        /// <value>
        /// Frequency of Musical Note
        /// </value>
        public decimal Frequency { get; set; }

        /// <summary>
        /// Gets or sets the value of Duration
        /// </summary>
        /// <value>
        /// Duration of Musical Note
        /// </value>
        public int Duration { get; set; }
    }
}

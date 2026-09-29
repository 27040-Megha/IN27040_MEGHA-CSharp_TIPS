using System;
using System.Collections.Generic;
using System.Linq;
using MusicalPlayer;

namespace Assignments
{
    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Entry point of application
        /// </summary>
        /// <param name="args">Arguments</param>
        public static void Main(string[] args)
        {
            var musicalNotes = LoadMusicalNote();
            Console.WriteLine("Enter musical notes: ");
            while (true)
            {
                string note = Console.ReadLine();
                var musicalValue = musicalNotes.FirstOrDefault(x => string.Equals(x.MusicalNote, note));
                if (musicalValue == null)
                {
                    Console.WriteLine("Invalid input");
                    break;
                }

                int frequency = (int)musicalValue.Frequency;
                PlaySound(frequency, musicalValue.Duration);
            }

            Console.ReadKey();
        }

        private static void PlaySound(int frequency, int duration)
        {
            Console.Beep(frequency, duration);
        }

        private static List<MusicalSequence> LoadMusicalNote()
        {
            return new List<MusicalSequence>()
                {
                new MusicalSequence("C", 261.63m, 200),
                new MusicalSequence("C#", 277.18m, 1300),
                new MusicalSequence("D", 293.66m, 400),
                new MusicalSequence("D#", 311.13m, 700),
                new MusicalSequence("E", 329.63m, 500),
                new MusicalSequence("F", 349.23m, 200),
                new MusicalSequence("F#", 369.99m, 300),
                new MusicalSequence("G", 392.00m, 100),
                new MusicalSequence("G#", 415.30m, 300),
                new MusicalSequence("A", 440.00m, 400),
                new MusicalSequence("A#", 466.16m, 700),
                new MusicalSequence("B", 493.88m, 300),
                };
        }
    }
}
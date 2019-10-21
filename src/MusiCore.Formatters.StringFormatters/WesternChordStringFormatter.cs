using System;
using MusiCore.Notation.Western;

namespace MusiCore.Formatters.StringFormatters
{
    public class WesternChordStringFormatter
    {
        public string Format(ChordClass chordClass)
        {
            string pitchClassString = chordClass.PitchClass.PitchClass switch
            {
                PitchClass a when a.Equals(PitchClass.A) => "A",
                PitchClass b when b.Equals(PitchClass.B) => "B",
                PitchClass c when c.Equals(PitchClass.C) => "C",
                PitchClass d when d.Equals(PitchClass.D) => "D",
                PitchClass e when e.Equals(PitchClass.E) => "E",
                PitchClass f when f.Equals(PitchClass.F) => "F",
                PitchClass g when g.Equals(PitchClass.G) => "G",
                _ => throw new InvalidOperationException()
            };

            string accidentalString = chordClass.PitchClass.Accidental switch
            {
                Accidental flat when flat.Equals(Accidental.Flat) => "b",
                Accidental sharp when sharp.Equals(Accidental.Sharp) => "#",
                Accidental natural when natural.Equals(Accidental.Natural) => string.Empty,
                _ => throw new InvalidOperationException()
            };

            string patternString = chordClass switch
            {
                ChordClass major when major.Pattern.Equals(TriadPattern.Major) => string.Empty,
                ChordClass minor when minor.Pattern.Equals(TriadPattern.Minor) => "m",
                ChordClass sus2 when sus2.Pattern.Equals(TriadPattern.SuspendedSecond) => "sus2",
                ChordClass sus4 when sus4.Pattern.Equals(TriadPattern.SuspendedFourth) => "sus4",
                _ => throw new InvalidOperationException()
            };

            return $"{pitchClassString}{accidentalString}{patternString}";
        }
    }
}

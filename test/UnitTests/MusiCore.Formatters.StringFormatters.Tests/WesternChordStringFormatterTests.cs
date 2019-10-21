using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using FluentAssertions;
using MusiCore.Notation.Western;
using Xunit;
using BindingFlags = System.Reflection.BindingFlags;

// ReSharper disable InconsistentNaming

namespace MusiCore.Formatters.StringFormatters.Tests
{
    public class WesternChordStringFormatterTests
    {
        public static readonly IEnumerable<object[]> Format_WithMajorChordNoAdditionalNotes_ShouldReturnPitchClassInUpperCaseWithAccidental_Data = new[]
        {
            new object[] { PitchClass.A, Accidental.Natural, "A" },
            new object[] { PitchClass.B, Accidental.Flat, "Bb" },
            new object[] { PitchClass.C, Accidental.Sharp, "C#" },
            new object[] { PitchClass.D, Accidental.Natural, "D" },
            new object[] { PitchClass.E, Accidental.Flat, "Eb" },
            new object[] { PitchClass.F, Accidental.Sharp, "F#" },
            new object[] { PitchClass.G, Accidental.Natural, "G" },
        };

        [Theory]
        [MemberData(nameof(Format_WithMajorChordNoAdditionalNotes_ShouldReturnPitchClassInUpperCaseWithAccidental_Data))]
        public void Format_WithMajorChordNoAdditionalNotes_ShouldReturnPitchClassInUpperCaseWithAccidental(PitchClass pitchClass, Accidental accidental, string expectedValue)
        {
            // ARRANGE
            var westernChordStringFormatter = new WesternChordStringFormatter();
            var chordClass = new ChordClass(new PitchClassWithAccidental(pitchClass, accidental), TriadPattern.Major, ImmutableList<ChordAddedNote>.Empty );

            // ACT
            string actualValue = westernChordStringFormatter.Format(chordClass);

            // ASSERT
            actualValue.Should().Be(expectedValue);
        }

        public static readonly IEnumerable<object[]> Format_WithMinorChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental_Data = new[]
        {
            new object[] { PitchClass.A, Accidental.Natural, "Am" },
            new object[] { PitchClass.B, Accidental.Flat, "Bbm" },
            new object[] { PitchClass.C, Accidental.Sharp, "C#m" },
            new object[] { PitchClass.D, Accidental.Natural, "Dm" },
            new object[] { PitchClass.E, Accidental.Flat, "Ebm" },
            new object[] { PitchClass.F, Accidental.Sharp, "F#m" },
            new object[] { PitchClass.G, Accidental.Natural, "Gm" }
        };

        [Theory]
        [MemberData(nameof(Format_WithMinorChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental_Data))]
        public void Format_WithMinorChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental(PitchClass pitchClass, Accidental accidental, string expectedValue)
        {
            // ARRANGE
            var westernChordStringFormatter = new WesternChordStringFormatter();
            var chordClass = new ChordClass(new PitchClassWithAccidental(pitchClass, accidental), TriadPattern.Minor, ImmutableList<ChordAddedNote>.Empty );

            // ACT
            string actualValue = westernChordStringFormatter.Format(chordClass);

            // ASSERT
            actualValue.Should().Be(expectedValue);
        }

        public static readonly IEnumerable<object[]> Format_WithSuspendedSecondChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental_Data = new[]
        {
            new object[] { PitchClass.A, Accidental.Natural, "Asus2" },
            new object[] { PitchClass.B, Accidental.Flat, "Bbsus2" },
            new object[] { PitchClass.C, Accidental.Sharp, "C#sus2" },
            new object[] { PitchClass.D, Accidental.Natural, "Dsus2" },
            new object[] { PitchClass.E, Accidental.Flat, "Ebsus2" },
            new object[] { PitchClass.F, Accidental.Sharp, "F#sus2" },
            new object[] { PitchClass.G, Accidental.Natural, "Gsus2" }
        };

        [Theory]
        [MemberData(nameof(Format_WithSuspendedSecondChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental_Data))]
        public void Format_WithSuspendedSecondChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental(PitchClass pitchClass, Accidental accidental, string expectedValue)
        {
            // ARRANGE
            var westernChordStringFormatter = new WesternChordStringFormatter();
            var chordClass = new ChordClass(new PitchClassWithAccidental(pitchClass, accidental), TriadPattern.SuspendedSecond, ImmutableList<ChordAddedNote>.Empty );

            // ACT
            string actualValue = westernChordStringFormatter.Format(chordClass);

            // ASSERT
            actualValue.Should().Be(expectedValue);
        }

        public static readonly IEnumerable<object[]> Format_WithSuspendedFourthChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental_Data = new[]
        {
            new object[] { PitchClass.A, Accidental.Natural, "Asus4" },
            new object[] { PitchClass.B, Accidental.Flat, "Bbsus4" },
            new object[] { PitchClass.C, Accidental.Sharp, "C#sus4" },
            new object[] { PitchClass.D, Accidental.Natural, "Dsus4" },
            new object[] { PitchClass.E, Accidental.Flat, "Ebsus4" },
            new object[] { PitchClass.F, Accidental.Sharp, "F#sus4" },
            new object[] { PitchClass.G, Accidental.Natural, "Gsus4" }
        };

        [Theory]
        [MemberData(nameof(Format_WithSuspendedFourthChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental_Data))]
        public void Format_WithSuspendedFourthChordNoAdditionalTones_ShouldReturnPitchClassInUpperCaseWithAccidental(PitchClass pitchClass, Accidental accidental, string expectedValue)
        {
            // ARRANGE
            var westernChordStringFormatter = new WesternChordStringFormatter();
            var chordClass = new ChordClass(new PitchClassWithAccidental(pitchClass, accidental), TriadPattern.SuspendedFourth, ImmutableList<ChordAddedNote>.Empty );

            // ACT
            string actualValue = westernChordStringFormatter.Format(chordClass);

            // ASSERT
            actualValue.Should().Be(expectedValue);
        }

        [Fact]
        public void Format_WithUnknownPitchClass_ShouldThrowInvalidOperationException()
        {
            // ARRANGE
            var pitchClass =
                (PitchClass)typeof(PitchClass).GetConstructors(BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic)
                                              .First(c => c.GetParameters().FirstOrDefault()?.ParameterType == typeof(int))
                                              .Invoke(new object[] { -3 });
            var accidental = Accidental.Natural;
            var triadPattern = TriadPattern.Major;
            var westernChordStringFormatter = new WesternChordStringFormatter();
            var chordClass = new ChordClass(new PitchClassWithAccidental(pitchClass, accidental), triadPattern, ImmutableList<ChordAddedNote>.Empty);

            // ACT
            Action format = () => westernChordStringFormatter.Format(chordClass);

            // ASSERT
            format.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void Format_WithUnknownAccidental_ShouldThrowInvalidOperationException()
        {
            // ARRANGE
            var pitchClass = PitchClass.A;
            var accidental = 
                (Accidental)typeof(Accidental).GetConstructors(BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic)
                                              .First(c => c.GetParameters().FirstOrDefault()?.ParameterType == typeof(int))
                                              .Invoke(new object[] { -3 });
            var triadPattern = TriadPattern.Major;
            var westernChordStringFormatter = new WesternChordStringFormatter();
            var chordClass = new ChordClass(new PitchClassWithAccidental(pitchClass, accidental), triadPattern, ImmutableList<ChordAddedNote>.Empty);

            // ACT
            Action format = () => westernChordStringFormatter.Format(chordClass);

            // ASSERT
            format.Should().ThrowExactly<InvalidOperationException>();
        }

        [Fact]
        public void Format_WithUnknownTriadPattern_ShouldThrowInvalidOperationException()
        {
            // ARRANGE
            var pitchClass = PitchClass.A;
            var accidental = Accidental.Natural;
            var triadPattern =
                (TriadPattern)typeof(TriadPattern).GetConstructors(BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic)
                                                  .First(c => c.GetParameters().FirstOrDefault()?.ParameterType == typeof(int))
                                                  .Invoke(new object[] { -3 });
            var westernChordStringFormatter = new WesternChordStringFormatter();
            var chordClass = new ChordClass(new PitchClassWithAccidental(pitchClass, accidental), triadPattern, ImmutableList<ChordAddedNote>.Empty);

            // ACT
            Action format = () => westernChordStringFormatter.Format(chordClass);

            // ASSERT
            format.Should().ThrowExactly<InvalidOperationException>();
        }
    }
}

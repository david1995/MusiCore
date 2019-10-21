using System.Collections.Generic;
using FluentAssertions;
using Xunit;

// ReSharper disable InconsistentNaming

namespace MusiCore.Notation.Western.Tests
{
    public class WesternNoteAnnotationTests
    {
        public static readonly IEnumerable<object[]> Dot_WithNote_ShouldReturnDotWithNote_Data = new []
        {
            new object[] { WesternNote.NewWesternRhythmicNote(Duration.Half) },
            new object[] { WesternNote.NewWesternRhythmicNote(Duration.Quarter) },
            new object[] { WesternNote.NewWesternRhythmicNote(Duration.Eighth) },
            new object[] { WesternNote.NewWesternRhythmicNote(Duration.Sixteenth) },
            new object[] { WesternNote.NewWesternBreak(Duration.Half) },
            new object[] { WesternNote.NewWesternBreak(Duration.Quarter) },
            new object[] { WesternNote.NewWesternBreak(Duration.Eighth) },
            new object[] { WesternNote.NewWesternBreak(Duration.Sixteenth) },
        };

        public static readonly IEnumerable<object[]> Dot_WithAnnotation_ShouldReturnDotWithAnnotation_Data = new[]
        {
            new object[] { WesternNoteAnnotation.NewDot(WesternNote.NewWesternNoteWithPitch(Duration.Quarter, new Pitch(Octave.Four, PitchClass.A, Accidental.Natural))) },
            new object[] { WesternNoteAnnotation.NewAccent(WesternNote.NewWesternNoteWithPitch(Duration.Quarter, new Pitch(Octave.Four, PitchClass.A, Accidental.Natural))) },
            new object[] { WesternNoteAnnotation.NewStaccato(WesternNote.NewWesternNoteWithPitch(Duration.Quarter, new Pitch(Octave.Four, PitchClass.A, Accidental.Natural))) },
        };

        [Theory]
        [MemberData(nameof(Dot_WithNote_ShouldReturnDotWithNote_Data))]
        public void Dot_WithNote_ShouldReturnDotWithNote(WesternNote annotatedNote)
        {
            // ARRANGE & ACT
            var westernNoteAnnotation = WesternNoteAnnotation.NewDot(annotatedNote);

            // ASSERT
            westernNoteAnnotation.Should().BeOfType<WesternNoteAnnotation.Dot>()
                                 .Which.AnnotatedNote.Should().Be(annotatedNote);
        }

        [Theory]
        [MemberData(nameof(Dot_WithAnnotation_ShouldReturnDotWithAnnotation_Data))]
        public void Dot_WithAnnotation_ShouldReturnDotWithAnnotation(WesternNoteAnnotation annotation)
        {
            // ACT
            var dottedNote = WesternNoteAnnotation.NewDot(annotation);

            // ASSERT
            dottedNote.Should().BeOfType<WesternNoteAnnotation.Dot>()
                      .Which.AnnotatedNote.Should().Be(annotation);
        }
    }
}

namespace MusiCore.Notation.Western

open MusiCore.Notation

type Octave =
| Zero = 0
| One = 1
| Two = 2
| Three = 3
| Four = 4
| Five = 5
| Six = 6
| Seven = 7
| Eight = 8
| Nine = 9

type PitchClass = A | B | C | D | E | F | G
type Accidental = DoubleFlat | Flat | Natural | Sharp | DoubleSharp
type Pitch = Octave * PitchClass * Accidental
type Duration = DoubleWhole | Whole | Half | Quarter | Eighth | Sixteenth | Thirtysecondth | Sixtyfourth


type IWesternNotationElement =
    inherit INote

type IWesternNotationElementWithDuration =
    inherit IWesternNotationElement
    abstract member Duration : Duration

type IWesternNote =
    inherit IWesternNotationElementWithDuration

type IWesternNoteAnnotation =
    inherit IWesternNotationElement
    abstract member WrappedNote : IWesternNote

type WesternNotationElement =
| WesternBreak of Duration : Duration

type WesternBreak =
    {
        Duration : Duration
    }
    interface IWesternNote with
        member this.Duration = this.Duration

type WesternRhythmicNote(duration : Duration) =
    interface IWesternNote with
        member this.Duration = this.Duration

    member public __.Duration = duration

type WesternNoteWithPitch(pitch : Pitch, duration : Duration) =
    interface IWesternNote with
        member this.Duration = this.Duration

    member public __.Duration = duration
    member public __.Pitch : Pitch = pitch

type DottedWesternNoteAnnotation(wrappedNote : IWesternNote) =
    interface IWesternNoteAnnotation with
        member this.WrappedNote = this.WrappedNote

    member public __.WrappedNote = wrappedNote

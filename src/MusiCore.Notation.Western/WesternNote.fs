namespace MusiCore.Notation.Western

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
type Accidental = Flat | Natural | Sharp
type PitchClassWithAccidental = { PitchClass : PitchClass; Accidental : Accidental }
type Pitch = { Octave : Octave; PitchClass : PitchClass; Accidental : Accidental }
type Duration = DoubleWhole | Whole | Half | Quarter | Eighth | Sixteenth | Thirtysecondth | Sixtyfourth


type IWesternNote =
  interface
  end

type WesternNote =
  | WesternBreak of Duration : Duration
  | WesternRhythmicNote of Duration : Duration
  | WesternNoteWithPitch of Duration : Duration * Pitch : Pitch
  interface IWesternNote

type WesternNoteAnnotation =
  | Dot of AnnotatedNote : IWesternNote
  | Accent of AnnotatedNote : IWesternNote
  | Staccato of AnnotatedNote : IWesternNote
  interface IWesternNote


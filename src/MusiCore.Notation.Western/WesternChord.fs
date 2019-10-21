namespace MusiCore.Notation.Western

open System.Collections.Immutable

type TriadPattern =
  | Major
  | Minor
  | SuspendedSecond
  | SuspendedFourth
  | Augmented
  | Diminished
  | PowerChord

type ChordAddedNote =
  | Maj6
  | Min6
  | Min7
  | Maj7
  | Add9
  | Add11
  | Add13

type ChordClass = { PitchClass : PitchClassWithAccidental; Pattern : TriadPattern; AddedNotes : ChordAddedNote ImmutableList }

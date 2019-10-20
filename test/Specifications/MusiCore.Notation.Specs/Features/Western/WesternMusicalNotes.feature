Feature: Western musical notes

Scenario Outline: A 4/4 beats measure should be able to contain at maximum 4 quarter notes
  Given there is a 4/4 beats measure
  When <AmountQuarterNotes> quarter notes are added to the measure
  Then the result should be <Validity>

  Examples:
  | Label               | AmountQuarterNotes | Validity |
  | Zero quarter notes  | 0                  | valid   |
  | Single quarter note | 1                  | valid   |
  | Four quarter notes  | 4                  | valid   |
  | Five quarter notes  | 5                  | invalid |

Scenario Outline: A 4/4 beats measure should be able to contain at maximum 2 half notes
  Given there is a 4/4 beats measure
  When <AmountHalfNotes> half notes are added to the measure
  Then the result should be <Validity>

  Examples:
  | Label            | AmountHalfNotes | Validity |
  | Zero half notes  | 0               | valid   |
  | Single half note | 1               | valid   |
  | Two half notes   | 2               | valid   |
  | Three half notes | 3               | invalid |

Scenario Outline: A 4/4 beats measure should be able to contain at maximum 1 whole note
  Given there is a 4/4 beats measure
  When <AmountWholeNotes> whole notes are added to the measure
  Then the result should be <Validity>

  Examples:
  | Label             | AmountWholeNotes | Validity |
  | Zero Whole notes  | 0                | valid   |
  | Single whole note | 1                | valid   |
  | Two half notes    | 2                | invalid |

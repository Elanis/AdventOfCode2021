namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec10_02 =
    let getCharScore (currentChar : char) =
        match currentChar with
            | ')' -> 1
            | ']' -> 2
            | '}' -> 3
            | '>' -> 4

    let rec computeIncompleteScore (heap : char list) (acc : int64) =
        match heap with
            | [] -> acc
            | (head::tail) -> computeIncompleteScore tail (acc * (int64(5)) + int64(getCharScore head))

    let computeScore (lines : string list) =
        let firstIllegalCharacters = lines.Select(Dec10_01.getFirstIllegalCharacter)
        let incompleteLines = firstIllegalCharacters.Where(fun (currentChar, _) -> currentChar = ' ')
        let incompleteLinesScores = incompleteLines.Select(fun (_, heap) -> computeIncompleteScore heap 0)
        let sortedScores = incompleteLinesScores.OrderBy(fun elt -> elt).ToList()
        sortedScores[(sortedScores.Count - 1) / 2]
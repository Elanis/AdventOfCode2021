namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec10_01 =
    let getMatchingEndChar (currentChar : char) =
        match currentChar with
            | '(' -> ')'
            | '[' -> ']'
            | '{' -> '}'
            | '<' -> '>'

    let isEndingChar (currentChar : char) =
        match currentChar with
            | ')' -> true
            | ']' -> true
            | '}' -> true
            | '>' -> true
            | _ -> false

    let rec getFirstIllegalCharacter_Internal (charList : char list) (heap : char list) =
        match charList with
            | [] -> (' ', heap)
            | (head::tail) -> 
                if isEndingChar head then
                    let (heapHead::heapTail) = heap
                    if heapHead = head then
                        getFirstIllegalCharacter_Internal tail heapTail
                    else (head, heap)
                else
                    getFirstIllegalCharacter_Internal tail ((getMatchingEndChar head)::heap)

    let getFirstIllegalCharacter (line : string) =
        getFirstIllegalCharacter_Internal (List.ofSeq(line.ToCharArray())) []

    // SCORE
    let getCharScore (illegalChar : (char * (char list))) =
        let ((currentChar, heap)) = illegalChar
        match currentChar with
            | ')' -> 3
            | ']' -> 57
            | '}' -> 1197
            | '>' -> 25137
            | ' ' -> 0 // Incomplete

    let computeScore (lines : string list) =
        let firstIllegalCharacters = lines.Select(getFirstIllegalCharacter)
        firstIllegalCharacters.Sum(getCharScore)
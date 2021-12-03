namespace AdventOfCode2021

open System.Linq
open System

module Dec03_02 =
    let rec getO2Rating (list : string list) (str : string) =
        match list with
            | [element] -> element
            | _ ->
                let firstChars = List.ofSeq(list.Select(fun elt -> elt.Chars(str.Length)))
                if((firstChars.Count(fun elt -> elt = '1')) >= (firstChars.Count(fun elt -> elt = '0'))) then
                    let newStr = str + "1"
                    getO2Rating (
                        List.ofSeq(list.Where(fun elt -> elt.StartsWith(newStr)))
                    ) newStr
                else 
                    let newStr = str + "0"
                    getO2Rating (
                        List.ofSeq(list.Where(fun elt -> elt.StartsWith(newStr)))
                    ) newStr


    let rec getCO2Rating (list : string list) (str : string) =
        match list with
            | [element] -> element
            | _ ->
                let firstChars = List.ofSeq(list.Select(fun elt -> elt.Chars(str.Length)))
                if((firstChars.Count(fun elt -> elt = '1')) < (firstChars.Count(fun elt -> elt = '0'))) then
                    let newStr = str + "1"
                    getCO2Rating (
                        List.ofSeq(list.Where(fun elt -> elt.StartsWith(newStr)))
                    ) newStr
                else 
                    let newStr = str + "0"
                    getCO2Rating (
                        List.ofSeq(list.Where(fun elt -> elt.StartsWith(newStr)))
                    ) newStr

    let getAtmosphereRating (list : string list) =
        (
            Convert.ToInt32((getO2Rating list ""), 2),
            Convert.ToInt32((getCO2Rating list ""), 2)
        )
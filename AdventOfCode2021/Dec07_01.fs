namespace AdventOfCode2021

open System.Linq
open System
open System.Collections.Generic

module Dec07_01 =
    let getMinimumFuelForAlignment (line : string) =
        let originalYList = line.Split(",").Select(fun (elt) -> (int) elt);
        let possibleSolutions = Seq.distinct originalYList
        let solutions = possibleSolutions.Select(fun(target) -> originalYList.Sum(fun (y) -> Math.Abs(target - y)))

        solutions.Min()
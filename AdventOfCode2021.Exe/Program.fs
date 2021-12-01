open System
open System.Linq
open AdventOfCode2021

// Dec 01 - 1
let dec01_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec01.txt")
    let items = fileContent.Select(fun (elt) -> (int) elt)
    Console.WriteLine("Dec01_01: {0}", Dec01_01.count (List.ofSeq(items)) 0)

// Dec 01 - 2
let dec01_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec01.txt")
    let items = fileContent.Select(fun (elt) -> (int) elt)
    Console.WriteLine("Dec01_02: {0}", Dec01_02.count (List.ofSeq(items)) 0)


// Execute
dec01_01
dec01_02
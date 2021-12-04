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

// Dec 02 - 1
let dec02_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec02.txt")
    Console.WriteLine("Dec02_01: {0}", Dec02_01.processAll (List.ofSeq(fileContent)) 0 0)

// Dec 02 - 2
let dec02_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec02.txt")
    Console.WriteLine("Dec02_02: {0}", Dec02_02.processAll (List.ofSeq(fileContent)) 0 0 0)

// Dec 03 - 1
let dec03_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec03.txt")
    Console.WriteLine("Dec03_01: {0}", Dec03_01.getConsumption (List.ofSeq(fileContent)))

// Dec 03 - 2
let dec03_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec03.txt")
    Console.WriteLine("Dec03_02: {0}", Dec03_02.getAtmosphereRating (List.ofSeq(fileContent)))

// Dec 04 - 1
let dec04_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec04.txt")
    Console.WriteLine("Dec04_01: {0}", Dec04_01.computeScore (List.ofSeq(fileContent)))

// Dec 04 - 2
let dec04_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec04.txt")
    Console.WriteLine("Dec04_02: {0}", Dec04_02.computeScore (List.ofSeq(fileContent)))

// Execute
dec01_01
dec01_02
dec02_01
dec02_02
dec03_01
dec03_02
dec04_01
dec04_02
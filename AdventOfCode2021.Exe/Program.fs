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

// Dec 05 - 1
let dec05_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec05.txt")
    Console.WriteLine("Dec05_01: {0}", Dec05_01.countOverlap (List.ofSeq(fileContent)))

// Dec 05 - 2
let dec05_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec05.txt")
    Console.WriteLine("Dec05_02: {0}", Dec05_02.countOverlap (List.ofSeq(fileContent)))

// Dec 06 - 1
let dec06_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec06.txt")
    Console.WriteLine("Dec06_01: {0}", Dec06_01.countLanternFish (fileContent.First()) 80)

// Dec 06 - 2
let dec06_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec06.txt")
    Console.WriteLine("Dec06_02: {0}", Dec06_02.countLanternFish (fileContent.First()) 256)

// Dec 07 - 1
let dec07_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec07.txt")
    Console.WriteLine("Dec07_01: {0}", Dec07_01.getMinimumFuelForAlignment (fileContent.First()))

// Dec 07 - 2
let dec07_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec07.txt")
    Console.WriteLine("Dec07_02: {0}", Dec07_02.getMinimumFuelForAlignment (fileContent.First()))

// Dec 08 - 1
let dec08_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec08.txt")
    Console.WriteLine("Dec08_01: {0}", Dec08_01.getUniqueDigitsAmount (List.ofSeq(fileContent)))

// Dec 08 - 2
let dec08_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec08.txt")
    Console.WriteLine("Dec08_02: {0}", Dec08_02.sumAllValues (List.ofSeq(fileContent)))

// Dec 09 - 1
let dec09_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec09.txt")
    Console.WriteLine("Dec09_01: {0}", Dec09_01.calcGlobalRiskLevel (List.ofSeq(fileContent)))

// Dec 09 - 2
let dec09_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec09.txt")
    Console.WriteLine("Dec09_02: {0}", Dec09_02.threeLargestBassins (List.ofSeq(fileContent)))

// Dec 10 - 1
let dec10_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec10.txt")
    Console.WriteLine("Dec10_01: {0}", Dec10_01.computeScore (List.ofSeq(fileContent)))

// Dec 10 - 2
let dec10_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec10.txt")
    Console.WriteLine("Dec10_02: {0}", Dec10_02.computeScore (List.ofSeq(fileContent)))

// Dec 11 - 1
let dec11_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec11.txt")
    Console.WriteLine("Dec11_01: {0}", Dec11_01.countFlashes (List.ofSeq(fileContent)) 100)

// Dec 11 - 2
let dec11_02 =
    let fileContent = System.IO.File.ReadLines("data/Dec11.txt")
    Console.WriteLine("Dec11_02: {0}", Dec11_02.firstSyncFlash (List.ofSeq(fileContent)))

// Dec 12 - 1
let dec12_01 =
    let fileContent = System.IO.File.ReadLines("data/Dec12.txt")
    Console.WriteLine("Dec12_01: {0}", Dec12_01.countPaths (List.ofSeq(fileContent)))

// Execute
dec01_01
dec01_02
dec02_01
dec02_02
dec03_01
dec03_02
dec04_01
dec04_02
dec05_01
dec05_02
dec06_01
dec06_02
dec07_01
dec07_02
dec08_01
dec08_02
dec09_01
dec09_02
dec10_01
dec10_02
dec11_01
dec11_02
dec12_01
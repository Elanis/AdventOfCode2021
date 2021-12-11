module Tests

open System.Linq
open Xunit
open AdventOfCode2021
open System

[<Fact>]
let ``Dec01_01_Test`` () =
    Assert.Equal(Dec01_01.count [199; 200; 208; 210; 200; 207; 240; 269; 260; 263] 0, 7)

[<Fact>]
let ``Dec01_02_Test`` () =
    Assert.Equal(Dec01_02.count [199; 200; 208; 210; 200; 207; 240; 269; 260; 263] 0, 5)

[<Fact>]
let ``Dec02_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec02.txt")
    Assert.Equal(Dec02_01.processAll (List.ofSeq(fileContent)) 0 0, (10, 15))

[<Fact>]
let ``Dec02_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec02.txt")
    Assert.Equal(Dec02_02.processAll (List.ofSeq(fileContent)) 0 0 0, (60, 15))

[<Fact>]
let ``Dec03_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec03.txt")
    Assert.Equal(Dec03_01.getConsumption (List.ofSeq(fileContent)), (22, 9))

[<Fact>]
let ``Dec03_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec03.txt")
    Assert.Equal(Dec03_02.getAtmosphereRating (List.ofSeq(fileContent)), (23, 10))

[<Fact>]
let ``Dec04_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec04.txt")
    Assert.Equal(Dec04_01.computeScore (List.ofSeq(fileContent)), 4512)

[<Fact>]
let ``Dec04_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec04.txt")
    Assert.Equal(Dec04_02.computeScore (List.ofSeq(fileContent)), 1924)

[<Fact>]
let ``Dec05_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec05.txt")
    Assert.Equal(Dec05_01.countOverlap (List.ofSeq(fileContent)), 5)

[<Fact>]
let ``Dec05_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec05.txt")
    Assert.Equal(Dec05_02.countOverlap (List.ofSeq(fileContent)), 12)

[<Fact>]
let ``Dec06_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec06.txt")
    Assert.Equal(Dec06_01.countLanternFish (fileContent.First()) 18, 26)
    Assert.Equal(Dec06_01.countLanternFish (fileContent.First()) 80, 5934)

[<Fact>]
let ``Dec06_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec06.txt")
    Assert.Equal(Dec06_02.countLanternFish (fileContent.First()) 18, 26)
    Assert.Equal(Dec06_02.countLanternFish (fileContent.First()) 80, 5934)
    Assert.Equal(Dec06_02.countLanternFish (fileContent.First()) 256, Int64.Parse("26984457539"))

[<Fact>]
let ``Dec07_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec07.txt")
    Assert.Equal(Dec07_01.getMinimumFuelForAlignment (fileContent.First()), 37)

[<Fact>]
let ``Dec07_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec07.txt")
    Assert.Equal(Dec07_02.getMinimumFuelForAlignment (fileContent.First()), 168)

[<Fact>]
let ``Dec08_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec08.txt")
    Assert.Equal(Dec08_01.getUniqueDigitsAmount (List.ofSeq(fileContent)), 26)

[<Fact>]
let ``Dec08_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec08.txt")
    Assert.Equal(Dec08_02.sumAllValues (List.ofSeq(fileContent)), 61229)

[<Fact>]
let ``Dec09_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec09.txt")
    Assert.Equal(Dec09_01.calcGlobalRiskLevel (List.ofSeq(fileContent)), 15)

[<Fact>]
let ``Dec09_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec09.txt")
    Assert.Equal(Dec09_02.threeLargestBassins (List.ofSeq(fileContent)), 1134)

[<Fact>]
let ``Dec10_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec10.txt")
    Assert.Equal(Dec10_01.computeScore (List.ofSeq(fileContent)), 26397)

[<Fact>]
let ``Dec10_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec10.txt")
    Assert.Equal(Dec10_02.computeScore (List.ofSeq(fileContent)), 288957)
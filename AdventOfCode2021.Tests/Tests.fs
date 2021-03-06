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

[<Fact>]
let ``Dec11a_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec11a.txt")
    Assert.Equal(Dec11_01.countFlashes (List.ofSeq(fileContent)) 1, 9)
    Assert.Equal(Dec11_01.countFlashes (List.ofSeq(fileContent)) 2, 9)

[<Fact>]
let ``Dec11b_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec11b.txt")
    Assert.Equal(Dec11_01.countFlashes (List.ofSeq(fileContent)) 10, 204)
    Assert.Equal(Dec11_01.countFlashes (List.ofSeq(fileContent)) 100, 1656)

[<Fact>]
let ``Dec11b_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec11b.txt")
    Assert.Equal(Dec11_02.firstSyncFlash (List.ofSeq(fileContent)), 195)

[<Fact>]
let ``Dec12a_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec12a.txt")
    Assert.Equal(Dec12_01.countPaths (List.ofSeq(fileContent)), 10)

[<Fact>]
let ``Dec12b_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec12b.txt")
    Assert.Equal(Dec12_01.countPaths (List.ofSeq(fileContent)), 19)

[<Fact>]
let ``Dec12c_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec12c.txt")
    Assert.Equal(Dec12_01.countPaths (List.ofSeq(fileContent)), 226)

[<Fact>]
let ``Dec12a_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec12a.txt")
    Assert.Equal(Dec12_02.countPaths (List.ofSeq(fileContent)), 36)

[<Fact>]
let ``Dec12b_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec12b.txt")
    Assert.Equal(Dec12_02.countPaths (List.ofSeq(fileContent)), 103)

[<Fact>]
let ``Dec12c_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec12c.txt")
    Assert.Equal(Dec12_02.countPaths (List.ofSeq(fileContent)), 3509)

[<Fact>]
let ``Dec13_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec13.txt")
    Assert.Equal(Dec13_01.countPointsAfterFirstFold (List.ofSeq(fileContent)), 17)

[<Fact>]
let ``Dec13_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec13.txt")
    Assert.Equal(Dec13_02.getLetters (List.ofSeq(fileContent)),
@"#####
#   #
#   #
#   #
#####"
)

[<Fact>]
let ``Dec14_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec14.txt")
    Assert.Equal(Dec14_01.processPolymerSteps (List.ofSeq(fileContent)) 1, "NCNBCHB")
    Assert.Equal(Dec14_01.processPolymerSteps (List.ofSeq(fileContent)) 2, "NBCCNBBBCBHCB")
    Assert.Equal(Dec14_01.processPolymerSteps (List.ofSeq(fileContent)) 3, "NBBBCNCCNBBNBNBBCHBHHBCHB")
    Assert.Equal(Dec14_01.processPolymerSteps (List.ofSeq(fileContent)) 4, "NBBNBNBBCCNBCNCCNBBNBBNBBBNBBNBBCBHCBHHNHCBBCBHCB")
    Assert.Equal((Dec14_01.processPolymerSteps (List.ofSeq(fileContent)) 5).Length, 97)
    
    let step10 = (Dec14_01.processPolymerSteps (List.ofSeq(fileContent)) 10).ToCharArray()
    Assert.Equal(step10.Length, 3073)
    Assert.Equal(step10.Count(fun elt -> elt = 'B'), 1749)
    Assert.Equal(step10.Count(fun elt -> elt = 'C'), 298)
    Assert.Equal(step10.Count(fun elt -> elt = 'H'), 161)
    Assert.Equal(step10.Count(fun elt -> elt = 'N'), 865)

    Assert.Equal(Dec14_01.computeScore (List.ofSeq(fileContent)) 10, 1588)

[<Fact>]
let ``Dec14_02_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec14.txt")

    Assert.Equal(Dec14_02.computeScore (List.ofSeq(fileContent)) 10, 1588)
    Assert.Equal(Dec14_02.computeScore (List.ofSeq(fileContent)) 40, Int64.Parse("2188189693529"))

[<Fact>]
let ``Dec15_01_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec15.txt")
    Assert.Equal(Dec15_01.calcMinimalRisk (List.ofSeq(fileContent)), 40)

[<Fact>]
let ``Dec15_02_large_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec15.txt")
    let calculated = Dec15_02.calcLargeMap (List.ofSeq(fileContent))

    let fileContent2 = System.IO.File.ReadLines("data/Dec15_large.txt")
    let expected = Dec15_01.parseMap (List.ofSeq(fileContent2))


    Assert.Equal(calculated.Length, expected.Length);
    Assert.Equal(calculated[0].Length, expected[0].Length);
    Assert.Equal(calculated.Sum(fun elt -> elt.Sum()), expected.Sum(fun elt -> elt.Sum()));

[<Fact>]
let ``Dec15_02_risk_Test`` () =
    let fileContent = System.IO.File.ReadLines("data/Dec15.txt")
    Assert.Equal(Dec15_02.calcLargeMapMinimalRisk (List.ofSeq(fileContent)), 315)
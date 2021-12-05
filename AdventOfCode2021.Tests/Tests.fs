module Tests

open Xunit
open AdventOfCode2021

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
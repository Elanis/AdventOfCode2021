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
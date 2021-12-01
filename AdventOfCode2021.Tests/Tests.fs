module Tests

open Xunit
open AdventOfCode2021

[<Fact>]
let ``Dec01_01_Test`` () =
    Assert.Equal(Dec01_01.count [199; 200; 208; 210; 200; 207; 240; 269; 260; 263] 0, 7)

[<Fact>]
let ``Dec01_02_Test`` () =
    let fileContent = List.ofSeq(System.IO.File.ReadLines("data/Dec01_02.txt"))
    Assert.Equal(Dec01_02.count fileContent 0, 5)
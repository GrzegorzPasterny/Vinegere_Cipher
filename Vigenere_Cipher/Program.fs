// Learn more about F# at http://fsharp.org

open System

let vinegere = 

    Console.WriteLine("Welcome in Vinegere's cipher encryptor!")
   
    let text = 
        Console.WriteLine("Type text to process:")
        Console.ReadLine().Replace(" ","").ToLower()

    let dir = 
        Console.WriteLine("To encrypt type '1', to decyrpt type '0', otherwise quit:")
        Console.ReadLine()

    let keyWord = 
        Console.WriteLine("Type key word:")
        Console.ReadLine().Replace(" ","").ToLower()

    let run = 
        
        let keyWordToInt = 
            keyWord.ToCharArray()
            |> List.ofArray
            |> List.map(fun i -> int i)
        
        let textToInt = 
            text.ToCharArray()
            |> List.ofArray
            |> List.map(fun i -> int i)
        
        let simpleArray = 
            [0 .. textToInt.Length - 1]

        let keyWordExtended = 
            simpleArray
            |> List.map(fun i -> keyWordToInt.Item(i % keyWordToInt.Length))
        
        let sumOfTwoEncr = List.map2 (fun x y -> 
            match x + y - 97 with
            | i when i <= 122 -> x + y - 97
            | i when i > 122 -> x + y - 97 - 26
            )

        let sumOfTwoDecr = List.map2 (fun x y -> 
            match x - (y - 97) with
            | i when i < 97 -> x - (y - 97) + 26
            | i when i >= 97 -> x - (y - 97) 
            )

        let toStringAgain text = 
            text 
            |> List.map (fun i -> char i)
            |> String.Concat

        match dir with
        | "1" -> 
            sumOfTwoEncr textToInt keyWordExtended
            |> toStringAgain

        | "0" -> 
            sumOfTwoDecr textToInt keyWordExtended 
            |> toStringAgain

        | _ -> 
            "invalid choose between encrypion and decryption"
        
    run 

[<EntryPoint>]
let main argv =
    Console.WriteLine(vinegere)
    0
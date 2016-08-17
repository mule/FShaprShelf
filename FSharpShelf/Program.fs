

open System

open Topshelf
open Time
open System.Timers

type HeartbeatService() =
    let info : string -> unit = fun s -> Console.WriteLine(sprintf "%s logger/sample-service: %s" (DateTime.UtcNow.ToString("o")) s)
    
    let timer = new Timer(10000.0)
    do timer.AutoReset <- true
    do timer.Elapsed.Add( fun args -> 
        info "Tick"
    )
    member x.Start() = timer.Start()
    member x.Stop() = timer.Stop


[<EntryPoint>]
let main argv =
    let info : string -> unit = fun s -> Console.WriteLine(sprintf "%s logger/sample-service: %s" (DateTime.UtcNow.ToString("o")) s)
    let timer = new Timer(10000.0)
    do timer.AutoReset <- true
    do timer.Elapsed.Add( fun args -> info "Tick")
    let start hc = 
        timer.Start()
        info "Service started"
        true

    let stop hc =
        timer.Stop()
        info "Service stopped"
        true

    Service.Default
    |> with_start start
    |> with_stop stop
    |> run
    

    

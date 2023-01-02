module Api

open Fable.Core

[<Emit("process.env.APIURL")>]
let apiUrl : string = jsNative
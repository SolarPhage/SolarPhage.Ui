module Shop.App

open Messages
open Types
open Elmish

let update (msg: ShopMessage) (state: ShopState) = 
    match msg with
    | LoadShop Loading ->
        state, Cmd.OfAsync.either Infrastructure.getShopItems () LoadShop FailedToLoadShop
    | LoadShop (Result items) ->
        { state with ShopItems = items }, Cmd.none
    | FailedToLoadShop x -> state, Cmd.none
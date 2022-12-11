module ShopInventoryItem

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.text "Sell"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage ShopMenu)
            prop.text "Back"
        ]
    ]
module ShopMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        prop.className "buttons"
        prop.children [
            Html.label [
                prop.onClick (fun _ -> dispatch <| ChangePage ShopBuyItem)
                prop.text "Shop Item"
            ]

            Html.label [
                prop.onClick (fun _ -> dispatch <| ChangePage ShopInventoryItem)
                prop.text "Inventory Item"
            ]

            Html.button [
                prop.className[ "button" ]
                prop.onClick (fun _ -> dispatch <| ChangePage TownMenu)
                prop.text "Back"
            ]
        ]
    ]
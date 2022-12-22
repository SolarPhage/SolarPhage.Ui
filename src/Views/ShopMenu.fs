module ShopMenu

open App.Types
open SharedTemplate
open Feliz

let content = 
    [
        Html.div [
            prop.text "test"
        ]
    ]

let footer (dispatch: Msg -> unit) = 
    [
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

let render (dispatch: Msg -> unit) = 
    renderMainContentAndFooter content (footer dispatch)


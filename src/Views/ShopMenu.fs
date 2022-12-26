module ShopMenu

open App.Types
open SharedTemplate
open Feliz

let content (state : State) = 
    [
        Html.div [
            Html.ul [
                for i in state.ShopItems do
                    Html.li [
                        prop.text $"{i.ItemInfo.Name}"
                    ]
            ]
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

let render (state : State) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)


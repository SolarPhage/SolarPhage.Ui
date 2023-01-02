module ShopMenu

open Messages
open Types
open Main.Types
open Templates.Shared
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

let footer (dispatch: MainMessage -> unit) = 
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

let render (state : State) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)


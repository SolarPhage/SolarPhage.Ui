module Shop.Views.ShopMenu

open Messages
open Types
open Templates.Shared
open Feliz
open Shop.Types

let content (state : ShopState) = 
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

let render (state : ShopState) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)


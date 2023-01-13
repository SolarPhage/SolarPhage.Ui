module Town.Views.TownMenu

open Messages
open Types
open Main.Types
open Templates.Shared
open Feliz

let content = 
    [
        Html.div [
            prop.text "test"
        ]
    ]

let footer (state : State) (dispatch: MainMessage -> unit) = 
    [
        // Html.button [
        //     prop.className[ "button" ]
        //     prop.onClick (fun _ -> dispatch <| LoadPage(ShopMenu, LoadShop Shared.Loading))
        //     prop.text "Shop"
        // ]

        // Html.button [
        //     prop.className[ "button" ]
        //     prop.onClick (fun _ -> dispatch <| LoadPage(DungeonMenu, LoadDungeon(state.Dungeon.DungeonId, Shared.Loading)))
        //     prop.text "Dungeon"
        // ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage MainMenu)
            prop.text "Quit"
        ]
    ]

let render (state : State) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter content (footer state dispatch)
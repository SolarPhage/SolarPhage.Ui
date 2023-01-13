module Dungeon.Views.DungeonMenu

open Messages
open Types
open Templates.Shared
open Feliz
open Dungeon.Types

let content (state : DungeonState) = 
    [
        Html.div [
            Html.ul [
                Html.li [ prop.text state.Dungeon.DungeonId ]
                Html.li [ prop.text state.Dungeon.Level ]
            ]
        ]
    ]

let footer (dispatch: MainMessage -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage GameMenu)
            prop.text "Menu"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.text "Explore"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CombatMenu)
            prop.text "Fight"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage TownMenu)
            prop.text "Back to Town"
        ]
    ]

let render (state : DungeonState) (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)
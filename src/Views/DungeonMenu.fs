module DungeonMenu

open App.Types
open SharedTemplate
open Feliz

let content (state : State) = 
    [
        Html.div [
            Html.ul [
                Html.li [ prop.text state.Dungeon.DungeonId ]
                Html.li [ prop.text state.Dungeon.Level ]
            ]
        ]
    ]

let footer (dispatch: Msg -> unit) = 
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

let render (state : State) (dispatch: Msg -> unit) = 
    renderMainContentAndFooter (content state) (footer dispatch)
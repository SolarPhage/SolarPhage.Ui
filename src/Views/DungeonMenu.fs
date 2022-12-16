module DungeonMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        prop.className "buttons"
        prop.children [
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
    ]
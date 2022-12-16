module CombatPhotocastsMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        prop.className "buttons"
        prop.children [
            Html.button [
                prop.className[ "button" ]
                prop.text "Move Up"
            ]

            Html.button [
                prop.className[ "button" ]
                prop.text "Move Down"
            ]

            Html.button [
                prop.className[ "button" ]
                prop.onClick (fun _ -> dispatch <| ChangePage CombatMenu)
                prop.text "Back"
            ]
        ]
    ]
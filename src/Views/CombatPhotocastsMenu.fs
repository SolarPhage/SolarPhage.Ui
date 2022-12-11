module CombatPhotocastsMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.text "Move Up"
        ]

        Html.button [
            prop.text "Move Down"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage CombatMenu)
            prop.text "Back"
        ]
    ]
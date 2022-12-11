module CombatPotionMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.text "Use"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage CombatMenu)
            prop.text "Back"
        ]
    ]
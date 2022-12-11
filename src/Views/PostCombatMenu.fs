module PostCombatMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage DungeonMenu)
            prop.text "Continue"
        ]
    ]
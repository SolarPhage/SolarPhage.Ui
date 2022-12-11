module CombatMenu

open App.Types
open Feliz

let render (dispatch: Msg -> unit) = 
    Html.div [
        Html.button [
            prop.text "Attack"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage CombatPotionMenu)
            prop.text "Potion"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage CombatPhotocastsMenu)
            prop.text "Photocasts"
        ]

        Html.button [
            prop.onClick (fun _ -> dispatch <| ChangePage DungeonMenu)
            prop.text "Back"
        ]
    ]
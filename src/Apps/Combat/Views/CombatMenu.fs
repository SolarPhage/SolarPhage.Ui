module Combat.Views.CombatMenu

open Messages
open Types
open Templates.Shared
open Feliz

let content = 
    [
        Html.div [
            prop.text "test"
        ]
    ]

let footer (dispatch: MainMessage -> unit) = 
    [
        Html.button [
            prop.className[ "button" ]
            prop.text "Attack"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CombatPotionMenu)
            prop.text "Potion"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage CombatPhotocastsMenu)
            prop.text "Photocasts"
        ]

        Html.button [
            prop.className[ "button" ]
            prop.onClick (fun _ -> dispatch <| ChangePage DungeonMenu)
            prop.text "Back"
        ]
    ]

let render (dispatch: MainMessage -> unit) = 
    renderMainContentAndFooter content (footer dispatch)